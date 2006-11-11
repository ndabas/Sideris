using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Text.RegularExpressions;

namespace Sideris.SiderisService
{
    /// <summary>
    /// Class to hold information about a file shared on this
    /// Sideris network.
    /// </summary>
    public class File
    {
        public string Peer;
        public string PeerName;
        public string Hash;
        public long Size;
        public string Name;
    }

    /// <summary>
    /// Web Service which allows peers to join and search this
    /// Sideris network.
    /// </summary>
    [WebServiceBinding(EmitConformanceClaims = true)]
    public class SiderisService : System.Web.Services.WebService
    {
        private static string database = "SiderisDB";

        private void SaveData()
        {
            if (Application[database] != null)
            {
                lock (database)
                {
                    SiderisDataSet db = Application[database]
                        as SiderisDataSet;
                    string path = Server.MapPath("~/App_Data/SiderisDB.xml");
                    db.WriteXml(path);
                }
            }
        }

        public SiderisService()
        {
            if (Application[database] == null)
            {
                lock (database)
                {
                    Application[database] = new SiderisDataSet();
                }
            }
        }

        /// <summary>
        /// Register a peer on this Sideris network.
        /// </summary>
        /// <param name="name">Hostname or alias for this peer.</param>
        /// <param name="port">Port on which the peer listens for
        /// incoming requests.</param>
        /// <param name="shares">An array of files shared by this
        /// peer. The Peer field is ignored.</param>
        /// <param name="expires">An expiry date and time
        /// returned by the server. The files shared by the peer
        /// will remain in the database till this time. The peer
        /// should re-register itself before this time.</param>
        /// <returns>True if successful, false otherwise.</returns>
        [WebMethod]
        public bool Register(string name, ushort port, File[] shares, out DateTime expires)
        {
            Purge();

            SiderisDataSet db = Application[database] as SiderisDataSet;
            SiderisDataSet.PeerDataTable peers = db.Peer;
            SiderisDataSet.FileDataTable files = db.File;
            SiderisDataSet.PeerRow peer;

            //
            // If this peer was already in the database,
            // remove it. Shared files are removed by the
            // foreign key constraint.
            //
            peer = FindPeer(port);
            if (peer != null)
            {
                lock (db)
                {
                    peer.Delete();
                    peers.AcceptChanges();
                }
            }

            //
            // Compute an expiry date and time for the peer,
            // and add it to the database.
            //
            expires = DateTime.Now + TimeSpan.FromMinutes(15);
            string address = GetPeerAddress(port);
            lock (db)
            {
                peer = peers.AddPeerRow(address, expires, name);

                //
                // Add the files shared by the peer to the database.
                //
                foreach (File file in shares)
                {
                    files.AddFileRow(peer, file.Hash, file.Size,
                        file.Name);
                }

                db.AcceptChanges();

            }

            SaveData();

            return true;
        }
        private string GetPeerAddress(int port)
        {
            string address = String.Format("{0}:{1}",
                Context.Request.UserHostAddress, (ushort)port);
            return address;
        }

        [WebMethod]
        public bool Ping(int port, out DateTime expires)
        {
            Purge();

            SiderisDataSet db = Application[database] as SiderisDataSet;
            SiderisDataSet.PeerDataTable peers = db.Peer;
            SiderisDataSet.PeerRow peer;

            //
            // Find the peer in the database, then update
            // the expiry time.
            //
            peer = FindPeer(port);
            if (peer != null)
            {
                expires = DateTime.Now + TimeSpan.FromMinutes(15);
                lock (db)
                {
                    peer.Expires = expires;
                    peers.AcceptChanges();
                }
                return true;
            }

            //
            // The peer was not in the database anyway.
            //
            expires = DateTime.Now;
            return false;
        }

        /// <summary>
        /// Remove a peer from this Sideris network.
        /// </summary>
        /// <param name="port">Port on which the peer was
        /// listening.</param>
        /// <returns>True if successful, false otherwise.</returns>
        [WebMethod]
        public bool Unregister(int port)
        {
            Purge();

            SiderisDataSet db = Application[database] as SiderisDataSet;
            SiderisDataSet.PeerDataTable peers = db.Peer;
            SiderisDataSet.PeerRow peer;

            //
            // Find the peer in the database, then delete it.
            // Shared files are deleted by the foreign key
            // constraint.
            //
            peer = FindPeer(port);
            if (peer != null)
            {
                lock (db)
                {
                    peer.Delete();
                    peers.AcceptChanges();
                }
                return true;
            }

            //
            // The peer was not in the database anyway.
            //
            return false;
        }

        /// <summary>
        /// Find files in this Sideris network.
        /// </summary>
        /// <param name="name">File name to find. A file will be
        /// found if any part of the filename matches the given
        /// string.</param>
        /// <returns>An array of files which matched the given
        /// criteria.</returns>
        [WebMethod]
        public File[] SearchByName(int port, string name)
        {
            name = Regex.Replace(name, @"[*%\[\]]", new MatchEvaluator(this.Escape));

            string queryFormat = "Parent.Address <> '{0}' AND Name LIKE '%{1}%'";
            string query = String.Format(queryFormat,
                GetPeerAddress(port), name);
            return SelectFiles(query);
        }

        private string Escape(Match match)
        {
            return String.Format("[{0}]", match.Value);
        }

        /// <summary>
        /// Find files in this Sideris network.
        /// </summary>
        /// <param name="hash">SHA-1 hash of the file to find.</param>
        /// <returns>An array of files which matched the given
        /// criteria.</returns>
        [WebMethod]
        public File[] SearchByHash(int port, string hash)
        {
            string queryFormat = "Parent.Address <> '{0}' AND Hash = '{1}'";
            string query = String.Format(queryFormat,
                GetPeerAddress(port), hash);
            return SelectFiles(query);
        }

        private File[] SelectFiles(string query)
        {
            Purge();

            SiderisDataSet db = Application[database] as SiderisDataSet;
            SiderisDataSet.FileDataTable files = db.File;
            SiderisDataSet.FileRow[] rows;

            rows = files.Select(query) as SiderisDataSet.FileRow[];
            File[] result = new File[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                result[i] = new File();
                result[i].Name = rows[i].Name;
                result[i].Hash = rows[i].Hash;
                result[i].Size = rows[i].Size;
                result[i].Peer = rows[i].PeerRow.Address;
                result[i].PeerName = rows[i].PeerRow.Name;
            }

            return result;
        }

        private SiderisDataSet.PeerRow FindPeer(int port)
        {
            SiderisDataSet db = Application[database] as SiderisDataSet;
            SiderisDataSet.PeerDataTable peers = db.Peer;

            string address = GetPeerAddress(port);
            return peers.FindByAddress(address);
        }

        private void Purge()
        {
            SiderisDataSet db = Application[database] as SiderisDataSet;
            SiderisDataSet.PeerDataTable peers = db.Peer;

            string query = String.Format("Expires <= #{0}#",
                DateTime.Now);
            SiderisDataSet.PeerRow[] rows = peers.Select(query)
                as SiderisDataSet.PeerRow[];

            if (rows.Length == 0)
            {
                return;
            }

            lock (db)
            {
                foreach (SiderisDataSet.PeerRow row in rows)
                {
                    row.Delete();
                }
                peers.AcceptChanges();
            }
        }

    }

}
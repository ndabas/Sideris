#region Using directives

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Windows.Forms;
using System.Threading;
using Sideris.SiderisServer;

#endregion

namespace Sideris
{
    public class PeerRequestHandler : Component, IRequestProcessor
    {
        private Server server;
        private FilesDataSet.SharesDataTable shares;
        private int port;

        public event EventHandler Started;

        protected virtual void OnStarted(EventArgs e)
        {
            if(Started != null)
            {
                Started(this, e);
            }
        }

        public PeerRequestHandler()
        {
            
        }

        public void StartServer(FilesDataSet.SharesDataTable shares)
        {
            this.shares = shares;
            this.port = Sideris.Properties.Settings.Value.Port;

            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Start));
        }

        private void Start(object state)
        {
            if(server != null)
            {
                server.Stop();
                server = null;
            }

            string path = Application.ExecutablePath;
            path = path.Substring(0, path.LastIndexOf('\\'));
            server = new Server(port, "/", path, this);
            server.Start();

            OnStarted(new EventArgs());
        }

        #region IHttpWorkerRequestHandler Members

        void IRequestProcessor.ProcessRequest(RequestProxy proxy)
        {
            HttpWorkerRequest wr = proxy.HttpWorkerRequest;
            string hash = wr.GetUriPath();
            if(hash.StartsWith("/"))
            {
                hash = hash.Substring(1);
            }

            string query = String.Format("Hash = '{0}'", hash);

            FilesDataSet.SharesRow[] rows;
            lock(shares)
            {
                rows = shares.Select(query) as FilesDataSet.SharesRow[];
            }

            if(rows.Length == 1)
            {
                string fullName = rows[0].FullName;
                string name = fullName.Substring(fullName.LastIndexOf('\\') + 1);
                long offset = 0;
                long length = rows[0].Size;

                string range = wr.GetKnownRequestHeader(HttpWorkerRequest.HeaderRange);
                if(range != null && range.Length > 0)
                {
                    int rangeStart = range.IndexOf("bytes=");
                    int rangeEnd = range.IndexOf('-');
                    if(rangeStart != -1 && rangeEnd != -1)
                    {
                        rangeStart += 6;
                        offset = Int64.Parse(range.Substring(
                            rangeStart, rangeEnd - rangeStart));
                    }
                }

                SendFile(wr, fullName, name, offset, length - offset);
            }
            else
            {
                string message = "The requested file was not found.";
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                wr.SendStatus(404, HttpWorkerRequest.GetStatusDescription(404));
                wr.SendUnknownResponseHeader("Accept-Ranges", "bytes");
                wr.SendUnknownResponseHeader("Content-Type", "text/plain");
                wr.SendResponseFromMemory(bytes, bytes.Length);
                wr.FlushResponse(true);
                wr.EndOfRequest();
            }
        }

        #endregion

        private void SendFile(HttpWorkerRequest wr, string file, string name, long offset, long length)
        {
            int status = offset == 0 ? 200 : 206;
            string content = String.Format("attachment; filename={0}", name);
            string range = String.Format("bytes {0}-{1}/{2}",
                offset, offset + length - 1, offset + length);

            wr.SendStatus(status, HttpWorkerRequest.GetStatusDescription(status));

            wr.SendUnknownResponseHeader("Accept-Ranges", "bytes");
            wr.SendUnknownResponseHeader("Content-Type", "application/octet-stream");
            wr.SendUnknownResponseHeader("Content-Disposition", content);
            if(offset != 0)
            {
                wr.SendUnknownResponseHeader("Content-Range", range);
            }

            wr.SendCalculatedContentLength((int) length);
            wr.SendResponseFromFile(file, offset, length);
            wr.FlushResponse(true);
            wr.EndOfRequest();
        }
    }
}

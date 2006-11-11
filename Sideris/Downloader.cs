#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.Timers;
using System.IO;

#endregion

namespace Sideris
{
    public class Downloader : Component
    {   
        
        public class Download
        {
            private Downloader downloader;
            internal FilesDataSet.DownloadsRow row;
            
            private FileStream file;
            private Stream responseStream;
            private int bufferSize = 8192;
            private byte[] buffer;

            private List<string> hosts;
            private ServiceClient service;
            private HttpWebRequest request;
            private Timer timer;

            private bool startPending;
            private bool running;

            public bool IsRunning
            {
                get { return running; }
            }

            public string FullName
            {
                get { return row.FullName; }
            }

            public string Hash
            {
                get { return row.Hash; }
            }

            public long Size
            {
                get { return row.Size; }
            }

            public long Completed
            {
                get { return row.Offset; }
            }

            public Download(Downloader downloader, FilesDataSet.DownloadsRow row, List<string> hostList)
            {
                this.downloader = downloader;
                this.service = new ServiceClient();
                this.row = row;
                this.startPending = false;
                this.running = false;

                this.timer = new Timer();
                this.timer.Enabled = false;
                this.timer.Interval = 60 * 1000;
                this.timer.Elapsed +=new ElapsedEventHandler(timer_Elapsed);
                
                this.buffer = new byte[bufferSize];
                this.hosts = hostList;
            }

            public void Start()
            {
                if(running)
                {
                    return;
                }

                if(hosts == null || hosts.Count == 0)
                {
                    startPending = true;
                    FindHosts();
                    return;
                }

                try
                {
                    file = new FileStream(row.FullName, FileMode.OpenOrCreate, FileAccess.Write);
                }
                catch
                {
                    return;
                }

                if(row.Offset != file.Length)
                {
                    row.Offset = 0;
                }
                file.Seek(row.Offset, SeekOrigin.Begin);

                string uriFormat = "http://{0}/{1}";
                string uri = String.Format(uriFormat, hosts[0], row.Hash);

                try
                {
                    request = WebRequest.Create(uri) as HttpWebRequest;
                    if(row.Offset > 0)
                    {
                        int range = (int) row.Offset;
                        request.AddRange(range);
                    }
                    request.BeginGetResponse(
                        new AsyncCallback(this.BeginRead), null);
                    running = true;
                }
                catch(WebException)
                {
                    Stop();
                }
            }

            private void BeginRead(IAsyncResult ar)
            {
                try
                {
                    HttpWebResponse response = request.EndGetResponse(ar)
                        as HttpWebResponse;
                    if(response.StatusCode == HttpStatusCode.OK
                        || response.StatusCode == HttpStatusCode.PartialContent)
                    {
                        responseStream = response.GetResponseStream();
                        timer.Stop();
                        timer.Start();
                        responseStream.BeginRead(buffer, 0, bufferSize,
                            new AsyncCallback(this.Read), null);
                    }
                }
                catch
                {
                }
            }

            private void Read(IAsyncResult ar)
            {
                int read = responseStream.EndRead(ar);
                if(read > 0)
                {
                    file.Write(buffer, 0, read);

                    lock(row)
                    {
                        row.Offset += read;
                        row.AcceptChanges();
                    }

                    downloader.OnDownloadProgressChanged(
                        new DownloadEventArgs(this));

                    if(row.Offset < row.Size)
                    {
                        timer.Stop();
                        timer.Start();
                        responseStream.BeginRead(buffer, 0, bufferSize,
                            new AsyncCallback(this.Read), null);
                    }
                    else
                    {
                        lock(row)
                        {
                            row.Delete();
                            row.AcceptChanges();
                        }
                        file.Close();
                        downloader.OnDownloadCompleted(
                            new DownloadEventArgs(this));
                    }
                }
                else
                {
                    responseStream.Close();
                    file.Close();
                }
            }

            public void Stop()
            {
                running = false;

                if(request != null)
                {
                    request.Abort();
                }
                if(responseStream != null)
                {
                    responseStream.Close();
                }
                if(file != null)
                {
                    file.Close();
                    file = null;
                }
                timer.Stop();
                row.AcceptChanges();
            }

            public void FindHosts()
            {
                service.ResultsAvailable += new ServiceClient.ResultsAvailableEventHandler(service_ResultsAvailable);
                service.SearchByHash(row.Hash);
            }

            private void service_ResultsAvailable(object sender,
                ServiceClient.ResultsAvailableEventArgs e)
            {
                if(e.Files.Length == 0)
                {
                    return;
                }

                lock(this)
                {
                    hosts = new List<string>();
                    foreach(SiderisService.File file in e.Files)
                    {
                        hosts.Add(file.Peer);
                    }
                }

                if(startPending)
                {
                    startPending = false;
                    Start();
                }
            }

            void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                Stop();
            }

            public void Cancel()
            {
                Stop();

                lock(row)
                {
                    row.Delete();
                    row.AcceptChanges();
                }
            }
        }

        public List<Download> downloads;
        public List<Download> Downloads
        {
            get { return downloads; }
        }

        public class DownloadEventArgs
        {
            private Download download;
            public Download Download
            {
                get { return download; }
            }

            public DownloadEventArgs(Download download)
            {
                this.download = download;
            }
        }

        public delegate void DownloadEventHandler(
            object sender, DownloadEventArgs e);

        public event DownloadEventHandler DownloadProgressChanged;

        protected virtual void OnDownloadProgressChanged(DownloadEventArgs e)
        {
            if(DownloadProgressChanged != null)
            {
                DownloadProgressChanged(this, e);
            }
        }

        public event DownloadEventHandler DownloadCompleted;

        protected virtual void OnDownloadCompleted(DownloadEventArgs e)
        {
            downloads.Remove(e.Download);

            if(DownloadCompleted != null)
            {
                DownloadCompleted(this, e);
            }
        }

        public Downloader()
        {
            downloads = new List<Download>();
        }

        private FilesDataSet files;
        public FilesDataSet Files
        {
            get { return files; }
            set
            {
                if(value != null)
                {
                    files = value;
                    files.Downloads.DownloadsRowDeleted += new FilesDataSet.DownloadsRowChangeEventHandler(Downloads_DownloadsRowDeleted);

                    downloads.Clear();
                    foreach(FilesDataSet.DownloadsRow row in files.Downloads.Rows)
                    {
                        downloads.Add(new Download(this, row, null));
                    }
                }
            }
        }

        public void AddDownload(string fullPath, string hash, long size, List<string> hosts)
        {
            FilesDataSet.DownloadsRow row;
            row = files.Downloads.AddDownloadsRow(fullPath, hash, size, 0, 0);
            files.AcceptChanges();

            Download download = new Download(this, row, hosts);
            downloads.Add(download);
            download.Start();
        }

        void Downloads_DownloadsRowDeleted(object sender, FilesDataSet.DownloadsRowChangeEvent e)
        {
            foreach(Download download in downloads)
            {
                if(download.row == e.Row)
                {
                    downloads.Remove(download);
                    break;
                }
            }
        }
    }
}

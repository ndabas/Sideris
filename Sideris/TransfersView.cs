#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Sideris
{
    public partial class TransfersView : UserControl
    {
        public TransfersView(FilesDataSet files)
        {
            InitializeComponent();

            downloader.Files = files;
            UpdateView();
        }

        public void UpdateView()
        {
            if(listView.InvokeRequired)
            {
                listView.Invoke(new MethodInvoker(this.UpdateView));
                return;
            }

            listView.Items.Clear();
            foreach(Downloader.Download download in downloader.Downloads)
            {
                ListViewItem item = listView.Items.Add(download.FullName);
                item.Tag = download;
                item.ImageIndex = download.IsRunning ? 0 : 1;
                item.SubItems.Add(download.Size.ToString());
                item.SubItems.Add(download.Completed.ToString());
                item.SubItems.Add(String.Format("{0}%",
                    (int) (download.Completed * 100 / download.Size)));
            }
        }

        private delegate void UpdateViewInvoker(Downloader.DownloadEventArgs e);

        private void UpdateView(Downloader.DownloadEventArgs e)
        {
            if(listView.InvokeRequired)
            {
                listView.Invoke(new UpdateViewInvoker(this.UpdateView), e);
                return;
            }

            foreach(ListViewItem item in listView.Items)
            {
                if(item.Tag == e.Download)
                {
                    item.SubItems[2].Text = e.Download.Completed.ToString();
                    item.SubItems[3].Text = String.Format("{0}%",
                        (int) (e.Download.Completed * 100 / e.Download.Size));
                }
            }
        }

        public void AddDownload(string fullPath, string hash, long size, List<string> hosts)
        {
            downloader.AddDownload(fullPath, hash, size, hosts);
            UpdateView();
        }

        private void downloader_DownloadProgressChanged(object sender, Downloader.DownloadEventArgs e)
        {
            UpdateView(e);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView.SelectedItems)
            {
                Downloader.Download download = item.Tag as Downloader.Download;
                if(!download.IsRunning)
                {
                    download.Start();
                }
            }

            UpdateView();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView.SelectedItems)
            {
                Downloader.Download download = item.Tag as Downloader.Download;
                if(download.IsRunning)
                {
                    download.Stop();
                }
            }

            UpdateView();
        }

        private void downloader_DownloadCompleted(object sender, Downloader.DownloadEventArgs e)
        {
            UpdateView();
        }

        private void contextMenuStrip_Opened(object sender, EventArgs e)
        {
            bool canStart = false;
            bool canPause = false;
            bool canCancel = false;

            if(listView.SelectedItems.Count > 0)
            {
                canCancel = true;
            }

            foreach(ListViewItem item in listView.SelectedItems)
            {
                Downloader.Download download = item.Tag as Downloader.Download;
                if(download.IsRunning)
                {
                    canPause = true;
                }
                else
                {
                    canStart = true;
                }
            }

            startToolStripMenuItem.Enabled = canStart;
            pauseToolStripMenuItem.Enabled = canPause;
            cancelToolStripMenuItem.Enabled = canCancel;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView.SelectedItems)
            {
                Downloader.Download download = item.Tag as Downloader.Download;
                download.Cancel();
            }

            UpdateView();
        }
    }
}

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
    public partial class SearchTab : UserControl
    {
        private Dictionary<string, ListViewItem> hashDict;
        private int numResults = 0;
        private int numFiles = 0;
        private string searchText;

        internal TransfersView transfersView;

        private class ResultInfo
        {
            public List<string> Hosts = null;
            public string Hash = String.Empty;
            public string Name = String.Empty;
            public long Size = 0;
        }

        public SearchTab(string search)
        {
            InitializeComponent();

            hashDict = new Dictionary<string, ListViewItem>();
            service.Search(search);
            searchResultsLabel.Text = String.Format(searchResultsLabel.Text,
                search);
            this.searchText = search;
        }

        private void service_ResultsAvailable(object sender, ServiceClient.ResultsAvailableEventArgs e)
        {
            AddResults(e.Files);
        }

        private delegate void AddResultsInvoker(
            SiderisService.File[] files);

        private void AddResults(SiderisService.File[] files)
        {
            if(listView.InvokeRequired)
            {
                listView.Invoke(new AddResultsInvoker(this.AddResults),
                    new object[] { files });
                return;
            }

            foreach(SiderisService.File file in files)
            {
                ResultInfo info;

                if(hashDict.ContainsKey(file.Hash))
                {
                    ListViewItem item = hashDict[file.Hash];
                    info = item.Tag as ResultInfo;
                    List<string> hosts = info.Hosts;

                    if(!hosts.Contains(file.Peer))
                    {
                        numResults++;
                        hosts.Add(file.Peer);
                        string count = String.Format("{0} peers",
                            hosts.Count);
                        item.SubItems[2].Text = count;
                    }

                    continue;
                }

                ListViewItem newItem = new ListViewItem(file.Name);
                List<string> hostList = new List<string>();

                hostList.Add(file.Peer);
                info = new ResultInfo();
                info.Hash = file.Hash;
                info.Hosts = hostList;
                info.Name = file.Name;
                info.Size = file.Size;
                newItem.Tag = info;

                string peer = String.Format("{0} ({1})",
                    file.PeerName, file.Peer);

                newItem.SubItems.Add(file.Size.ToString());
                newItem.SubItems.Add(peer);

                listView.Items.Add(newItem);
                hashDict[file.Hash] = newItem;

                numResults++;
                numFiles++;
            }

            TabPage page = this.Parent as TabPage;
            page.Text = String.Format("{0} ({1})", searchText, numFiles);
            resultsLabel.Text = String.Format("Results: {0}", numResults);
            filesFoundLabel.Text = String.Format("Files found: {0}",
                numFiles);
        }

        private void service_SearchProgressChanged(object sender, ServiceClient.SearchProgressChangedEventArgs e)
        {
            SetSearchStatus(String.Format("{0}% complete.", e.ProgressPercentage));
        }

        private void service_SearchStarted(object sender, ServiceClient.SearchEventArgs e)
        {
            SetSearchStatus("Search started.");
        }

        private delegate void SetSearchStatusInvoker(string status);

        private void SetSearchStatus(string status)
        {
            if(searchProgressLabel.InvokeRequired)
            {
                searchProgressLabel.Invoke(
                    new SetSearchStatusInvoker(this.SetSearchStatus),
                    status);
                return;
            }

            searchProgressLabel.Text = status;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            using(TabPage page = this.Parent as TabPage)
            {
                TabControl control = page.Parent as TabControl;
                control.TabPages.Remove(page);
            }
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if(listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select some files to download.");
                return;
            }

            string path = Properties.Settings.Value.DownloadsFolder;
            saveFileDialog.InitialDirectory = path;
            bool added = false;

            foreach(ListViewItem item in listView.SelectedItems)
            {
                ResultInfo info = item.Tag as ResultInfo;

                saveFileDialog.FileName = info.Name;
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    added = true;
                    transfersView.AddDownload(saveFileDialog.FileName,
                        info.Hash, info.Size, info.Hosts);
                }
            }

            if(added)
            {
                Control control = this.Parent;
                do
                {
                    control = control.Parent;
                } while(!(control is MainWindow));

                MainWindow win = control as MainWindow;
                if(win != null)
                {
                    win.SelectView(win.transfersView);
                }
            }
        }
    }
}

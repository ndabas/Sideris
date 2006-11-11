using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Sideris
{
    partial class MainWindow : Form
    {
        // The database for the shared files and downloads
        private static FilesDataSet siderisFiles;

        // Views
        internal View activeView;
        internal View connectionView;
        internal View searchView;
        internal View sharesView;
        internal View transfersView;

        // File where the database is saved
        private string datafile;

        /// <summary>
        /// Appends a message to the log display on the connection view.
        /// </summary>
        /// <param name="message">Message to append.</param>
        void AppendToConnectionLog(string message)
        {
            AppendToConnectionLog(message, Color.Black);
        }

        /// <summary>
        /// Appends a message to the log display on the connection view 
        /// with the specified color.
        /// </summary>
        /// <param name="message">Message to append.</param>
        /// <param name="color">Color for the message.</param>
        void AppendToConnectionLog(string message, Color color)
        {
            (connectionView.Control as ConnectionView).AppendToLog(message, color);
        }

        void ClearConnectionLog()
        {
            (connectionView.Control as ConnectionView).ClearLog();
        }

        private delegate void SetStatusInvoker(string message, Image icon);

        private void SetStatus(string status, Image icon)
        {
            if (statusStrip.InvokeRequired)
            {
                statusStrip.Invoke(new SetStatusInvoker(this.SetStatus),
                    status, icon);
            }
            else
            {
                toolStripStatusLabel.Text = status;
                toolStripStatusLabel.Image = icon;
            }
        }

        /// <summary>
        /// Represents a view in the main app window. When a new view
        /// is selected, the appropiate toolbar button and menu item
        /// is set to the checked state.
        /// </summary>
        internal class View
        {
            public UserControl Control;
            public ToolStripButton Button;
            public ToolStripMenuItem MenuItem;

            public View(UserControl control, ToolStripButton button,
                ToolStripMenuItem menuItem)
            {
                this.Control = control;
                this.Control.Dock = DockStyle.Fill;
                this.Button = button;
                this.MenuItem = menuItem;
            }
        }

        /// <summary>
        /// Select a new view in the main app window.
        /// </summary>
        /// <param name="view">The new view to select.</param>
        internal void SelectView(View view)
        {
            // Flip out the old view.
            if (activeView != null)
            {
                activeView.Button.Checked = false;
                activeView.MenuItem.Checked = false;
                panel.Controls.Remove(activeView.Control);
            }

            // Select the new view.
            view.Button.Checked = true;
            view.MenuItem.Checked = true;
            panel.Controls.Add(view.Control);

            activeView = view;
        }

        public MainWindow()
        {
            InitializeComponent();

            siderisFiles = new FilesDataSet();
            service.Files = siderisFiles;
            folderScanner.Files = siderisFiles;

            // Load file data if we had saved it.
            datafile = Application.LocalUserAppDataPath + "\\Files.xml";
            if (File.Exists(datafile))
            {
                siderisFiles.Shares.BeginLoadData();
                siderisFiles.Downloads.BeginLoadData();

                siderisFiles.ReadXml(datafile);

                siderisFiles.Shares.EndLoadData();
                siderisFiles.Downloads.EndLoadData();
            }

            // The connection view.
            connectionView = new View(new ConnectionView(),
                connectionToolStripButton, connectionToolStripMenuItem1);

            // The search view
            searchView = new View(new SearchView(),
                searchesToolStripButton, searchesToolStripMenuItem);

            // The shares view
            sharesView = new View(new SharesView(siderisFiles),
                sharesToolStripButton, sharesToolStripMenuItem);

            transfersView = new View(new TransfersView(siderisFiles),
                transfersToolStripButton, transfersStripMenuItem);

            (searchView.Control as SearchView).transfersView =
                transfersView.Control as TransfersView;

            // Select the connection view on app startup.
            SelectView(connectionView);
            ClearConnectionLog();
            AppendToConnectionLog("Welcome to Sideris!", Color.Blue);

            // Auto-connect if neccessary
            if (Sideris.Properties.Settings.Default.AutoConnect)
            {
                service.Register();
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.Register();
            peerRequestHandler.StartServer(siderisFiles.Shares);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the options dialog.
            OptionsForm optionsForm = new OptionsForm();
            DialogResult result = optionsForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Save the settings.
                Sideris.Properties.Settings.Default.Save();

                // Refresh our hashes.
                folderScanner.Scan();
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            siderisFiles.AcceptChanges();
            siderisFiles.WriteXml(datafile);
        }

        private void serviceClient_StateChanged(object sender, ServiceClient.RegistrationStateChangedEventArgs e)
        {
            if (e.State == ServiceClient.RegistrationState.Registered)
            {
                string message = String.Format("Connected to {0}.",
                    Sideris.Properties.Settings.Default.DiscoveryServer);
                AppendToConnectionLog(message, Color.Blue);
                SetStatus("Connected", Properties.Resources.Connect0);
            }
            else
            {
                AppendToConnectionLog("Not connected.", Color.Red);
                SetStatus("Not Connected", Properties.Resources.Connect4);
            }
        }

        private void folderScanner_ScanComplete(object sender, EventArgs e)
        {
            (sharesView.Control as SharesView).UpdateView();
        }

        private void folderScanner_FileUpdated(object sender, FolderScanner.FileUpdatedEventArgs e)
        {
            string messageFormat = "";
            string name = e.FileInfo.Name;

            switch (e.Action)
            {
                case FolderScanner.Action.Added:
                    messageFormat = "File added: {0}";
                    break;
                case FolderScanner.Action.DuplicateIgnored:
                case FolderScanner.Action.DuplicateDeleted:
                    messageFormat = "Duplicate file ignored: {0}";
                    break;
                case FolderScanner.Action.HashUpdated:
                    messageFormat = "Hash updated for: {0}";
                    break;
            }
            (transfersView.Control as TransfersView).UpdateView();


            AppendToConnectionLog(String.Format(messageFormat, name));
        }

        private void connectionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectView(connectionView);
        }

        private void searchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectView(searchView);
        }

        private void connectionToolStripButton_Click(object sender, EventArgs e)
        {
            SelectView(connectionView);
        }

        private void searchesToolStripButton_Click(object sender, EventArgs e)
        {
            SelectView(searchView);
        }

        private void sharesToolStripButton_Click(object sender, EventArgs e)
        {
            SelectView(sharesView);
            (sharesView.Control as SharesView).UpdateView();
            folderScanner.Scan();
        }

        private void sharesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectView(sharesView);
            (sharesView.Control as SharesView).UpdateView();
            folderScanner.Scan();
        }

        private void peerRequestHandler_Started(object sender, EventArgs e)
        {
            int port = (ushort)Sideris.Properties.Settings.Default.Port;
            string message = String.Format(
                "Listening on port {0} for peer requests.", port);
            AppendToConnectionLog(message, Color.Blue);
        }

        private void transfersStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectView(transfersView);
            (transfersView.Control as TransfersView).UpdateView();
        }

        private void transfersToolStripButton_Click(object sender, EventArgs e)
        {
            SelectView(transfersView);
            (transfersView.Control as TransfersView).UpdateView();
        }

        private void searchToolStripButton1_Click(object sender, EventArgs e)
        {
            if (activeView != searchView)
            {
                SelectView(searchView);
            }

            SearchView view = searchView.Control as SearchView;
            view.Search(searchToolStripTextBox.Text);
        }

        private void searchToolStripTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchToolStripButton1_Click(sender, e);
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.Unregister();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

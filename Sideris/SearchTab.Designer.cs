namespace Sideris
{
    partial class SearchTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = new System.Windows.Forms.ColumnHeader(Sideris.Properties.Settings.Value.SharedFolder);
            this.sizeColumnHeader = new System.Windows.Forms.ColumnHeader(Sideris.Properties.Settings.Value.SharedFolder);
            this.peerColumnHeader = new System.Windows.Forms.ColumnHeader(Sideris.Properties.Settings.Value.SharedFolder);
            this.closeButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.searchResultsLabel = new System.Windows.Forms.Label();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.filesFoundLabel = new System.Windows.Forms.Label();
            this.searchProgressLabel = new System.Windows.Forms.Label();
            this.service = new Sideris.ServiceClient();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
// 
// listView
// 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.sizeColumnHeader,
            this.peerColumnHeader});
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(4, 46);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(343, 153);
            this.listView.TabIndex = 1;
            this.listView.View = System.Windows.Forms.View.Details;
// 
// nameColumnHeader
// 
            this.nameColumnHeader.Text = "Filename";
            this.nameColumnHeader.Width = 160;
// 
// sizeColumnHeader
// 
            this.sizeColumnHeader.Text = "Size";
// 
// peerColumnHeader
// 
            this.peerColumnHeader.Text = "Peer";
// 
// closeButton
// 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeButton.Location = new System.Drawing.Point(4, 206);
            this.closeButton.Name = "closeButton";
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
// 
// downloadButton
// 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadButton.Location = new System.Drawing.Point(272, 206);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.TabIndex = 3;
            this.downloadButton.Text = "Download";
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
// 
// searchResultsLabel
// 
            this.searchResultsLabel.AutoSize = true;
            this.searchResultsLabel.Location = new System.Drawing.Point(4, 4);
            this.searchResultsLabel.Name = "searchResultsLabel";
            this.searchResultsLabel.Size = new System.Drawing.Size(110, 14);
            this.searchResultsLabel.TabIndex = 4;
            this.searchResultsLabel.Text = "Search results for {0}";
// 
// resultsLabel
// 
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.Location = new System.Drawing.Point(4, 25);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(54, 14);
            this.resultsLabel.TabIndex = 5;
            this.resultsLabel.Text = "Results: 0";
// 
// filesFoundLabel
// 
            this.filesFoundLabel.AutoSize = true;
            this.filesFoundLabel.Location = new System.Drawing.Point(159, 25);
            this.filesFoundLabel.Name = "filesFoundLabel";
            this.filesFoundLabel.Size = new System.Drawing.Size(72, 14);
            this.filesFoundLabel.TabIndex = 6;
            this.filesFoundLabel.Text = "Files found: 0";
// 
// searchProgressLabel
// 
            this.searchProgressLabel.AutoSize = true;
            this.searchProgressLabel.Location = new System.Drawing.Point(159, 4);
            this.searchProgressLabel.Name = "searchProgressLabel";
            this.searchProgressLabel.Size = new System.Drawing.Size(80, 14);
            this.searchProgressLabel.TabIndex = 7;
            this.searchProgressLabel.Text = "Starting search";
// 
// service
// 
            this.service.Files = null;
            this.service.ResultsAvailable += new Sideris.ServiceClient.ResultsAvailableEventHandler(this.service_ResultsAvailable);
            this.service.SearchProgressChanged += new Sideris.ServiceClient.SearchProgressChangedEventHandler(this.service_SearchProgressChanged);
            this.service.SearchStarted += new Sideris.ServiceClient.SearchEventHandler(this.service_SearchStarted);
// 
// saveFileDialog
// 
            this.saveFileDialog.Filter = "All files (*.*)|*.*";
            this.saveFileDialog.RestoreDirectory = true;
// 
// SearchTab
// 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.searchProgressLabel);
            this.Controls.Add(this.filesFoundLabel);
            this.Controls.Add(this.resultsLabel);
            this.Controls.Add(this.searchResultsLabel);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.listView);
            this.Name = "SearchTab";
            this.Size = new System.Drawing.Size(350, 233);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Label searchResultsLabel;
        private System.Windows.Forms.Label resultsLabel;
        private System.Windows.Forms.Label filesFoundLabel;
        private ServiceClient service;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader sizeColumnHeader;
        private System.Windows.Forms.ColumnHeader peerColumnHeader;
        private System.Windows.Forms.Label searchProgressLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

namespace Sideris
{
    partial class TransfersView
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
            this.components = new System.ComponentModel.Container();
            this.transfersLabel = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = new System.Windows.Forms.ColumnHeader(Sideris.Properties.Settings.Value.SharedFolder);
            this.statusColumnHeader = new System.Windows.Forms.ColumnHeader(Sideris.Properties.Settings.Value.SharedFolder);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloader = new Sideris.Downloader();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
// 
// transfersLabel
// 
            this.transfersLabel.AutoSize = true;
            this.transfersLabel.Location = new System.Drawing.Point(4, 4);
            this.transfersLabel.Name = "transfersLabel";
            this.transfersLabel.Size = new System.Drawing.Size(52, 14);
            this.transfersLabel.TabIndex = 0;
            this.transfersLabel.Text = "Transfers";
// 
// listView
// 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.statusColumnHeader});
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.Location = new System.Drawing.Point(4, 25);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(375, 218);
            this.listView.TabIndex = 1;
            this.listView.View = System.Windows.Forms.View.Details;
// 
// nameColumnHeader
// 
            this.nameColumnHeader.Text = "File name";
            this.nameColumnHeader.Width = 260;
// 
// statusColumnHeader
// 
            this.statusColumnHeader.Text = "Status";
// 
// contextMenuStrip
// 
            this.contextMenuStrip.AllowDrop = true;
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.pauseToolStripMenuItem});
            this.contextMenuStrip.Location = new System.Drawing.Point(19, 31);
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(94, 48);
// 
// startToolStripMenuItem
// 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.SettingsKey = "TransfersView.startToolStripMenuItem";
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
// 
// pauseToolStripMenuItem
// 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.SettingsKey = "TransfersView.pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
// 
// downloader
// 
            this.downloader.DownloadProgressChanged += new Sideris.Downloader.DownloadEventHandler(this.downloader_DownloadProgressChanged);
            this.downloader.DownloadCompleted += new Sideris.Downloader.DownloadEventHandler(this.downloader_DownloadCompleted);
// 
// TransfersView
// 
            this.Controls.Add(this.listView);
            this.Controls.Add(this.transfersLabel);
            this.Name = "TransfersView";
            this.Size = new System.Drawing.Size(382, 246);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label transfersLabel;
        private Downloader downloader;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader statusColumnHeader;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
    }
}

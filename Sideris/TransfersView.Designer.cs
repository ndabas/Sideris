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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransfersView));
            this.transfersLabel = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = new System.Windows.Forms.ColumnHeader(Sideris.Properties.Settings.Default.SharedFolder);
            this.sizeColumnHeader = new System.Windows.Forms.ColumnHeader(Sideris.Properties.Settings.Default.SharedFolder);
            this.completedColumnHeader = new System.Windows.Forms.ColumnHeader(Sideris.Properties.Settings.Default.SharedFolder);
            this.percentColumnHeader = new System.Windows.Forms.ColumnHeader(Sideris.Properties.Settings.Default.SharedFolder);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
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
            this.sizeColumnHeader,
            this.completedColumnHeader,
            this.percentColumnHeader});
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(4, 25);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(375, 218);
            this.listView.SmallImageList = this.imageList;
            this.listView.TabIndex = 1;
            this.listView.View = System.Windows.Forms.View.Details;
// 
// nameColumnHeader
// 
            this.nameColumnHeader.Text = "File name";
            this.nameColumnHeader.Width = 260;
// 
// sizeColumnHeader
// 
            this.sizeColumnHeader.Text = "Size";
            this.sizeColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sizeColumnHeader.Width = 100;
// 
// completedColumnHeader
// 
            this.completedColumnHeader.Text = "Completed";
            this.completedColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.completedColumnHeader.Width = 100;
// 
// percentColumnHeader
// 
            this.percentColumnHeader.Text = "Percent";
            this.percentColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
// 
// contextMenuStrip
// 
            this.contextMenuStrip.AllowDrop = true;
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.toolStripSeparator1,
            this.cancelToolStripMenuItem});
            this.contextMenuStrip.Location = new System.Drawing.Point(19, 31);
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(91, 76);
            this.contextMenuStrip.Opened += new System.EventHandler(this.contextMenuStrip_Opened);
// 
// startToolStripMenuItem
// 
            this.startToolStripMenuItem.Image = Sideris.Properties.Resources.Start_png_1;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
// 
// pauseToolStripMenuItem
// 
            this.pauseToolStripMenuItem.Image = Sideris.Properties.Resources.Pause_png_1;
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
// 
// toolStripSeparator1
// 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            
// cancelToolStripMenuItem
// 
            this.cancelToolStripMenuItem.Image = Sideris.Properties.Resources.Cancel;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
// 
// imageList
// 
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Start");
            this.imageList.Images.SetKeyName(1, "Pause");
// 
// downloader
// 
            this.downloader.Files = null;
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
        private System.Windows.Forms.ColumnHeader percentColumnHeader;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader sizeColumnHeader;
        private System.Windows.Forms.ColumnHeader completedColumnHeader;
        private System.Windows.Forms.ImageList imageList;
    }
}

namespace Sideris
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.searchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transfersStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.service = new Sideris.ServiceClient();
            this.folderScanner = new Sideris.FolderScanner();
            this.peerRequestHandler = new Sideris.PeerRequestHandler();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panel = new System.Windows.Forms.Panel();
            this.searchToolStrip = new System.Windows.Forms.ToolStrip();
            this.searchToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.searchToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.viewsToolStrip = new System.Windows.Forms.ToolStrip();
            this.connectionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.searchesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.sharesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.transfersToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.searchToolStrip.SuspendLayout();
            this.viewsToolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(523, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "Main Menu";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Image = global::Sideris.Properties.Resources.ConnectDo_png_1;
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Image = global::Sideris.Properties.Resources.ConnectDrop_png_1;
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(123, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem1,
            this.searchesToolStripMenuItem,
            this.sharesToolStripMenuItem,
            this.transfersStripMenuItem,
            this.toolStripSeparator1,
            this.optionsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // connectionToolStripMenuItem1
            // 
            this.connectionToolStripMenuItem1.Image = global::Sideris.Properties.Resources.ConnectedHighHigh_png_0;
            this.connectionToolStripMenuItem1.Name = "connectionToolStripMenuItem1";
            this.connectionToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.connectionToolStripMenuItem1.Text = "Connection";
            this.connectionToolStripMenuItem1.Click += new System.EventHandler(this.connectionToolStripMenuItem1_Click);
            // 
            // searchesToolStripMenuItem
            // 
            this.searchesToolStripMenuItem.Image = global::Sideris.Properties.Resources.SearchResults_png_2;
            this.searchesToolStripMenuItem.Name = "searchesToolStripMenuItem";
            this.searchesToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.searchesToolStripMenuItem.Text = "Searches";
            this.searchesToolStripMenuItem.Click += new System.EventHandler(this.searchesToolStripMenuItem_Click);
            // 
            // sharesToolStripMenuItem
            // 
            this.sharesToolStripMenuItem.Image = global::Sideris.Properties.Resources.SharedFiles_png_1;
            this.sharesToolStripMenuItem.Name = "sharesToolStripMenuItem";
            this.sharesToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.sharesToolStripMenuItem.Text = "Shares";
            this.sharesToolStripMenuItem.Click += new System.EventHandler(this.sharesToolStripMenuItem_Click);
            // 
            // transfersStripMenuItem
            // 
            this.transfersStripMenuItem.Image = global::Sideris.Properties.Resources.Transfer_png_1;
            this.transfersStripMenuItem.Name = "transfersStripMenuItem";
            this.transfersStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.transfersStripMenuItem.Text = "Transfers";
            this.transfersStripMenuItem.Click += new System.EventHandler(this.transfersStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::Sideris.Properties.Resources.Preferences_png_1;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.optionsToolStripMenuItem.Text = "Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // service
            // 
            this.service.Files = null;
            this.service.StateChanged += new Sideris.ServiceClient.RegistrationStateChangedEventHandler(this.serviceClient_StateChanged);
            // 
            // folderScanner
            // 
            this.folderScanner.Files = null;
            this.folderScanner.FileUpdated += new Sideris.FolderScanner.FileUpdatedEventHandler(this.folderScanner_FileUpdated);
            this.folderScanner.ScanComplete += new System.EventHandler(this.folderScanner_ScanComplete);
            // 
            // peerRequestHandler
            // 
            this.peerRequestHandler.Started += new System.EventHandler(this.peerRequestHandler_Started);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(523, 205);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(523, 301);
            this.toolStripContainer1.TabIndex = 20;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mainMenuStrip);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.viewsToolStrip);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.searchToolStrip);
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(523, 205);
            this.panel.TabIndex = 20;
            // 
            // searchToolStrip
            // 
            this.searchToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.searchToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripTextBox,
            this.searchToolStripButton1});
            this.searchToolStrip.Location = new System.Drawing.Point(3, 49);
            this.searchToolStrip.Name = "searchToolStrip";
            this.searchToolStrip.Size = new System.Drawing.Size(166, 25);
            this.searchToolStrip.TabIndex = 3;
            this.searchToolStrip.Text = "toolStrip1";
            // 
            // searchToolStripTextBox
            // 
            this.searchToolStripTextBox.Name = "searchToolStripTextBox";
            this.searchToolStripTextBox.Size = new System.Drawing.Size(92, 25);
            // 
            // searchToolStripButton1
            // 
            this.searchToolStripButton1.Image = global::Sideris.Properties.Resources.Search_png_5;
            this.searchToolStripButton1.Name = "searchToolStripButton1";
            this.searchToolStripButton1.Size = new System.Drawing.Size(60, 22);
            this.searchToolStripButton1.Text = "Search";
            this.searchToolStripButton1.Click += new System.EventHandler(this.searchToolStripButton1_Click);
            // 
            // viewsToolStrip
            // 
            this.viewsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.viewsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripButton,
            this.searchesToolStripButton,
            this.sharesToolStripButton,
            this.transfersToolStripButton});
            this.viewsToolStrip.Location = new System.Drawing.Point(3, 24);
            this.viewsToolStrip.Name = "viewsToolStrip";
            this.viewsToolStrip.Size = new System.Drawing.Size(297, 25);
            this.viewsToolStrip.TabIndex = 1;
            this.viewsToolStrip.Text = "toolStrip1";
            // 
            // connectionToolStripButton
            // 
            this.connectionToolStripButton.Image = global::Sideris.Properties.Resources.ConnectedHighHigh_png_0;
            this.connectionToolStripButton.Name = "connectionToolStripButton";
            this.connectionToolStripButton.Size = new System.Drawing.Size(81, 22);
            this.connectionToolStripButton.Text = "Connection";
            this.connectionToolStripButton.Click += new System.EventHandler(this.connectionToolStripButton_Click);
            // 
            // searchesToolStripButton
            // 
            this.searchesToolStripButton.Image = global::Sideris.Properties.Resources.SearchResults_png_2;
            this.searchesToolStripButton.Name = "searchesToolStripButton";
            this.searchesToolStripButton.Size = new System.Drawing.Size(71, 22);
            this.searchesToolStripButton.Text = "Searches";
            this.searchesToolStripButton.Click += new System.EventHandler(this.searchesToolStripButton_Click);
            // 
            // sharesToolStripButton
            // 
            this.sharesToolStripButton.Image = global::Sideris.Properties.Resources.SharedFiles_png_1;
            this.sharesToolStripButton.Name = "sharesToolStripButton";
            this.sharesToolStripButton.Size = new System.Drawing.Size(60, 22);
            this.sharesToolStripButton.Text = "Shares";
            this.sharesToolStripButton.Click += new System.EventHandler(this.sharesToolStripButton_Click);
            // 
            // transfersToolStripButton
            // 
            this.transfersToolStripButton.Image = global::Sideris.Properties.Resources.Transfer_png_1;
            this.transfersToolStripButton.Name = "transfersToolStripButton";
            this.transfersToolStripButton.Size = new System.Drawing.Size(73, 22);
            this.transfersToolStripButton.Text = "Transfers";
            this.transfersToolStripButton.Click += new System.EventHandler(this.transfersToolStripButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.statusStrip.Size = new System.Drawing.Size(523, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(480, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(523, 301);
            this.Controls.Add(this.toolStripContainer1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainWindow";
            this.Text = "Sideris";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.searchToolStrip.ResumeLayout(false);
            this.searchToolStrip.PerformLayout();
            this.viewsToolStrip.ResumeLayout(false);
            this.viewsToolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem searchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private ServiceClient service;
        private FolderScanner folderScanner;
        private PeerRequestHandler peerRequestHandler;
        private System.Windows.Forms.ToolStripMenuItem transfersStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStrip viewsToolStrip;
        private System.Windows.Forms.ToolStripButton connectionToolStripButton;
        private System.Windows.Forms.ToolStripButton searchesToolStripButton;
        private System.Windows.Forms.ToolStripButton sharesToolStripButton;
        private System.Windows.Forms.ToolStripButton transfersToolStripButton;
        private System.Windows.Forms.ToolStrip searchToolStrip;
        private System.Windows.Forms.ToolStripTextBox searchToolStripTextBox;
        private System.Windows.Forms.ToolStripButton searchToolStripButton1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}
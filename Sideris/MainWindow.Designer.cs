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
            this.leftRaftingContainer = new System.Windows.Forms.RaftingContainer();
            this.leftRaftingContainer1 = new System.Windows.Forms.RaftingContainer();
            this.topRaftingContainer = new System.Windows.Forms.RaftingContainer();
            this.viewsToolStrip = new System.Windows.Forms.ToolStrip();
            this.connectionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.searchesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.sharesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.transfersToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.searchToolStrip = new System.Windows.Forms.ToolStrip();
            this.searchToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.searchToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.bottomRaftingContainer = new System.Windows.Forms.RaftingContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.mainStatusStripPanel = new System.Windows.Forms.StatusStripPanel();
            this.speedStatusStripPanel = new System.Windows.Forms.StatusStripPanel();
            this.panel = new System.Windows.Forms.Panel();
            this.service = new Sideris.ServiceClient();
            this.folderScanner = new Sideris.FolderScanner();
            this.peerRequestHandler = new Sideris.PeerRequestHandler();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.leftRaftingContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.leftRaftingContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.topRaftingContainer)).BeginInit();
            this.topRaftingContainer.SuspendLayout();
            this.viewsToolStrip.SuspendLayout();
            this.searchToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.bottomRaftingContainer)).BeginInit();
            this.bottomRaftingContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
// 
// mainMenuStrip
// 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.mainMenuStrip.Raft = System.Windows.Forms.RaftingSides.Top;
            this.mainMenuStrip.Size = new System.Drawing.Size(523, 25);
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
            this.connectionToolStripMenuItem.SettingsKey = "MainWindow.connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Text = "Connection";
// 
// connectToolStripMenuItem
// 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.SettingsKey = "MainWindow.connectToolStripMenuItem";
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
// 
// disconnectToolStripMenuItem
// 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.SettingsKey = "MainWindow.disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Text = "Disconnect";
// 
// toolStripMenuItem1
// 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.SettingsKey = "MainWindow.toolStripMenuItem1";
// 
// exitToolStripMenuItem
// 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.SettingsKey = "MainWindow.exitToolStripMenuItem";
            this.exitToolStripMenuItem.Text = "Exit";
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
            this.viewToolStripMenuItem.SettingsKey = "MainWindow.viewToolStripMenuItem";
            this.viewToolStripMenuItem.Text = "View";
// 
// connectionToolStripMenuItem1
// 
            this.connectionToolStripMenuItem1.Name = "connectionToolStripMenuItem1";
            this.connectionToolStripMenuItem1.SettingsKey = "MainWindow.connectionToolStripMenuItem1";
            this.connectionToolStripMenuItem1.Text = "Connection";
            this.connectionToolStripMenuItem1.Click += new System.EventHandler(this.connectionToolStripMenuItem1_Click);
// 
// searchesToolStripMenuItem
// 
            this.searchesToolStripMenuItem.Name = "searchesToolStripMenuItem";
            this.searchesToolStripMenuItem.SettingsKey = "MainWindow.searchesToolStripMenuItem";
            this.searchesToolStripMenuItem.Text = "Searches";
            this.searchesToolStripMenuItem.Click += new System.EventHandler(this.searchesToolStripMenuItem_Click);
// 
// sharesToolStripMenuItem
// 
            this.sharesToolStripMenuItem.Name = "sharesToolStripMenuItem";
            this.sharesToolStripMenuItem.SettingsKey = "MainWindow.sharesToolStripMenuItem";
            this.sharesToolStripMenuItem.Text = "Shares";
            this.sharesToolStripMenuItem.Click += new System.EventHandler(this.sharesToolStripMenuItem_Click);
// 
// transfersStripMenuItem
// 
            this.transfersStripMenuItem.Name = "transfersStripMenuItem";
            this.transfersStripMenuItem.SettingsKey = "MainWindow.toolStripMenuItem2";
            this.transfersStripMenuItem.Text = "Transfers";
            this.transfersStripMenuItem.Click += new System.EventHandler(this.transfersStripMenuItem_Click);
// 
// toolStripSeparator1
// 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.SettingsKey = "MainWindow.toolStripSeparator1";
// 
// optionsToolStripMenuItem
// 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.SettingsKey = "MainWindow.optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Text = "Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
// 
// helpToolStripMenuItem
// 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.aboutToolStripMenuItem
            });
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.SettingsKey = "MainWindow.helpToolStripMenuItem";
            this.helpToolStripMenuItem.Text = "Help";
// 
// aboutToolStripMenuItem
// 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.SettingsKey = "MainWindow.aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Text = "About";
// 
// leftRaftingContainer
// 
            this.leftRaftingContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftRaftingContainer.Name = "leftRaftingContainer";
// 
// leftRaftingContainer1
// 
            this.leftRaftingContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftRaftingContainer1.Name = "leftRaftingContainer1";
// 
// topRaftingContainer
// 
            this.topRaftingContainer.Controls.Add(this.mainMenuStrip);
            this.topRaftingContainer.Controls.Add(this.viewsToolStrip);
            this.topRaftingContainer.Controls.Add(this.searchToolStrip);
            this.topRaftingContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.topRaftingContainer.Name = "topRaftingContainer";
// 
// viewsToolStrip
// 
            this.viewsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.viewsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripButton,
            this.searchesToolStripButton,
            this.sharesToolStripButton,
            this.transfersToolStripButton});
            this.viewsToolStrip.Location = new System.Drawing.Point(0, 25);
            this.viewsToolStrip.Name = "viewsToolStrip";
            this.viewsToolStrip.Raft = System.Windows.Forms.RaftingSides.Top;
            this.viewsToolStrip.TabIndex = 0;
            this.viewsToolStrip.Text = "toolStrip1";
// 
// connectionToolStripButton
// 
            this.connectionToolStripButton.Name = "connectionToolStripButton";
            this.connectionToolStripButton.SettingsKey = "MainWindow.connectionToolStripButton";
            this.connectionToolStripButton.Text = "Connection";
            this.connectionToolStripButton.Click += new System.EventHandler(this.connectionToolStripButton_Click);
// 
// searchesToolStripButton
// 
            this.searchesToolStripButton.Name = "searchesToolStripButton";
            this.searchesToolStripButton.SettingsKey = "MainWindow.searchesToolStripButton";
            this.searchesToolStripButton.Text = "Searches";
            this.searchesToolStripButton.Click += new System.EventHandler(this.searchesToolStripButton_Click);
// 
// sharesToolStripButton
// 
            this.sharesToolStripButton.Name = "sharesToolStripButton";
            this.sharesToolStripButton.SettingsKey = "MainWindow.sharesToolStripButton";
            this.sharesToolStripButton.Text = "Shares";
            this.sharesToolStripButton.Click += new System.EventHandler(this.sharesToolStripButton_Click);
// 
// transfersToolStripButton
// 
            this.transfersToolStripButton.Name = "transfersToolStripButton";
            this.transfersToolStripButton.SettingsKey = "MainWindow.transfersToolStripButton";
            this.transfersToolStripButton.Text = "Transfers";
            this.transfersToolStripButton.Click += new System.EventHandler(this.transfersToolStripButton_Click);
// 
// searchToolStrip
// 
            this.searchToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripTextBox,
            this.searchToolStripButton1});
            this.searchToolStrip.Location = new System.Drawing.Point(272, 25);
            this.searchToolStrip.Name = "searchToolStrip";
            this.searchToolStrip.Raft = System.Windows.Forms.RaftingSides.Top;
            this.searchToolStrip.TabIndex = 2;
            this.searchToolStrip.Text = "toolStrip1";
// 
// searchToolStripTextBox
// 
            this.searchToolStripTextBox.Name = "searchToolStripTextBox";
            this.searchToolStripTextBox.SettingsKey = "MainWindow.textToolStripTextBox";
            this.searchToolStripTextBox.Size = new System.Drawing.Size(92, 25);
            this.searchToolStripTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchToolStripTextBox_KeyUp);
// 
// searchToolStripButton1
// 
            this.searchToolStripButton1.Name = "searchToolStripButton1";
            this.searchToolStripButton1.SettingsKey = "MainWindow.searchToolStripButton1";
            this.searchToolStripButton1.Text = "Search";
            this.searchToolStripButton1.Click += new System.EventHandler(this.searchToolStripButton1_Click);
// 
// bottomRaftingContainer
// 
            this.bottomRaftingContainer.Controls.Add(this.statusStrip);
            this.bottomRaftingContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomRaftingContainer.Name = "bottomRaftingContainer";
// 
// statusStrip
// 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainStatusStripPanel,
            this.speedStatusStripPanel});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.statusStrip.Raft = System.Windows.Forms.RaftingSides.Bottom;
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
// 
// mainStatusStripPanel
// 
            this.mainStatusStripPanel.Name = "mainStatusStripPanel";
            this.mainStatusStripPanel.SettingsKey = "MainWindow.mainStatusStripPanel";
            this.mainStatusStripPanel.Text = "Ready";
// 
// speedStatusStripPanel
// 
            this.speedStatusStripPanel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Tail;
            this.speedStatusStripPanel.AutoSize = false;
            this.speedStatusStripPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.speedStatusStripPanel.Name = "speedStatusStripPanel";
            this.speedStatusStripPanel.SettingsKey = "MainWindow.uploadStatusStripPanel";
            this.speedStatusStripPanel.Size = new System.Drawing.Size(100, 16);
            this.speedStatusStripPanel.Text = "Speed";
            this.speedStatusStripPanel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// panel
// 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 50);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(523, 232);
            this.panel.TabIndex = 19;
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
// 
// peerRequestHandler
// 
            this.peerRequestHandler.Started += new System.EventHandler(this.peerRequestHandler_Started);
// 
// MainWindow
// 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(523, 301);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.leftRaftingContainer);
            this.Controls.Add(this.leftRaftingContainer1);
            this.Controls.Add(this.topRaftingContainer);
            this.Controls.Add(this.bottomRaftingContainer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Name = "MainWindow";
            this.Text = "Sideris";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.mainMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.leftRaftingContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.leftRaftingContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.topRaftingContainer)).EndInit();
            this.topRaftingContainer.ResumeLayout(false);
            this.topRaftingContainer.PerformLayout();
            this.viewsToolStrip.ResumeLayout(false);
            this.searchToolStrip.ResumeLayout(false);
            this.searchToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.bottomRaftingContainer)).EndInit();
            this.bottomRaftingContainer.ResumeLayout(false);
            this.bottomRaftingContainer.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.RaftingContainer leftRaftingContainer;
        private System.Windows.Forms.RaftingContainer leftRaftingContainer1;
        private System.Windows.Forms.RaftingContainer topRaftingContainer;
        private System.Windows.Forms.RaftingContainer bottomRaftingContainer;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStrip searchToolStrip;
        private System.Windows.Forms.ToolStripTextBox searchToolStripTextBox;
        private System.Windows.Forms.ToolStripButton searchToolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem searchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.StatusStripPanel mainStatusStripPanel;
        private System.Windows.Forms.StatusStripPanel speedStatusStripPanel;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStrip viewsToolStrip;
        private System.Windows.Forms.ToolStripButton connectionToolStripButton;
        private System.Windows.Forms.ToolStripButton sharesToolStripButton;
        private System.Windows.Forms.ToolStripButton searchesToolStripButton;
        private System.Windows.Forms.ToolStripButton transfersToolStripButton;
        private System.Windows.Forms.Panel panel;
        private ServiceClient service;
        private FolderScanner folderScanner;
        private PeerRequestHandler peerRequestHandler;
        private System.Windows.Forms.ToolStripMenuItem transfersStripMenuItem;
    }
}
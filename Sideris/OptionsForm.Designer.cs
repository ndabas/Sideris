namespace Sideris
{
    partial class OptionsForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.connectionTabPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.portNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sharesTabPage = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.browseButton2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.browseButton1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.identificationTabPage = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.autoConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.downloadFolderTextBox = new System.Windows.Forms.TextBox();
            this.subFoldersCheckBox = new System.Windows.Forms.CheckBox();
            this.sharedFolderTextBox = new System.Windows.Forms.TextBox();
            this.computerNameTextBox = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.connectionTabPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.sharesTabPage.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.identificationTabPage.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.connectionTabPage);
            this.tabControl.Controls.Add(this.sharesTabPage);
            this.tabControl.Controls.Add(this.identificationTabPage);
            this.tabControl.Location = new System.Drawing.Point(13, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(369, 317);
            this.tabControl.TabIndex = 0;
            // 
            // connectionTabPage
            // 
            this.connectionTabPage.Controls.Add(this.groupBox3);
            this.connectionTabPage.Controls.Add(this.groupBox2);
            this.connectionTabPage.Controls.Add(this.groupBox1);
            this.connectionTabPage.Location = new System.Drawing.Point(4, 22);
            this.connectionTabPage.Name = "connectionTabPage";
            this.connectionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.connectionTabPage.Size = new System.Drawing.Size(361, 291);
            this.connectionTabPage.TabIndex = 0;
            this.connectionTabPage.Text = "Connection";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.autoConnectCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(4, 231);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Auto-Connect";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.portNumericUpDown);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(4, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Peer Requests";
            // 
            // portNumericUpDown
            // 
            this.portNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Sideris.Properties.Settings.Default, "Port", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.portNumericUpDown.Location = new System.Drawing.Point(43, 68);
            this.portNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNumericUpDown.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.portNumericUpDown.Name = "portNumericUpDown";
            this.portNumericUpDown.Size = new System.Drawing.Size(62, 21);
            this.portNumericUpDown.TabIndex = 2;
            this.portNumericUpDown.Value = global::Sideris.Properties.Settings.Default.Port;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select a port on which to listen for incoming requests from other\r\npeers. This po" +
                "rt must be open to the network if you have a\r\nfirewall.";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.serverTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peer Discovery";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(314, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "A discovery server is neede to be able to find other peers in the\r\nSideris networ" +
                "k.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sideris network discovery server address:";
            // 
            // sharesTabPage
            // 
            this.sharesTabPage.Controls.Add(this.groupBox6);
            this.sharesTabPage.Controls.Add(this.groupBox4);
            this.sharesTabPage.Location = new System.Drawing.Point(4, 22);
            this.sharesTabPage.Name = "sharesTabPage";
            this.sharesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.sharesTabPage.Size = new System.Drawing.Size(361, 291);
            this.sharesTabPage.TabIndex = 1;
            this.sharesTabPage.Text = "Shares";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.browseButton2);
            this.groupBox6.Controls.Add(this.downloadFolderTextBox);
            this.groupBox6.Location = new System.Drawing.Point(4, 133);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(345, 76);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Downloads";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 20);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(202, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Select a folder to save downloaded files.";
            // 
            // browseButton2
            // 
            this.browseButton2.Location = new System.Drawing.Point(250, 39);
            this.browseButton2.Name = "browseButton2";
            this.browseButton2.Size = new System.Drawing.Size(75, 23);
            this.browseButton2.TabIndex = 7;
            this.browseButton2.Text = "Browse...";
            this.browseButton2.Click += new System.EventHandler(this.browseButton2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.subFoldersCheckBox);
            this.groupBox4.Controls.Add(this.browseButton1);
            this.groupBox4.Controls.Add(this.sharedFolderTextBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(4, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(348, 119);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Shared Files";
            // 
            // browseButton1
            // 
            this.browseButton1.Location = new System.Drawing.Point(250, 54);
            this.browseButton1.Name = "browseButton1";
            this.browseButton1.Size = new System.Drawing.Size(75, 23);
            this.browseButton1.TabIndex = 3;
            this.browseButton1.Text = "Browse...";
            this.browseButton1.Click += new System.EventHandler(this.browseButton1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Share Folder:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Files in this folder will be shared with other users.";
            // 
            // identificationTabPage
            // 
            this.identificationTabPage.Controls.Add(this.groupBox5);
            this.identificationTabPage.Location = new System.Drawing.Point(4, 22);
            this.identificationTabPage.Name = "identificationTabPage";
            this.identificationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.identificationTabPage.Size = new System.Drawing.Size(361, 291);
            this.identificationTabPage.TabIndex = 2;
            this.identificationTabPage.Text = "Identification";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.computerNameTextBox);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Location = new System.Drawing.Point(11, 7);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(341, 81);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Computer Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Computer name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(304, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Your computer will be identified to other peers with this name.";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(307, 337);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(225, 337);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // autoConnectCheckBox
            // 
            this.autoConnectCheckBox.AutoSize = true;
            this.autoConnectCheckBox.Checked = global::Sideris.Properties.Settings.Default.AutoConnect;
            this.autoConnectCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Sideris.Properties.Settings.Default, "AutoConnect", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.autoConnectCheckBox.Location = new System.Drawing.Point(6, 20);
            this.autoConnectCheckBox.Name = "autoConnectCheckBox";
            this.autoConnectCheckBox.Size = new System.Drawing.Size(184, 17);
            this.autoConnectCheckBox.TabIndex = 0;
            this.autoConnectCheckBox.Text = "Automatically connect on startup";
            // 
            // serverTextBox
            // 
            this.serverTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Sideris.Properties.Settings.Default, "DiscoveryServer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.serverTextBox.Location = new System.Drawing.Point(9, 77);
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(335, 21);
            this.serverTextBox.TabIndex = 1;
            this.serverTextBox.Text = global::Sideris.Properties.Settings.Default.DiscoveryServer;
            // 
            // downloadFolderTextBox
            // 
            this.downloadFolderTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Sideris.Properties.Settings.Default, "DownloadsFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.downloadFolderTextBox.Location = new System.Drawing.Point(6, 41);
            this.downloadFolderTextBox.Name = "downloadFolderTextBox";
            this.downloadFolderTextBox.Size = new System.Drawing.Size(238, 21);
            this.downloadFolderTextBox.TabIndex = 6;
            this.downloadFolderTextBox.Text = global::Sideris.Properties.Settings.Default.DownloadsFolder;
            this.downloadFolderTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.sharedFolderTextBox_Validating);
            // 
            // subFoldersCheckBox
            // 
            this.subFoldersCheckBox.AutoSize = true;
            this.subFoldersCheckBox.Checked = global::Sideris.Properties.Settings.Default.IncludeSubfolders;
            this.subFoldersCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Sideris.Properties.Settings.Default, "IncludeSubfolders", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.subFoldersCheckBox.Location = new System.Drawing.Point(6, 83);
            this.subFoldersCheckBox.Name = "subFoldersCheckBox";
            this.subFoldersCheckBox.Size = new System.Drawing.Size(114, 17);
            this.subFoldersCheckBox.TabIndex = 4;
            this.subFoldersCheckBox.Text = "Include subfolders";
            // 
            // sharedFolderTextBox
            // 
            this.sharedFolderTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Sideris.Properties.Settings.Default, "SharedFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sharedFolderTextBox.Location = new System.Drawing.Point(6, 56);
            this.sharedFolderTextBox.Name = "sharedFolderTextBox";
            this.sharedFolderTextBox.Size = new System.Drawing.Size(238, 21);
            this.sharedFolderTextBox.TabIndex = 2;
            this.sharedFolderTextBox.Text = global::Sideris.Properties.Settings.Default.SharedFolder;
            this.sharedFolderTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.sharedFolderTextBox_Validating);
            // 
            // computerNameTextBox
            // 
            this.computerNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Sideris.Properties.Settings.Default, "ComputerName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.computerNameTextBox.Location = new System.Drawing.Point(99, 43);
            this.computerNameTextBox.MaxLength = 32;
            this.computerNameTextBox.Name = "computerNameTextBox";
            this.computerNameTextBox.Size = new System.Drawing.Size(100, 21);
            this.computerNameTextBox.TabIndex = 2;
            this.computerNameTextBox.Text = global::Sideris.Properties.Settings.Default.ComputerName;
            // 
            // OptionsForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(394, 372);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OptionsForm";
            this.Text = "Sideris";
            this.tabControl.ResumeLayout(false);
            this.connectionTabPage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.sharesTabPage.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.identificationTabPage.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage connectionTabPage;
        private System.Windows.Forms.TabPage sharesTabPage;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown portNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox autoConnectCheckBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button browseButton1;
        private System.Windows.Forms.TextBox sharedFolderTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox subFoldersCheckBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        internal System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.TabPage identificationTabPage;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox computerNameTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button browseButton2;
        private System.Windows.Forms.TextBox downloadFolderTextBox;
    }
}
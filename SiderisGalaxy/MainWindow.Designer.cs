namespace Sideris.SiderisGalaxy
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
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.portNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(272, 41);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(272, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sideris Galaxy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Peer-to-Peer server";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Location = new System.Drawing.Point(12, 157);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(66, 13);
            this.statusLabel.TabIndex = 11;
            this.statusLabel.Text = "Not started.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "Select a port on which Galaxy will listen for\r\npeers.";
            // 
            // portNumericUpDown
            // 
            this.portNumericUpDown.Location = new System.Drawing.Point(75, 113);
            this.portNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNumericUpDown.Name = "portNumericUpDown";
            this.portNumericUpDown.Size = new System.Drawing.Size(79, 21);
            this.portNumericUpDown.TabIndex = 13;
            this.portNumericUpDown.Value = new decimal(new int[] {
            13060,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Port:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(12, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 2);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(12, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 2);
            this.panel2.TabIndex = 16;
            // 
            // MainWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(359, 183);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Sideris Galaxy";
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown portNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
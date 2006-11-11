namespace Sideris
{
    partial class SharesView
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
            this.label1 = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.fullNameColumnHeader = new System.Windows.Forms.ColumnHeader(Sideris.Properties.Settings.Default.SharedFolder);
            this.SuspendLayout();
// 
// label1
// 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shared files";
// 
// listView
// 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.fullNameColumnHeader
            });
            this.listView.Location = new System.Drawing.Point(4, 25);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(300, 197);
            this.listView.TabIndex = 1;
            this.listView.View = System.Windows.Forms.View.Details;
// 
// fullNameColumnHeader
// 
            this.fullNameColumnHeader.Text = "File";
            this.fullNameColumnHeader.Width = 200;
// 
// SharesView
// 
            this.Controls.Add(this.listView);
            this.Controls.Add(this.label1);
            this.Name = "SharesView";
            this.Size = new System.Drawing.Size(307, 225);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader fullNameColumnHeader;
    }
}

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
    public partial class SharesView : UserControl
    {
        public SharesView()
        {
            InitializeComponent();
        }

        public delegate void UpdateViewInvoker(FilesDataSet.SharesDataTable shares);

        public void UpdateView(FilesDataSet.SharesDataTable shares)
        {
            if(listView.InvokeRequired)
            {
                listView.Invoke(new UpdateViewInvoker(this.UpdateView), shares);
                return;
            }

            listView.Items.Clear();
            foreach(FilesDataSet.SharesRow row in shares.Rows)
            {
                listView.Items.Add(row.FullName);
            }
        }

    }
}

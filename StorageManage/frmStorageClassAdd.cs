using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StorageManageLibrary;

namespace StorageManage
{
    /// <summary>
    /// 货物类别新增
    /// </summary>
    public partial class frmStorageClassAdd : Form
    {
        public frmStorageClassAdd()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StorageClassManage ptm = new StorageClassManage();

            long maxnode =long.Parse( ptm.GetMaxNodeData(txtFatherID.Text))+1;

            ptm.InsertTypeNode(maxnode.ToString(), txtTypeName.Text, txtFatherID.Text);

            frmStorageClass.frmstorageclass.Refresh();
            
            this.Close();
        }
    }
}
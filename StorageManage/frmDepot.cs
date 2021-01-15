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
    /// 仓库
    /// </summary>
    public partial class frmDepot : frmBase
    {
        DepotManage DepotManage = new DepotManage(); 
        public frmDepot()
        {
            InitializeComponent();
            txtGuid.Text = Guid.NewGuid().ToString();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDepot_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dtl = DepotManage.GetDepotData2();
            gridControl1.DataSource = dtl;
            gridView1.Columns[0].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtGuid.Text = Guid.NewGuid().ToString();

            txtDepotName.Text = "";
            txtDepotPerson.Text = "";
            txtTelephone.Text = "";
            cboRemark.Checked = false;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            Depot Depot = new Depot();
            Depot.DepotGuid = txtGuid.Text;
            Depot.DepotName = txtDepotName.Text;
          
            Depot.DepotPerson = txtDepotPerson.Text;
            if (txtTelephone.Text.Trim() == "")
            {
                Depot.Telephone = "0";
            }
            else
            {

                Depot.Telephone = txtTelephone.Text;
            }
            
            if (cboRemark.Checked == true)
            {
                Depot.Remark = "1";
            }
            else
            {
                Depot.Remark = "0";
            }
           

            DepotManage.Save(Depot);

            LoadData();

            this.ShowMessage("保存成功!");
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                DataRowView dr = (DataRowView)(gridView1.GetFocusedRow());

                txtGuid.Text = dr[0].ToString();
                txtDepotName.Text = dr[1].ToString();
                txtDepotPerson.Text = dr[2].ToString();
                txtTelephone.Text = dr[3].ToString();
                if (dr[4].ToString().Trim() == "1")
                {
                    cboRemark.Checked = true;
                }
                else
                {
                    cboRemark.Checked = false;
                }
               
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除该数据！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                DataRowView dr = (DataRowView)(gridView1.GetFocusedRow());
                DepotManage.DeleteDepot(dr[0].ToString());

                LoadData();
                this.ShowMessage("删除成功!");
            }
        }
    }
}
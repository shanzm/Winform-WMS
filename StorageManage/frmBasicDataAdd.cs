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
    /// 常用选项
    /// </summary>
    public partial class frmBasicDataAdd : Form
    {
        BasicDataManage BasicDataManage = new BasicDataManage();
        public frmBasicDataAdd()
        {
            InitializeComponent();
        }

       

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

            loaddata();
        }

        private void loaddata()
        {
            //(1-单位 2-规格 3:封装 4:计价法)
            int flag = 0;
            switch (cboSelect.Text.Trim())
            {
                case "单位":
                    flag = 1;
                    break;
                case "规格":
                    flag = 2;
                    break;
                case "封装":
                    flag = 3;
                    break;
                case "计价法":
                    flag = 4;
                    break;
            }

            //绑定仓库
            DataTable dtl = BasicDataManage.GetBasicData2(flag);
            this.gridSelect.DataSource = dtl;
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            int flag = 0;
            switch (cboSelect.Text.Trim())
            {
                case "单位":
                    flag = 1;
                    break;
                case "规格":
                    flag = 2;
                    break;
                case "封装":
                    flag = 3;
                    break;
                case "计价法":
                    flag = 4;
                    break;
            }

            BasicData BasicData = new BasicData();
            BasicData.UnitName = txtValue.Text;
            BasicData.flag = flag;

            BasicDataManage.Save(BasicData);

            loaddata();

           
        }

        private void tsBtnDel_Click(object sender, EventArgs e)
        {

            if (gridVProGroup.RowCount > 0)
            {
                int flag = 0;
                switch (cboSelect.Text.Trim())
                {
                    case "单位":
                        flag = 1;
                        break;
                    case "规格":
                        flag = 2;
                        break;
                    case "封装":
                        flag = 3;
                        break;
                    case "计价法":
                        flag = 4;
                        break;
                }
                DialogResult dr = MessageBox.Show("确定要删除所选择的记录吗", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    string unitid = ((DataRowView)(gridVProGroup.GetFocusedRow())).Row[0].ToString();


                    BasicDataManage.DeleteBasicData(unitid);

                    loaddata();
                }

            }
        }
    }
}
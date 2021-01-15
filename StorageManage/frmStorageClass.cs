using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using StorageManageLibrary;

namespace StorageManage
{
    /// <summary>
    /// 货号类别管理
    /// </summary>
    public partial class frmStorageClass : frmBase
    {
        public static frmStorageClass frmstorageclass;
        public frmStorageClass()
        {
            InitializeComponent();
            frmstorageclass = this;
        }



        /// <summary>
        /// 加载树
        /// </summary>
        public void LoadStorageClassTree()
        {

            DataTable mdt = new DataTable();
            StorageClassManage pmc = new StorageClassManage();
            mdt = pmc.GetStorageClassData();

            this.treeView1.ImageList = imageList2;
            if (mdt.Rows.Count > 0)
            {
                int MaxLayer = 10;
                ArrayList al = new ArrayList();
                for (int i = 1; i <= MaxLayer; i++)
                {

                    if (i == 1)
                    {
                        DataRow[] dr;
                        dr = mdt.Select("FatherID='0'");
                        for (int j = 0; j < dr.Length; j++)
                        {
                            TreeNode tn = new TreeNode();
                            tn.Text = dr[j]["InterName"].ToString();

                            tn.Tag = dr[j]["InterID"].ToString();

                            this.treeView1.Nodes.Add(tn);
                            al.Add(tn);

                        }
                        dr = null;
                    }
                    else
                    {
                        int upLenth = al.Count; //记录上一层节点数
                        for (int k = 0; k < upLenth; k++)
                        {
                            TreeNode tvn = (TreeNode)al[k];
                            DataRow[] dr = mdt.Select("FatherID='" + tvn.Tag.ToString() + "'");
                            for (int j = 0; j < dr.Length; j++)
                            {
                                TreeNode tn = new TreeNode();
                                tn.Text = dr[j]["InterName"].ToString();
                                tn.Tag = dr[j]["InterID"].ToString();
                                tvn.Nodes.Add(tn);
                                al.Add(tn); //增加本层节点，以便下一层加载
                            }
                            dr = null;
                        }
                        for (int k = upLenth - 1; k >= 0; k--)
                        {
                            al.RemoveAt(k); //删除上一层节点的引用
                        }
                        if (al.Count == 0)
                        {
                            break;
                        }
                    }
                }
                al = null;
            }

            mdt.Dispose();
        }



        public void FillData()
        {
            treeView1.Nodes.Clear();
            LoadStorageClassTree();
            treeView1.ExpandAll();

            this.ShowDialog();
        }


        public void Refresh()
        {
            treeView1.Nodes.Clear();
            LoadStorageClassTree();
            treeView1.ExpandAll();

        
        }


        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmStorageClassAdd fpt = new frmStorageClassAdd();
            fpt.txtFatherID.Text  = treeView1.SelectedNode.Tag.ToString();
            fpt.txtFatherName.Text = treeView1.SelectedNode.Text;
            fpt.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Text == "货品分类")
            {
                this.ShowMessage("根结点不可以删除！");
                return;
            }

            DialogResult dr = MessageBox.Show("确定要删除选择的结点（包括子结点）吗?", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                StorageClassManage prodm = new StorageClassManage();
                prodm.DeleteNodeData(treeView1.SelectedNode.Tag.ToString());
                Refresh();
            }
        }

        private void frmStorageClass_Load(object sender, EventArgs e)
        {
            LoadStorageClassTree();

            treeView1.ExpandAll();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
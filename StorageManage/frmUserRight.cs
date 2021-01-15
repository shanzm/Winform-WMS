using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StorageManageLibrary;
using System.Web.UI.WebControls;

namespace StorageManage
{
    public partial class frmUserRight : frmBase
    {
        /// <summary>
        /// 权限设置
        /// </summary>
        public frmUserRight()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserRight_Load(object sender, EventArgs e)
        {
            LoginUserManage lum = new LoginUserManage();
            DataTable dtl = lum.GetLoginUserInfo();
            ListItem item;
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                item = new ListItem();
                item.Text = dtl.Rows[i]["USERNAME"].ToString();
                item.Value = dtl.Rows[i]["USERID"].ToString();
                checkedListBox1.Items.Add(item);
            }


            UserRightManage urm = new UserRightManage();
            dtl = urm.GetModule();
          
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                item = new ListItem();
                item.Text = dtl.Rows[i]["ModuleName"].ToString();
                item.Value = dtl.Rows[i]["ModuleId"].ToString();
                chLBPopedom.Items.Add(item);
            }

        }

        //保存用户权限
        private void tsbSave_Click(object sender, EventArgs e)
        {
            List<UserRight> lst = new List<UserRight>();
            UserRight UserRight = new UserRight();
            UserRightManage UserRightManage = new UserRightManage();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i) == true)
                {
                    UserRight = new UserRight();
                    UserRight.UserID = ((ListItem)checkedListBox1.Items[i]).Value;
                    for (int j = 0; j < chLBPopedom.Items.Count; j++)
                    {
                        switch (((ListItem)chLBPopedom.Items[j]).Value.Trim())
                        {
                            #region 赋值
                            case "ckdmxb":
                                UserRight.ckdmxb = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "ckdhzb":
                                UserRight.ckdhzb = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "dbdgl":
                                UserRight.dbdgl = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "dbdxz":
                                UserRight.dbdxz = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "dbzsh":
                                UserRight.dbzsh = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "cccx":
                                UserRight.cccx = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "cksfmxb":
                                UserRight.cksfmxb = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "bmsfmxb":
                                UserRight.bmsfmxb = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "sfchzb":
                                UserRight.sfchzb = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "sflxhzb":
                                UserRight.sflxhzb = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "lkdgl":
                                UserRight.lkdgl = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "chmxz":
                                UserRight.chmxz = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "kcpd":
                                UserRight.kcpd = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "kcpdxz":
                                UserRight.kcpdxz = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "kcpdsh":
                                UserRight.kcpdsh = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "hp":
                                UserRight.hp = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "ck":
                                UserRight.ck = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "kh":
                                UserRight.kh = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "gys":
                                UserRight.gys = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "yg":
                                UserRight.yg = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "bm":
                                UserRight.bm = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "lkdxz":
                                UserRight.lkdxz = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "yhgl":
                                UserRight.yhgl = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "qxgl":
                                UserRight.qxgl = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "lkdsh":
                                UserRight.lkdsh = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "lkdmxb":
                                UserRight.lkdmxb = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "lkdhzb":
                                UserRight.lkdhzb = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "ckdgl":
                                UserRight.ckdgl = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "ckdxz":
                                UserRight.ckdxz = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            case "ckdsh":
                                UserRight.ckdsh = chLBPopedom.GetItemChecked(j) == true ? "1" : "0";
                                break;
                            #endregion
                        }
                    }

                    lst.Add(UserRight);
                }
            
            }


            UserRightManage.SaveUserRight(lst);

            this.ShowMessage("保存成功！");
        }

        private void chkAllUser_Click(object sender, EventArgs e)
        {
            if (chkAllUser.Checked == true)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void chkAllModule_Click(object sender, EventArgs e)
        {
            if (chkAllModule.Checked== true)
            {
                for (int i = 0; i < chLBPopedom.Items.Count; i++)
                {
                    chLBPopedom.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < chLBPopedom.Items.Count; i++)
                {
                    chLBPopedom.SetItemChecked(i, false);
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //点击时加载此用户的权限
            UserRight UserRight = new UserRight();
            UserRightManage UserRightManage = new UserRightManage();
            string userid = ((ListItem)checkedListBox1.SelectedItem).Value;
            UserRight = UserRightManage.GetUserRight(userid);

            for (int j = 0; j < chLBPopedom.Items.Count; j++)
            {
                switch (((ListItem)chLBPopedom.Items[j]).Value.Trim())
                {
                    #region 赋值
                    case "ckdmxb":
                        if (UserRight.ckdmxb == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                       
                        break;
                    case "ckdhzb":
                        if (UserRight.ckdhzb == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "dbdgl":
                        if (UserRight.dbdgl == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "dbdxz":
                        if (UserRight.dbdxz == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "dbzsh":
                        if (UserRight.dbzsh == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "cccx":
                        if (UserRight.cccx == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "cksfmxb":
                        if (UserRight.cksfmxb == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "bmsfmxb":
                        if (UserRight.bmsfmxb == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "sfchzb":
                        if (UserRight.sfchzb == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "sflxhzb":
                        if (UserRight.sflxhzb == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "lkdgl":
                        if (UserRight.lkdgl == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "chmxz":
                        if (UserRight.chmxz == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "kcpd":
                        if (UserRight.kcpd == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "kcpdxz":
                        if (UserRight.kcpdxz == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "kcpdsh":
                        if (UserRight.kcpdsh == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "hp":
                        if (UserRight.hp == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "ck":
                        if (UserRight.ck == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "kh":
                        if (UserRight.kh == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "gys":
                        if (UserRight.gys == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "yg":
                        if (UserRight.yg == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "bm":
                        if (UserRight.bm == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "lkdxz":
                        if (UserRight.lkdxz == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "yhgl":
                        if (UserRight.yhgl == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "qxgl":
                        if (UserRight.qxgl == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "lkdsh":
                        if (UserRight.lkdsh == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "lkdmxb":
                        if (UserRight.lkdmxb == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "lkdhzb":
                        if (UserRight.lkdhzb == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "ckdgl":
                        if (UserRight.ckdgl == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "ckdxz":
                        if (UserRight.ckdxz == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    case "ckdsh":
                        if (UserRight.ckdsh == "1")
                        {
                            chLBPopedom.SetItemChecked(j, true);
                        }
                        else
                        {
                            chLBPopedom.SetItemChecked(j, false);
                        }
                        break;
                    #endregion
                }
            }

        }
    }
}
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace update
{
    /// <summary>
    /// 功能: 自动更新客户端程序,指定一个服务器的更新地址即可
    /// 作者: whm
    /// 日期: 2010-3-12
    /// </summary>
    public class frmUpdate : Form
    {
        private Container components;
        private Label l1;
        private Label label1;
        private string UpdatePath = "";

        public frmUpdate(string sPath)
        {
            this.InitializeComponent();
            this.UpdatePath = sPath;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(this.update)).Start();
        }

        private void InitializeComponent()
        {
            this.l1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Location = new System.Drawing.Point(16, 38);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(0, 12);
            this.l1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "EMRP管理系统正在更新,请稍候......";
            // 
            // frmUpdate
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(344, 63);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l1);
            this.Name = "frmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        [STAThread]
        private static void Main(string[] args)
        {
            Application.Run(new frmUpdate(args[0]));
        }

        private void update()
        {
            try
            {
                string[] directories = Directory.GetDirectories(this.UpdatePath);
                for (int i = 0; i < directories.Length; i++)
                {
                    string[] strArray2 = Directory.GetFiles(directories[i].ToString());
                    if (!Directory.Exists(Application.StartupPath + directories[i].Replace(this.UpdatePath, "")))
                    {
                        Directory.CreateDirectory(Application.StartupPath + directories[i].Replace(this.UpdatePath, ""));
                    }
                    for (int k = 0; k < strArray2.Length; k++)
                    {
                        if (Path.GetFileName(strArray2[k]).ToLower() != "update.exe")
                        {
                            this.l1.Text = Path.GetFileName(strArray2[k]);
                            File.Copy(strArray2[k], Application.StartupPath + directories[i].Replace(this.UpdatePath, "") + @"\" + Path.GetFileName(strArray2[k]), true);
                        }
                    }
                }
                string[] files = Directory.GetFiles(this.UpdatePath);
                for (int j = 0; j < files.Length; j++)
                {
                    if (Path.GetFileName(files[j]).ToLower() != "update.exe")
                    {
                        this.l1.Text = Path.GetFileName(files[j]);
                        File.Copy(files[j], Application.StartupPath + @"\" + Path.GetFileName(files[j]), true);
                    }
                }
                if (MessageBox.Show("EMRP管理系统更新成功，是否重新启动应用程序?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start(Application.StartupPath + @"\ErpManage.exe");
                }
                Application.Exit();
            }
            catch (Exception exception)
            {
                MessageBox.Show("自动更新系统失败，请联系管理员,错误信息：" + exception.Message, "提示");
                Application.Exit();
            }
        }
    }
}


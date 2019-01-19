using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManageSystem
{
    public partial class ALogin : Form
    {
        public ALogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Users r = new Users();
            r.Account = txtName.Text.Trim();
            r.Password = txtPassword.Text.Trim();
            DataSet ds = DBOperate.readDB("select * from UserInfo where UserAccount='" + r.Account + "' and UserPassword='" + r.Password + "' and UserType='管理员'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Main m = new Main();
                m.Show();
                this.Hide();
            }
            else
                MessageBox.Show("账号或者密码错误！");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPW rp = new ResetPW();
            rp.ShowDialog();
        }

    }
}

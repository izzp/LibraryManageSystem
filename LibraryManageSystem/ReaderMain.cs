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
    public partial class ReaderMain : Form
    {
        string s;
        public string S //属性用于接收登陆用户
        {
            get { return s; }
            set { s = value; }
        }
        public ReaderMain()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();

        }

        private void ReaderMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void tabControl1_Click(object sender, EventArgs e)//更改个人信息时的事件
        {
            Login l = new Login();
            DataSet ds = DBOperate.readDB("select * from UserInfo where UserAccount='"+s+"'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblNum.Text = (ds.Tables[0].Rows[0][0]).ToString();
                txtName.Text = (ds.Tables[0].Rows[0][2]).ToString();
                txtMobile.Text = (ds.Tables[0].Rows[0][3]).ToString();
                txtEmail.Text = (ds.Tables[0].Rows[0][4]).ToString();
            }
            string webpic = "你的oss路径" +lblNum.Text + ".jpg";
            pictureUser.ImageLocation = webpic;
        }
        private void tabControl4_Click(object sender, EventArgs e)//还书界面自动触发事件
        {
            cmbReturn.Items.Clear();
            DataSet dr = DBOperate.readDB("select Books.BookName 书名,Books.ISBN 书号,Books.BookStyle 类型,BorrowTime 借出时间,ReturnTime 应归还时间 from BRBooks INNER JOIN Books  on BRBooks.ISBN=Books.ISBN where BRBooks.UserAccount='" + s + "'");
            if (dr.Tables[0].Rows.Count > 0)
            {
                btnReturn.Enabled = true;
                dataGridView3.DataSource = dr.Tables[0];
                for (int i = 0; i < dr.Tables[0].Rows.Count; i++)
                {
                    string str = (dr.Tables[0].Rows[i][0]).ToString();
                    cmbReturn.Items.Add(str);
                }
            }
            else if (dr.Tables[0].Rows.Count == 0)
            {
                btnReturn.Enabled = false;
            }
        }

        private void btnSelectBooks_Click(object sender, EventArgs e)
        {
            DataSet ds = DBOperate.readDB("select ISBN,BookName 书名,BookStyle 类型,Price 价格,Press 出版社,Author 作者,EnterTime 入库时间,IsBorrow 是否借出 from Books");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            u.Account = lblNum.Text;
            u.Name = txtName.Text.Trim();
            u.Mobile = txtMobile.Text.Trim();
            u.Email = txtEmail.Text.Trim();
            if (DBOperate.writeDB("update UserInfo set UserName='" + u.Name + "',UserMobile='" + u.Mobile + "',UserEmail='" + u.Email + "' where UserAccount='"+u.Account+"'") > 0)
            {
                MessageBox.Show("保存成功！");
            }
            else
            {
                MessageBox.Show("保存失败！");
            }
        }
        int index ;//定义下面用于接收是选中的第几行
        private void btnSearch_Click(object sender, EventArgs e)//按类型或者作者查书的事件
        {
            DataSet ds = null;
            Book b=new Book();
            b.Style = txtSearch.Text.Trim();
            b.Author = txtSearch.Text.Trim();
            b.Name = txtSearch.Text.Trim();
            if (comboBox1.Text == "类型")
            {
                ds = DBOperate.readDB("select ISBN,BookName 书名,BookStyle 类型,Price 价格,Press 出版社,Author 作者,EnterTime 入库时间,IsBorrow 是否借出 from Books where BookStyle like '%"+b.Style+"%'");
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "作者")
            {
                ds = DBOperate.readDB("select ISBN,BookName 书名,BookStyle 类型,Price 价格,Press 出版社,Author 作者,EnterTime 入库时间,IsBorrow 是否借出 from Books where Author like '%" + b.Author + "%'");
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                ds = DBOperate.readDB("select ISBN,BookName 书名,BookStyle 类型,Price 价格,Press 出版社,Author 作者,EnterTime 入库时间,IsBorrow 是否借出 from Books where BookName like '%" + b.Name + "%'");
                dataGridView1.DataSource = ds.Tables[0];
            }
           
        }
        private void btnSearchPic_Click(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index; //获取选中行的行号  
            string ISBN = dataGridView1.Rows[index].Cells[0].Value.ToString();//获取选中行的ISBN
            string webpic = "你的oss路径" + ISBN + ".jpg";//拉取阿里云oss对应图片
            pictureSearch.ImageLocation = webpic;
        }
        private void btnSearch2_Click(object sender, EventArgs e)//查询按钮的事件
        {
            DataSet ds = null;
            Book b = new Book();
            b.Style = textBox2.Text.Trim();
            b.Author = textBox2.Text.Trim();
            b.Name = textBox2.Text.Trim();
            ds = DBOperate.readDB("select ISBN,BookName 书名,BookStyle 类型,Price 价格,Press 出版社,Author 作者,EnterTime 入库时间,IsBorrow 是否借出 from Books where BookName like '" + b.Name + "'");
            dataGridView2.DataSource = ds.Tables[0];
            if(textBox2.Text.Trim()=="")
            {
                MessageBox.Show("请先输入书名！");
            }
            else
            {
                if (dataGridView2.RowCount == 0 )
                {
                    MessageBox.Show("该书信息不存在或信息填写不完整，请重试！");
                }
                else
                {
                    string ISBN = ds.Tables[0].Rows[0]["ISBN"].ToString();//获取选中行的ISBN
                    string webpic = "你的oss路径" + ISBN + ".jpg";
                    pictureBorrow.ImageLocation = webpic;
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }

        }

        private void btnBorrow_Click(object sender, EventArgs e)//借书的按钮的事件
        {
            Book br = new Book();
            br.Name = textBox2.Text.Trim();
            DataSet ds = DBOperate.readDB("select * from Books where BookName='" + textBox2.Text.Trim() + "'");
            if (dataGridView2.RowCount>=1)
            {
                br.IsBorrow = ds.Tables[0].Rows[0][7].ToString();
                if (br.IsBorrow == "是")
                {
                    MessageBox.Show("该书已被借阅");
                    return;
                }
                else
                {
                    br.ISBN = ds.Tables[0].Rows[0][0].ToString();
                    if (DBOperate.writeDB("insert into BRBooks values( '" + br.ISBN + "' ,'" + s + "','" + DateTime.Now.ToShortDateString() + "','" + dateTimePicker1.Value.ToShortDateString() + "')") > 0)
                    {
                        if (DBOperate.writeDB("update Books set IsBorrow='是' where ISBN='" + br.ISBN + "'") > 0)
                        {
                            MessageBox.Show("借阅成功");
                        }
                        else
                        {
                            MessageBox.Show("该书已被借阅");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请先输入书名后点击查询！");
            }
            
        }

        private void btnReturn_Click(object sender, EventArgs e)//还书按钮事件
        {
            Book br = new Book();
            br.Name = cmbReturn.SelectedItem.ToString();
            DataSet ds = DBOperate.readDB("select * from BRBooks INNER JOIN Books on BRBooks.ISBN=Books.ISBN where BookName='" +br.Name+ "'");
            if (ds.Tables[0].Rows.Count>0)
            {
               // DBOperate.writeDB("update Books set IsBorrow='否' where ISBN='" + br.ISBN + "'");
                DBOperate.writeDB("update Books set IsBorrow='否' where ISBN=(select ISBN from Books where BookName = '" + br.Name + "')");
                DBOperate.writeDB("delete  from BRBooks where ISBN=(select ISBN from Books where BookName =  '" + br.Name + "')");
                cmbReturn.Items.Remove(cmbReturn.SelectedItem);//移除当前选中项
                cmbReturn.Text = "";
                 MessageBox.Show("归还成功");
                 DataSet dd = DBOperate.readDB("select * from BRBooks INNER JOIN Books on BRBooks.ISBN=Books.ISBN where BookName='" + br.Name + "'");
                 dataGridView3.DataSource = dd.Tables[0];
             }
            else
            {
                MessageBox.Show("请选择你借阅的书");
            }
            }

        private void btnPicReturn_Click(object sender, EventArgs e)//还书界面选择书的的图片事件
        {
            string name = cmbReturn.SelectedItem.ToString();
            DataSet ds = DBOperate.readDB("select * from Books where BookName='" + name + "'");
            string ISBN = ds.Tables[0].Rows[0][0].ToString();
            string webpic = "你的oss路径" + ISBN + ".jpg";
            pictureReturn.ImageLocation = webpic;
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            AboutBox1 R = new AboutBox1();
            R.ShowDialog();
        }

        private void ReaderMain_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
        }

        private void pictureReturn_Click(object sender, EventArgs e)
        {

        }

        private void btnZX_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }

        private void pictureUser_Click(object sender, EventArgs e)
        {

        }

        }
    }

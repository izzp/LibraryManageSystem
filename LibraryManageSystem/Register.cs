using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using System.Text.RegularExpressions;
using Aliyun.OSS;

namespace LibraryManageSystem
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtNum.Text = "";
            txtPass.Text = "";
            textPass2.Text = "";
            txtName.Text = "";
            textPhone.Text = "";
            textVerificationCode.Text = "";
            txtEmail.Text = "";
        }
        string num;//验证码随机数
  
        private void btnGetVerificationCode_Click(object sender, EventArgs e)//获取短信验证码
        {
            Random rd = new Random();
             num = (rd.Next(100000, 1000000)).ToString();
            String product = "Dysmsapi";//短信API产品名称（短信产品名固定，无需修改）
            String domain = "dysmsapi.aliyuncs.com";//短信API产品域名（接口地址固定，无需修改）
            String accessKeyId = "你的阿里云";//accessKeyId，
            String accessKeySecret = "你的密钥";//accessKeySecret，
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
            //IAcsClient client = new DefaultAcsClient(profile);
            // SingleSendSmsRequest request = new SingleSendSmsRequest();
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            try
            {

                request.PhoneNumbers = ""+textPhone.Text.Trim()+"";
                request.SignName = "雨心的世界";
                request.TemplateCode = "SMS_";
                request.TemplateParam = "{\"code\":\""+num+"\"}";
                request.OutId = "yourOutId";
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                System.Console.WriteLine(sendSmsResponse.Message);
                MessageBox.Show("验证码发送成功！");
            }
            catch (ServerException ex)
            {
                throw (ex);
            }
            catch (ClientException ex)
            {
                throw (ex);
            }
        }
        string upUserStr;//设置一个用于接收上传图片路径的字符串
        private void btnUp_Click(object sender, EventArgs e)
        {
            Regex account = new Regex(@"^[a-zA-Z][a-zA-Z0-9]{6,14}$");
            Regex passWord = new Regex(@"^[a-zA-Z0-9]{4,10}$");
            Regex name = new Regex(@"^[\u4e00-\u9fa5]{2,}$");
            Regex tel = new Regex(@"^0?(13|14|15|17|18|19)[0-9]{9}$");
            Regex mail = new Regex(@"^[\w!#$%&'*+/=?^_`{|}~-]+(?:\.[\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?$");
            Users u = new Users();
            u.Account = txtNum.Text.Trim();
            u.Password = txtPass.Text.Trim();
            u.Name = txtName.Text.Trim();
            u.Mobile = textPhone.Text.Trim();
            u.Email = txtEmail.Text.Trim();
            if (!account.IsMatch(txtNum.Text.Trim()))
            {
                pictureBox2.Visible = true;
            }
            else
            {
                pictureBox2.Visible = false;
            }
            if (!passWord.IsMatch(txtPass.Text.Trim()))
            {
                pictureBox3.Visible = true;
            }
            else
            {
                pictureBox3.Visible = false;
            }
            if (!name.IsMatch(txtName.Text.Trim()))
            {
                pictureBox4.Visible = true;
            }
            else
            {
                pictureBox4.Visible = false;
            }
            if (!tel.IsMatch(textPhone.Text.Trim()))
            {
                pictureBox5.Visible = true;
            }
            else
            {
                pictureBox5.Visible = false;
            }
            if (!mail.IsMatch(txtEmail.Text.Trim()))
            {
                pictureBox6.Visible = true;
            }
            else
            {
                pictureBox6.Visible = false;
            }
            DataSet ds = DBOperate.readDB("select * from UserInfo where UserAccount='" + u.Account + "'");
            DataSet ds1 = DBOperate.readDB("select * from UserInfo where UserMobile='" + u.Mobile + "' and UserEmail='" + u.Email + "'");                     
            if (txtPass.Text.Trim() !=textPass2.Text.Trim())
            {
                MessageBox.Show("两次密码输入不一致！");
                return;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("当前用户已被注册！");
            }
            else
            {
                if (pictureBox2.Visible || pictureBox3.Visible || pictureBox4.Visible || pictureBox5.Visible || pictureBox6.Visible)
                {
                    MessageBox.Show("信息填写错误！");
                    return;
                }
                else
                {

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("当前用户的手机号或者邮箱已被注册！");
                    }
                    else
                    {
                            if (num == textVerificationCode.Text.Trim())
                            {
                            if (DBOperate.writeDB("insert into UserInfo values('" + u.Account + "','" + u.Password + "','" + u.Name + "','" + u.Mobile + "','" + u.Email + "','读者')") > 0)
                            {
                                ///把选择的图片上传给阿里云oss
                                if (txtName.Text.Trim() != null)
                                {
                                    var endpoint = "oss-cn-beijing.aliyuncs.com";
                                    var accessKeyId = "你的阿里云";
                                    var accessKeySecret = "你的密钥";
                                    var bucketName = "c-sharp";
                                    var objectName = @"users/" + txtNum.Text.Trim() + ".jpg";
                                    var localFilename = @"" + upUserStr + "";
                                    // 创建OSSClient实例。
                                    var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
                                    try
                                    {
                                        // 上传文件。
                                        var result = client.PutObject(bucketName, objectName, localFilename);
                                        Console.WriteLine("Put object succeeded, ETag: {0} ", result.ETag);
                                        MessageBox.Show("上传成功");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Put object failed, {0}", ex.Message);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("图片上传失败，请联系管理员");
                                }
                                MessageBox.Show("注册成功!");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("注册失败!");
                            }
                            }
                            else
                            {
                            MessageBox.Show("请输入验证码，或验证码不正确！");
                            }
                    }
                }
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd1 = new OpenFileDialog();
            ofd1.Filter = "图片文件（*.jpg）|*.jpg";
            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                upUserStr = ofd1.FileName;
                Image imgPhoto = Image.FromFile(ofd1.FileName);
                pictureUpRegin.Image = imgPhoto;
            }
        }
    }
}

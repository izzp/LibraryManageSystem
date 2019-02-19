using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Aliyun.Acs.Dm.Model.V20151123;
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
    public partial class ResetPW : Form
    {
        public ResetPW()
        {
            InitializeComponent();
        }
        string newpassword;//新密码
        private void btnSmsReset_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            newpassword = (rd.Next(10000000, 100000000)).ToString();//随机生成一个8位数字密码
            DataSet ds = DBOperate.readDB("select * from UserInfo where UserMobile='" + txtSmsReset.Text.Trim() + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (DBOperate.writeDB("update UserInfo set UserPassword='" + newpassword + "' where UserMobile='" + txtSmsReset.Text.Trim() + "'") > 0)
                {
                    String product = "Dysmsapi";//短信API产品名称（短信产品名固定，无需修改）
                    String domain = "dysmsapi.aliyuncs.com";//短信API产品域名
                    String accessKeyId = "";//accessKeyId，
                    String accessKeySecret = "";//accessKeySecret，
                    IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
                    //IAcsClient client = new DefaultAcsClient(profile);
                    // SingleSendSmsRequest request = new SingleSendSmsRequest();
                    DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
                    IAcsClient acsClient = new DefaultAcsClient(profile);
                    SendSmsRequest request = new SendSmsRequest();
                    try
                    {
                        request.PhoneNumbers = "" + txtSmsReset.Text.Trim() + "";
                        request.SignName = "雨心的世界";
                        request.TemplateCode = "SMS_";
                        request.TemplateParam = "{\"password\":\"" + newpassword + "\"}";
                        request.OutId = "yourOutId";
                        SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                        System.Console.WriteLine(sendSmsResponse.Message);
                        MessageBox.Show("重置密码成功、已发送到您的手机！");
                    }
                    catch (ServerException ex)
                    {
                        throw (ex);
                    }
                    catch (ClientException ex)
                    {
                        throw (ex);
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("重置失败，请联系系统管理员!");
                }
            }
            else
            {

                MessageBox.Show("请输入注册过该平台的手机号");
            }
        }

        private void btnEmailReset_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            newpassword = (rd.Next(10000000, 100000000)).ToString();//随机生成一个8位数字密码
            DataSet ds = DBOperate.readDB("select * from UserInfo where UserEmail='" + txtEmailReset.Text.Trim() + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (DBOperate.writeDB("update UserInfo set UserPassword='" + newpassword + "' where UserEmail='" + txtEmailReset.Text.Trim() + "'") > 0)
                {
                    IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", "阿里云", "密钥");
                    IAcsClient client = new DefaultAcsClient(profile);
                    SingleSendMailRequest request = new SingleSendMailRequest();
                    try
                    {
                        String pass = "<table style=\";width:99.8%;height:99.8%\";><tbody><tr><td style=\";background:#fafafa url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAy0lEQVQY0x2PsQtAYBDFP1keKZfBKIqNycCERUkMKLuSgZnRarIpJX8s3zfcDe9+794du+8bRVHQOI4wDAOmaULTNDDGYFkWMVVVQUTQdZ3iOMZxHCjLElVV0TRNYHVdC7ptW6RpSn3f4wdJkiTs+w6WJAl4DcOAbdugKAq974umaRAEARgXn+cRW3zfFxuiKCJZloXGHMeBbdv4Beq6Duu6Issy7iYB8Jbnucg8zxPLsggnj/zvIxaGIXmeB9d1wSE+nOeZf4HruvABUtou5ypjMF4AAAAASUVORK5CYII=)\";><div style=\";border-radius:10px;font-size:13px;color:#555;width:666px;font-family:'Century Gothic','Trebuchet MS','Hiragino Sans GB','微软雅黑','Microsoft Yahei',Tahoma,Helvetica,Arial,SimSun,sans-serif;margin:50px auto;border:1px solid #eee;max-width:100%;background:#fff repeating-linear-gradient(-45deg,#fff,#fff 1.125rem,transparent 1.125rem,transparent 2.25rem);box-shadow:0 1px 5px rgba(0,0,0,.15)\";><div style=\";width:100%;background:#49BDAD;color:#fff;border-radius:10px 10px 0 0;background-image:-moz-linear-gradient(0deg,#43c6b8,#ffd1f4);background-image:-webkit-linear-gradient(0deg,#43c6b8,#ffd1f4);height:66px\";><p style=\";font-size:15px;word-break:break-all;padding:23px 32px;margin:0;background-color:hsla(0,0%,100%,.4);border-radius:10px 10px 0 0\";>尊敬的图书馆管理系统用户您好：</p></div><div style=\";margin:40px auto;width:90%\";><p>" + newpassword + "是您的新密码，请牢记</p><p>请注意：此邮件自动发送，请勿直接回复。</p></div></div></td></tr></tbody></table>";
                        request.AccountName = "你的发信域名";
                        request.FromAlias = "图书管理系统";
                        request.AddressType = 1;
                        request.TagName = "BackPassword";
                        request.ReplyToAddress = true;
                        request.ToAddress = (txtEmailReset.Text.Trim()).ToString();
                        request.Subject = "图书管理系统的重置后密码";
                        request.HtmlBody = pass;
                        SingleSendMailResponse httpResponse = client.GetAcsResponse(request);
                    }
                    finally
                    {
                        MessageBox.Show("邮件发送成功，如未收到请联系系统管理员或者在垃圾箱中寻找");
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("重置失败，请联系系统管理员!");
                }
            }
            else
            {

                MessageBox.Show("请输入注册过该平台的电子邮箱");
            }
        }
    }
}

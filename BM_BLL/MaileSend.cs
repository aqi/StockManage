using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Net;
using System.Net.Mail;

namespace Web0204.BM.BLL
{
    /// <summary>
    /// 发送邮件功能
    /// </summary>
    public class MaileSend
    {
        public bool SendMail(string mailto)
        {

            MailAddress from = new MailAddress("xyingqi123@163.com");
            MailAddress to = new MailAddress(mailto);
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = "登陆通知";
            mail.Body = "你已登陆系统";
            SmtpClient mySmth = new SmtpClient();

            mySmth.Send(mail);
            mail.Dispose();
            return true;
        }
    }
}

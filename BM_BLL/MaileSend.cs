using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Net;
using System.Net.Mail;

namespace Web0204.BM.BLL
{
    /// <summary>
    /// �����ʼ�����
    /// </summary>
    public class MaileSend
    {
        public bool SendMail(string mailto)
        {

            MailAddress from = new MailAddress("xyingqi123@163.com");
            MailAddress to = new MailAddress(mailto);
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = "��½֪ͨ";
            mail.Body = "���ѵ�½ϵͳ";
            SmtpClient mySmth = new SmtpClient();

            mySmth.Send(mail);
            mail.Dispose();
            return true;
        }
    }
}

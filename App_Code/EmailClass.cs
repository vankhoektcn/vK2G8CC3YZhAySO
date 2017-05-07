using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Text;
using System.IO;
public class EmailClass
{
    public static string Send_Email(string SendFrom, string SendTo, string Subject, string Body)
    {
        try
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");


            bool result = regex.IsMatch(SendTo);
            if (result == false)
            {
                return "Địa chỉ email không hợp lệ.";
            }
            else
            {
                System.Net.Mail.SmtpClient smtp = new SmtpClient();
                System.Net.Mail.MailMessage msg = new MailMessage(SendFrom, SendTo, Subject, Body);
                msg.IsBodyHtml = true;
                smtp.Host = "smtp.gmail.com";//Sử dụng SMTP của gmail
                smtp.Send(msg);
                return "Email đã được gửi đến: " + SendTo + ".";
            }
        }
        catch
        {
            return "";
        }
    }

    public static bool Send_Email_With_Attachment(string ten, string SendTo, string SendFrom, string Subject, string Body, string AttachmentPath)
    {
        try
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            string from = SendFrom;
            string to = SendTo;
            string subject = Subject;
            string body = Body;

            bool result = regex.IsMatch(to);
            if (result == false)
            {
                return false;
            }
            else
            {
                string host = System.Configuration.ConfigurationManager.AppSettings.Get("HostName");
                int port = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings.Get("Port"));
                string pass = System.Configuration.ConfigurationManager.AppSettings.Get("PwdEmail");
                string display = System.Configuration.ConfigurationManager.AppSettings.Get("EmailName");
                string email = System.Configuration.ConfigurationManager.AppSettings.Get("Email");
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Credentials = new System.Net.NetworkCredential(email, pass);
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                MailMessage mail = new MailMessage();

                try
                {
                    mail.From = new MailAddress(email, display, System.Text.Encoding.UTF8);
                    mail.To.Add(new MailAddress(to, "" + ten));
                    mail.Subject = Subject;
                    mail.Body = Body;
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;
                    if (AttachmentPath != "" && File.Exists(AttachmentPath))
                    {
                        Attachment att = new Attachment(AttachmentPath);
                        mail.Attachments.Add(att);
                    }
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    SmtpServer.Send(mail);
                    return true;
                }
                catch { return false; }


            }
        }
        catch
        {
            return false;
        }
    }
    public static bool Send_Email_With_CC_Attachment(string SendCC, string SendFrom, string Subject, string Body, string AttachmentPath)
    {
        try
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            string from = SendFrom;
            string subject = Subject;
            string body = Body;
            string cc = SendCC;

            string host = System.Configuration.ConfigurationManager.AppSettings.Get("HostName");
            int port = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings.Get("Port"));
            string pass = System.Configuration.ConfigurationManager.AppSettings.Get("PwdEmail");
            string display = System.Configuration.ConfigurationManager.AppSettings.Get("EmailName");
            string email = System.Configuration.ConfigurationManager.AppSettings.Get("Email");
            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Credentials = new System.Net.NetworkCredential(email, pass);
            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.EnableSsl = true;
            MailMessage mail = new MailMessage();
            try
            {
                bool result = true;
                String[] ALL_EMAILS = cc.Split(';');
                mail.From = new MailAddress(email, display, System.Text.Encoding.UTF8);
                foreach (string emailaddress in ALL_EMAILS)
                {
                    result = regex.IsMatch(emailaddress);
                    if (result == false)
                    {
                        mail.CC.Add(new MailAddress("" + emailaddress, "" + emailaddress));
                    }
                }
                mail.Subject = Subject;
                mail.Body = Body;
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                if (AttachmentPath != "" && File.Exists(AttachmentPath))
                {
                    Attachment att = new Attachment(AttachmentPath);
                    mail.Attachments.Add(att);
                }
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpServer.Send(mail);
                return true;
            }
            catch { return false; }


        }
        catch
        {
            return false;
        }
    }
    #region format datetime
    public static string DateTimeFormat(string date)
    {
        string valueretun = "";
        string[] txtmang = date.Split('/');
        string day = "";
        string month = "";
        for (int i = 0; i < txtmang.Length; i++)
        {
            if (i == 0)
                day = txtmang[i].ToString();
            if (i == 1)
                month = txtmang[i].ToString();
            else
                valueretun = month + "/" + day + "/" + txtmang[i].ToString();
        }
        return valueretun;
    }
    /// <summary>
    /// 10/13/2012 3:36:37 PM
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string FormatDateTime(string date)
    {

        return Convert.ToDateTime(date).ToString("dd/MM/yyyy");
       
    }
    #endregion
}
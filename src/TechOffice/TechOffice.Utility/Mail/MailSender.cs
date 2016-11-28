using System.Net.Mail;

namespace AnThinhPhat.Utilities.Mail
{
    public static class MailSender
    {
        public static void SendRegister(string email, string subject, string linkConfirm)
        {
            int port = TechOfficeConfig.PORT;
            string host = TechOfficeConfig.HOST;
            string from = TechOfficeConfig.FROM;
            string user = TechOfficeConfig.USERNAME;
            string pass = TechOfficeConfig.PASSWORD;

            SmtpMailSender.Email(host, email, "", subject, from, "Phong Noi Vu Huyen Phu Rieng", user, pass, null, linkConfirm, null, MailType.Register, MailPriority.High);
        }

        public static void SendFeedback(string email, string subject,string content, MailAttachment[] files)
        {
            int port = TechOfficeConfig.PORT;
            string host = TechOfficeConfig.HOST;
            string from = TechOfficeConfig.FROM;
            string user = TechOfficeConfig.USERNAME;
            string pass = TechOfficeConfig.PASSWORD;

            SmtpMailSender.Email(host, email, content, subject, from, "Phong Noi Vu Huyen Phu Rieng", user, pass, files, "", null, MailType.Feedback, MailPriority.Normal);
        }

        public static void SendRemind() { }

        public static void SendRecoverPassword(string email, string subject, string linkConfirm, string plainText)
        {
            int port = TechOfficeConfig.PORT;
            string host = TechOfficeConfig.HOST;
            string from = TechOfficeConfig.FROM;
            string user = TechOfficeConfig.USERNAME;
            string pass = TechOfficeConfig.PASSWORD;

            SmtpMailSender.Email(host, email, "", subject, from, "Phong Noi Vu Huyen Phu Rieng", user, pass, null, linkConfirm, plainText, MailType.RecoverPass, MailPriority.High);
        }

        public static void Send(string to, string subject, string body)
        {
            int port = TechOfficeConfig.PORT;
            string host = TechOfficeConfig.HOST;
            string from = TechOfficeConfig.FROM;
            string user = TechOfficeConfig.USERNAME;
            string pass = TechOfficeConfig.PASSWORD;
            SmtpMailSender.Email(host, to, body, subject, from, "Phong Noi Vu Huyen Phu Rieng", user, pass, null, null, null, MailType.Normal, MailPriority.Normal);
        }
    }
}

using System.Net;
using System.Net.Mail;
using System.Windows;

namespace PCConfig.Model.Access
{
    public class MailManager
    {
        private readonly EmailConfiguration _emailConfiguration;

        public MailManager()
        {
            ConfigurationManager manager = new();
            _emailConfiguration = manager.GetEmailConfiguration();
        }

        public int GenerateConfirmationCode()
        {
            Random random = new();
            int sixDigitNumber = random.Next(100000, 999999);

            return sixDigitNumber;
        }

        public bool SendConfirmationCodeToEmail(string email, int code)
        {
            string subject = "Код подтверждения";
            string body = $"Код подтверждения - {code}. Введите данный код в программе, для того чтобы зарегистрироваться";

            using SmtpClient smtpClient = new("smtp.mail.ru");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(_emailConfiguration.Address, _emailConfiguration.Password);
            smtpClient.EnableSsl = true;

            using MailMessage mailMessage = new(_emailConfiguration.Address, email, subject, body);
            mailMessage.IsBodyHtml = true;

            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отправления письма на почту: {ex.Message}");
                return false;
            }
        }
    }
}
using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

namespace HotShootFunction
{
    public class EmailSender
    {
        private static NetworkCredential _emailCredentials;
        private static SmtpClient _smtpServer;
        private static HttpClient _client = new HttpClient();

        public static async Task SendEmailOnOfferFound(string productName)
        {
            await SendMail($"Znaleziono {productName} w gorącym strzale",
                $"Znaleziono {productName} w gorącym strzale.\r\n Kup pod linkiem: https://www.al.to/goracy_strzal");
        }

        private static async Task SendMail(string title, string message)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("michal.checinski.powiadomienia@gmail.com");

            mail.To.Add(Environment.GetEnvironmentVariable("SendMailTo"));

            mail.Subject = title;
            mail.Body = message;

            if (_smtpServer == null)
            {
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                smtpServer.Port = 587;

                if (_emailCredentials == null)
                {
                    var azureServiceTokenProvider = new AzureServiceTokenProvider();
                    var kvClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback), _client);

                    var emailPassword = (await kvClient.GetSecretAsync(Environment.GetEnvironmentVariable("KeyVaultUri"), "notificationMailPassword")).Value;

                    _emailCredentials = new NetworkCredential("michal.checinski.powiadomienia@gmail.com", emailPassword);
                }

                smtpServer.Credentials = _emailCredentials;
                smtpServer.EnableSsl = true;

                _smtpServer = smtpServer;
            }

            _smtpServer.Send(mail);
        }
    }
}

using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public class MailService : IMailService
    {
        public async Task SendMailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Paluga4Students", "noreply@paluga.ch"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message };

            using (var client = new SmtpClient())
            {
                //client.LocalDomain = "some.domain.com";
                await client.ConnectAsync("mail.smtp2go.com", 2525, SecureSocketOptions.Auto).ConfigureAwait(false);

                if (client.Capabilities.HasFlag(SmtpCapabilities.Authentication))
                {
                    var mechanisms = string.Join(", ", client.AuthenticationMechanisms);

                    // Note: if we don't want MailKit to use a particular SASL mechanism, we can disable it like this:
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate("hmedgjonaj@gmail.com", "1RZsst5E5In9");
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }

                client.Disconnect(true);

               
            }
        }

        public async Task SignUpMail(string email, string token)
        {
            await SendMailAsync(email, "Verify you account", "Click the link below to verify your account <br>" +
                "<a href='http://localhost:54212/verify/" + token + "'>Click here</a>");
        }
    }
}

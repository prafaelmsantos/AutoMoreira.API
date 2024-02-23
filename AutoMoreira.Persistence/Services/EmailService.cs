namespace AutoMoreira.Persistence.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async Task SendEmailToUserAsync(string toName, string toAddress, string userName, string password)
        {
            try
            {
                var message = new MimeMessage();

                var userEmail = UserEmail(toName, userName, password);

                message.From.Add(new MailboxAddress(_emailSettings.Name, _emailSettings.Address));
                message.To.Add(new MailboxAddress(toName, toAddress));
                message.Subject = userEmail.Item1;
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = string.Format(userEmail.Item2)
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);

                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        public async Task SendEmailToClientAsync(string toName, string toAddress)
        {
            try
            {
                var message = new MimeMessage();

                var userEmail = ClientEmail(toName);

                message.From.Add(new MailboxAddress(_emailSettings.Name, _emailSettings.Address));
                message.To.Add(new MailboxAddress(toName, toAddress));
                message.Subject = userEmail.Item1;
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = string.Format(userEmail.Item2)
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);

                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        private static (string, string) UserEmail(string toName, string userName, string password)
        {
            string subject = "Auto Moreira: Registo de utilizador";
            string body = "<p style=\"text-align:center\"><img alt=\"\" src=\"https://auto-moreira-app.onrender.com/static/media/logo.9ebafe1ed9a8e5bc22b3.png\" style=\"height:80px; width:100px\" /></p>";
            body += $"<p style=\"text-align:center\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"font-size:11px\">Bem-vindo(a)&nbsp;<strong>{toName}</strong>. </span></span></p>";
            body += "<p style=\"text-align:center\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"font-size:11px\">Credenciais de acesso:</span></span></p>";
            body += $"<p style=\"text-align:center\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"font-size:12px\"><strong>Nome de Utilizador: </strong>{userName}</span></span></p>";
            body += $"<p style=\"text-align:center\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"font-size:12px\"><strong>Palavra-passe: </strong>{password}</span></span></p>";
            body += "<p style=\"text-align:center\">&nbsp;</p>";
            body += "<p style=\"text-align:center\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"font-size:11px\"><span style=\"color:#000000\">Atentamente,</span></span></span></p>";
            body += "<p style=\"text-align:center\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"font-size:11px\"><span style=\"color:#000000\"><strong>Equipa Auto Moreira</strong></span></span></span></p>";
            body += "<p style=\"text-align:center\">&nbsp;</p>";
            body += "<p style=\"text-align:center\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"font-size:12px\">📞 (+351) 231 472 555</span></span></p>";
            body += "<p style=\"text-align:center\">📧 <a href=\"mailto:automoreiraportugal@gmail.com\">automoreiraportugal@gmail.com</a></p>";
            body += "<p style=\"text-align:center\">🏎&nbsp;<a href=\"https://auto-moreira-app.onrender.com/\">autoMoreira</a></p>";
            body += "<h3 style=\"text-align:center\"><span style=\"font-size:9px\">2024 @AutoMoreira | Todos os Direitos Reservados.</span></h3>";

            return (subject, body);
        }

        private static (string, string) ClientEmail(string toName)
        {
            string subject = $"Auto Moreira: Recebemos a sua mensagem {toName}";
            string body = "<p style=\"text-align:center\"><img alt=\"\" src=\"https://auto-moreira-app.onrender.com/static/media/logo.9ebafe1ed9a8e5bc22b3.png\" style=\"height:80px; width:100px\" /></p>";
            body += $"<p style=\"text-align:center\"><span style=\"font-size:11px\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"color:#000000\">Estimado(a) <strong>{toName}</strong>,</span></span></span></p>";
            body += "<p style=\"text-align:center\"><span style=\"font-size:11px\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"color:#000000\">Agradecemos desde j&aacute; o interesse que manifestou em n&oacute;s, Auto Moreira.</span></span></span></p>";
            body += "<p style=\"text-align:center\"><span style=\"font-size:11px\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"color:#000000\">Recebemos a sua mensagem e entraremos&nbsp;em&nbsp;contacto&nbsp;consigo assim que poss&iacute;vel para esclarecer todas as suas quest&otilde;es.</span></span></span></p>";
            body += "<p style=\"text-align:center\"><span style=\"font-size:11px\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"color:#000000\">No caso de ter alguma quest&atilde;o que pretenda ver esclarecida no imediato, n&atilde;o hesite em contactar-nos, por chamada telef&oacute;nica ou em resposta a este e-mail.</span></span></span></p>";
            body += "<p style=\"text-align:center\">&nbsp;</p>";
            body += "<p style=\"text-align:center\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"font-size:11px\"><span style=\"color:#000000\">Atentamente,</span></span></span></p>";
            body += "<p style=\"text-align:center\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"font-size:11px\"><span style=\"color:#000000\"><strong>Equipa Auto Moreira</strong></span></span></span></p>";
            body += "<p style=\"text-align:center\">&nbsp;</p>";
            body += "<p style=\"text-align:center\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"font-size:12px\">📞 (+351) 231 472 555</span></span></p>";
            body += "<p style=\"text-align:center\">📧 <a href=\"mailto:automoreiraportugal@gmail.com\">automoreiraportugal@gmail.com</a></p>";
            body += "<p style=\"text-align:center\">🏎&nbsp;<a href=\"https://auto-moreira-app.onrender.com/\">autoMoreira</a></p>";
            body += "<h3 style=\"text-align:center\"><span style=\"font-size:9px\">2024 @AutoMoreira | Todos os Direitos Reservados.</span></h3>";

            return (subject, body);
        }

        private static string GenericEmail()
        {
            string body = "<p style=\"text-align:center\">&nbsp;</p>";
            body += "<p style=\"text-align:center\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"font-size:11px\"><span style=\"color:#000000\">Atentamente,</span></span></span></p>";
            body += "<p style=\"text-align:center\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"font-size:11px\"><span style=\"color:#000000\"><strong>Equipa Auto Moreira</strong></span></span></span></p>";
            body += "<p style=\"text-align:center\">&nbsp;</p>";
            body += "<p style=\"text-align:center\"><span style=\"font-family:Arial,Helvetica,sans-serif\"><span style=\"font-size:12px\">📞 (+351) 231 472 555</span></span></p>";
            body += "<p style=\"text-align:center\">📧 <a href=\"mailto:automoreiraportugal@gmail.com\">automoreiraportugal@gmail.com</a></p>";
            body += "<p style=\"text-align:center\">🏎&nbsp;<a href=\"https://auto-moreira-app.onrender.com/\">autoMoreira</a></p>";
            body += "<h3 style=\"text-align:center\"><span style=\"font-size:9px\">2024 @AutoMoreira | Todos os Direitos Reservados.</span></h3>";

            return body;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace AutomotiveSols.EmailServices
{
    public class AuthMessageSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("husnainakbar140@gmail.com");
                //From Address  
                string FromAddress = "husnainakbar140@gmail.com";
                string FromAddressPassword = "786516@hus";
                string FromAdressTitle = "Confirm Your Account";

                mail.To.Add(email);
             mail.Subject = "Microsoft ASP.NET Core";
                mail.IsBodyHtml = true;
                mail.Body = message;

                using (SmtpClient client = new SmtpClient("smtp.gmail.com",587))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(FromAddress, FromAddressPassword);
                    client.EnableSsl = true;
                    client.Send(mail);
                }

                ////To Address  
                //string ToAddress = email;
                //string ToAdressTitle = "Microsoft ASP.NET Core";
                //string Subject = subject;
                //string BodyContent = message;

                ////Smtp Server  
                //string SmtpServer = "smtp.gmail.com	";
                ////Smtp Port Number  
                //int SmtpPortNumber = 587;

                //var mimeMessage = new MimeMessage();
                //mimeMessage.From.Add(new MailboxAddress
                //                        (FromAdressTitle,
                //                         FromAddress
                //                         ));
                //mimeMessage.To.Add(new MailboxAddress
                //                         (ToAdressTitle,
                //                         ToAddress
                //                         ));
                //mimeMessage.Subject = Subject; //Subject
                //mimeMessage.Body = new TextPart("plain")
                //{
                //    Text = BodyContent
                //};

                //using (var client = new SmtpClient())
                //{
                //    client.Connect(SmtpServer, SmtpPortNumber, true);
                //    client.Authenticate(
                //        "husnainakbar140@gmail.com",
                //        "786516@hus"
                //        );
                //    await client.SendAsync(mimeMessage);
                //    Console.WriteLine("The mail has been sent successfully !!");
                //    Console.ReadLine();
                //    await client.DisconnectAsync(true);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
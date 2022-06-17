using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmailService
    {
        public static void SendEmail(string Email,string token,FundooContext fundoocontext)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("remapitesting963@gmail.com", "yvuplybisfmsdglo");

                var user = fundoocontext.User.FirstOrDefault(u => u.Email == Email);
                MailMessage msgObj=new MailMessage();
                msgObj.To.Add(Email);
                msgObj.From = new MailAddress("remapitesting963@gmail.com");
                msgObj.Subject = "Password Reset Link";
                msgObj.IsBodyHtml = true;
                msgObj.Body = "<!DOCTYPE html><html>" +
                    $"<h1 style=\"color:grey;font-size:100%\">Hello {user.FirstName} {user.LastName}</h1><br>"+"<h1 style=\"color:grey;font-size:80%\">click on the below link to recover Password</h1>" +
                     "</body>" +
                     $"www.fundooNotes.com/reset-password/{token}" +
                     "<body style=\"background-color:white;font-size:50%;text-align:left;\">" +
                     "<h1 style=\"color:grey;\">Regards fundoonotes</h1>" +

                    "</html>";


                client.Send(msgObj);
            }
        }
    }
}

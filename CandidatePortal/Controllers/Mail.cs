using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CandidatePortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
namespace CandidatePortal.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class Mail:ControllerBase
    {
        CandidatePortalContext db = new CandidatePortalContext();
        [HttpPost("SendEmail")]
        public static object SendEmail([FromForm] MailObject request)
        {

            try
            {
                string Message = request.Message;
                string Email = request.Email;
                // Credentials
                var credentials = new System.Net.NetworkCredential("17110332@student.hcmute.edu.vn", "QuietMy301020");

                // Mail message
                var mail = new System.Net.Mail.MailMessage()
                {
                    From = new MailAddress("17110332@student.hcmute.edu.vn"),
                    Subject = "Công ty LV",
                    Body = Message
                };

                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(Email));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };
                // client.UseDefaultCredentials = true;
                client.Send(mail);

                return new { 
                    mess= "Email Sent Successfully!"
                };
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

        }

        public static object SendEmailController(string Message, string Email)
        {

            try
            {
                // Credentials
                var credentials = new System.Net.NetworkCredential("17110332@student.hcmute.edu.vn", "QuietMy301020");

                // Mail message
                var mail = new System.Net.Mail.MailMessage()
                {
                    From = new MailAddress("17110332@student.hcmute.edu.vn"),
                    Subject = "Công ty LV",
                    Body = Message
                };

                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(Email));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };
                // client.UseDefaultCredentials = true;
                client.Send(mail);

                return new
                {
                    mess = "Email Sent Successfully!"
                };
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

        }
    }
}

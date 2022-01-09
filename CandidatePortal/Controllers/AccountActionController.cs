using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CandidatePortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Web;
using System.Net.Mail;
namespace CandidatePortal.Controllers
{

    [Microsoft.AspNetCore.Cors.EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountActionController : Controller
    {
        CandidatePortalContext db = new CandidatePortalContext();
        [HttpPost("RegistAccount")]
        public object RegistAccount([FromForm] NhmApplicant request)
        {
            try
            {
                var index = db.NhmApplicants.Count();
                var Applicant = new NhmApplicant();
                Applicant.Username = request.Username;
                Applicant.Password = request.Password;
                Applicant.Email = request.Email;
                Applicant.Mobile = request.Mobile;
                Applicant.LastName = request.LastName;
                Applicant.FirstName = request.FirstName;
                Applicant.TypeUser = 1;//1: ứng viên, 2: HR
                Applicant.ApplicantCode = "UV" + (index + 1).ToString();
                db.NhmApplicants.Add(Applicant);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public void SendEmailController(string Message, string Email)
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
        }
        [HttpPost("Login")]
        public object Login([FromForm] NhmApplicant request)
        {
            try
            {
                string username = request.Username;
                string password = Base64Decode(request.Password);
                var accountinfo = db.NhmApplicants.FirstOrDefault(n => n.Username == username && n.Password == password);
                if (accountinfo == null)
                    return 0;// sai tài khoản hoặc mật khẩu
                var logininfo = new NhmLogin();
                logininfo.LoginTime = DateTime.Now;
                logininfo.UserName = username;
                logininfo.SessionLogin = Base64Encode(accountinfo.ApplicantCode + "___+=()*" + username + "%$!" + password + "*@-" + (DateTime.Now).ToString()+"!@#$#@!"+accountinfo.TypeUser);
                db.NhmLogins.Add(logininfo);
                db.SaveChanges();
                return logininfo;
            }
            catch
            {
                return -1;
            }
        }
        [HttpGet("GetFullName/{ApplicantCode}")]
        public object GetFullName(string ApplicantCode)
        {
            string fullname = "";
            try
            {
                var applicant = db.NhmApplicants.FirstOrDefault(n => n.ApplicantCode == ApplicantCode);
                fullname = applicant.FirstName + " " + applicant.LastName;
                return fullname;
            }
            catch
            {
                return fullname;
            }
        }

        //đổi mật khẩu
        [HttpPost("ChangePassword")]
        public object ChangePassword([FromForm] AccountRequest request)
        {
            try
            {
                var obj = db.NhmApplicants.FirstOrDefault(n => n.Username == request.Username && n.Password == Base64Decode(request.Password));
                if(obj == null)
                {
                    return 0;
                }
                else
                {
                    obj.Password = Base64Decode(request.NewPassword);
                    db.NhmApplicants.Update(obj);

                    //thêm vào bảng change pass
                    var changepass = new NhmChangePassword();
                    changepass.UserName = request.Username;
                    changepass.PasswordOld = Base64Decode(request.Password);
                    changepass.PasswordNew = Base64Decode(request.NewPassword);
                    changepass.CreatedBy = request.Username;
                    changepass.CreatedOn = DateTime.Now;
                    db.NhmChangePasswords.Add(changepass);
                    db.SaveChanges();
                    return 1;
                }
            }
            catch
            {
                return -1;
            }
        }
        //quên mật khẩu
        [HttpPost("ForgotPassword")]
        public object ForgotPassword([FromForm] NhmApplicant request)
        {
            try
            {
                var obj = db.NhmApplicants.FirstOrDefault(n => n.Username==request.Username && n.Email==request.Email);
                if (obj == null)
                {
                    return new
                    {
                        err = "Email hoặc tài khoản không đúng"
                    };
                }
                else
                {
                    //thêm vào bảng change pass
                    var changepass = new NhmChangePassword();
                    changepass.UserName = request.Username;
                    changepass.PasswordOld = obj.Password;
                    changepass.PasswordNew = "123456"; // gen password
                    changepass.CreatedBy = request.Username;
                    changepass.CreatedOn = DateTime.Now;
                    db.NhmChangePasswords.Add(changepass);
                    obj.Password = changepass.PasswordNew;
                    db.SaveChanges();
                    SendEmailController("Xin chào "+ request.Username +" , Mật khẩu mới của bạn là: "+ changepass.PasswordNew, request.Email);
                    return 1;
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}

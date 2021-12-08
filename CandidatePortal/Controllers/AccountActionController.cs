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
                logininfo.SessionLogin = Base64Encode(accountinfo.LastName + " " + accountinfo.LastName + "___+=()*" + username + "%$!" + password + "*@-" + (DateTime.Now).ToString());
                db.NhmLogins.Add(logininfo);
                db.SaveChanges();
                return logininfo;
            }
            catch
            {
                return -1;
            }
        }
    }
}

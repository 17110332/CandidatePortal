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
using System.Globalization;

namespace CandidatePortal.Controllers
{

    [Microsoft.AspNetCore.Cors.EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : Controller
    {
        CandidatePortalContext db = new CandidatePortalContext();
        public static string SessionLoginStr;
        [HttpGet("GetApplicantByUserName/{sessionlogin}")]
        public object GetApplicantByUserName(string sessionlogin)
        {
            try
            {
                var logininfo = db.NhmLogins.FirstOrDefault(n => n.SessionLogin == sessionlogin);
                SessionLoginStr = sessionlogin;
                return db.ApplicantRequest.FromSqlRaw(@"select * from InfoApplicant where Username={0}", logininfo.UserName).ToList();
            }
            catch
            {
                return null;
            }


        }
        [HttpPost("SaveInfoPersonal")]
        public object SaveInfoPersonal([FromForm] BaseRequest request)
        {
            try
            {
                var applicant = db.NhmApplicants.FirstOrDefault(n => n.ApplicantCode == request.ApplicantCode);
                if (applicant != null)
                {
                    applicant.BirthDay = request.BirthDay;//DateTime.ParseExact(request.BirthDay, "dd/MM/yyyy", CultureInfo.InvariantCulture); 
                    applicant.DistrictCode = request.DistrictCode;
                    applicant.Email = request.Email;
                    applicant.FirstName = request.FirstName;
                    applicant.LastName = request.LastName;
                    applicant.Mobile = request.Mobile;
                    applicant.ModifiedBy = request.ApplicantCode;
                    applicant.ModifiedOn = DateTime.Now;
                    applicant.ProvinceCode = request.ProvinceCode;
                    applicant.StreetName = request.StreetName;
                    applicant.WardCode = request.WardCode;
                    db.SaveChanges();
                    string strupdatePersonal = @"update NhmApplicantsInfoPersonal set Gender = {1},Married={2},TitleDoc={3},IntroduceYourself={4},Level={5},School={6},Graduated={7},Exp={8},
                    WorkProgress={9},Skill={10},SkillOther={11} where ApplicantCode={0}";

                    db.Database.ExecuteSqlRaw(strupdatePersonal, request.ApplicantCode, request.Gender, request.Married, request.TitleDoc, request.IntroduceYourself,
                    request.Level, request.School, request.Graduated, request.Exp, request.WorkProgress, request.Skill, request.SkillOther);
                    return 1;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }


        [HttpPost("UploadFile")]
        public object UploadFile([FromForm] FileRequest request)
        {
            var username = db.NhmLogins.FirstOrDefault(n => n.SessionLogin == SessionLoginStr);
            if (username != null)
            {
                var base64str = request.FileBase64;
                var applicant = db.NhmApplicants.FirstOrDefault(n => n.Username == username.UserName);
                db.Database.ExecuteSqlRaw("exec NHM_SPUpdateInfoPersonal {0},{1},{2},{3}", applicant.ApplicantCode, base64str,request.Options,request.FileName);
                return 1;
            }
            return 0;

        }
    }
}

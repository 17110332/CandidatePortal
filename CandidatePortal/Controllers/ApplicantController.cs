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
        [HttpGet("GetApplicantByUserName/{sessionlogin}")]
        public object GetApplicantByUserName(string sessionlogin)
        {
            //try
            //{
            //    var logininfo = db.NhmLogins.FirstOrDefault(n => n.SessionLogin == sessionlogin);
            //    return db.ApplicantRequest.FromSqlRaw(@"select * from InfoApplicant where Username={0}", logininfo.UserName).ToList();
            //}
            //catch
            //{
            //    return null;
            //}
            var logininfo = db.NhmLogins.FirstOrDefault(n => n.SessionLogin == sessionlogin);
            return db.ApplicantRequest.FromSqlRaw(@"select * from InfoApplicant where Username={0}", logininfo.UserName).ToList();

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
                    request.Level, request.School, request.Graduated, request.Exp, request.WorkProgress, request.Skill, request.SkillOther, request.Avatar, request.CVApplicant);
                    return 1;
                    //return db.ApplicantPersonalRequest.FromSqlRaw(@"exec NHM_UpdatePersonal {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", 
                    //    request.ApplicantCode, request.Gender, request.Married, request.TitleDoc, request.IntroduceYourself,
                    //     request.Level, request.School, request.Graduated, request.Exp, request.WorkProgress, request.Skill, request.SkillOther, request.Avatar, request.CVApplicant);

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
            //try
            //{
            //    var base64str = request.FileBase64;
            //    return base64str;
            //}
            //catch
            //{
            //    return "";
            //}
          
         //   var base64str = request.FileBase64;
        //    byte[] newBytes = Convert.FromBase64String(base64str);//new System.Data.Linq.Binary(newBytes);

            return 1;

        }

        //[HttpPost("UploadFile/{requestBase64Str}")]
        //public object UploadFile(string requestBase64Str)
        //{
        //    var base64str = requestBase64Str;
        //    return base64str;
        //}
    }
}

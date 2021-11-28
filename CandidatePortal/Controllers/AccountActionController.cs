using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}

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
    public class CountryController : Controller
    {
        CandidatePortalContext db = new CandidatePortalContext();
        [HttpGet("GetProvinces")]
        public IEnumerable<NhmProvince> GetProvinces()
        {
            try
            {
                return db.NhmProvinces.ToList();
            }
            catch
            {
                return null;
            }
        }

        [HttpGet("GetDistrict/{provincecode}")]
        public IEnumerable<NhmDistrict> GetDistrict(string provincecode)
        {
            try
            {
                return db.NhmDistricts.Where(n => n.ProvinceCode == provincecode).ToList();
            }
            catch
            {
                return null;
            }
           
        }

        [HttpGet("GetWards/{districtcode}")]
        public IEnumerable<NhmWard> GetWards(string districtcode)
        {
            try
            {
                return db.NhmWards.Where(n => n.DistrictCode == districtcode).ToList();
            }
            catch
            {
                return null;
            }
           
        }
    }
}

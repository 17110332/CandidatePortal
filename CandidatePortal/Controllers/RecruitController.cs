using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CandidatePortal.Models;
using  Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace CandidatePortal.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitController : ControllerBase
    {
        CandidatePortalContext db = new CandidatePortalContext();
        [HttpPost("GetRecruitsByUserID")]
        public object GetRecruitsByUserID([FromForm] ParamsRequest param) //[FromForm]Products product
        {
            try
            {
                var PageSize = new SqlParameter
                {
                    ParameterName = "PageSize",
                    DbType = System.Data.DbType.Int32,
                    Direction = System.Data.ParameterDirection.Output
                };
                var TotalPage = new SqlParameter
                {
                    ParameterName = "TotalPage",
                    DbType = System.Data.DbType.Int32,
                    Direction = System.Data.ParameterDirection.Output
                };
                //     db.Database.ExecuteSqlRaw(@"exec NHM_GetRecruits {0},{1},{2},{3} OUT,{4} OUT", "vn", Condition, param.PageIndex, PageSize, TotalPage);
                return new
                {
                    lstJob = db.NhmRecruitRequest.FromSqlRaw(@"exec NHM_GetRecruitsByUserID {0},{1} OUT,{2} OUT,{3}",  param.PageIndex, PageSize, TotalPage, param.ApplicantCode).ToList(),
                    PageSize = PageSize.Value.ToString(),
                    TotalPage = TotalPage.Value.ToString()
                };
            }
            catch
            {
                return null;
            }
           
        }
      
    }
}

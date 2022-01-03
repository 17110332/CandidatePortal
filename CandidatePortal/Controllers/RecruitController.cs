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
                    lstJob = db.NhmRecruitRequest.FromSqlRaw(@"exec NHM_GetRecruitsByUserID {0},{1} OUT,{2} OUT,{3}", param.PageIndex, PageSize, TotalPage, param.ApplicantCode).ToList(),
                    PageSize = PageSize.Value.ToString(),
                    TotalPage = TotalPage.Value.ToString()
                };
            }
            catch
            {
                return null;
            }

        }

        [HttpGet("GetRecruitDetail/{RecruitID:int}")]
        public object GetRecruitDetail(int RecruitID)
        {
            try
            {
                return db.NhmRecruitDetailRequest.FromSqlRaw(@"exec Nhm_GetDetailRecruitForHr {0}", RecruitID).ToList();
            }
            catch
            {
                return null;
            }
        }
        [HttpGet("GetSalary/{JobWCode}")]
        public object GetSalary(string JobWCode)
        {
            try
            {
                return db.NhmJobWorkings.FirstOrDefault(n => n.JobWCode == JobWCode);
            }
            catch
            {
                return null;
            }
        }
        [HttpPost("SaveRecruit")]
        public object SaveRecruit([FromForm] NhmRecruitDetailRequestHR RecruitRequest)
        {
            
            try
            {
                string sql = @"Exec Nhm_SpInsertOrUpdateRecruit {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}";
                return db.Database.ExecuteSqlRaw(sql, RecruitRequest.RecruitID, RecruitRequest.TypeJobWCode, RecruitRequest.DepartmentCode, RecruitRequest.JobWCode, RecruitRequest.Quantity, RecruitRequest.FromDate, RecruitRequest.ToDate
                    , RecruitRequest.IsActive, RecruitRequest.Photo, RecruitRequest.CreatedBy, RecruitRequest.Jobdescription, RecruitRequest.Benefits, RecruitRequest.Required, RecruitRequest.Language, RecruitRequest.Exp);
            }
            catch
            {
                return -1;
            }
        }

        [HttpGet("DeleteRecruit/{RecruitID:int}")]
        public object DeleteRecruit(int RecruitID)
        {
            try
            {
                return db.Database.ExecuteSqlRaw(@"DELETE from NhmRecruits where RecruitID={0}", RecruitID);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet("GetCandidate/{ApplicantCode}")]
        public object GetCandidate(string ApplicantCode)
        {
            return db.ApplicantRequestHR.FromSqlRaw(@"exec Nhm_SpGetCandidateByUserID {0}", ApplicantCode).ToList();
            //try
            //{
            //    return db.ApplicantRequestHR.FromSqlRaw(@"exec Nhm_SpGetCandidateByUserID {0}", ApplicantCode).ToList();
            //}
            //catch
            //{
            //    return null;
            //}
        }
    }
}

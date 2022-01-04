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
            // return db.ApplicantRequestHR.FromSqlRaw(@"exec Nhm_SpGetCandidateByUserID {0}", ApplicantCode).ToList();
            try
            {
                return db.ApplicantRequestHR.FromSqlRaw(@"exec Nhm_SpGetCandidateByUserID {0}", ApplicantCode).ToList();
            }
            catch
            {
                return null;
            }
        }
        [HttpGet("GetCandidateTMP/{ApplicantCode}")]
        public object GetCandidateTMP(string ApplicantCode)
        {
            // return db.ApplicantRequestHR.FromSqlRaw(@"exec Nhm_SpGetCandidateByUserID {0}", ApplicantCode).ToList();
            try
            {
                return db.ApplicantRequestHR.FromSqlRaw(@"exec Nhm_SpGetCandidateTMPByUserID {0}", ApplicantCode).ToList();
            }
            catch
            {
                return null;
            }
        }
        [HttpPost("UpdateStatus/{ApplicantCodeLogin}")]
        public object UpdateStatus([FromForm] NhmRecruitsTMPWithUserID request,string ApplicantCodeLogin)
        {

            try
            {
                string ApplicantCode = request.ApplicantCode.Split("_",StringSplitOptions.None)[0];
                int statusupdate = request.Status;
                if(request.ApplicantCode.Split("_", StringSplitOptions.None)[1]== "updatestatus")
                {
                    statusupdate = statusupdate + 1;
                }
                else if(request.ApplicantCode.Split("_", StringSplitOptions.None)[1] == "quaylai")
                {
                    if (request.Status==5) // từ chối nhận việc => bước pass pv
                    {
                        statusupdate = 3;
                    }
                    else if(request.Status == 6) // rót pv => bước pv
                    {
                        statusupdate = 2;
                    }
                    else // các th còn lại => lùi 1
                    {
                        statusupdate = statusupdate - 1;
                    }                }
                else if (request.ApplicantCode.Split("_", StringSplitOptions.None)[1] == "rot")
                {
                    statusupdate = 6;
                }
                else if (request.ApplicantCode.Split("_", StringSplitOptions.None)[1] == "khonglamviec")
                {
                    statusupdate = 5;
                }
                string sql = @"update NhmRecruitsTMPWithUserID set Status={0} where ApplicantCode={1} and RecruitID={2} and Status={3}";
                return new
                {
                    update = db.Database.ExecuteSqlRaw(sql, statusupdate, ApplicantCode, request.RecruitID, request.Status),
                    respond = db.ApplicantRequestHR.FromSqlRaw(@"exec Nhm_SpGetCandidateByUserID {0}", ApplicantCodeLogin).ToList()
                };
            }
            catch
            {
                return -1;
            }
        }
        [HttpPost("SaveApplicantTMP/{ApplicantCodeLogin}")]
        public object SaveApplicantTMP([FromForm] NhmRecruitsTMPWithUserID request, string ApplicantCodeLogin)
        {
            try
            {
                return db.Database.ExecuteSqlRaw("insert into Nhm_ApplicantSaveTMP(ApplicantCode,CreatedBy) values ({0},{1})",request.ApplicantCode,ApplicantCodeLogin);
            }
            catch
            {
                return null;
            }
        }
        [HttpPost("DeleteApplicant/{ApplicantCodeLogin}")]
        public object DeleteApplicant([FromForm] NhmRecruitsTMPWithUserID request, string ApplicantCodeLogin)
        {
            try
            {
                return new
                {
                    delete = db.Database.ExecuteSqlRaw("Delete from NhmRecruitsTMPWithUserID where ApplicantCode={0} and RecruitID={1} and Status={2}", 
                                                        request.ApplicantCode, request.RecruitID, request.Status),
                    respond = db.ApplicantRequestHR.FromSqlRaw(@"exec Nhm_SpGetCandidateByUserID {0}", ApplicantCodeLogin).ToList()
                };
            }
            catch
            {
                return null;
            }
        }
        [HttpPost("DeleteApplicantTMP/{ApplicantCodeLogin}")]
        public object DeleteApplicantTMP([FromForm] NhmRecruitsTMPWithUserID request, string ApplicantCodeLogin)
        {
            try
            {
                return new
                {
                    delete = db.Database.ExecuteSqlRaw("Delete from Nhm_ApplicantSaveTMP where ApplicantCode={0} and CreatedBy={1}",
                                                        request.ApplicantCode, ApplicantCodeLogin),
                    respond = db.ApplicantRequestHR.FromSqlRaw(@"exec Nhm_SpGetCandidateTMPByUserID {0}", ApplicantCodeLogin).ToList()
                };
            }
            catch
            {
                return null;
            }
        }
    }
}

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
    public class Home : ControllerBase
    {
        CandidatePortalContext db = new CandidatePortalContext();
        [HttpPost("GetJobRecruits/{Condition}")]
        public object GetJobRecruits(string Condition, [FromForm] ParamsRequest param) //[FromForm]Products product
        {
            //try
            //{
            //    return db.NhmRecruitRequest.FromSqlRaw(@"exec NHM_GetRecruits {0},{1},{2},{3},{4}", "vn", 
            //        Condition,param.PageIndex, param.PageSize,param.TotalPage).ToList();
            //}
            //catch
            //{
            //    return null;
            //}
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
                    lstJob = db.NhmRecruitRequest.FromSqlRaw(@"exec NHM_GetRecruits {0},{1},{2},{3} OUT,{4} OUT,{5}", "vn",
                       Condition, param.PageIndex, PageSize, TotalPage, param.ApplicantCode).ToList(),
                    PageSize = PageSize.Value.ToString(),
                    TotalPage = TotalPage.Value.ToString()
                };
            }
            catch
            {
                return null;
            }
           
        }
        [HttpGet("GetTypeJobW")]
        public IEnumerable<object> GetTypeJobW()
        {
            try
            {
                return db.NhmTypeJobWorkingRequest.FromSqlRaw(@"exec GetTypeJobW {0} ", "vn").ToList();
            }
            catch 
            {
                return null;
            }
        }

        [HttpGet("GetJobW")]
        public IEnumerable<object> GetJobW()
        {
            try
            {
                return db.NhmJobWorkingRequest.FromSqlRaw(@"exec GetJobW {0}", "vn").ToList();
            }
            catch
            {
                return null;
            }
        }

        [HttpGet("GetProvince")]
        public IEnumerable<object> GetProvince()
        {
            try
            {
                return db.NhmProvinceRequest.FromSqlRaw(@"exec GetProvinces").ToList();
            }
            catch
            {
                return null;
            }
        }


        [HttpGet("GetRecruitDetail/{RecruitID:int}")]
        public object GetRecruitDetail(int RecruitID)
        {
            // return db.NhmRecruitDetailRequest.FromSqlRaw(@"exec Nhm_GetDetailRecruit {0}", RecruitID).ToList();
            try
            {
                return db.NhmRecruitDetailRequest.FromSqlRaw(@"exec Nhm_GetDetailRecruit {0}", RecruitID).ToList();
            }
            catch
            {
                return null;
            }
        }

        //trang chi tiết
        [HttpGet("GetLanguage/{RecruitID:int}")]
        public IEnumerable<object> GetLanguage(int RecruitID)
        {
            try
            {
                return db.Language.FromSqlRaw(@"exec GetLanguage {0}", RecruitID).ToList();
            }
            catch
            {
                return null;
            }
        }

        [HttpGet("GetTop5JobRecruit")]
        public IEnumerable<object> GetTop5JobRecruit(int RecruitID)
        {
            try
            {
                return db.NhmRecruitRequest.FromSqlRaw(@"exec NHM_GetRecruitsTop5").ToList();
            }
            catch
            {
                return null;
            }
        }
        [HttpGet("GetTop18JobRecruit")]
        public IEnumerable<object> GetTop18JobRecruit()
        {
            //try
            //{
            //    return db.NhmRecruitRequest.FromSqlRaw(@"exec NHM_GetRecruitsNewestInTwoWeek").ToList();
            //}
            //catch
            //{
            //    return null;
            //}
            return db.NhmRecruitRequest.FromSqlRaw(@"exec NHM_GetRecruitsNewestInTwoWeek").ToList();
        }
        [HttpPost("onLike")]
        public object onLike([FromForm] NhmRecruitsTMPWithUserID param)
        {
            try
            {
                var datacheck = db.NhmRecruitsTMPWithUserID.FromSqlRaw("select top(1) 1 as SL from NhmRecruitsTMPWithUserID where ApplicantCode={0} and RecruitID={1}", param.ApplicantCode, param.RecruitID);
                if (datacheck.Count() > 0) // đã có rồi => đang like thì xóa đi
                {
                    return new
                    {
                        delete = db.Database.ExecuteSqlRaw(@"delete from NhmRecruitsTMPWithUserID where ApplicantCode = {0} and RecruitID={1}", param.ApplicantCode, param.RecruitID),
                        type = "delete"
                    };
                }
                else // chưa có=> chưa like thì like (thêm vào db)
                {
                    return new
                    {
                        insert = db.Database.ExecuteSqlRaw(@"insert into NhmRecruitsTMPWithUserID(ApplicantCode,RecruitID,Islike,Status) values ({0},{1},{2},{3})", param.ApplicantCode, param.RecruitID, true, 0),
                        type = "insert"
                    };

                }
            }
            catch
            {
                return null;
            }
          
        }

        [HttpPost("onApply")]
        public object onApply([FromForm] NhmRecruitsTMPWithUserID param)
        {
            try
            {
                var datacheck = db.NhmRecruitsTMPWithUserID.FromSqlRaw("select top(1) 1 as SL from NhmRecruitsTMPWithUserID where ApplicantCode={0} and Status in (1,4)", 
                    param.ApplicantCode, param.RecruitID);
                if (datacheck.Count() > 0) //đã là nv, hoặc đang trogn quy trình ứng tuyển 1 việc khác
                {
                    //cảnh báo đã là nv, hoặc đang trogn quy trình ứng tuyển 1 việc khác, ko dc apply việc này
                    return new {
                        error ="Đã là là nhân viên chính thức, hoặc đang trong quy trình ứng tuyển 1 việc khác. Bạn không thể ứng tuyển việc này!"
                    };
                }
                else // chưa có=> chưa like thì like (thêm vào db)
                {
                    //them vào db và báo thành công
                    return new
                    {
                        insert = db.Database.ExecuteSqlRaw(@"insert into NhmRecruitsTMPWithUserID(ApplicantCode,RecruitID,Islike,Status) values ({0},{1},{2},{3})", param.ApplicantCode, param.RecruitID, false, 1),
                        success = "Ứng tuyển thành công"
                    };
                }
            }
            catch
            {
                return null;
            }

        }
    }
}

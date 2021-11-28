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
            db.Database.ExecuteSqlRaw(@"exec NHM_GetRecruits {0},{1},{2},{3} OUT,{4} OUT", "vn", Condition, param.PageIndex, PageSize, TotalPage);
            return new
            {
                lstJob = db.NhmRecruitRequest.FromSqlRaw(@"exec NHM_GetRecruits {0},{1},{2},{3} OUT,{4} OUT", "vn",
                   Condition, param.PageIndex, PageSize, TotalPage).ToList(),
                PageSize = PageSize.Value.ToString(),
                TotalPage = TotalPage.Value.ToString()
            };
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
    }
}

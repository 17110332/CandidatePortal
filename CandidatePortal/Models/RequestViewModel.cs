using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatePortal.Models
{
    public class RequestViewModel
    {
        [Key]
        public Guid RecID { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDCardNo { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }
        public string ProvinceCode { get; set; }
        public string DistrictCode { get; set; }
        public string WardCode { get; set; }
        public string StreetName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? TypeUser { get; set; }
        public int? PhotoID { get; set; }
        public string DistrictName { get; set; }
        public string DistrictName2 { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentName2 { get; set; }
        public string LocationCode { get; set; }
        public int CVFileID { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public byte[] CVFile { get; set; }
        public string Language { get; set; }
        public string ComboboxName { get; set; }
        public string TableName { get; set; }
        [Required]
        public string ApplicantCode { get; set; }
     
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int ID { get; set; }
        public int? RecruitID { get; set; }
        public DateTime? ApplyDate { get; set; }
        public int? ApplyStatus { get; set; }

        public string JobWCode { get; set; }
        public string JobWName { get; set; }
        public string JobWName2 { get; set; }
        public string RealSalary { get; set; }
        public string FromSalary { get; set; }
        public string ToSalary { get; set; }
        public bool? IsAgree { get; set; }
        public string UserName { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public string SessionLogin { get; set; }
        public byte[] Photo { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceName2 { get; set; }
    
        public string TypeJobWCode { get; set; }
     
        public int? Quantity { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? IsActive { get; set; }
        public string TypeJobWName { get; set; }
        public string TypeJobWName2 { get; set; }
        public string ListName { get; set; }
        public string Caption { get; set; }
        public string WardName { get; set; }
        public string WardName2 { get; set; }

    }
}

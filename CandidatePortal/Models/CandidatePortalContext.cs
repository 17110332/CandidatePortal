using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class CandidatePortalContext : DbContext
    {
        public CandidatePortalContext()
        {
        }

        public CandidatePortalContext(DbContextOptions<CandidatePortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NhmApplicant> NhmApplicants { get; set; }
        public virtual DbSet<NhmCandidate> NhmCandidates { get; set; }
        public virtual DbSet<NhmChangePassword> NhmChangePasswords { get; set; }
        public virtual DbSet<NhmComboboxList> NhmComboboxLists { get; set; }
        public virtual DbSet<NhmCvfile> NhmCvfiles { get; set; }
        public virtual DbSet<NhmDepartment> NhmDepartments { get; set; }
        public virtual DbSet<NhmDistrict> NhmDistricts { get; set; }
        public virtual DbSet<NhmEmployee> NhmEmployees { get; set; }
        public virtual DbSet<NhmJobWorking> NhmJobWorkings { get; set; }
        public virtual DbSet<NhmLogin> NhmLogins { get; set; }
        public virtual DbSet<NhmPhoto> NhmPhotos { get; set; }
        public virtual DbSet<NhmProvince> NhmProvinces { get; set; }
        public virtual DbSet<NhmRecruit> NhmRecruits { get; set; }
        public virtual DbSet<NhmTypeJobWorking> NhmTypeJobWorkings { get; set; } 
        public virtual DbSet<NhmProvinceRequest> NhmProvinceRequest { get; set; }
        public virtual DbSet<NhmValueList> NhmValueLists { get; set; }
        public virtual DbSet<NhmWard> NhmWards { get; set; }
        public virtual DbSet<RequestViewModel> RequestViewModel { get; set; }


        public virtual DbSet<NhmApplicant> NhmApplicantsRequest { get; set; }
        public virtual DbSet<NhmCandidate> NhmCandidatesRequest { get; set; }
        public virtual DbSet<NhmChangePassword> NhmChangePasswordsRequest { get; set; }
        public virtual DbSet<NhmComboboxList> NhmComboboxListsRequest { get; set; }
        public virtual DbSet<NhmCvfile> NhmCvfilesRequest { get; set; }
        public virtual DbSet<NhmDepartmentRequest> NhmDepartmentsRequest { get; set; }
        public virtual DbSet<NhmDistrict> NhmDistrictsRequest { get; set; }
        public virtual DbSet<NhmEmployee> NhmEmployeesRequest { get; set; }
        public virtual DbSet<NhmJobWorkingRequest> NhmJobWorkingRequest { get; set; }
        public virtual DbSet<NhmRecruitDetailRequest> NhmRecruitDetailRequest { get; set; }
        public virtual DbSet<NhmRecruitDetailRequestHR> NhmRecruitDetailRequestHR { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<NhmAccountRequest> NhmAccountRequest { get; set; }
        public virtual DbSet<NhmLoginRequest> NhmLoginsRequest { get; set; }
        public virtual DbSet<NhmPhoto> NhmPhotosRequest { get; set; }
        public virtual DbSet<NhmProvince> NhmProvincesRequest { get; set; }
        public virtual DbSet<NhmRecruitRequest> NhmRecruitRequest { get; set; }
        public virtual DbSet<NhmRecruitRequestHR> NhmRecruitRequestHR { get; set; }
        public virtual DbSet<NhmTypeJobWorkingRequest> NhmTypeJobWorkingRequest { get; set; }
        public virtual DbSet<NhmValueList> NhmValueListsRequest { get; set; }
        public virtual DbSet<NhmWard> NhmWardsRequest { get; set; }

        public virtual DbSet<ApplicantRequest> ApplicantRequest { get; set; }
        public virtual DbSet<ApplicantRequestHR> ApplicantRequestHR { get; set; }
        public virtual DbSet<BaseRequest> BaseRequest { get; set; }

        public virtual DbSet<ApplicantPersonalRequest> ApplicantPersonalRequest { get; set; }
        public virtual DbSet<FileRequest> FileRequest { get; set; }
        public virtual DbSet<FileStringBase64> FileStringBase64 { get; set; }
        public virtual DbSet<NhmRecruitsTMPWithUserID> NhmRecruitsTMPWithUserID { get; set; }
        public virtual DbSet<CountRequest> CountRequest { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-QD046B1\\HUYENMY;Database=CandidatePortal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ApplicantRequestHR>()
             .HasKey(p => new { p.ApplicantCode, p.RecruitID,p.Status });

            modelBuilder.Entity<NhmApplicant>(entity =>
            {
                entity.HasKey(e => e.ApplicantCode)
                    .HasName("PK__NHM_Appl__FB2697AB3EF4E19D");

                entity.ToTable("NhmApplicants");

                entity.Property(e => e.ApplicantCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDay);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CVFileID).HasColumnName("CVFileID");

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(true);

                entity.Property(e => e.IDCardNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IDCardNo");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(true);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoID).HasColumnName("PhotoID");

                entity.Property(e => e.ProvinceCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName).IsUnicode(true);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WardCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CVFile)
                    .WithMany(p => p.NhmApplicants)
                    .HasForeignKey(d => d.CVFileID)
                    .HasConstraintName("FK__NHM_Appli__CVFil__32E0915F");

                entity.HasOne(d => d.DistrictCodeNavigation)
                    .WithMany(p => p.NhmApplicants)
                    .HasForeignKey(d => d.DistrictCode)
                    .HasConstraintName("FK__NHM_Appli__Distr__300424B4");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.NhmApplicants)
                    .HasForeignKey(d => d.PhotoID)
                    .HasConstraintName("FK__NHM_Appli__Photo__31EC6D26");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.NhmApplicants)
                    .HasForeignKey(d => d.ProvinceCode)
                    .HasConstraintName("FK__NHM_Appli__Provi__2F10007B");

                entity.HasOne(d => d.WardCodeNavigation)
                    .WithMany(p => p.NhmApplicants)
                    .HasForeignKey(d => d.WardCode)
                    .HasConstraintName("FK__NHM_Appli__WardC__30F848ED");
            });

            modelBuilder.Entity<NhmCandidate>(entity =>
            {
                entity.ToTable("NHM_Candidate");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.ApplicantCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApplyDate).HasColumnType("datetime");

                entity.Property(e => e.RecruitID).HasColumnName("RecruitID");

                entity.Property(e => e.Salary)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApplicantCodeNavigation)
                    .WithMany(p => p.NhmCandidates)
                    .HasForeignKey(d => d.ApplicantCode)
                    .HasConstraintName("FK__NHM_Candi__Appli__47DBAE45");

                entity.HasOne(d => d.Recruit)
                    .WithMany(p => p.NhmCandidates)
                    .HasForeignKey(d => d.RecruitID)
                    .HasConstraintName("FK__NHM_Candi__Recru__48CFD27E");
            });

            modelBuilder.Entity<NhmChangePassword>(entity =>
            {
                entity.ToTable("NHM_ChangePassword");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.PasswordNew)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordOld)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NhmComboboxList>(entity =>
            {
                entity.HasKey(e => new { e.Language, e.ComboboxName })
                    .HasName("PK__NHM_Comb__B0AAE293E85E3376");

                entity.ToTable("NHM_ComboboxList");

                entity.Property(e => e.Language)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ComboboxName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NhmCvfile>(entity =>
            {
                entity.HasKey(e => e.CVFileID)
                    .HasName("PK__NHM_CVFi__EF0219D83B643D0C");

                entity.ToTable("NHM_CVFiles");

                entity.Property(e => e.CVFileID).HasColumnName("CVFileID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CVFile).HasColumnName("CVFile");

                entity.Property(e => e.FileName).IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NhmDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentCode)
                    .HasName("PK__NHM_Depa__6EA8896C338F4EA6");

                entity.ToTable("NHM_Departments");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName2)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LocationCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.LocationCodeNavigation)
                    .WithMany(p => p.NhmDepartments)
                    .HasForeignKey(d => d.LocationCode)
                    .HasConstraintName("FK__NHM_Depar__Locat__35BCFE0A");
            });

            modelBuilder.Entity<NhmDistrict>(entity =>
            {
                entity.HasKey(e => e.DistrictCode)
                    .HasName("PK__NHM_Dist__3D4E86AA2A4EA4B7");

                entity.ToTable("NhmDistricts");

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictName2)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.NhmDistricts)
                    .HasForeignKey(d => d.ProvinceCode)
                    .HasConstraintName("FK__NHM_Distr__Provi__29572725");
            });

            modelBuilder.Entity<NhmEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeCode)
                    .HasName("PK__NHM_Empl__1F642549CEDDCDB2");

                entity.ToTable("NHM_Employees");

                entity.Property(e => e.EmployeeCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IDCardNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IDCardNo");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoID).HasColumnName("PhotoID");

                entity.Property(e => e.ProvinceCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName).IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WardCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.DistrictCodeNavigation)
                    .WithMany(p => p.NhmEmployees)
                    .HasForeignKey(d => d.DistrictCode)
                    .HasConstraintName("FK__NHM_Emplo__Distr__4316F928");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.NhmEmployees)
                    .HasForeignKey(d => d.PhotoID)
                    .HasConstraintName("FK__NHM_Emplo__Photo__44FF419A");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.NhmEmployees)
                    .HasForeignKey(d => d.ProvinceCode)
                    .HasConstraintName("FK__NHM_Emplo__Provi__4222D4EF");

                entity.HasOne(d => d.WardCodeNavigation)
                    .WithMany(p => p.NhmEmployees)
                    .HasForeignKey(d => d.WardCode)
                    .HasConstraintName("FK__NHM_Emplo__WardC__440B1D61");
            });

            modelBuilder.Entity<NhmJobWorking>(entity =>
            {
                entity.HasKey(e => e.JobWCode)
                    .HasName("PK__NHM_JobW__D338E992B2F64AC8");

                entity.ToTable("NhmJobWorkings");

                entity.Property(e => e.JobWCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JobWCode");

                entity.Property(e => e.FromSalary)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.JobWName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("JobWName");

                entity.Property(e => e.JobWName2)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("JobWName2");

                entity.Property(e => e.RealSalary)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ToSalary)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NhmLogin>(entity =>
            {
                entity.ToTable("NhmLogins");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.LoginTime).HasColumnType("datetime");

                entity.Property(e => e.LogoutTime).HasColumnType("datetime");

                entity.Property(e => e.SessionLogin).IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NhmPhoto>(entity =>
            {
                entity.HasKey(e => e.PhotoID)
                    .HasName("PK__NHM_Phot__21B7B5821748B20C");

                entity.ToTable("NHM_Photos");

                entity.Property(e => e.PhotoID).HasColumnName("PhotoID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FileName).IsUnicode(false);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.Size)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NhmProvince>(entity =>
            {
                entity.HasKey(e => e.ProvinceCode)
                    .HasName("PK__NHM_Prov__11D9FAD4B8AB34AC");

                entity.ToTable("NhmProvinces");

                entity.Property(e => e.ProvinceCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceName2)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NhmRecruit>(entity =>
            {
                entity.HasKey(e => e.RecruitID)
                    .HasName("PK__NHM_Recr__6203B6BFB707FB23");

                entity.ToTable("NHM_Recruits");

                entity.Property(e => e.RecruitID).HasColumnName("RecruitID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.JobWCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JobWCode");

                entity.Property(e => e.ModifiedBy).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.TypeJobWCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TypeJobWCode");

                entity.HasOne(d => d.DepartmentCodeNavigation)
                    .WithMany(p => p.NhmRecruits)
                    .HasForeignKey(d => d.DepartmentCode)
                    .HasConstraintName("FK__NHM_Recru__Depar__3E52440B");

                entity.HasOne(d => d.JobWcodeNavigation)
                    .WithMany(p => p.NhmRecruits)
                    .HasForeignKey(d => d.JobWCode)
                    .HasConstraintName("FK__NHM_Recru__JobWC__3F466844");

                entity.HasOne(d => d.TypeJobWcodeNavigation)
                    .WithMany(p => p.NhmRecruits)
                    .HasForeignKey(d => d.TypeJobWCode)
                    .HasConstraintName("FK__NHM_Recru__TypeJ__3D5E1FD2");
            });

            modelBuilder.Entity<NhmTypeJobWorking>(entity =>
            {
                entity.HasKey(e => e.TypeJobWCode)
                    .HasName("PK__NHM_Type__F6DB4CF5ADB3F057");

                entity.ToTable("NHM_TypeJobWorking");

                entity.Property(e => e.TypeJobWCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TypeJobWCode");

                entity.Property(e => e.LocationCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TypeJobWName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TypeJobWName");

                entity.Property(e => e.TypeJobWName2)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TypeJobWName2");

                entity.HasOne(d => d.LocationCodeNavigation)
                    .WithMany(p => p.NhmTypeJobWorkings)
                    .HasForeignKey(d => d.LocationCode)
                    .HasConstraintName("FK__NHM_TypeJ__Locat__38996AB5");
            });

            modelBuilder.Entity<NhmValueList>(entity =>
            {
                entity.HasKey(e => new { e.Language, e.ListName })
                    .HasName("PK__NHM_Valu__76679258B48295F8");

                entity.ToTable("NHM_ValueList");

                entity.Property(e => e.Language)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ListName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Caption).IsUnicode(false);
            });

            modelBuilder.Entity<NhmWard>(entity =>
            {
                entity.HasKey(e => e.WardCode)
                    .HasName("PK__NHM_Ward__1A7FBFF144DC28DE");

                entity.ToTable("NhmWards");

                entity.Property(e => e.WardCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WardName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.WardName2)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.DistrictCodeNavigation)
                    .WithMany(p => p.NhmWards)
                    .HasForeignKey(d => d.DistrictCode)
                    .HasConstraintName("FK__NHM_Wards__Distr__2C3393D0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Classification> Classification { get; set; }
        public virtual DbSet<Commodity> Commodity { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<ContractType> ContractType { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<DemandPlan> DemandPlan { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DocumentSubmissionStatus> DocumentSubmissionStatus { get; set; }
        public virtual DbSet<FinancialYear> FinancialYear { get; set; }
        public virtual DbSet<Municipality> Municipality { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<PaymentTerm> PaymentTerm { get; set; }
        public virtual DbSet<ProcessType> ProcessType { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Quotation> Quotation { get; set; }
        public virtual DbSet<Requisition> Requisition { get; set; }
        public virtual DbSet<RequisitionType> RequisitionType { get; set; }
        public virtual DbSet<ShippingMethod> ShippingMethod { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SupplierCategory> SupplierCategory { get; set; }
        public virtual DbSet<Tender> Tender { get; set; }
        public virtual DbSet<TenderOutcome> TenderOutcome { get; set; }
        public virtual DbSet<TenderType> TenderType { get; set; }
        public virtual DbSet<Ward> Ward { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //IConfigurationRoot configuration = new ConfigurationBuilder()
                //            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                //            .AddJsonFile("appsettings.json")
                //            .Build();
                //optionsBuilder.UseSqlServer(configuration.GetConnectionString("SCMConnection"));
                optionsBuilder.UseSqlServer("Server=DESKTOP-6CLOVU1\\SQLEXPRESS;Database=SCMUserIdentity; Trusted_Connection=True; MultipleActiveResultSets=true");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.DocumentName).HasMaxLength(50);

                entity.Property(e => e.DocumentPath).HasMaxLength(100);

                entity.Property(e => e.Extension).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.ProcessId)
                    .HasConstraintName("FK__Attachmen__Proce__756D6ECB");

                entity.HasOne(d => d.ProcessNavigation)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.ProcessId)
                    .HasConstraintName("FK__Attachmen__Proce__74794A92");

                entity.HasOne(d => d.Process1)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.ProcessId)
                    .HasConstraintName("FK__Attachmen__Proce__7755B73D");

                entity.HasOne(d => d.Process2)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.ProcessId)
                    .HasConstraintName("FK__Attachmen__Proce__76619304");

                entity.HasOne(d => d.ProcessType)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.ProcessTypeId)
                    .HasConstraintName("FK__Attachmen__Proce__5BAD9CC8");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).ValueGeneratedNever();

                entity.Property(e => e.CityName).HasMaxLength(50);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__City__ProvinceId__07C12930");
            });

            modelBuilder.Entity<Classification>(entity =>
            {
                entity.Property(e => e.ClassificationId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Commodity>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.ContractId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.Property(e => e.ContractTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.Property(e => e.CountryName).HasMaxLength(100);
            });

            modelBuilder.Entity<DemandPlan>(entity =>
            {
                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DocumentSubmissionStatus>(entity =>
            {
                entity.HasKey(e => e.DocumentStatusId)
                    .HasName("PK__Document__AFDCAF5D2275BE8A");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.ProcessType)
                    .WithMany(p => p.DocumentSubmissionStatus)
                    .HasForeignKey(d => d.ProcessTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DocumentS__Proce__08B54D69");

                entity.HasOne(d => d.Requisition)
                    .WithMany(p => p.DocumentSubmissionStatus)
                    .HasForeignKey(d => d.RequisitionId)
                    .HasConstraintName("FK__DocumentS__Requi__43D61337");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.DocumentSubmissionStatus)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__DocumentS__Suppl__56E8E7AB");

                entity.HasOne(d => d.Tender)
                    .WithMany(p => p.DocumentSubmissionStatus)
                    .HasForeignKey(d => d.TenderId)
                    .HasConstraintName("FK__DocumentS__Tende__09A971A2");
            });

            modelBuilder.Entity<FinancialYear>(entity =>
            {
                entity.Property(e => e.FinancialYearId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Municipality>(entity =>
            {
                entity.Property(e => e.MunicipalityId).ValueGeneratedNever();

                entity.Property(e => e.MunicipalityAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MunicipalityEmailAddress)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.MunicipalityName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MunicipalityTelephone)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Municipality)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Municipal__CityI__0C85DE4D");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Cc).HasMaxLength(100);

                entity.Property(e => e.Comment).IsRequired();

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.From)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.To)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Requisition)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.RequisitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Requi__7C1A6C5A");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.PaymentMethodId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PaymentTerm>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProcessType>(entity =>
            {
                entity.Property(e => e.ProcessTypeId).ValueGeneratedNever();

                entity.Property(e => e.ProcessName).HasMaxLength(100);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.ProvinceId).ValueGeneratedNever();

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Province)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Province__Countr__1DB06A4F");
            });

            modelBuilder.Entity<Quotation>(entity =>
            {
                entity.Property(e => e.QuotationId).ValueGeneratedNever();

                entity.Property(e => e.BillToAddress).HasMaxLength(50);

                entity.Property(e => e.BillToName).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasMaxLength(50);

                entity.Property(e => e.DateUpdated).HasMaxLength(50);

                entity.Property(e => e.Item).HasMaxLength(50);

                entity.Property(e => e.ItemDescription).HasMaxLength(50);

                entity.Property(e => e.QuotationName).HasMaxLength(100);

                entity.Property(e => e.QuoteCreatedBy).HasMaxLength(50);

                entity.Property(e => e.SupplierAddress).HasMaxLength(50);

                entity.Property(e => e.SupplierEmail).HasMaxLength(100);

                entity.Property(e => e.SupplierFax).HasMaxLength(50);

                entity.Property(e => e.SupplierPhoneNumber).HasMaxLength(50);

                entity.Property(e => e.ValidUntil).HasColumnType("datetime");
            });

            modelBuilder.Entity<Requisition>(entity =>
            {
                entity.Property(e => e.AttachmentDescription).HasMaxLength(250);

                entity.Property(e => e.AttachmentPath).HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DeliveryAddress).HasMaxLength(100);

                entity.Property(e => e.ExpectedDate).HasColumnType("datetime");

                entity.Property(e => e.Glaccount).HasColumnName("GLAccount");

                entity.Property(e => e.Item).HasMaxLength(100);

                entity.Property(e => e.ItemDescription).HasMaxLength(100);

                entity.Property(e => e.Motivation).HasMaxLength(100);

                entity.Property(e => e.QueriesEmail).HasMaxLength(50);

                entity.Property(e => e.QueriesName).HasMaxLength(50);

                entity.Property(e => e.QueriesPhone).HasMaxLength(50);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.Property(e => e.RequisitionTitle).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Vattotal)
                    .HasColumnName("VATTotal")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Requisition)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Requisiti__CityI__4A8310C6");

                entity.HasOne(d => d.Classification)
                    .WithMany(p => p.Requisition)
                    .HasForeignKey(d => d.ClassificationId)
                    .HasConstraintName("FK__Requisiti__Class__489AC854");

                entity.HasOne(d => d.Commodity)
                    .WithMany(p => p.Requisition)
                    .HasForeignKey(d => d.CommodityId)
                    .HasConstraintName("FK__Requisiti__Commo__4B7734FF");

                entity.HasOne(d => d.ContractType)
                    .WithMany(p => p.Requisition)
                    .HasForeignKey(d => d.ContractTypeId)
                    .HasConstraintName("FK__Requisiti__Contr__46B27FE2");

                entity.HasOne(d => d.DemandPlan)
                    .WithMany(p => p.Requisition)
                    .HasForeignKey(d => d.DemandPlanId)
                    .HasConstraintName("FK__Requisiti__Deman__498EEC8D");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Requisition)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Requisiti__Depar__45BE5BA9");

                entity.HasOne(d => d.RequisitionType)
                    .WithMany(p => p.Requisition)
                    .HasForeignKey(d => d.RequisitionTypeId)
                    .HasConstraintName("FK__Requisiti__Requi__44CA3770");

                entity.HasOne(d => d.ShippingMethod)
                    .WithMany(p => p.Requisition)
                    .HasForeignKey(d => d.ShippingMethodId)
                    .HasConstraintName("FK__Requisiti__Shipp__47A6A41B");
            });

            modelBuilder.Entity<RequisitionType>(entity =>
            {
                entity.Property(e => e.RequisitionTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ShippingMethod>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId).ValueGeneratedNever();

                entity.Property(e => e.Status1)
                    .HasColumnName("Status")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Bbbeeid).HasColumnName("BBBEEId");

                entity.Property(e => e.BuildingName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ContactPersonCell)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ContactPersonEmail)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ContactPersonFax)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ContactPersonName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ContactPersonPosition)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ContactPersonSurname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ContactPersonTelephone)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LegalName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RegistrationNo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Surburb)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Vatregistered).HasColumnName("VATRegistered");

                entity.Property(e => e.VatregistrationNo)
                    .IsRequired()
                    .HasColumnName("VATRegistrationNo")
                    .HasMaxLength(100);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Supplier)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Supplier__CityId__2645B050");

                entity.HasOne(d => d.Classification)
                    .WithMany(p => p.Supplier)
                    .HasForeignKey(d => d.ClassificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Supplier__Classi__2739D489");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Supplier)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Supplier__Countr__2DE6D218");

                entity.HasOne(d => d.Municipality)
                    .WithMany(p => p.Supplier)
                    .HasForeignKey(d => d.MunicipalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Supplier__Munici__2EDAF651");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Supplier)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Supplier__Paymen__282DF8C2");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Supplier)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Supplier__Provin__2BFE89A6");

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.Supplier)
                    .HasForeignKey(d => d.WardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Supplier__WardId__2CF2ADDF");
            });

            modelBuilder.Entity<SupplierCategory>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.SupplierCategory1)
                    .HasColumnName("SupplierCategory")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Supplier)
                    .WithMany()
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__SupplierC__Suppl__4E53A1AA");
            });

            modelBuilder.Entity<Tender>(entity =>
            {
                entity.Property(e => e.Buyer)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CommitteeCoordinator)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TenderAdvertDate).HasColumnType("datetime");

                entity.Property(e => e.TenderCoordinator)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Classification)
                    .WithMany(p => p.Tender)
                    .HasForeignKey(d => d.ClassificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tender__Classifi__17036CC0");

                entity.HasOne(d => d.FinancialYear)
                    .WithMany(p => p.Tender)
                    .HasForeignKey(d => d.FinancialYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tender__Financia__17F790F9");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tender)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tender__ProjectI__18EBB532");

                entity.HasOne(d => d.TenderType)
                    .WithMany(p => p.Tender)
                    .HasForeignKey(d => d.TenderTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tender__TenderTy__19DFD96B");
            });

            modelBuilder.Entity<TenderOutcome>(entity =>
            {
                entity.Property(e => e.TenderOutcomeId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<TenderType>(entity =>
            {
                entity.Property(e => e.TenderTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.Property(e => e.WardId).ValueGeneratedNever();

                entity.Property(e => e.WardName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Municipality)
                    .WithMany(p => p.Ward)
                    .HasForeignKey(d => d.MunicipalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ward__Municipali__1AD3FDA4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

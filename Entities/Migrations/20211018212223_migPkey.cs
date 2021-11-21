using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class migPkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classification",
                columns: table => new
                {
                    ClassificationId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classification", x => x.ClassificationId);
                });

            migrationBuilder.CreateTable(
                name: "Commodity",
                columns: table => new
                {
                    CommodityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodity", x => x.CommodityId);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ContractTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "ContractType",
                columns: table => new
                {
                    ContractTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractType", x => x.ContractTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    CountryName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "DemandPlan",
                columns: table => new
                {
                    DemandPlanId = table.Column<int>(nullable: false),
                    Item = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandPlan", x => x.DemandPlanId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false),
                    DepartmentName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "FinancialYear",
                columns: table => new
                {
                    FinancialYearId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialYear", x => x.FinancialYearId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTerm",
                columns: table => new
                {
                    PaymentTermId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTerm", x => x.PaymentTermId);
                });

            migrationBuilder.CreateTable(
                name: "ProcessType",
                columns: table => new
                {
                    ProcessTypeId = table.Column<int>(nullable: false),
                    ProcessName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessType", x => x.ProcessTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Quotation",
                columns: table => new
                {
                    QuotationId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: true),
                    RequisitionId = table.Column<int>(nullable: true),
                    Item = table.Column<string>(maxLength: 50, nullable: true),
                    ItemDescription = table.Column<string>(maxLength: 50, nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    UnitPrice = table.Column<double>(nullable: true),
                    Total = table.Column<double>(nullable: true),
                    BillToAddress = table.Column<string>(maxLength: 50, nullable: true),
                    BillToName = table.Column<string>(maxLength: 50, nullable: true),
                    DateCreated = table.Column<string>(maxLength: 50, nullable: true),
                    DateUpdated = table.Column<string>(maxLength: 50, nullable: true),
                    TermsAndContions = table.Column<string>(nullable: true),
                    SpecialNotesAndInstructions = table.Column<string>(nullable: true),
                    SubTotal = table.Column<double>(nullable: true),
                    TaxRate = table.Column<double>(nullable: true),
                    ValidUntil = table.Column<DateTime>(type: "datetime", nullable: true),
                    TotalTaxedAmount = table.Column<double>(nullable: true),
                    QuoteCreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    QuotationName = table.Column<string>(maxLength: 100, nullable: true),
                    SupplierPhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    SupplierAddress = table.Column<string>(maxLength: 50, nullable: true),
                    SupplierFax = table.Column<string>(maxLength: 50, nullable: true),
                    SupplierEmail = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotation", x => x.QuotationId);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionType",
                columns: table => new
                {
                    RequisitionTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionType", x => x.RequisitionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethod",
                columns: table => new
                {
                    ShippingMethodId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethod", x => x.ShippingMethodId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "TenderOutcome",
                columns: table => new
                {
                    TenderOutcomeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderOutcome", x => x.TenderOutcomeId);
                });

            migrationBuilder.CreateTable(
                name: "TenderType",
                columns: table => new
                {
                    TenderTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderType", x => x.TenderTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(nullable: false),
                    ProvinceName = table.Column<string>(maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceId);
                    table.ForeignKey(
                        name: "FK__Province__Countr__1DB06A4F",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tender",
                columns: table => new
                {
                    TenderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    TenderTypeId = table.Column<int>(nullable: false),
                    TenderOutcomeId = table.Column<int>(nullable: false),
                    FinancialYearId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    EstimatedValue = table.Column<double>(nullable: true),
                    Buyer = table.Column<string>(maxLength: 100, nullable: false),
                    CommitteeCoordinator = table.Column<string>(maxLength: 50, nullable: false),
                    TenderCoordinator = table.Column<string>(maxLength: 50, nullable: false),
                    TenderAdvertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumberOfSuppliers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tender", x => x.TenderId);
                    table.ForeignKey(
                        name: "FK__Tender__Classifi__17036CC0",
                        column: x => x.ClassificationId,
                        principalTable: "Classification",
                        principalColumn: "ClassificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Tender__Financia__17F790F9",
                        column: x => x.FinancialYearId,
                        principalTable: "FinancialYear",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Tender__ProjectI__18EBB532",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Tender__TenderTy__19DFD96B",
                        column: x => x.TenderTypeId,
                        principalTable: "TenderType",
                        principalColumn: "TenderTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false),
                    CityName = table.Column<string>(maxLength: 50, nullable: true),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK__City__ProvinceId__07C12930",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    MunicipalityId = table.Column<int>(nullable: false),
                    MunicipalityName = table.Column<string>(maxLength: 100, nullable: false),
                    MunicipalityAddress = table.Column<string>(maxLength: 100, nullable: false),
                    MunicipalityTelephone = table.Column<string>(maxLength: 100, nullable: false),
                    MunicipalityEmailAddress = table.Column<string>(maxLength: 250, nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.MunicipalityId);
                    table.ForeignKey(
                        name: "FK__Municipal__CityI__0C85DE4D",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requisition",
                columns: table => new
                {
                    RequisitionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequisitionNo = table.Column<Guid>(nullable: false),
                    RequisitionTitle = table.Column<string>(maxLength: 50, nullable: true),
                    RequisitionTypeId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    ContractTypeId = table.Column<int>(nullable: true),
                    ShippingMethodId = table.Column<int>(nullable: true),
                    Motivation = table.Column<string>(maxLength: 100, nullable: true),
                    QueriesName = table.Column<string>(maxLength: 50, nullable: true),
                    QueriesPhone = table.Column<string>(maxLength: 50, nullable: true),
                    QueriesEmail = table.Column<string>(maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 20, nullable: true),
                    SiteVisitRequired = table.Column<bool>(nullable: true),
                    AttachmentPath = table.Column<string>(maxLength: 250, nullable: true),
                    AttachmentDescription = table.Column<string>(maxLength: 250, nullable: true),
                    OverwriteExistingAttachment = table.Column<bool>(nullable: true),
                    AttachmentVisibleToSupplier = table.Column<bool>(nullable: true),
                    ApprovalException = table.Column<bool>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: true),
                    ClassificationId = table.Column<int>(nullable: true),
                    ServiceItem = table.Column<bool>(nullable: true),
                    CommodityId = table.Column<int>(nullable: true),
                    Item = table.Column<string>(maxLength: 100, nullable: true),
                    UnitOfMeasure = table.Column<int>(nullable: true),
                    GLAccount = table.Column<string>(nullable: true),
                    ItemDescription = table.Column<string>(maxLength: 100, nullable: true),
                    DetailedDescription = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    VATTotal = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    RequestedBy = table.Column<string>(nullable: true),
                    ExpectedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    DeliveryAddress = table.Column<string>(maxLength: 100, nullable: true),
                    DemandPlanId = table.Column<int>(nullable: true),
                    Reason = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisition", x => x.RequisitionId);
                    table.ForeignKey(
                        name: "FK__Requisiti__CityI__4A8310C6",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Requisiti__Class__489AC854",
                        column: x => x.ClassificationId,
                        principalTable: "Classification",
                        principalColumn: "ClassificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Requisiti__Commo__4B7734FF",
                        column: x => x.CommodityId,
                        principalTable: "Commodity",
                        principalColumn: "CommodityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Requisiti__Contr__46B27FE2",
                        column: x => x.ContractTypeId,
                        principalTable: "ContractType",
                        principalColumn: "ContractTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Requisiti__Deman__498EEC8D",
                        column: x => x.DemandPlanId,
                        principalTable: "DemandPlan",
                        principalColumn: "DemandPlanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Requisiti__Depar__45BE5BA9",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Requisiti__Requi__44CA3770",
                        column: x => x.RequisitionTypeId,
                        principalTable: "RequisitionType",
                        principalColumn: "RequisitionTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Requisiti__Shipp__47A6A41B",
                        column: x => x.ShippingMethodId,
                        principalTable: "ShippingMethod",
                        principalColumn: "ShippingMethodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    WardId = table.Column<int>(nullable: false),
                    WardName = table.Column<string>(maxLength: 100, nullable: false),
                    MunicipalityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.WardId);
                    table.ForeignKey(
                        name: "FK__Ward__Municipali__1AD3FDA4",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequisitionId = table.Column<int>(nullable: false),
                    To = table.Column<string>(maxLength: 100, nullable: false),
                    From = table.Column<string>(maxLength: 100, nullable: false),
                    Action = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: false),
                    Message = table.Column<string>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false),
                    Cc = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK__Notificat__Requi__7C1A6C5A",
                        column: x => x.RequisitionId,
                        principalTable: "Requisition",
                        principalColumn: "RequisitionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(maxLength: 100, nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    LegalName = table.Column<string>(maxLength: 100, nullable: false),
                    RegistrationNo = table.Column<string>(maxLength: 100, nullable: false),
                    VATRegistered = table.Column<bool>(nullable: false),
                    VATRegistrationNo = table.Column<string>(maxLength: 100, nullable: false),
                    BBBEEId = table.Column<int>(nullable: false),
                    Currency = table.Column<string>(maxLength: 50, nullable: false),
                    PaymentMethodId = table.Column<int>(nullable: false),
                    PaymentTermId = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(maxLength: 100, nullable: false),
                    BuildingName = table.Column<string>(maxLength: 100, nullable: false),
                    Surburb = table.Column<string>(maxLength: 250, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: false),
                    MunicipalityId = table.Column<int>(nullable: false),
                    WardId = table.Column<int>(nullable: false),
                    PostalCode = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    ContactPersonName = table.Column<string>(maxLength: 100, nullable: false),
                    ContactPersonSurname = table.Column<string>(maxLength: 100, nullable: false),
                    ContactPersonPosition = table.Column<string>(maxLength: 100, nullable: false),
                    ContactPersonTelephone = table.Column<string>(maxLength: 100, nullable: false),
                    ContactPersonFax = table.Column<string>(maxLength: 100, nullable: false),
                    ContactPersonCell = table.Column<string>(maxLength: 100, nullable: false),
                    ContactPersonEmail = table.Column<string>(maxLength: 100, nullable: false),
                    QuotationContact = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK__Supplier__CityId__2645B050",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Supplier__Classi__2739D489",
                        column: x => x.ClassificationId,
                        principalTable: "Classification",
                        principalColumn: "ClassificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Supplier__Countr__2DE6D218",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Supplier__Munici__2EDAF651",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Supplier__Paymen__282DF8C2",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Supplier__Provin__2BFE89A6",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Supplier__WardId__2CF2ADDF",
                        column: x => x.WardId,
                        principalTable: "Ward",
                        principalColumn: "WardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessTypeId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Extension = table.Column<string>(maxLength: 50, nullable: true),
                    DocumentName = table.Column<string>(maxLength: 50, nullable: true),
                    DocumentPath = table.Column<string>(maxLength: 100, nullable: true),
                    ProcessId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.AttachmentId);
                    table.ForeignKey(
                        name: "FK__Attachmen__Proce__756D6ECB",
                        column: x => x.ProcessId,
                        principalTable: "Quotation",
                        principalColumn: "QuotationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Attachmen__Proce__74794A92",
                        column: x => x.ProcessId,
                        principalTable: "Requisition",
                        principalColumn: "RequisitionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Attachmen__Proce__7755B73D",
                        column: x => x.ProcessId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Attachmen__Proce__76619304",
                        column: x => x.ProcessId,
                        principalTable: "Tender",
                        principalColumn: "TenderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Attachmen__Proce__5BAD9CC8",
                        column: x => x.ProcessTypeId,
                        principalTable: "ProcessType",
                        principalColumn: "ProcessTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentSubmissionStatus",
                columns: table => new
                {
                    DocumentStatusId = table.Column<int>(nullable: false),
                    ProcessTypeId = table.Column<int>(nullable: false),
                    TenderId = table.Column<int>(nullable: true),
                    RequisitionId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Document__AFDCAF5D2275BE8A", x => x.DocumentStatusId);
                    table.ForeignKey(
                        name: "FK__DocumentS__Proce__08B54D69",
                        column: x => x.ProcessTypeId,
                        principalTable: "ProcessType",
                        principalColumn: "ProcessTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DocumentS__Requi__43D61337",
                        column: x => x.RequisitionId,
                        principalTable: "Requisition",
                        principalColumn: "RequisitionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DocumentS__Suppl__56E8E7AB",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DocumentS__Tende__09A971A2",
                        column: x => x.TenderId,
                        principalTable: "Tender",
                        principalColumn: "TenderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierCategory",
                columns: table => new
                {
                    SupplierCategoryId = table.Column<int>(nullable: false),
                    SupplierCategory = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    SupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__SupplierC__Suppl__4E53A1AA",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_ProcessId",
                table: "Attachment",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_ProcessTypeId",
                table: "Attachment",
                column: "ProcessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceId",
                table: "City",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentSubmissionStatus_ProcessTypeId",
                table: "DocumentSubmissionStatus",
                column: "ProcessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentSubmissionStatus_RequisitionId",
                table: "DocumentSubmissionStatus",
                column: "RequisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentSubmissionStatus_SupplierId",
                table: "DocumentSubmissionStatus",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentSubmissionStatus_TenderId",
                table: "DocumentSubmissionStatus",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipality_CityId",
                table: "Municipality",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_RequisitionId",
                table: "Notification",
                column: "RequisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Province_CountryId",
                table: "Province",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_CityId",
                table: "Requisition",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_ClassificationId",
                table: "Requisition",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_CommodityId",
                table: "Requisition",
                column: "CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_ContractTypeId",
                table: "Requisition",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_DemandPlanId",
                table: "Requisition",
                column: "DemandPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_DepartmentId",
                table: "Requisition",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_RequisitionTypeId",
                table: "Requisition",
                column: "RequisitionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_ShippingMethodId",
                table: "Requisition",
                column: "ShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CityId",
                table: "Supplier",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ClassificationId",
                table: "Supplier",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CountryId",
                table: "Supplier",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_MunicipalityId",
                table: "Supplier",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_PaymentMethodId",
                table: "Supplier",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ProvinceId",
                table: "Supplier",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_WardId",
                table: "Supplier",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierCategory_SupplierId",
                table: "SupplierCategory",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Tender_ClassificationId",
                table: "Tender",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tender_FinancialYearId",
                table: "Tender",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Tender_ProjectId",
                table: "Tender",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tender_TenderTypeId",
                table: "Tender",
                column: "TenderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_MunicipalityId",
                table: "Ward",
                column: "MunicipalityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "DocumentSubmissionStatus");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "PaymentTerm");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "SupplierCategory");

            migrationBuilder.DropTable(
                name: "TenderOutcome");

            migrationBuilder.DropTable(
                name: "Quotation");

            migrationBuilder.DropTable(
                name: "ProcessType");

            migrationBuilder.DropTable(
                name: "Tender");

            migrationBuilder.DropTable(
                name: "Requisition");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "FinancialYear");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "TenderType");

            migrationBuilder.DropTable(
                name: "Commodity");

            migrationBuilder.DropTable(
                name: "ContractType");

            migrationBuilder.DropTable(
                name: "DemandPlan");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "RequisitionType");

            migrationBuilder.DropTable(
                name: "ShippingMethod");

            migrationBuilder.DropTable(
                name: "Classification");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "Municipality");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}

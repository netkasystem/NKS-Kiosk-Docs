using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NThaiSmartWeb.EFModels;

public partial class DBContext : DbContext
{
    public DBContext(DbContextOptions<KioskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdHocReport> AdHocReport { get; set; }

    public virtual DbSet<AdHocReportChart> AdHocReportChart { get; set; }

    public virtual DbSet<AdHocReportData> AdHocReportData { get; set; }

    public virtual DbSet<AdHocReportFilter> AdHocReportFilter { get; set; }

    public virtual DbSet<AdHocReportModule> AdHocReportModule { get; set; }

    public virtual DbSet<AdHocReportModuleAdditionalColumns> AdHocReportModuleAdditionalColumns { get; set; }

    public virtual DbSet<AdHocReportTimePeriod> AdHocReportTimePeriod { get; set; }

    public virtual DbSet<Address> Address { get; set; }

    public virtual DbSet<AdminEditLog> AdminEditLog { get; set; }

    public virtual DbSet<AdminEditLogDetail> AdminEditLogDetail { get; set; }

    public virtual DbSet<AdminLog> AdminLog { get; set; }

    public virtual DbSet<AdminMessage> AdminMessage { get; set; }

    public virtual DbSet<AdminMessageCustomer> AdminMessageCustomer { get; set; }

    public virtual DbSet<AlarmDescription> AlarmDescription { get; set; }

    public virtual DbSet<AlarmType> AlarmType { get; set; }

    public virtual DbSet<AlertProfile> AlertProfile { get; set; }

    public virtual DbSet<AlertProfileDetail> AlertProfileDetail { get; set; }

    public virtual DbSet<AlertType> AlertType { get; set; }

    public virtual DbSet<Amphur> Amphur { get; set; }

    public virtual DbSet<AnalyticalWhatif> AnalyticalWhatif { get; set; }

    public virtual DbSet<Associated> Associated { get; set; }

    public virtual DbSet<AssociatedMonitoring> AssociatedMonitoring { get; set; }

    public virtual DbSet<AttachmentType> AttachmentType { get; set; }

    public virtual DbSet<AuthenticationSource> AuthenticationSource { get; set; }

    public virtual DbSet<AutoReportSetting> AutoReportSetting { get; set; }

    public virtual DbSet<BooleanTranslate> BooleanTranslate { get; set; }

    public virtual DbSet<BusinessHour> BusinessHour { get; set; }

    public virtual DbSet<BusinessHoursProfile> BusinessHoursProfile { get; set; }

    public virtual DbSet<Calendar> Calendar { get; set; }

    public virtual DbSet<CalendarStaff> CalendarStaff { get; set; }

    public virtual DbSet<Card> Card { get; set; }

    public virtual DbSet<CardAlarmType> CardAlarmType { get; set; }

    public virtual DbSet<CaseAsset> CaseAsset { get; set; }

    public virtual DbSet<CaseAttachment> CaseAttachment { get; set; }

    public virtual DbSet<CaseCategory> CaseCategory { get; set; }

    public virtual DbSet<CaseIdFormat> CaseIdFormat { get; set; }

    public virtual DbSet<CaseLog> CaseLog { get; set; }

    public virtual DbSet<CaseLogCategory> CaseLogCategory { get; set; }

    public virtual DbSet<CaseLogDeleted> CaseLogDeleted { get; set; }

    public virtual DbSet<CaseLogType> CaseLogType { get; set; }

    public virtual DbSet<CaseStatus> CaseStatus { get; set; }

    public virtual DbSet<CaseSubCategory> CaseSubCategory { get; set; }

    public virtual DbSet<CaseType> CaseType { get; set; }

    public virtual DbSet<CaseTypeCustom> CaseTypeCustom { get; set; }

    public virtual DbSet<CaseTypeCustomSetup> CaseTypeCustomSetup { get; set; }

    public virtual DbSet<CategoryIcon> CategoryIcon { get; set; }

    public virtual DbSet<CauseBy> CauseBy { get; set; }

    public virtual DbSet<ChangePassword> ChangePassword { get; set; }

    public virtual DbSet<ChatCopilot> ChatCopilot { get; set; }

    public virtual DbSet<ClosureType> ClosureType { get; set; }

    public virtual DbSet<CmsSwitchLocationService> CmsSwitchLocationService { get; set; }

    public virtual DbSet<Collaboration> Collaboration { get; set; }

    public virtual DbSet<Compliant> Compliant { get; set; }

    public virtual DbSet<Config> Config { get; set; }

    public virtual DbSet<ConfigAlertRole> ConfigAlertRole { get; set; }

    public virtual DbSet<ConfigAlertTemplate> ConfigAlertTemplate { get; set; }

    public virtual DbSet<ConfigAlertTemplateRole> ConfigAlertTemplateRole { get; set; }

    public virtual DbSet<Contact> Contact { get; set; }

    public virtual DbSet<ContactChannel> ContactChannel { get; set; }

    public virtual DbSet<ContactProfile> ContactProfile { get; set; }

    public virtual DbSet<Contract> Contract { get; set; }

    public virtual DbSet<ContractAttachment> ContractAttachment { get; set; }

    public virtual DbSet<ContractAttachmentOld> ContractAttachmentOld { get; set; }

    public virtual DbSet<ContractCustomField> ContractCustomField { get; set; }

    public virtual DbSet<ContractCustomForm> ContractCustomForm { get; set; }

    public virtual DbSet<ContractLogAttachment> ContractLogAttachment { get; set; }

    public virtual DbSet<Country> Country { get; set; }

    public virtual DbSet<Currency> Currency { get; set; }

    public virtual DbSet<CustomForm> CustomForm { get; set; }

    public virtual DbSet<CustomFormField> CustomFormField { get; set; }

    public virtual DbSet<CustomFormFieldValue> CustomFormFieldValue { get; set; }

    public virtual DbSet<CustomSurveyResult> CustomSurveyResult { get; set; }

    public virtual DbSet<CustomSurveyValue> CustomSurveyValue { get; set; }

    public virtual DbSet<Customer> Customer { get; set; }

    public virtual DbSet<CustomerContact> CustomerContact { get; set; }

    public virtual DbSet<CustomerType> CustomerType { get; set; }

    public virtual DbSet<Dataprotectionkeys> Dataprotectionkeys { get; set; }

    public virtual DbSet<DatasourceConfig> DatasourceConfig { get; set; }

    public virtual DbSet<Department> Department { get; set; }

    public virtual DbSet<EmailAutoIncidentSetup> EmailAutoIncidentSetup { get; set; }

    public virtual DbSet<EmailProfile> EmailProfile { get; set; }

    public virtual DbSet<EmailProfileDetail> EmailProfileDetail { get; set; }

    public virtual DbSet<EmailSmsAlertTemp> EmailSmsAlertTemp { get; set; }

    public virtual DbSet<EmailSmsLog> EmailSmsLog { get; set; }

    public virtual DbSet<EmailSmsLogTemp> EmailSmsLogTemp { get; set; }

    public virtual DbSet<EmailTemplate> EmailTemplate { get; set; }

    public virtual DbSet<EmailTemplateType> EmailTemplateType { get; set; }

    public virtual DbSet<EmailTemplateVariable> EmailTemplateVariable { get; set; }

    public virtual DbSet<FaqCategory> FaqCategory { get; set; }

    public virtual DbSet<FaqDetail> FaqDetail { get; set; }

    public virtual DbSet<FaqHelpfulLog> FaqHelpfulLog { get; set; }

    public virtual DbSet<FileServer> FileServer { get; set; }

    public virtual DbSet<FileServerPriv> FileServerPriv { get; set; }

    public virtual DbSet<FileValidation> FileValidation { get; set; }

    public virtual DbSet<FoundFaultBy> FoundFaultBy { get; set; }

    public virtual DbSet<FunctionPrivilege> FunctionPrivilege { get; set; }

    public virtual DbSet<FunctionPrivilegeDetail> FunctionPrivilegeDetail { get; set; }

    public virtual DbSet<Gender> Gender { get; set; }

    public virtual DbSet<GeneralChoice> GeneralChoice { get; set; }

    public virtual DbSet<GeneralQuestion> GeneralQuestion { get; set; }

    public virtual DbSet<Geography> Geography { get; set; }

    public virtual DbSet<Holiday> Holiday { get; set; }

    public virtual DbSet<Hour> Hour { get; set; }

    public virtual DbSet<ImLog> ImLog { get; set; }

    public virtual DbSet<Impact> Impact { get; set; }

    public virtual DbSet<ImpactAffectedParties> ImpactAffectedParties { get; set; }

    public virtual DbSet<ImpactAnalysis> ImpactAnalysis { get; set; }

    public virtual DbSet<ImpactCost> ImpactCost { get; set; }

    public virtual DbSet<ImpactDetail> ImpactDetail { get; set; }

    public virtual DbSet<ImpactSow> ImpactSow { get; set; }

    public virtual DbSet<ImpactTime> ImpactTime { get; set; }

    public virtual DbSet<Incident> Incident { get; set; }

    public virtual DbSet<IncidentAssignmentRule> IncidentAssignmentRule { get; set; }

    public virtual DbSet<IncidentCaseTypeCustom> IncidentCaseTypeCustom { get; set; }

    public virtual DbSet<IncidentChange> IncidentChange { get; set; }

    public virtual DbSet<IncidentCircuit> IncidentCircuit { get; set; }

    public virtual DbSet<IncidentCreateSummary> IncidentCreateSummary { get; set; }

    public virtual DbSet<IncidentCustom> IncidentCustom { get; set; }

    public virtual DbSet<IncidentCustomField> IncidentCustomField { get; set; }

    public virtual DbSet<IncidentDashboardProfile> IncidentDashboardProfile { get; set; }

    public virtual DbSet<IncidentDeleted> IncidentDeleted { get; set; }

    public virtual DbSet<IncidentEscalationLog> IncidentEscalationLog { get; set; }

    public virtual DbSet<IncidentPending> IncidentPending { get; set; }

    public virtual DbSet<IncidentRemainSummary> IncidentRemainSummary { get; set; }

    public virtual DbSet<IncidentResolution> IncidentResolution { get; set; }

    public virtual DbSet<IncidentResolveSummary> IncidentResolveSummary { get; set; }

    public virtual DbSet<IncidentServiceReport> IncidentServiceReport { get; set; }

    public virtual DbSet<IncidentTemplate> IncidentTemplate { get; set; }

    public virtual DbSet<Invoiceitems> Invoiceitems { get; set; }

    public virtual DbSet<Invoices> Invoices { get; set; }

    public virtual DbSet<ItemStatus> ItemStatus { get; set; }

    public virtual DbSet<Kiosk> Kiosk { get; set; }

    public virtual DbSet<KioskConsented> KioskConsented { get; set; }

    public virtual DbSet<KioskHealthStatus> KioskHealthStatus { get; set; }

    public virtual DbSet<KioskHeartbeat> KioskHeartbeat { get; set; }

    public virtual DbSet<KioskMonitoringPin> KioskMonitoringPin { get; set; }

    public virtual DbSet<KioskSetup> KioskSetup { get; set; }

    public virtual DbSet<Level> Level { get; set; }

    public virtual DbSet<License> License { get; set; }

    public virtual DbSet<LineNotification> LineNotification { get; set; }

    public virtual DbSet<LineTemplate> LineTemplate { get; set; }

    public virtual DbSet<Location> Location { get; set; }

    public virtual DbSet<Login> Login { get; set; }

    public virtual DbSet<LoginFail> LoginFail { get; set; }

    public virtual DbSet<LoginOtp> LoginOtp { get; set; }

    public virtual DbSet<LoginSpr> LoginSpr { get; set; }

    public virtual DbSet<MandatoryFieldConfig> MandatoryFieldConfig { get; set; }

    public virtual DbSet<Menu> Menu { get; set; }

    public virtual DbSet<MenuApiPath> MenuApiPath { get; set; }

    public virtual DbSet<MenuApiPathAnonymous> MenuApiPathAnonymous { get; set; }

    public virtual DbSet<MenuApiPathPhase2> MenuApiPathPhase2 { get; set; }

    public virtual DbSet<MenuChatbot> MenuChatbot { get; set; }

    public virtual DbSet<MenuGroup> MenuGroup { get; set; }

    public virtual DbSet<MenuTutorialMapping> MenuTutorialMapping { get; set; }

    public virtual DbSet<MenuUserRouting> MenuUserRouting { get; set; }

    public virtual DbSet<MessageCustomerCircuit> MessageCustomerCircuit { get; set; }

    public virtual DbSet<MessageCustomerContact> MessageCustomerContact { get; set; }

    public virtual DbSet<MobilePhoneRegisNsd> MobilePhoneRegisNsd { get; set; }

    public virtual DbSet<Module> Module { get; set; }

    public virtual DbSet<ModuleAdditionalColumns> ModuleAdditionalColumns { get; set; }

    public virtual DbSet<ModuleDashboardProfile> ModuleDashboardProfile { get; set; }

    public virtual DbSet<ModuleLookup> ModuleLookup { get; set; }

    public virtual DbSet<ModuleMappingView> ModuleMappingView { get; set; }

    public virtual DbSet<ModuleRole> ModuleRole { get; set; }

    public virtual DbSet<NetkaProduct> NetkaProduct { get; set; }

    public virtual DbSet<NetworkServiceType> NetworkServiceType { get; set; }

    public virtual DbSet<NksfsrvFileCabinet> NksfsrvFileCabinet { get; set; }

    public virtual DbSet<Node> Node { get; set; }

    public virtual DbSet<NodeCard> NodeCard { get; set; }

    public virtual DbSet<NotificationTask> NotificationTask { get; set; }

    public virtual DbSet<NotificationTaskContact> NotificationTaskContact { get; set; }

    public virtual DbSet<NsdFunction> NsdFunction { get; set; }

    public virtual DbSet<NsdImport> NsdImport { get; set; }

    public virtual DbSet<NsdxDashboardProfile> NsdxDashboardProfile { get; set; }

    public virtual DbSet<NsdxErrorLog> NsdxErrorLog { get; set; }

    public virtual DbSet<NsdxFileAttachmentFtp> NsdxFileAttachmentFtp { get; set; }

    public virtual DbSet<NsdxFileAttatchment> NsdxFileAttatchment { get; set; }

    public virtual DbSet<NsdxResetFactoryLog> NsdxResetFactoryLog { get; set; }

    public virtual DbSet<NsdxSystemLog> NsdxSystemLog { get; set; }

    public virtual DbSet<Office> Office { get; set; }

    public virtual DbSet<Ola> Ola { get; set; }

    public virtual DbSet<OlaDetail> OlaDetail { get; set; }

    public virtual DbSet<PageProduct> PageProduct { get; set; }

    public virtual DbSet<PageProductLog> PageProductLog { get; set; }

    public virtual DbSet<PartCodeScript> PartCodeScript { get; set; }

    public virtual DbSet<PartnerProjectRegister> PartnerProjectRegister { get; set; }

    public virtual DbSet<PlaningAnalysis> PlaningAnalysis { get; set; }

    public virtual DbSet<Position> Position { get; set; }

    public virtual DbSet<Prefix> Prefix { get; set; }

    public virtual DbSet<Priority> Priority { get; set; }

    public virtual DbSet<PriorityLevel> PriorityLevel { get; set; }

    public virtual DbSet<Privilege> Privilege { get; set; }

    public virtual DbSet<PrivilegeDetail> PrivilegeDetail { get; set; }

    public virtual DbSet<Probability> Probability { get; set; }

    public virtual DbSet<ProductKeySale> ProductKeySale { get; set; }

    public virtual DbSet<ProductKeySaleDetail> ProductKeySaleDetail { get; set; }

    public virtual DbSet<ProductKeyTrial> ProductKeyTrial { get; set; }

    public virtual DbSet<ProductKeyTrialDetail> ProductKeyTrialDetail { get; set; }

    public virtual DbSet<ProductsIdentity> ProductsIdentity { get; set; }

    public virtual DbSet<Project> Project { get; set; }

    public virtual DbSet<PropertyControlFiled> PropertyControlFiled { get; set; }

    public virtual DbSet<PropertyFieldConfig> PropertyFieldConfig { get; set; }

    public virtual DbSet<PropertyFieldValueMaster> PropertyFieldValueMaster { get; set; }

    public virtual DbSet<Province> Province { get; set; }

    public virtual DbSet<Region> Region { get; set; }

    public virtual DbSet<ReportExportLog> ReportExportLog { get; set; }

    public virtual DbSet<ReportViewLog> ReportViewLog { get; set; }

    public virtual DbSet<ReportViewLogConfig> ReportViewLogConfig { get; set; }

    public virtual DbSet<ResolutionCategory> ResolutionCategory { get; set; }

    public virtual DbSet<ResolutionType> ResolutionType { get; set; }

    public virtual DbSet<Risk> Risk { get; set; }

    public virtual DbSet<RiskAnalysis> RiskAnalysis { get; set; }

    public virtual DbSet<RiskCaseLogType> RiskCaseLogType { get; set; }

    public virtual DbSet<RiskCategory> RiskCategory { get; set; }

    public virtual DbSet<RiskLevel> RiskLevel { get; set; }

    public virtual DbSet<RiskMitigation> RiskMitigation { get; set; }

    public virtual DbSet<Role> Role { get; set; }

    public virtual DbSet<RoleAuthorize> RoleAuthorize { get; set; }

    public virtual DbSet<RootCause> RootCause { get; set; }

    public virtual DbSet<SaasCustomer> SaasCustomer { get; set; }

    public virtual DbSet<Section> Section { get; set; }

    public virtual DbSet<Sector> Sector { get; set; }

    public virtual DbSet<Select2Mapping> Select2Mapping { get; set; }

    public virtual DbSet<SendEmailDebug> SendEmailDebug { get; set; }

    public virtual DbSet<SendEmailSmsErrorLog> SendEmailSmsErrorLog { get; set; }

    public virtual DbSet<ServiceCab> ServiceCab { get; set; }

    public virtual DbSet<ServiceTeam> ServiceTeam { get; set; }

    public virtual DbSet<ServiceType> ServiceType { get; set; }

    public virtual DbSet<Shift> Shift { get; set; }

    public virtual DbSet<Site> Site { get; set; }

    public virtual DbSet<SiteZone> SiteZone { get; set; }

    public virtual DbSet<Skill> Skill { get; set; }

    public virtual DbSet<SkillLevel> SkillLevel { get; set; }

    public virtual DbSet<SkillTraining> SkillTraining { get; set; }

    public virtual DbSet<Sla> Sla { get; set; }

    public virtual DbSet<SlaDetail> SlaDetail { get; set; }

    public virtual DbSet<SmsTemplate> SmsTemplate { get; set; }

    public virtual DbSet<Spare> Spare { get; set; }

    public virtual DbSet<SpareLog> SpareLog { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffLocation> StaffLocation { get; set; }

    public virtual DbSet<StaffLocationLog> StaffLocationLog { get; set; }

    public virtual DbSet<StaffLocationTracking> StaffLocationTracking { get; set; }

    public virtual DbSet<StaffProfile> StaffProfile { get; set; }

    public virtual DbSet<StaffStatus> StaffStatus { get; set; }

    public virtual DbSet<StatusMappingSdIncident> StatusMappingSdIncident { get; set; }

    public virtual DbSet<SubCategoryTeam> SubCategoryTeam { get; set; }

    public virtual DbSet<Supplier> Supplier { get; set; }

    public virtual DbSet<SupplierContact> SupplierContact { get; set; }

    public virtual DbSet<SupplierContactProfile> SupplierContactProfile { get; set; }

    public virtual DbSet<SymptomType> SymptomType { get; set; }

    public virtual DbSet<Tambol> Tambol { get; set; }

    public virtual DbSet<Team> Team { get; set; }

    public virtual DbSet<Template> Template { get; set; }

    public virtual DbSet<TestStartFinish> TestStartFinish { get; set; }

    public virtual DbSet<Tier> Tier { get; set; }

    public virtual DbSet<Translate> Translate { get; set; }

    public virtual DbSet<Tutorial> Tutorial { get; set; }

    public virtual DbSet<TypeOfService> TypeOfService { get; set; }

    public virtual DbSet<Urgency> Urgency { get; set; }

    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<UserControl> UserControl { get; set; }

    public virtual DbSet<Variables> Variables { get; set; }

    public virtual DbSet<Vendor> Vendor { get; set; }

    public virtual DbSet<Watcher> Watcher { get; set; }

    public virtual DbSet<Webboard> Webboard { get; set; }

    public virtual DbSet<WebboardCategory> WebboardCategory { get; set; }

    public virtual DbSet<WebboardReply> WebboardReply { get; set; }

    public virtual DbSet<WorkCategory> WorkCategory { get; set; }

    public virtual DbSet<WorkDay> WorkDay { get; set; }

    public virtual DbSet<WorkflowParticipate> WorkflowParticipate { get; set; }

    public virtual DbSet<WorkflowRule> WorkflowRule { get; set; }

    public virtual DbSet<WorkflowRuleCondition> WorkflowRuleCondition { get; set; }

    public virtual DbSet<WorkingLogDeleted> WorkingLogDeleted { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AdHocReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ad_hoc_report");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CanDelete)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("can_delete");
            entity.Property(e => e.CreatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_date");
            entity.Property(e => e.CretedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("creted_by");
            entity.Property(e => e.Inactive)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.IsChart)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_chart");
            entity.Property(e => e.IsCustomer).HasColumnName("is_customer");
            entity.Property(e => e.IsGrid)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_grid");
            entity.Property(e => e.IsPublic)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_public");
            entity.Property(e => e.IsShareTeam)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("is_share_team");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.ReportShareTeamId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("report_share_team_id");
            entity.Property(e => e.RptDescription)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("rpt_description");
            entity.Property(e => e.RptName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("rpt_name");
            entity.Property(e => e.RptType)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("rpt_type");
            entity.Property(e => e.TimeField)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("time_field");
            entity.Property(e => e.TimeVal)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("time_val");
        });

        modelBuilder.Entity<AdHocReportChart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ad_hoc_report_chart");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(100)
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasColumnType("bit(1)")
                .HasColumnName("is_active");
            entity.Property(e => e.JsonData).HasColumnName("json_data");
            entity.Property(e => e.JsonTemplate).HasColumnName("json_template");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ProfileId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("profile_id");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(100)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<AdHocReportData>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ad_hoc_report_data");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ProfileId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("profile_id");
            entity.Property(e => e.Value)
                .HasMaxLength(1000)
                .HasDefaultValueSql("''")
                .HasColumnName("value");
        });

        modelBuilder.Entity<AdHocReportFilter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ad_hoc_report_filter");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.FieldName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("field_name");
            entity.Property(e => e.Operand)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("operand");
            entity.Property(e => e.Operand2)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("operand2");
            entity.Property(e => e.ProfileId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("profile_id");
            entity.Property(e => e.SessionId)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("session_id");
            entity.Property(e => e.Value)
                .HasMaxLength(1000)
                .HasDefaultValueSql("''")
                .HasColumnName("value");
        });

        modelBuilder.Entity<AdHocReportModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ad_hoc_report_module");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.LookUpTb)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("look_up_tb");
            entity.Property(e => e.Module)
                .HasMaxLength(45)
                .HasDefaultValueSql("''");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
        });

        modelBuilder.Entity<AdHocReportModuleAdditionalColumns>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ad_hoc_report_module_additional_columns");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.LookUpTb)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("look_up_tb");
            entity.Property(e => e.Module)
                .HasMaxLength(45)
                .HasDefaultValueSql("''");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.SqlGetCaseidByUser)
                .HasMaxLength(201)
                .HasDefaultValueSql("''")
                .HasColumnName("sql_get_caseid_by_user");
        });

        modelBuilder.Entity<AdHocReportTimePeriod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ad_hoc_report_time_period");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Duration)
                .HasComment("days")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("duration");
            entity.Property(e => e.Label)
                .HasMaxLength(45)
                .HasColumnName("label");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PRIMARY");

            entity.ToTable("address");

            entity.HasIndex(e => new { e.Type, e.AddressId }, "SEEK");

            entity.Property(e => e.AddressId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("address_id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.DescriptionEnglish)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("description_english");
            entity.Property(e => e.DescriptionThai)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("description_thai");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<AdminEditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admin_edit_log");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("date");
            entity.Property(e => e.Page)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("page");
            entity.Property(e => e.Time)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("time");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("username");
        });

        modelBuilder.Entity<AdminEditLogDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admin_edit_log_detail");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.FieldName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("field_name");
            entity.Property(e => e.LogId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("log_id");
            entity.Property(e => e.NewValue)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("new_value");
            entity.Property(e => e.OldValue)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("old_value");
            entity.Property(e => e.TableName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("table_name");
        });

        modelBuilder.Entity<AdminLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admin_log");

            entity.HasIndex(e => e.Username, "username");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Action)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("action");
            entity.Property(e => e.Date)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Page)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("page");
            entity.Property(e => e.TableName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("table_name");
            entity.Property(e => e.Time)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("time");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("username");
        });

        modelBuilder.Entity<AdminMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admin_message");

            entity.HasIndex(e => new { e.Id, e.Startdate, e.Enddate }, "message");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.DepartmentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("department_id");
            entity.Property(e => e.Enddate)
                .HasColumnType("datetime")
                .HasColumnName("enddate");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.SectionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("section_id");
            entity.Property(e => e.Startdate)
                .HasColumnType("datetime")
                .HasColumnName("startdate");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("subject");
        });

        modelBuilder.Entity<AdminMessageCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admin_message_customer");

            entity.HasIndex(e => new { e.Id, e.Startdate, e.Enddate }, "message");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.CustomerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("customer_id");
            entity.Property(e => e.EndInterrupt)
                .HasColumnType("datetime")
                .HasColumnName("end_interrupt");
            entity.Property(e => e.Enddate)
                .HasColumnType("datetime")
                .HasColumnName("enddate");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.SiteId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("site_id");
            entity.Property(e => e.StartInterrupt)
                .HasColumnType("datetime")
                .HasColumnName("start_interrupt");
            entity.Property(e => e.Startdate)
                .HasColumnType("datetime")
                .HasColumnName("startdate");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("subject");
        });

        modelBuilder.Entity<AlarmDescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("alarm_description");

            entity.HasIndex(e => e.Alarm, "unique").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Alarm).HasColumnName("alarm");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
        });

        modelBuilder.Entity<AlarmType>(entity =>
        {
            entity.HasKey(e => e.AlarmTypeId).HasName("PRIMARY");

            entity.ToTable("alarm_type");

            entity.Property(e => e.AlarmTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("alarm_type_id");
            entity.Property(e => e.AlarmTypeDescription)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("alarm_type_description");
            entity.Property(e => e.AlarmTypeTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("alarm_type_title");
            entity.Property(e => e.Inactive)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.Remark)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("remark");
        });

        modelBuilder.Entity<AlertProfile>(entity =>
        {
            entity.HasKey(e => e.AlertProfileId).HasName("PRIMARY");

            entity.ToTable("alert_profile");

            entity.HasIndex(e => e.ModuleId, "alert_profile_un").IsUnique();

            entity.Property(e => e.AlertProfileId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("alert_profile_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.ProfileName)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("profile_name");
        });

        modelBuilder.Entity<AlertProfileDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("alert_profile_detail");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.EmailTemplateStaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("email_template_staff_id");
            entity.Property(e => e.EmailTemplateUserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("email_template_user_id");
            entity.Property(e => e.IsSendEmailStaff)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_send_email_staff");
            entity.Property(e => e.IsSendEmailUser)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_send_email_user");
            entity.Property(e => e.IsSendSmsStaff)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_send_sms_staff");
            entity.Property(e => e.IsSendSmsUser)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_send_sms_user");
            entity.Property(e => e.ProfileId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("profile_id");
            entity.Property(e => e.SmsTemplateStaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sms_template_staff_id");
            entity.Property(e => e.SmsTemplateUserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sms_template_user_id");
            entity.Property(e => e.StatusId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("status_id");
        });

        modelBuilder.Entity<AlertType>(entity =>
        {
            entity.HasKey(e => e.AlertTypeId).HasName("PRIMARY");

            entity.ToTable("alert_type");

            entity.Property(e => e.AlertTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("alert_type_id");
            entity.Property(e => e.AlertTypeTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("alert_type_title");
        });

        modelBuilder.Entity<Amphur>(entity =>
        {
            entity.HasKey(e => e.AmphurId).HasName("PRIMARY");

            entity.ToTable("amphur");

            entity.HasIndex(e => e.CountryId, "FK_amphur_country");

            entity.HasIndex(e => e.GeoId, "FK_amphur_geography");

            entity.HasIndex(e => e.ProvinceId, "FK_amphur_province");

            entity.Property(e => e.AmphurId)
                .HasColumnType("int(5)")
                .HasColumnName("AMPHUR_ID");
            entity.Property(e => e.AmphurCode)
                .HasMaxLength(10)
                .HasColumnName("AMPHUR_CODE");
            entity.Property(e => e.AmphurName)
                .HasMaxLength(150)
                .HasColumnName("AMPHUR_NAME");
            entity.Property(e => e.AmphurNameEn)
                .HasMaxLength(150)
                .HasDefaultValueSql("''")
                .HasColumnName("AMPHUR_NAME_EN");
            entity.Property(e => e.CountryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("COUNTRY_ID");
            entity.Property(e => e.GeoId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("GEO_ID");
            entity.Property(e => e.ProvinceId)
                .HasColumnType("int(5)")
                .HasColumnName("PROVINCE_ID");
        });

        modelBuilder.Entity<AnalyticalWhatif>(entity =>
        {
            entity.HasKey(e => e.WhatifId).HasName("PRIMARY");

            entity.ToTable("analytical_whatif");

            entity.Property(e => e.WhatifId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("whatif_id");
            entity.Property(e => e.Assumption)
                .HasColumnType("text")
                .HasColumnName("assumption");
            entity.Property(e => e.Consideration)
                .HasColumnType("text")
                .HasColumnName("consideration");
            entity.Property(e => e.Dependencie)
                .HasColumnType("text")
                .HasColumnName("dependencie");
            entity.Property(e => e.Lever)
                .HasColumnType("text")
                .HasColumnName("lever");
            entity.Property(e => e.WhatifSequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("whatif_sequence");
        });

        modelBuilder.Entity<Associated>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("associated");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.DstId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("dst_id");
            entity.Property(e => e.ModuleDstId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_dst_id");
            entity.Property(e => e.ModuleSrcId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_src_id");
            entity.Property(e => e.SrcId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("src_id");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<AssociatedMonitoring>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("associated_monitoring");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.DstId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("dst_id");
            entity.Property(e => e.ModuleDstId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_dst_id");
            entity.Property(e => e.ModuleSrcId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_src_id");
            entity.Property(e => e.SrcId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("src_id");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<AttachmentType>(entity =>
        {
            entity.HasKey(e => e.AttachmentTypeId).HasName("PRIMARY");

            entity.ToTable("attachment_type");

            entity.Property(e => e.AttachmentTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("attachment_type_id");
            entity.Property(e => e.AttachmentTypeTitle)
                .HasMaxLength(45)
                .HasColumnName("attachment_type_title");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
        });

        modelBuilder.Entity<AuthenticationSource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("authentication_source");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.BaseDn)
                .HasMaxLength(1000)
                .HasDefaultValueSql("''")
                .HasColumnName("base_dn");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_date");
            entity.Property(e => e.EnableTls)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("enable_tls");
            entity.Property(e => e.Inactive)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("inactive");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.ServerName)
                .HasMaxLength(45)
                .HasColumnName("server_name");
            entity.Property(e => e.ServerPort)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("server_port");
            entity.Property(e => e.SourceAdditional)
                .HasMaxLength(1000)
                .HasColumnName("source_additional");
            entity.Property(e => e.SourceAnonymous)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("source_anonymous");
            entity.Property(e => e.SourceIdentifier)
                .HasMaxLength(45)
                .HasColumnName("source_identifier");
            entity.Property(e => e.SourceName)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("source_name");
            entity.Property(e => e.SourceProvider)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("source_provider");
            entity.Property(e => e.SourceVersion)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("source_version");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");
        });

        modelBuilder.Entity<AutoReportSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("auto_report_setting");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Report)
                .HasMaxLength(255)
                .HasColumnName("report");
            entity.Property(e => e.ReportType)
                .HasMaxLength(45)
                .HasColumnName("report_type");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.Value)
                .HasMaxLength(2000)
                .HasColumnName("value");
        });

        modelBuilder.Entity<BooleanTranslate>(entity =>
        {
            entity.HasKey(e => e.BooleanText).HasName("PRIMARY");

            entity.ToTable("boolean_translate");

            entity.HasIndex(e => e.BooleanValue, "boolean_value");

            entity.Property(e => e.BooleanText)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("boolean_text");
            entity.Property(e => e.BooleanValue).HasColumnName("boolean_value");
        });

        modelBuilder.Entity<BusinessHour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("business_hour");

            entity.HasIndex(e => e.ProfileId, "profile_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Close)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("close");
            entity.Property(e => e.Day)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("day");
            entity.Property(e => e.Open)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("open");
            entity.Property(e => e.ProfileId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("profile_id");
            entity.Property(e => e.WorkDay)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("work_day");

            entity.HasOne(d => d.Profile).WithMany(p => p.BusinessHour)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_business_hour_business_hours_profile");
        });

        modelBuilder.Entity<BusinessHoursProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("business_hours_profile");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.BusinessHoursTitle)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("business_hours_title");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_date");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.Inactive)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("inactive");
        });

        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("calendar");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Allday)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("allday");
            entity.Property(e => e.Body)
                .HasColumnType("text")
                .HasColumnName("body");
            entity.Property(e => e.CType)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("c_type");
            entity.Property(e => e.CaseRef)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_ref");
            entity.Property(e => e.Color)
                .HasMaxLength(45)
                .HasColumnName("color");
            entity.Property(e => e.Column)
                .HasMaxLength(20)
                .HasColumnName("column");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Email)
                .HasMaxLength(1)
                .HasColumnName("email");
            entity.Property(e => e.End)
                .HasColumnType("datetime")
                .HasColumnName("end");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .HasColumnName("location");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Recurrence)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("recurrence");
            entity.Property(e => e.Restrict)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("restrict");
            entity.Property(e => e.RoomId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("room_id");
            entity.Property(e => e.Sms)
                .HasMaxLength(1)
                .HasColumnName("sms");
            entity.Property(e => e.Start)
                .HasColumnType("datetime")
                .HasColumnName("start");
            entity.Property(e => e.WebexReserve)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("webex_reserve");
        });

        modelBuilder.Entity<CalendarStaff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("calendar_staff");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CalendarId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("calendar_id");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("PRIMARY");

            entity.ToTable("card");

            entity.Property(e => e.CardId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("card_id");
            entity.Property(e => e.CardDescription)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("card_description");
            entity.Property(e => e.CardTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("card_title");
            entity.Property(e => e.Inactive)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("inactive");
            entity.Property(e => e.Remark)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("remark");
        });

        modelBuilder.Entity<CardAlarmType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("card_alarm_type");

            entity.Property(e => e.AlarmTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("alarm_type_id");
            entity.Property(e => e.CardId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("card_id");
        });

        modelBuilder.Entity<CaseAsset>(entity =>
        {
            entity.HasKey(e => new { e.CaseId, e.AssetId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("case_asset");

            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.AssetId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("asset_id");
        });

        modelBuilder.Entity<CaseAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("case_attachment");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AttachmentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("attachment_id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.CaseLogId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_id");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
        });

        modelBuilder.Entity<CaseCategory>(entity =>
        {
            entity.HasKey(e => e.CaseCategoryId).HasName("PRIMARY");

            entity.ToTable("case_category");

            entity.HasIndex(e => e.CaseTypeId, "case_type_id");

            entity.HasIndex(e => new { e.CaseCategoryTitle, e.CaseTypeId }, "unique").IsUnique();

            entity.Property(e => e.CaseCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_category_id");
            entity.Property(e => e.CaseCategoryTitle)
                .HasMaxLength(225)
                .HasDefaultValueSql("''")
                .HasColumnName("case_category_title");
            entity.Property(e => e.CaseTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_type_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
        });

        modelBuilder.Entity<CaseIdFormat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("case_id_format");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseIdFormat1)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("case_id_format");
            entity.Property(e => e.CaseIdTitle)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("case_id_title");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
        });

        modelBuilder.Entity<CaseLog>(entity =>
        {
            entity.HasKey(e => e.CaseLogId).HasName("PRIMARY");

            entity.ToTable("case_log");

            entity.HasIndex(e => e.CaseId, "case_id");

            entity.HasIndex(e => e.CaseLogCategoryId, "case_log_category_id");

            entity.HasIndex(e => e.CaseLogTypeId, "case_log_type_id");

            entity.Property(e => e.CaseLogId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.CaseLogCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_category_id");
            entity.Property(e => e.CaseLogDescription).HasColumnName("case_log_description");
            entity.Property(e => e.CaseLogTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_type_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("date");
            entity.Property(e => e.LoggedBy)
                .HasMaxLength(32)
                .HasDefaultValueSql("'0'")
                .HasColumnName("logged_by");
            entity.Property(e => e.Reference)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("reference");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("'00:00:00'")
                .HasColumnType("time")
                .HasColumnName("time");

            entity.HasOne(d => d.CaseLogType).WithMany(p => p.CaseLog)
                .HasForeignKey(d => d.CaseLogTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_case_log_type_id");
        });

        modelBuilder.Entity<CaseLogCategory>(entity =>
        {
            entity.HasKey(e => e.CaseLogCategoryId).HasName("PRIMARY");

            entity.ToTable("case_log_category");

            entity.HasIndex(e => e.CaseLogCategoryTitle, "unique").IsUnique();

            entity.Property(e => e.CaseLogCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_category_id");
            entity.Property(e => e.CaseLogCategoryTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("case_log_category_title");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
        });

        modelBuilder.Entity<CaseLogDeleted>(entity =>
        {
            entity.HasKey(e => e.CaseLogId).HasName("PRIMARY");

            entity.ToTable("case_log_deleted");

            entity.HasIndex(e => e.CaseId, "case_id");

            entity.HasIndex(e => e.CaseLogCategoryId, "case_log_category_id");

            entity.HasIndex(e => e.CaseLogTypeId, "case_log_type_id");

            entity.Property(e => e.CaseLogId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.CaseLogCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_category_id");
            entity.Property(e => e.CaseLogDescription)
                .HasColumnType("text")
                .HasColumnName("case_log_description");
            entity.Property(e => e.CaseLogTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_type_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("date");
            entity.Property(e => e.LoggedBy)
                .HasMaxLength(32)
                .HasDefaultValueSql("'0'")
                .HasColumnName("logged_by");
            entity.Property(e => e.Reference)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("reference");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("'00:00:00'")
                .HasColumnType("time")
                .HasColumnName("time");
        });

        modelBuilder.Entity<CaseLogType>(entity =>
        {
            entity.HasKey(e => e.CaseLogTypeId).HasName("PRIMARY");

            entity.ToTable("case_log_type");

            entity.HasIndex(e => e.CaseLogCategoryId, "FK_case_log_category");

            entity.HasIndex(e => e.CaseLogTypeTitle, "unique").IsUnique();

            entity.Property(e => e.CaseLogTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_type_id");
            entity.Property(e => e.CaseLogCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_category_id");
            entity.Property(e => e.CaseLogTypeTitle)
                .HasDefaultValueSql("''")
                .HasColumnName("case_log_type_title");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");

            entity.HasOne(d => d.CaseLogCategory).WithMany(p => p.CaseLogType)
                .HasForeignKey(d => d.CaseLogCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_case_log_category");
        });

        modelBuilder.Entity<CaseStatus>(entity =>
        {
            entity.HasKey(e => e.CaseStatusId).HasName("PRIMARY");

            entity.ToTable("case_status");

            entity.Property(e => e.CaseStatusId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_status_id");
            entity.Property(e => e.CaseStatusTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("case_status_title");
            entity.Property(e => e.Color)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("color");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("''")
                .HasColumnType("text")
                .HasColumnName("description");
        });

        modelBuilder.Entity<CaseSubCategory>(entity =>
        {
            entity.HasKey(e => e.CaseSubCategoryId).HasName("PRIMARY");

            entity.ToTable("case_sub_category");

            entity.HasIndex(e => new { e.CaseSubCategoryTitle, e.CaseCategoryId }, "unique").IsUnique();

            entity.Property(e => e.CaseSubCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_sub_category_id");
            entity.Property(e => e.CaseCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_category_id");
            entity.Property(e => e.CaseSubCategoryTitle)
                .HasMaxLength(150)
                .HasColumnName("case_sub_category_title");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
        });

        modelBuilder.Entity<CaseType>(entity =>
        {
            entity.HasKey(e => e.CaseTypeId).HasName("PRIMARY");

            entity.ToTable("case_type");

            entity.HasIndex(e => e.CaseTypeId, "case_type_id");

            entity.HasIndex(e => e.Inactive, "inactive");

            entity.Property(e => e.CaseTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_type_id");
            entity.Property(e => e.CaseTypeDescription)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("case_type_description");
            entity.Property(e => e.CaseTypeTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("case_type_title");
            entity.Property(e => e.ImageName).HasColumnName("image_name");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.IsAlert)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_alert");
            entity.Property(e => e.OwnerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("owner_id");
            entity.Property(e => e.TeamId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("team_id");
        });

        modelBuilder.Entity<CaseTypeCustom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("case_type_custom");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.FieldName)
                .HasMaxLength(30)
                .HasColumnName("field_name");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.LabelName)
                .HasMaxLength(50)
                .HasColumnName("label_name");
        });

        modelBuilder.Entity<CaseTypeCustomSetup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("case_type_custom_setup");

            entity.HasIndex(e => e.CaseTypeId, "case_type_id").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_type_id");
            entity.Property(e => e.MandatoryField)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("mandatory_field");
            entity.Property(e => e.OptionalField)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("optional_field");
        });

        modelBuilder.Entity<CategoryIcon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category_icon");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_category_id");
            entity.Property(e => e.CaseSubCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_sub_category_id");
            entity.Property(e => e.ImageName)
                .HasMaxLength(255)
                .HasDefaultValueSql("'applications.png'")
                .HasColumnName("image_name");
        });

        modelBuilder.Entity<CauseBy>(entity =>
        {
            entity.HasKey(e => e.CauseById).HasName("PRIMARY");

            entity.ToTable("cause_by");

            entity.Property(e => e.CauseById)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("cause_by_id");
            entity.Property(e => e.CauseByTitle)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("cause_by_title");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.Inactive)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.SlaAffected)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("sla_affected");
        });

        modelBuilder.Entity<ChangePassword>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("change_password");

            entity.HasIndex(e => e.Date, "date");

            entity.HasIndex(e => e.Username, "username");

            entity.Property(e => e.Date)
                .HasMaxLength(10)
                .HasColumnName("date");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Time)
                .HasMaxLength(10)
                .HasColumnName("time");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<ChatCopilot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("chat_copilot");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Answer)
                .HasDefaultValueSql("''")
                .HasColumnName("answer");
            entity.Property(e => e.Question)
                .HasDefaultValueSql("''")
                .HasColumnName("question");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<ClosureType>(entity =>
        {
            entity.HasKey(e => e.ClosureTypeId).HasName("PRIMARY");

            entity.ToTable("closure_type");

            entity.HasIndex(e => e.ClosureTypeTitle, "unique").IsUnique();

            entity.Property(e => e.ClosureTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("closure_type_id");
            entity.Property(e => e.ClosureTypeTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("closure_type_title");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
        });

        modelBuilder.Entity<CmsSwitchLocationService>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cms_switch_location_service");

            entity.HasIndex(e => e.Facility, "facility");

            entity.HasIndex(e => e.Node, "node");

            entity.HasIndex(e => e.Rack, "rack");

            entity.HasIndex(e => e.Room, "room");

            entity.HasIndex(e => e.Service, "service");

            entity.Property(e => e.Facility)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("facility");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("ip");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("model");
            entity.Property(e => e.Node)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("node");
            entity.Property(e => e.Port)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("port");
            entity.Property(e => e.Portid)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("portid");
            entity.Property(e => e.Rack)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("rack");
            entity.Property(e => e.Room)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("room");
            entity.Property(e => e.Service)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("service");
        });

        modelBuilder.Entity<Collaboration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("collaboration");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Attach).HasColumnName("attach");
            entity.Property(e => e.Datetime)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("datetime");
            entity.Property(e => e.Isdelete)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("isdelete");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.Room)
                .HasMaxLength(45)
                .HasColumnName("room");
            entity.Property(e => e.Staffid)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staffid");
        });

        modelBuilder.Entity<Compliant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("compliant");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.Sequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sequence");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Config>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("config");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.DomainName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("domain_name");
            entity.Property(e => e.Product)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NetkaQuartz Service Desk'")
                .HasColumnName("product");
            entity.Property(e => e.ProductKey)
                .HasMaxLength(128)
                .HasDefaultValueSql("''")
                .HasColumnName("product_key");
            entity.Property(e => e.Satisfaction)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("satisfaction");
            entity.Property(e => e.ServerIp)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("server_ip");
            entity.Property(e => e.SmsMessageKeyword)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("sms_message_keyword");
            entity.Property(e => e.SmsNumberKeyword)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("sms_number_keyword");
            entity.Property(e => e.SmsPassword)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("sms_password");
            entity.Property(e => e.SmsPasswordKeyword)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("sms_password_keyword");
            entity.Property(e => e.SmsProtocol)
                .HasMaxLength(45)
                .HasDefaultValueSql("'POST'")
                .HasColumnName("sms_protocol");
            entity.Property(e => e.SmsResult)
                .HasMaxLength(45)
                .HasDefaultValueSql("'OK'")
                .HasColumnName("sms_result");
            entity.Property(e => e.SmsUrl)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("sms_url");
            entity.Property(e => e.SmsUserKeyword)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("sms_user_keyword");
            entity.Property(e => e.SmsUsername)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("sms_username");
            entity.Property(e => e.SmtpAuth)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("smtp_auth");
            entity.Property(e => e.SmtpPassword)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("smtp_password");
            entity.Property(e => e.SmtpSender)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("smtp_sender");
            entity.Property(e => e.SmtpServer)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("smtp_server");
            entity.Property(e => e.WindowsPassword)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("windows_password");
            entity.Property(e => e.WindowsServerName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("windows_server_name");
            entity.Property(e => e.WindowsUsername)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("windows_username");
        });

        modelBuilder.Entity<ConfigAlertRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("config_alert_role");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.QueryStaff)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("query_staff");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<ConfigAlertTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("config_alert_template");

            entity.HasIndex(e => new { e.ModuleId, e.CaseLogTypeId, e.CaseStatusId, e.AlertTypeId }, "config_alert_template_un").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AlertTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("alert_type_id");
            entity.Property(e => e.CaseLogTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_type_id");
            entity.Property(e => e.CaseStatusId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_status_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.IsSendStaff).HasColumnName("is_send_staff");
            entity.Property(e => e.IsSendUser).HasColumnName("is_send_user");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.TemplateStaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("template_staff_id");
            entity.Property(e => e.TemplateUserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("template_user_id");
        });

        modelBuilder.Entity<ConfigAlertTemplateRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("config_alert_template_role");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AlertRoleId)
                .HasMaxLength(100)
                .HasDefaultValueSql("'0'")
                .HasColumnName("alert_role_id");
            entity.Property(e => e.ConfigLertTemplateId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("config_lert_template_id");
            entity.Property(e => e.TemplateId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("template_id");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PRIMARY");

            entity.ToTable("contact");

            entity.HasIndex(e => e.CustomerId, "customer_id");

            entity.HasIndex(e => e.GenderId, "gender_id");

            entity.HasIndex(e => e.PrefixId, "prefix_id");

            entity.HasIndex(e => e.SiteId, "site_id");

            entity.HasIndex(e => new { e.Firstname, e.Lastname }, "unique").IsUnique();

            entity.Property(e => e.ContactId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contact_id");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.CustomerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("customer_id");
            entity.Property(e => e.Department)
                .HasMaxLength(100)
                .HasColumnName("department");
            entity.Property(e => e.Email)
                .HasMaxLength(1000)
                .HasColumnName("email");
            entity.Property(e => e.Fax)
                .HasMaxLength(45)
                .HasColumnName("fax");
            entity.Property(e => e.Firstname)
                .HasMaxLength(150)
                .HasDefaultValueSql("''")
                .HasColumnName("firstname");
            entity.Property(e => e.GenderId)
                .HasColumnType("int(10) unsigned zerofill")
                .HasColumnName("gender_id");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.InactiveChatbot)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive_chatbot");
            entity.Property(e => e.Lastname)
                .HasMaxLength(150)
                .HasDefaultValueSql("''")
                .HasColumnName("lastname");
            entity.Property(e => e.Mobile)
                .HasMaxLength(45)
                .HasColumnName("mobile");
            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .HasColumnName("phone");
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .HasColumnName("position");
            entity.Property(e => e.PrefixId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("prefix_id");
            entity.Property(e => e.ProfileImage).HasColumnName("profile_image");
            entity.Property(e => e.SiteId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("site_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Contact)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("customer_id");

            entity.HasOne(d => d.Prefix).WithMany(p => p.Contact)
                .HasForeignKey(d => d.PrefixId)
                .HasConstraintName("prefix_id");

            entity.HasOne(d => d.Site).WithMany(p => p.Contact)
                .HasForeignKey(d => d.SiteId)
                .HasConstraintName("site_id");
        });

        modelBuilder.Entity<ContactChannel>(entity =>
        {
            entity.HasKey(e => e.ContactChannelId).HasName("PRIMARY");

            entity.ToTable("contact_channel");

            entity.Property(e => e.ContactChannelId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contact_channel_id");
            entity.Property(e => e.ContactChannelSequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contact_channel_sequence");
            entity.Property(e => e.ContactChannelTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("contact_channel_title");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
        });

        modelBuilder.Entity<ContactProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contact_profile");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CalendarNoti)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("calendar_noti");
            entity.Property(e => e.ContactId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contact_id");
            entity.Property(e => e.MenuId)
                .HasColumnType("int(11)")
                .HasColumnName("menu_id");
            entity.Property(e => e.PrivateMsgNoti)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("private_msg_noti");
            entity.Property(e => e.TaskAssignNoti)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("task_assign_noti");
            entity.Property(e => e.TaskEscalationNoti)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("task_escalation_noti");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PRIMARY");

            entity.ToTable("contract");

            entity.HasIndex(e => e.EmailProfileId, "FK_contract_email_profile");

            entity.HasIndex(e => e.SaleId, "FK_contract_staff");

            entity.HasIndex(e => e.CustomerId, "customer_id");

            entity.HasIndex(e => e.SlaId, "sla_id");

            entity.Property(e => e.ContractId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contract_id");
            entity.Property(e => e.Availability).HasColumnName("availability");
            entity.Property(e => e.ContractCode)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("contract_code");
            entity.Property(e => e.ContractTitle)
                .HasMaxLength(100)
                .HasColumnName("contract_title");
            entity.Property(e => e.CustomerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("customer_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EmailProfileId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("email_profile_id");
            entity.Property(e => e.Expire)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("expire");
            entity.Property(e => e.ExpireAlert)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("expire_alert");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.SaleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sale_id");
            entity.Property(e => e.SlaId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sla_id");
            entity.Property(e => e.Start)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("start");
        });

        modelBuilder.Entity<ContractAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contract_attachment");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ContractId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contract_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.File)
                .HasDefaultValueSql("''")
                .HasColumnName("file");
            entity.Property(e => e.FileName)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("file_name");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
        });

        modelBuilder.Entity<ContractAttachmentOld>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contract_attachment_old");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Filelink)
                .HasMaxLength(255)
                .HasColumnName("filelink");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        modelBuilder.Entity<ContractCustomField>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contract_custom_field");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ContractCustomFieldId)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("contract_custom_field_id");
            entity.Property(e => e.ContractCustomFieldValue)
                .HasColumnType("text")
                .HasColumnName("contract_custom_field_value");
            entity.Property(e => e.ContractId)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("contract_id");
        });

        modelBuilder.Entity<ContractCustomForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contract_custom_form");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.FormFieldJson).HasColumnName("form_field_json");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<ContractLogAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contract_log_attachment");

            entity.HasIndex(e => e.ContractId, "FK_contract_log_attachment_attachment_type");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AttachmentTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("attachment_type_id");
            entity.Property(e => e.ContractId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contract_id");
            entity.Property(e => e.ContractLogDescription)
                .HasMaxLength(255)
                .HasColumnName("contract_log_description");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.LoggedBy)
                .HasMaxLength(45)
                .HasColumnName("logged_by");
            entity.Property(e => e.Time)
                .HasColumnType("time")
                .HasColumnName("time");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("country");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.A2).HasMaxLength(2);
            entity.Property(e => e.A3).HasMaxLength(3);
            entity.Property(e => e.Country1)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Region)
                .HasMaxLength(20)
                .HasColumnName("region");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("currency");

            entity.HasIndex(e => e.CurrencyTitle, "unique").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CurrencyTitle)
                .HasMaxLength(45)
                .HasColumnName("currency_title");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Sequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sequence");
            entity.Property(e => e.Taxrate)
                .HasPrecision(5, 2)
                .HasColumnName("taxrate");
        });

        modelBuilder.Entity<CustomForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("custom_form");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.FormFieldJson).HasColumnName("form_field_json");
            entity.Property(e => e.ProfileName)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("profile_name");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<CustomFormField>(entity =>
        {
            entity.HasKey(e => e.CustomFormId).HasName("PRIMARY");

            entity.ToTable("custom_form_field");

            entity.Property(e => e.CustomFormId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("custom_form_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.FieldDisplay)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("field_display");
            entity.Property(e => e.FieldName)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("field_name");
            entity.Property(e => e.FieldTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("field_type_id");
            entity.Property(e => e.FuctionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("fuction_id");
            entity.Property(e => e.Hint)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("hint");
            entity.Property(e => e.IsRequired)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("is_required");
            entity.Property(e => e.OrderNum)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("order_num");
            entity.Property(e => e.PlaceHolder)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("place_holder");
            entity.Property(e => e.ServiceTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("service_type_id");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<CustomFormFieldValue>(entity =>
        {
            entity.HasKey(e => new { e.CustomFormFieldId, e.Value })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("custom_form_field_value");

            entity.Property(e => e.CustomFormFieldId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("custom_form_field_id");
            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("value");
            entity.Property(e => e.Lable)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("lable");
            entity.Property(e => e.OrderNum)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("order_num");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<CustomSurveyResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("custom_survey_result");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.Remark)
                .HasMaxLength(255)
                .HasColumnName("remark");
            entity.Property(e => e.Result)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("result");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<CustomSurveyValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("custom_survey_value");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Percentage)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("percentage");
            entity.Property(e => e.Title)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
            entity.Property(e => e.Value)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("value");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customer");

            entity.HasIndex(e => e.CustomerTypeId, "customer_type_id");

            entity.HasIndex(e => e.SectorId, "sector_id");

            entity.HasIndex(e => e.CustomerName, "unique").IsUnique();

            entity.Property(e => e.CustomerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("customer_id");
            entity.Property(e => e.CustomerCode)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("customer_code");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("customer_name");
            entity.Property(e => e.CustomerNameEn)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("customer_name_en");
            entity.Property(e => e.CustomerTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("customer_type_id");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.SectorId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sector_id");
        });

        modelBuilder.Entity<CustomerContact>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customer_contact");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("customer_id");
            entity.Property(e => e.ContactName)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("contact_name");
            entity.Property(e => e.ContactNameEn)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("contact_name_en");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("customer_name");
            entity.Property(e => e.Email)
                .HasColumnType("text")
                .HasColumnName("email");
            entity.Property(e => e.Email2)
                .HasColumnType("text")
                .HasColumnName("email2");
            entity.Property(e => e.Inactive)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.Remark)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("remark");
            entity.Property(e => e.Symbol)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("symbol");
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.HasKey(e => e.CustomerTypeId).HasName("PRIMARY");

            entity.ToTable("customer_type");

            entity.HasIndex(e => e.CustomerTypeTitle, "unique").IsUnique();

            entity.Property(e => e.CustomerTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("customer_type_id");
            entity.Property(e => e.CustomerTypeTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("customer_type_title");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Dataprotectionkeys>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dataprotectionkeys");

            entity.Property(e => e.Id).HasColumnType("int(11)");
        });

        modelBuilder.Entity<DatasourceConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("datasource_config");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(45)
                .HasColumnName("ip_address");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Port)
                .HasMaxLength(45)
                .HasColumnName("port");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PRIMARY");

            entity.ToTable("department");

            entity.HasIndex(e => e.DepartmentTitle, "unique").IsUnique();

            entity.Property(e => e.DepartmentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("department_id");
            entity.Property(e => e.DepartmentSequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("department_sequence");
            entity.Property(e => e.DepartmentTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("department_title");
        });

        modelBuilder.Entity<EmailAutoIncidentSetup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("email_auto_incident_setup");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.MailServer)
                .HasMaxLength(45)
                .HasColumnName("mail_server");
            entity.Property(e => e.OpenKeyword)
                .HasMaxLength(45)
                .HasColumnName("open_keyword");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Port)
                .HasMaxLength(45)
                .HasColumnName("port");
            entity.Property(e => e.Secure)
                .HasMaxLength(45)
                .HasColumnName("secure");
            entity.Property(e => e.ServiceTypeTitle)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("service_type_title");
            entity.Property(e => e.User)
                .HasMaxLength(45)
                .HasColumnName("user");
        });

        modelBuilder.Entity<EmailProfile>(entity =>
        {
            entity.HasKey(e => e.EmailProfileId).HasName("PRIMARY");

            entity.ToTable("email_profile");

            entity.Property(e => e.EmailProfileId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("email_profile_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.ProfileName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("profile_name");
            entity.Property(e => e.TemplateTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("template_type_id");
        });

        modelBuilder.Entity<EmailProfileDetail>(entity =>
        {
            entity.HasKey(e => e.ProfileDetailId).HasName("PRIMARY");

            entity.ToTable("email_profile_detail");

            entity.Property(e => e.ProfileDetailId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("profile_detail_id");
            entity.Property(e => e.EmailTemplateId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("email_template_id");
            entity.Property(e => e.IsSendEmail)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_send_email");
            entity.Property(e => e.IsSendSms)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_send_sms");
            entity.Property(e => e.ProfileId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("profile_id");
            entity.Property(e => e.SmsTemplateId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sms_template_id");
            entity.Property(e => e.StatusId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("status_id");
        });

        modelBuilder.Entity<EmailSmsAlertTemp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("email_sms_alert_temp");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AlertType)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("alert_type");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.IsSent)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_sent");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.Remark)
                .HasMaxLength(500)
                .HasColumnName("remark");
            entity.Property(e => e.SendTo)
                .HasDefaultValueSql("''")
                .HasColumnType("text")
                .HasColumnName("send_to");
            entity.Property(e => e.SentDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("sent_date");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("status");
            entity.Property(e => e.Subject)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("subject");
        });

        modelBuilder.Entity<EmailSmsLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("email_sms_log");

            entity.HasIndex(e => e.CaseId, "case_id");

            entity.HasIndex(e => e.CaseLogId, "case_log_id");

            entity.HasIndex(e => e.ChangeId, "change_id");

            entity.HasIndex(e => e.ProblemId, "problem_id");

            entity.HasIndex(e => e.PvmId, "pvm_id");

            entity.HasIndex(e => e.SdId, "sd_id");

            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.CaseLogId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_id");
            entity.Property(e => e.ChangeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("change_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("date");
            entity.Property(e => e.Email)
                .HasColumnType("text")
                .HasColumnName("email");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("mobile");
            entity.Property(e => e.ProblemId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("problem_id");
            entity.Property(e => e.PvmId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("pvm_id");
            entity.Property(e => e.Remark)
                .HasColumnType("text")
                .HasColumnName("remark");
            entity.Property(e => e.SdId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sd_id");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("'00:00:00'")
                .HasColumnType("time")
                .HasColumnName("time");
        });

        modelBuilder.Entity<EmailSmsLogTemp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("email_sms_log_temp");

            entity.HasIndex(e => e.CaseId, "case_id");

            entity.HasIndex(e => e.CaseLogId, "case_log_id");

            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.CaseLogId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("date");
            entity.Property(e => e.Email)
                .HasColumnType("text")
                .HasColumnName("email");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("mobile");
            entity.Property(e => e.Remark)
                .HasColumnType("text")
                .HasColumnName("remark");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("'00:00:00'")
                .HasColumnType("time")
                .HasColumnName("time");
        });

        modelBuilder.Entity<EmailTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("email_template");

            entity.HasIndex(e => e.TemplateTypeId, "FK_email_template_email_template_type");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ImgFooter)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("img_footer");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.Subject)
                .HasColumnType("text")
                .HasColumnName("subject");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("template_name");
            entity.Property(e => e.TemplateTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("template_type_id");

            entity.HasOne(d => d.TemplateType).WithMany(p => p.EmailTemplate)
                .HasForeignKey(d => d.TemplateTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_email_template_email_template_type");
        });

        modelBuilder.Entity<EmailTemplateType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("email_template_type");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.TemplateType)
                .HasMaxLength(45)
                .HasColumnName("template_type");
        });

        modelBuilder.Entity<EmailTemplateVariable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("email_template_variable");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.FieldName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("field_name");
            entity.Property(e => e.MappingControlName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("mapping_control_name");
            entity.Property(e => e.ServiceTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("service_type_id");
            entity.Property(e => e.TemplateType)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("template_type");
            entity.Property(e => e.VariableName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("variable_name");
        });

        modelBuilder.Entity<FaqCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("faq_category");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CategoryTitle)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("category_title");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.Favicon)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("favicon");
        });

        modelBuilder.Entity<FaqDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("faq_detail");

            entity.HasIndex(e => e.CategoryId, "FK_faq_detail_category");

            entity.HasIndex(e => new { e.Quastion, e.Answer }, "FullText").HasAnnotation("MySql:FullTextIndex", true);

            entity.HasIndex(e => e.Quastion, "quastion").HasAnnotation("MySql:FullTextIndex", true);

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Answer)
                .HasDefaultValueSql("''")
                .HasColumnType("longtext")
                .HasColumnName("answer");
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("category_id");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_date");
            entity.Property(e => e.DislikeCount)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("dislike_count");
            entity.Property(e => e.LikeCount)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("like_count");
            entity.Property(e => e.Quastion)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("quastion");
            entity.Property(e => e.Stat)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("stat");
            entity.Property(e => e.Tags)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("tags");
        });

        modelBuilder.Entity<FaqHelpfulLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("faq_helpful_log");

            entity.HasIndex(e => new { e.FaqId, e.Username }, "knowledgebase_helpful_log_un").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Dislike).HasColumnName("dislike");
            entity.Property(e => e.FaqId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("faq_id");
            entity.Property(e => e.Like).HasColumnName("like");
            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .HasDefaultValueSql("''")
                .HasColumnName("username");
        });

        modelBuilder.Entity<FileServer>(entity =>
        {
            entity.HasKey(e => e.FsId).HasName("PRIMARY");

            entity.ToTable("file_server");

            entity.Property(e => e.FsId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("fs_id");
            entity.Property(e => e.Filelink)
                .HasMaxLength(255)
                .HasColumnName("filelink");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        modelBuilder.Entity<FileServerPriv>(entity =>
        {
            entity.HasKey(e => e.FspId).HasName("PRIMARY");

            entity.ToTable("file_server_priv");

            entity.HasIndex(e => e.FsId, "fs_id");

            entity.Property(e => e.FspId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("fsp_id");
            entity.Property(e => e.ContactId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contact_id");
            entity.Property(e => e.FsId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("fs_id");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
        });

        modelBuilder.Entity<FileValidation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("file_validation");

            entity.HasIndex(e => new { e.FileExtension, e.DecSignature }, "ukey").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.DecSignature)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("dec_signature");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.FileExtension)
                .HasMaxLength(5)
                .HasColumnName("file_extension");
            entity.Property(e => e.HexSignature)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("hex_signature");
            entity.Property(e => e.Validate)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("validate");
        });

        modelBuilder.Entity<FoundFaultBy>(entity =>
        {
            entity.HasKey(e => e.FoundFaultById).HasName("PRIMARY");

            entity.ToTable("found_fault_by");

            entity.Property(e => e.FoundFaultById)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("found_fault_by_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.FoundFaultByTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("found_fault_by_title");
            entity.Property(e => e.Inactive)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("inactive");
        });

        modelBuilder.Entity<FunctionPrivilege>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("function_privilege");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AllowClose).HasColumnName("allow_close");
            entity.Property(e => e.AllowCreate).HasColumnName("allow_create");
            entity.Property(e => e.AllowDelete).HasColumnName("allow_delete");
            entity.Property(e => e.AllowEdit).HasColumnName("allow_edit");
            entity.Property(e => e.AllowExport).HasColumnName("allow_export");
            entity.Property(e => e.AllowPrint).HasColumnName("allow_print");
            entity.Property(e => e.AllowPriority).HasColumnName("allow_priority");
            entity.Property(e => e.AllowReadOnly).HasColumnName("allow_read_only");
            entity.Property(e => e.AllowReview).HasColumnName("allow_review");
            entity.Property(e => e.LevelId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("level_id");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
        });

        modelBuilder.Entity<FunctionPrivilegeDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("function_privilege_detail");

            entity.Property(e => e.AllowClose).HasDefaultValueSql("'0'");
            entity.Property(e => e.AllowCreate).HasDefaultValueSql("'0'");
            entity.Property(e => e.AllowDelete).HasDefaultValueSql("'0'");
            entity.Property(e => e.AllowEdit).HasDefaultValueSql("'0'");
            entity.Property(e => e.AllowExport).HasDefaultValueSql("'0'");
            entity.Property(e => e.AllowPrint).HasDefaultValueSql("'0'");
            entity.Property(e => e.AllowPriority).HasDefaultValueSql("'0'");
            entity.Property(e => e.AllowReadOnly).HasDefaultValueSql("'0'");
            entity.Property(e => e.AllowReview).HasDefaultValueSql("'0'");
            entity.Property(e => e.AllowShare).HasDefaultValueSql("'0'");
            entity.Property(e => e.Id)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.LevelId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("LevelID");
            entity.Property(e => e.LevelName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ModuleID");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PRIMARY");

            entity.ToTable("gender");

            entity.HasIndex(e => e.GenderTitle, "unique").IsUnique();

            entity.Property(e => e.GenderId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("gender_id");
            entity.Property(e => e.GenderSequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("gender_sequence");
            entity.Property(e => e.GenderTitle)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("gender_title");
        });

        modelBuilder.Entity<GeneralChoice>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("general_choice");

            entity.Property(e => e.Answer)
                .HasColumnType("text")
                .HasColumnName("answer");
            entity.Property(e => e.QuestionChoice)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("question_choice");
            entity.Property(e => e.QuestionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("question_id");
        });

        modelBuilder.Entity<GeneralQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PRIMARY");

            entity.ToTable("general_question");

            entity.Property(e => e.QuestionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("question_id");
            entity.Property(e => e.OrderNum)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("order_num");
            entity.Property(e => e.Question)
                .HasColumnType("text")
                .HasColumnName("question");
        });

        modelBuilder.Entity<Geography>(entity =>
        {
            entity.HasKey(e => e.GeoId).HasName("PRIMARY");

            entity.ToTable("geography");

            entity.HasIndex(e => e.GeoName, "unique").IsUnique();

            entity.Property(e => e.GeoId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("GEO_ID");
            entity.Property(e => e.GeoName)
                .HasDefaultValueSql("''")
                .HasColumnName("GEO_NAME");
            entity.Property(e => e.GeoSequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("GEO_SEQUENCE");
        });

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.HasKey(e => e.HolidayId).HasName("PRIMARY");

            entity.ToTable("holiday");

            entity.HasIndex(e => e.ProfileId, "profile_id");

            entity.HasIndex(e => new { e.ProfileId, e.HolidayDescription, e.HolidayStartdate, e.HolidayEnddate }, "unique").IsUnique();

            entity.Property(e => e.HolidayId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("holiday_id");
            entity.Property(e => e.Fixed)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("fixed");
            entity.Property(e => e.HolidayDescription)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("holiday_description");
            entity.Property(e => e.HolidayEnddate)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("holiday_enddate");
            entity.Property(e => e.HolidayStartdate)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("holiday_startdate");
            entity.Property(e => e.ProfileId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("profile_id");

            entity.HasOne(d => d.Profile).WithMany(p => p.Holiday)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_holiday_business_hours_profile");
        });

        modelBuilder.Entity<Hour>(entity =>
        {
            entity.HasKey(e => e.Hour1).HasName("PRIMARY");

            entity.ToTable("hour");

            entity.Property(e => e.Hour1)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("hour");
        });

        modelBuilder.Entity<ImLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("im_log");

            entity.Property(e => e.CreateBy)
                .HasMaxLength(45)
                .HasColumnName("create_by");
            entity.Property(e => e.Date)
                .HasMaxLength(10)
                .HasColumnName("date");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.Time)
                .HasMaxLength(10)
                .HasColumnName("time");
        });

        modelBuilder.Entity<Impact>(entity =>
        {
            entity.HasKey(e => e.ImpactId).HasName("PRIMARY");

            entity.ToTable("impact");

            entity.HasIndex(e => e.ImpactTitle, "unique").IsUnique();

            entity.Property(e => e.ImpactId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("impact_id");
            entity.Property(e => e.AllowDelete)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("allow_delete");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ImpactSequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("impact_sequence");
            entity.Property(e => e.ImpactTitle)
                .HasMaxLength(45)
                .HasColumnName("impact_title");
        });

        modelBuilder.Entity<ImpactAffectedParties>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("impact_affected_parties");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.Organization)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("organization");
        });

        modelBuilder.Entity<ImpactAnalysis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("impact_analysis");

            entity.HasIndex(e => e.CaseId, "case_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("comment");
            entity.Property(e => e.IsAnalysis)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_analysis");
        });

        modelBuilder.Entity<ImpactCost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("impact_cost");

            entity.HasIndex(e => e.CaseId, "case_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.Item)
                .HasMaxLength(255)
                .HasColumnName("item");
            entity.Property(e => e.Quantity)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("quantity");
            entity.Property(e => e.TotalCost)
                .HasMaxLength(255)
                .HasColumnName("total_cost");
            entity.Property(e => e.Unit)
                .HasMaxLength(100)
                .HasColumnName("unit");
            entity.Property(e => e.UnitCost)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("unit_cost");
        });

        modelBuilder.Entity<ImpactDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("impact_detail");

            entity.HasIndex(e => e.CaseId, "case_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AffectedParties)
                .HasColumnType("text")
                .HasColumnName("affected_parties");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ServiceInterruption)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("service_interruption");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<ImpactSow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("impact_sow");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.Duration)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("duration");
            entity.Property(e => e.Item)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("item");
            entity.Property(e => e.SowId)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("sow_id");
        });

        modelBuilder.Entity<ImpactTime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("impact_time");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.Duration)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("duration");
            entity.Property(e => e.Task)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("task");
        });

        modelBuilder.Entity<Incident>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("incident");

            entity.HasIndex(e => e.CaseCategoryId, "case_category_id");

            entity.HasIndex(e => e.CaseStatusId, "case_status_id");

            entity.HasIndex(e => e.CaseSubCategoryId, "case_sub_category_id");

            entity.HasIndex(e => e.ContactId, "contact_id");

            entity.HasIndex(e => e.ContractId, "contract_id");

            entity.HasIndex(e => e.EngineerId, "engineer_id");

            entity.HasIndex(e => e.LocationId, "location_id");

            entity.HasIndex(e => e.OperatorId, "operator_id");

            entity.HasIndex(e => e.PriorityId, "priority_id");

            entity.HasIndex(e => e.RequestedDate, "requested_date");

            entity.HasIndex(e => e.SdId, "sd_id");

            entity.HasIndex(e => e.ServiceTypeId, "service_type_id");

            entity.HasIndex(e => e.SiteId, "site_id");

            entity.HasIndex(e => e.TeamId, "team_id");

            entity.HasIndex(e => e.TierId, "tier_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Approve)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("approve");
            entity.Property(e => e.ApproveBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("approve_by");
            entity.Property(e => e.CaseCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_category_id");
            entity.Property(e => e.CaseDescription).HasColumnName("case_description");
            entity.Property(e => e.CaseDuration)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_duration");
            entity.Property(e => e.CaseId)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("case_id");
            entity.Property(e => e.CaseIdFormat)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("case_id_format");
            entity.Property(e => e.CaseImportReference)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("case_import_reference");
            entity.Property(e => e.CaseStatusId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_status_id");
            entity.Property(e => e.CaseSubCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_sub_category_id");
            entity.Property(e => e.CaseTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_type_id");
            entity.Property(e => e.ClosedDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("closed_date");
            entity.Property(e => e.ClosureTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("closure_type_id");
            entity.Property(e => e.ContactChannelId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contact_channel_id");
            entity.Property(e => e.ContactDetail)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("contact_detail");
            entity.Property(e => e.ContactId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contact_id");
            entity.Property(e => e.ContractId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contract_id");
            entity.Property(e => e.CustomerCaseId)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("customer_case_id");
            entity.Property(e => e.Customfield1)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("customfield1");
            entity.Property(e => e.Customfield2)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("customfield2");
            entity.Property(e => e.Downtime)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("downtime");
            entity.Property(e => e.DueDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("due_date");
            entity.Property(e => e.Email)
                .HasColumnType("text")
                .HasColumnName("email");
            entity.Property(e => e.EnableAuditLog).HasColumnName("enable_audit_log");
            entity.Property(e => e.EnableWorkLog).HasColumnName("enable_work_log");
            entity.Property(e => e.EngineerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("engineer_id");
            entity.Property(e => e.IsKnowledge)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("is_knowledge");
            entity.Property(e => e.IsMandatory)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("is_mandatory");
            entity.Property(e => e.IsSevere)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("is_severe");
            entity.Property(e => e.IsSlaEffect)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_sla_effect");
            entity.Property(e => e.LocationCustomText)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("location_custom_text");
            entity.Property(e => e.LocationId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("location_id");
            entity.Property(e => e.NumReassign)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("num_reassign");
            entity.Property(e => e.OfficeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("office_id");
            entity.Property(e => e.OlaId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ola_id");
            entity.Property(e => e.OnsiteDuration)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("onsite_duration");
            entity.Property(e => e.OnsiteOverdue).HasColumnName("onsite_overdue");
            entity.Property(e => e.OperatorId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("operator_id");
            entity.Property(e => e.ParentCaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("parent_case_id");
            entity.Property(e => e.PendingStartDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("pending_start_date");
            entity.Property(e => e.PendingStopDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("pending_stop_date");
            entity.Property(e => e.PriorityId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("priority_id");
            entity.Property(e => e.ProblemId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("problem_id");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("reference");
            entity.Property(e => e.Remark)
                .HasColumnType("text")
                .HasColumnName("remark");
            entity.Property(e => e.ReportDetails)
                .HasDefaultValueSql("''")
                .HasColumnName("report_details");
            entity.Property(e => e.ReportTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("report_type_id");
            entity.Property(e => e.RequestedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("requested_date");
            entity.Property(e => e.ResolutionDetail).HasColumnName("resolution_detail");
            entity.Property(e => e.ResolutionTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("resolution_type_id");
            entity.Property(e => e.ResolveDuration)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("resolve_duration");
            entity.Property(e => e.ResolveOverdue).HasColumnName("resolve_overdue");
            entity.Property(e => e.ResolvedDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("resolved_date");
            entity.Property(e => e.ResponseDuration)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("response_duration");
            entity.Property(e => e.ResponseOverdue).HasColumnName("response_overdue");
            entity.Property(e => e.RfcId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("rfc_id");
            entity.Property(e => e.RiskId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("risk_id");
            entity.Property(e => e.SdId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sd_id");
            entity.Property(e => e.ServiceTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("service_type_id");
            entity.Property(e => e.Signature)
                .HasDefaultValueSql("''")
                .HasColumnName("signature");
            entity.Property(e => e.SiteId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("site_id");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.SymptomTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("symptom_type_id");
            entity.Property(e => e.Tags)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("tags");
            entity.Property(e => e.TeamId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("team_id");
            entity.Property(e => e.TierId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("tier_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
            entity.Property(e => e.Uptime)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("uptime");
            entity.Property(e => e.VendorCaseId)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("vendor_case_id");
        });

        modelBuilder.Entity<IncidentAssignmentRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("incident_assignment_rule");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_category_id");
            entity.Property(e => e.CaseSubCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_sub_category_id");
            entity.Property(e => e.EngineerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("engineer_id");
            entity.Property(e => e.ServiceCatalogId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("service_catalog_id");
            entity.Property(e => e.TeamId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("team_id");
            entity.Property(e => e.Title)
                .HasMaxLength(60)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<IncidentCaseTypeCustom>(entity =>
        {
            entity.HasKey(e => e.CaseId).HasName("PRIMARY");

            entity.ToTable("incident_case_type_custom");

            entity.HasIndex(e => e.CaseTypeId, "case_type_id");

            entity.Property(e => e.CaseId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.CaseTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_type_id");
            entity.Property(e => e.Customfield1)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("customfield1");
            entity.Property(e => e.Customfield2)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("customfield2");
            entity.Property(e => e.Customfield3)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("customfield3");
        });

        modelBuilder.Entity<IncidentChange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("incident_change");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ChangeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("change_id");
            entity.Property(e => e.IncidentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("incident_id");
            entity.Property(e => e.Linked)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("linked");
        });

        modelBuilder.Entity<IncidentCircuit>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("incident_circuit");

            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.CircuitId)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("circuit_id");
        });

        modelBuilder.Entity<IncidentCreateSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("incident_create_summary");

            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .HasColumnName("id");
            entity.Property(e => e.MonthName)
                .HasMaxLength(35)
                .HasColumnName("month_name");
            entity.Property(e => e.NumberOfCreatedcase)
                .HasColumnType("bigint(21)")
                .HasColumnName("number_of_createdcase");
        });

        modelBuilder.Entity<IncidentCustom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("incident_custom");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.FieldName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("field_name");
            entity.Property(e => e.LabelName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("label_name");
        });

        modelBuilder.Entity<IncidentCustomField>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("incident_custom_field");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.IncidentCustomFieldId)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("incident_custom_field_id");
            entity.Property(e => e.IncidentCustomFieldValue)
                .HasColumnType("text")
                .HasColumnName("incident_custom_field_value");
            entity.Property(e => e.IncidentId)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("incident_id");
        });

        modelBuilder.Entity<IncidentDashboardProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("incident_dashboard_profile");

            entity.HasIndex(e => new { e.Name, e.StaffId }, "incident_dashboard_profile_un").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("CREATE_BY");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("CREATE_DATE");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("IS_ACTIVE");
            entity.Property(e => e.JsonData)
                .HasDefaultValueSql("'[]'")
                .HasColumnName("JSON_DATA");
            entity.Property(e => e.JsonTemplate)
                .HasDefaultValueSql("'[]'")
                .HasColumnName("JSON_TEMPLATE");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("NAME");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("UPDATE_BY");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_DATE");
        });

        modelBuilder.Entity<IncidentDeleted>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("incident_deleted");

            entity.HasIndex(e => e.CaseId, "case_id");

            entity.HasIndex(e => e.CaseStatusId, "case_status_id");

            entity.HasIndex(e => e.CaseSubCategoryId, "case_sub_category_id");

            entity.HasIndex(e => e.ContactId, "contact_id");

            entity.HasIndex(e => e.ContractId, "contract_id");

            entity.HasIndex(e => e.EngineerId, "engineer_id");

            entity.HasIndex(e => e.LocationId, "location_id");

            entity.HasIndex(e => e.OperatorId, "operator_id");

            entity.HasIndex(e => e.PriorityId, "priority_id");

            entity.HasIndex(e => e.RequestedDate, "requested_date");

            entity.HasIndex(e => e.SdId, "sd_id");

            entity.HasIndex(e => e.ServiceTypeId, "service_type_id");

            entity.HasIndex(e => e.SiteId, "site_id");

            entity.HasIndex(e => e.TeamId, "team_id");

            entity.HasIndex(e => e.TierId, "tier_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Approve)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("approve");
            entity.Property(e => e.ApproveBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("approve_by");
            entity.Property(e => e.CaseDescription)
                .HasColumnType("text")
                .HasColumnName("case_description");
            entity.Property(e => e.CaseDuration)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_duration");
            entity.Property(e => e.CaseId)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("case_id");
            entity.Property(e => e.CaseIdFormat)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("case_id_format");
            entity.Property(e => e.CaseImportReference)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("case_import_reference");
            entity.Property(e => e.CaseStatusId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_status_id");
            entity.Property(e => e.CaseSubCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_sub_category_id");
            entity.Property(e => e.CaseTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_type_id");
            entity.Property(e => e.ClosedDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("closed_date");
            entity.Property(e => e.ClosureTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("closure_type_id");
            entity.Property(e => e.ContactChannelId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contact_channel_id");
            entity.Property(e => e.ContactDetail)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("contact_detail");
            entity.Property(e => e.ContactId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contact_id");
            entity.Property(e => e.ContractId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contract_id");
            entity.Property(e => e.CustomerCaseId)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("customer_case_id");
            entity.Property(e => e.Customfield1)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("customfield1");
            entity.Property(e => e.Customfield2)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("customfield2");
            entity.Property(e => e.Downtime)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("downtime");
            entity.Property(e => e.DueDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("due_date");
            entity.Property(e => e.Email)
                .HasColumnType("text")
                .HasColumnName("email");
            entity.Property(e => e.EnableAuditLog).HasColumnName("enable_audit_log");
            entity.Property(e => e.EnableWorkLog).HasColumnName("enable_work_log");
            entity.Property(e => e.EngineerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("engineer_id");
            entity.Property(e => e.IsKnowledge)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("is_knowledge");
            entity.Property(e => e.IsSlaEffect)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_sla_effect");
            entity.Property(e => e.LocationId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("location_id");
            entity.Property(e => e.OlaId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ola_id");
            entity.Property(e => e.OnsiteDuration)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("onsite_duration");
            entity.Property(e => e.OnsiteOverdue).HasColumnName("onsite_overdue");
            entity.Property(e => e.OperatorId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("operator_id");
            entity.Property(e => e.ParentCaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("parent_case_id");
            entity.Property(e => e.PendingStartDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("pending_start_date");
            entity.Property(e => e.PendingStopDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("pending_stop_date");
            entity.Property(e => e.PriorityId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("priority_id");
            entity.Property(e => e.ProblemId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("problem_id");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("reference");
            entity.Property(e => e.Remark)
                .HasColumnType("text")
                .HasColumnName("remark");
            entity.Property(e => e.RequestedDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("requested_date");
            entity.Property(e => e.ResolutionDetail).HasColumnName("resolution_detail");
            entity.Property(e => e.ResolutionTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("resolution_type_id");
            entity.Property(e => e.ResolveDuration)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("resolve_duration");
            entity.Property(e => e.ResolveOverdue).HasColumnName("resolve_overdue");
            entity.Property(e => e.ResolvedDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("resolved_date");
            entity.Property(e => e.ResponseDuration)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("response_duration");
            entity.Property(e => e.ResponseOverdue).HasColumnName("response_overdue");
            entity.Property(e => e.RfcId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("rfc_id");
            entity.Property(e => e.SdId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sd_id");
            entity.Property(e => e.ServiceTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("service_type_id");
            entity.Property(e => e.SiteId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("site_id");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.SymptomTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("symptom_type_id");
            entity.Property(e => e.Tags)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("tags");
            entity.Property(e => e.TeamId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("team_id");
            entity.Property(e => e.TierId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("tier_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
            entity.Property(e => e.Uptime)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("uptime");
            entity.Property(e => e.VendorCaseId)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("vendor_case_id");
        });

        modelBuilder.Entity<IncidentEscalationLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("incident_escalation_log");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EngineerId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10)")
                .HasColumnName("engineer_id");
            entity.Property(e => e.IncidentId)
                .HasColumnType("int(10)")
                .HasColumnName("incident_id");
            entity.Property(e => e.NewTierId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10)")
                .HasColumnName("new_tier_id");
            entity.Property(e => e.OldTierId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10)")
                .HasColumnName("old_tier_id");
            entity.Property(e => e.Reason)
                .HasColumnType("text")
                .HasColumnName("reason");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("'00:00:00'")
                .HasColumnType("time")
                .HasColumnName("time");
        });

        modelBuilder.Entity<IncidentPending>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("incident_pending");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.CaseLogStart)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_start");
            entity.Property(e => e.CaseLogStop)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_stop");
            entity.Property(e => e.PendingDuration)
                .HasColumnType("int(10)")
                .HasColumnName("pending_duration");
            entity.Property(e => e.PendingDurationOnWorkingHour)
                .HasColumnType("int(10)")
                .HasColumnName("pending_duration_on_working_hour");
            entity.Property(e => e.PendingStartDate)
                .HasColumnType("datetime")
                .HasColumnName("pending_start_date");
            entity.Property(e => e.PendingStopDate)
                .HasColumnType("datetime")
                .HasColumnName("pending_stop_date");
        });

        modelBuilder.Entity<IncidentRemainSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("incident_remain_summary");

            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .HasColumnName("id");
            entity.Property(e => e.Month1)
                .HasMaxLength(5)
                .HasColumnName("month1");
            entity.Property(e => e.MonthName)
                .HasMaxLength(35)
                .HasColumnName("month_name");
            entity.Property(e => e.NumberOfRemaining)
                .HasColumnType("bigint(21)")
                .HasColumnName("number_of_remaining");
        });

        modelBuilder.Entity<IncidentResolution>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("incident_resolution");

            entity.Property(e => e.CaseCategoryTitle)
                .HasMaxLength(45)
                .HasColumnName("case_category_title");
            entity.Property(e => e.CaseId)
                .HasMaxLength(45)
                .HasColumnName("case_id");
            entity.Property(e => e.CaseStatusTitle)
                .HasMaxLength(45)
                .HasColumnName("case_status_title");
            entity.Property(e => e.CaseSubCategoryTitle)
                .HasMaxLength(45)
                .HasColumnName("case_sub_category_title");
            entity.Property(e => e.CaseTypeTitle)
                .HasMaxLength(255)
                .HasColumnName("case_type_title");
            entity.Property(e => e.Contact)
                .HasMaxLength(32)
                .HasColumnName("contact");
            entity.Property(e => e.ContractTitle)
                .HasMaxLength(100)
                .HasColumnName("contract_title");
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(21)
                .HasColumnName("created_date");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(200)
                .HasColumnName("customer_name");
            entity.Property(e => e.DepartmentTitle)
                .HasMaxLength(45)
                .HasColumnName("department_title");
            entity.Property(e => e.Engineer)
                .HasMaxLength(78)
                .HasColumnName("engineer");
            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.LoggedBy)
                .HasMaxLength(32)
                .HasColumnName("logged_by");
            entity.Property(e => e.OfficeTitle)
                .HasMaxLength(45)
                .HasColumnName("office_title");
            entity.Property(e => e.PriorityTitle)
                .HasMaxLength(45)
                .HasColumnName("priority_title");
            entity.Property(e => e.RegionTitle)
                .HasMaxLength(45)
                .HasColumnName("region_title");
            entity.Property(e => e.ResolutionTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("resolution_type_id");
            entity.Property(e => e.ResolutionTypeTitle)
                .HasMaxLength(60)
                .HasColumnName("resolution_type_title");
            entity.Property(e => e.SectionTitle)
                .HasMaxLength(45)
                .HasColumnName("section_title");
            entity.Property(e => e.ServiceTypeTitle)
                .HasMaxLength(255)
                .HasColumnName("service_type_title");
            entity.Property(e => e.SiteTitle)
                .HasMaxLength(200)
                .HasColumnName("site_title");
            entity.Property(e => e.TeamTitle)
                .HasMaxLength(45)
                .HasColumnName("team_title");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e._7x24)
                .HasMaxLength(5)
                .HasColumnName("7x24");
        });

        modelBuilder.Entity<IncidentResolveSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("incident_resolve_summary");

            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .HasColumnName("id");
            entity.Property(e => e.Month1)
                .HasMaxLength(5)
                .HasColumnName("month1");
            entity.Property(e => e.MonthName)
                .HasMaxLength(35)
                .HasColumnName("month_name");
            entity.Property(e => e.NumberOfResolvedcase)
                .HasColumnType("bigint(21)")
                .HasColumnName("number_of_resolvedcase");
        });

        modelBuilder.Entity<IncidentServiceReport>(entity =>
        {
            entity.HasKey(e => e.CaseId).HasName("PRIMARY");

            entity.ToTable("incident_service_report");

            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.DiagnosedByCustomer)
                .HasColumnType("text")
                .HasColumnName("diagnosed_by_customer");
            entity.Property(e => e.RootCauseDetail)
                .HasColumnType("text")
                .HasColumnName("root_cause_detail");
            entity.Property(e => e.SolvingMethod)
                .HasColumnType("text")
                .HasColumnName("solving_method");
        });

        modelBuilder.Entity<IncidentTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("incident_template");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_category_id");
            entity.Property(e => e.CaseDescription).HasColumnName("case_description");
            entity.Property(e => e.CaseSubCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_sub_category_id");
            entity.Property(e => e.CaseTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_type_id");
            entity.Property(e => e.DepartmentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("department_id");
            entity.Property(e => e.EngineerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("engineer_id");
            entity.Property(e => e.Filelink)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("filelink");
            entity.Property(e => e.IconPath)
                .HasDefaultValueSql("''")
                .HasColumnName("icon_path");
            entity.Property(e => e.ImpactId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("impact_id");
            entity.Property(e => e.Inactive)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("password");
            entity.Property(e => e.PriorityId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("priority_id");
            entity.Property(e => e.Remark)
                .HasColumnType("text")
                .HasColumnName("remark");
            entity.Property(e => e.SectionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("section_id");
            entity.Property(e => e.ServiceTypeId)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("service_type_id");
            entity.Property(e => e.ShareEngineer)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("share_engineer");
            entity.Property(e => e.ShareUser)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("share_user");
            entity.Property(e => e.SymptomTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("symptom_type_id");
            entity.Property(e => e.TeamId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("team_id");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(100)
                .HasColumnName("template_name");
            entity.Property(e => e.TierId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("tier_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UrgencyId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("urgency_id");
        });

        modelBuilder.Entity<Invoiceitems>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("invoiceitems");

            entity.HasIndex(e => new { e.Invoiceid, e.Itemseq }, "invoiceitems_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Invoiceid)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("invoiceid");
            entity.Property(e => e.Itemhour)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("itemhour");
            entity.Property(e => e.Itemmin)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("itemmin");
            entity.Property(e => e.Itemname)
                .HasMaxLength(255)
                .HasColumnName("itemname");
            entity.Property(e => e.Itemprice)
                .HasPrecision(10, 2)
                .HasColumnName("itemprice");
            entity.Property(e => e.Itemseq)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("itemseq");
            entity.Property(e => e.Itemtax)
                .HasPrecision(10, 2)
                .HasColumnName("itemtax");
            entity.Property(e => e.Itemtaxtype)
                .HasComment("0=none,1=include,2=not include")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("itemtaxtype");
            entity.Property(e => e.Itemtotal)
                .HasPrecision(10, 2)
                .HasColumnName("itemtotal");
        });

        modelBuilder.Entity<Invoices>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("invoices");

            entity.HasIndex(e => new { e.Refdoctype, e.Refdocid }, "invoices_idx").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Createby)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("createby");
            entity.Property(e => e.Createdate)
                .HasColumnType("datetime")
                .HasColumnName("createdate");
            entity.Property(e => e.Currencyid)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("currencyid");
            entity.Property(e => e.Deleteby)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("deleteby");
            entity.Property(e => e.Deletedate)
                .HasColumnType("datetime")
                .HasColumnName("deletedate");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Invid)
                .HasMaxLength(50)
                .HasColumnName("invid");
            entity.Property(e => e.Isdelete)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("isdelete");
            entity.Property(e => e.Issend)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("issend");
            entity.Property(e => e.Officeid)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("officeid");
            entity.Property(e => e.Refdocid)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("refdocid");
            entity.Property(e => e.Refdoctype)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("refdoctype");
            entity.Property(e => e.Siteid)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("siteid");
            entity.Property(e => e.Taxrate)
                .HasPrecision(5, 2)
                .HasColumnName("taxrate");
            entity.Property(e => e.Updateby)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("updateby");
            entity.Property(e => e.Updatedate)
                .HasColumnType("datetime")
                .HasColumnName("updatedate");
        });

        modelBuilder.Entity<ItemStatus>(entity =>
        {
            entity.HasKey(e => e.ItemStatusId).HasName("PRIMARY");

            entity.ToTable("item_status");

            entity.Property(e => e.ItemStatusId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("item_status_id");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.Isdispose)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("isdispose");
            entity.Property(e => e.Isplanning)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("isplanning");
            entity.Property(e => e.ItemStatusTitle)
                .HasMaxLength(80)
                .HasDefaultValueSql("''")
                .HasColumnName("item_status_title");
        });

        modelBuilder.Entity<Kiosk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kiosk");

            entity.HasIndex(e => e.KioskCode, "kiosk_temp_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("address");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactName)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("contact_name");
            entity.Property(e => e.ContactTel)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("contact_tel");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasComment("วันที่สร้าง")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasComment("คำอธิบายเพิ่มเติม")
                .HasColumnName("description");
            entity.Property(e => e.Inactive)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.KioskCode)
                .HasMaxLength(50)
                .HasComment("รหัสเครื่อง Kiosk")
                .HasColumnName("kiosk_code");
            entity.Property(e => e.KioskName)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("kiosk_name");
            entity.Property(e => e.KioskToken)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasComment("Permanent kiosk token for SSO / agent auth")
                .HasColumnName("kiosk_token");
            entity.Property(e => e.Latitude)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("longitude");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasComment("วันที่อัพเดตล่าสุด")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<KioskConsented>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kiosk_consented");

            entity.HasIndex(e => e.Idcard, "kiosk_consented_idcard_IDX");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ConsentedBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("consented_by");
            entity.Property(e => e.ConsentedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("consented_date");
            entity.Property(e => e.Idcard)
                .HasMaxLength(13)
                .HasDefaultValueSql("''")
                .HasColumnName("idcard");
            entity.Property(e => e.JsonData)
                .HasDefaultValueSql("''")
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.KioskId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("kiosk_id");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<KioskHealthStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kiosk_health_status");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.BackgroundColor)
                .HasMaxLength(20)
                .HasDefaultValueSql("'#000000'")
                .HasColumnName("background_color");
            entity.Property(e => e.FontColor)
                .HasMaxLength(20)
                .HasDefaultValueSql("'#000000'")
                .HasColumnName("font_color");
            entity.Property(e => e.HealthTitle)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("health_title");
            entity.Property(e => e.LassMin)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("lass_min");
        });

        modelBuilder.Entity<KioskHeartbeat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kiosk_heartbeat");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.KioskId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("kiosk_id");
            entity.Property(e => e.Lastupdate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("lastupdate");
        });

        modelBuilder.Entity<KioskMonitoringPin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kiosk_monitoring_pin");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.KioskId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("kiosk_id");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
        });

        modelBuilder.Entity<KioskSetup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kiosk_setup", tb => tb.HasComment("ตารางเก็บข้อมูล template สำหรับ setup kiosk script"));

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id)
                .HasComment("รหัสอัตโนมัติของสคริปต์")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasComment("รหัสอ้างอิงของสคริปต์ เช่น setup-kiosk-v1")
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasComment("วันที่สร้างข้อมูล")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasComment("รายละเอียดเพิ่มเติมของสคริปต์หรือวิธีใช้งาน")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Filename)
                .HasMaxLength(100)
                .HasComment("ชื่อไฟล์ shell script เช่น setup-kiosk.sh")
                .HasColumnName("filename");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("'1'")
                .HasComment("สถานะการใช้งาน (1=ใช้งาน, 0=ไม่ใช้งาน)")
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasComment("ชื่อของสคริปต์ เช่น Kiosk Ubuntu Install")
                .HasColumnName("name");
            entity.Property(e => e.OsType)
                .HasMaxLength(50)
                .HasComment("ระบบปฏิบัติการที่รองรับ เช่น ubuntu22.04, debian")
                .HasColumnName("os_type");
            entity.Property(e => e.ScriptContent)
                .HasComment("เนื้อ shell script ที่จะรันใน kiosk")
                .HasColumnType("text")
                .HasColumnName("script_content");
            entity.Property(e => e.Tags)
                .HasMaxLength(255)
                .HasComment("คำค้นหรือหมวดหมู่ เช่น docker,cardreader,auto-setup")
                .HasColumnName("tags");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasComment("วันที่แก้ไขล่าสุด")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .HasComment("เวอร์ชันของสคริปต์ เช่น v1.0.3 หรือ latest")
                .HasColumnName("version");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("level");

            entity.HasIndex(e => e.Level1, "level").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Level1)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("level");
        });

        modelBuilder.Entity<License>(entity =>
        {
            entity.HasKey(e => e.ProductKey).HasName("PRIMARY");

            entity.ToTable("license");

            entity.Property(e => e.ProductKey)
                .HasMaxLength(512)
                .HasColumnName("product_key");
            entity.Property(e => e.Available)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("available");
            entity.Property(e => e.Product)
                .HasMaxLength(100)
                .HasColumnName("product");
            entity.Property(e => e.Remark)
                .HasMaxLength(80)
                .HasDefaultValueSql("''")
                .HasColumnName("remark");
            entity.Property(e => e.Total)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("total");
            entity.Property(e => e.Used)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("used");
            entity.Property(e => e.Valid)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("valid");
        });

        modelBuilder.Entity<LineNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("line_notification");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AlertDate)
                .HasColumnType("datetime")
                .HasColumnName("alert_date");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("created_by");
            entity.Property(e => e.IsProcess)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("is_process");
            entity.Property(e => e.JobId)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("job_id");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.Subject)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("subject");
        });

        modelBuilder.Entity<LineTemplate>(entity =>
        {
            entity.HasKey(e => e.LineTemplateId).HasName("PRIMARY");

            entity.ToTable("line_template");

            entity.Property(e => e.LineTemplateId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("line_template_id");
            entity.Property(e => e.LineTemplateName)
                .HasMaxLength(255)
                .HasColumnName("line_template_name");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PRIMARY");

            entity.ToTable("location");

            entity.Property(e => e.LocationId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("location_id");
            entity.Property(e => e.Building)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("building");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("''")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Floor)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("floor");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.Lat)
                .HasPrecision(10, 7)
                .HasColumnName("lat");
            entity.Property(e => e.Lng)
                .HasPrecision(10, 7)
                .HasColumnName("lng");
            entity.Property(e => e.LocationTitle)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("location_title");
            entity.Property(e => e.LocationType)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("location_type");
            entity.Property(e => e.OfficeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("office_id");
            entity.Property(e => e.Rack)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("rack");
            entity.Property(e => e.Room)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("room");
            entity.Property(e => e.Row)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("row");
            entity.Property(e => e.Shelf)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("shelf");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("login");

            entity.HasIndex(e => e.DateIn, "date_in");

            entity.HasIndex(e => e.Ip, "ip");

            entity.HasIndex(e => e.Username, "username");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.DateIn).HasColumnName("date_in");
            entity.Property(e => e.DateOut).HasColumnName("date_out");
            entity.Property(e => e.Ip)
                .HasMaxLength(500)
                .HasColumnName("ip");
            entity.Property(e => e.SessionId)
                .HasMaxLength(100)
                .HasColumnName("session_id");
            entity.Property(e => e.TimeIn)
                .HasColumnType("time")
                .HasColumnName("time_in");
            entity.Property(e => e.TimeOut)
                .HasColumnType("time")
                .HasColumnName("time_out");
            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .HasColumnName("username");
        });

        modelBuilder.Entity<LoginFail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("login_fail");

            entity.HasIndex(e => e.Username, "username");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Datetime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(500)
                .HasColumnName("ip");
            entity.Property(e => e.Lock)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("lock");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<LoginOtp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("login_otp");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Otp)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("otp");
            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .HasDefaultValueSql("''")
                .HasColumnName("username");
        });

        modelBuilder.Entity<LoginSpr>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("login_spr");

            entity.HasIndex(e => e.DateIn, "date_in");

            entity.HasIndex(e => e.Ip, "ip");

            entity.HasIndex(e => e.Username, "username");

            entity.Property(e => e.DateIn).HasColumnName("date_in");
            entity.Property(e => e.DateOut).HasColumnName("date_out");
            entity.Property(e => e.Ip)
                .HasMaxLength(500)
                .HasColumnName("ip");
            entity.Property(e => e.SessionId)
                .HasMaxLength(100)
                .HasColumnName("session_id");
            entity.Property(e => e.TimeIn)
                .HasColumnType("time")
                .HasColumnName("time_in");
            entity.Property(e => e.TimeOut)
                .HasColumnType("time")
                .HasColumnName("time_out");
            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .HasColumnName("username");
        });

        modelBuilder.Entity<MandatoryFieldConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("mandatory_field_config");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ControlName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("control_name");
            entity.Property(e => e.ControlType)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("control_type");
            entity.Property(e => e.IsMandatory)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("is_mandatory");
            entity.Property(e => e.LabelId)
                .HasMaxLength(45)
                .HasColumnName("label_id");
            entity.Property(e => e.LabelName)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("label_name");
            entity.Property(e => e.Module)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PRIMARY");

            entity.ToTable("menu");

            entity.HasIndex(e => e.ParentMenuId, "FK_menu_menu");

            entity.HasIndex(e => e.MenuGroupId, "FK_menu_menu_group");

            entity.Property(e => e.MenuId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_id");
            entity.Property(e => e.MenuCreateDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("menu_create_date");
            entity.Property(e => e.MenuDescription)
                .HasMaxLength(500)
                .HasColumnName("menu_description");
            entity.Property(e => e.MenuGroupId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_group_id");
            entity.Property(e => e.MenuIconClass)
                .HasMaxLength(200)
                .HasColumnName("menu_icon_class");
            entity.Property(e => e.MenuName)
                .HasMaxLength(200)
                .HasColumnName("menu_name");
            entity.Property(e => e.MenuNewFlag)
                .HasColumnType("bit(1)")
                .HasColumnName("menu_new_flag");
            entity.Property(e => e.MenuSequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_sequence");
            entity.Property(e => e.MenuUpdateDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("menu_update_date");
            entity.Property(e => e.MenuUrl)
                .HasMaxLength(255)
                .HasColumnName("menu_url");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.ParentMenuId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("parent_menu_id");
        });

        modelBuilder.Entity<MenuApiPath>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("menu_api_path");

            entity.HasIndex(e => e.ModuleId, "menu_api_path_fk");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.Path)
                .HasMaxLength(200)
                .HasColumnName("path");
        });

        modelBuilder.Entity<MenuApiPathAnonymous>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("menu_api_path_anonymous");

            entity.HasIndex(e => e.Path, "menu_api_path_anonymous_unique").IsUnique();

            entity.HasIndex(e => e.ModuleId, "menu_api_path_fk");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.Path)
                .HasMaxLength(200)
                .HasColumnName("path");

            entity.HasOne(d => d.Module).WithMany(p => p.MenuApiPathAnonymous)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("menu_api_path_anonymous2_fk");
        });

        modelBuilder.Entity<MenuApiPathPhase2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("menu_api_path_phase2");

            entity.HasIndex(e => e.ModuleId, "menu_api_path_fk");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.Path)
                .HasMaxLength(200)
                .HasColumnName("path");

            entity.HasOne(d => d.Module).WithMany(p => p.MenuApiPathPhase2)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("menu_api_path_phase2_fk");
        });

        modelBuilder.Entity<MenuChatbot>(entity =>
        {
            entity.HasKey(e => new { e.MenuId, e.Title })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("menu_chatbot");

            entity.HasIndex(e => e.Menu, "menu");

            entity.HasIndex(e => e.MenuId, "menu_id");

            entity.HasIndex(e => e.Parent, "parent");

            entity.Property(e => e.MenuId)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("menu_id");
            entity.Property(e => e.Title)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
            entity.Property(e => e.Menu)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("menu");
            entity.Property(e => e.Parent)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("parent");
            entity.Property(e => e.RequiremenId)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("Requiremen_id");
        });

        modelBuilder.Entity<MenuGroup>(entity =>
        {
            entity.HasKey(e => e.MenuGroupId).HasName("PRIMARY");

            entity.ToTable("menu_group");

            entity.HasIndex(e => e.MenuGroupParent, "FK_menu_group_menu_group");

            entity.Property(e => e.MenuGroupId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_group_id");
            entity.Property(e => e.MenuGroupCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("menu_group_create_date");
            entity.Property(e => e.MenuGroupDescription)
                .HasMaxLength(500)
                .HasColumnName("menu_group_description");
            entity.Property(e => e.MenuGroupIconClass)
                .HasMaxLength(200)
                .HasColumnName("menu_group_icon_class");
            entity.Property(e => e.MenuGroupName)
                .HasMaxLength(200)
                .HasColumnName("menu_group_name");
            entity.Property(e => e.MenuGroupParent)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_group_parent");
            entity.Property(e => e.MenuGroupSequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_group_sequence");
            entity.Property(e => e.MenuGroupUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("menu_group_update_date");
            entity.Property(e => e.MenuGroupUrl)
                .HasMaxLength(200)
                .HasColumnName("menu_group_url");
            entity.Property(e => e.MenuGroupValue)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_group_value");
        });

        modelBuilder.Entity<MenuTutorialMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("menu_tutorial_mapping");

            entity.HasIndex(e => e.MenuId, "FK_tutorial_menu_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Filename)
                .HasDefaultValueSql("''")
                .HasColumnType("text")
                .HasColumnName("filename");
            entity.Property(e => e.MenuId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_id");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuTutorialMapping)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tutorial_menu_id");
        });

        modelBuilder.Entity<MenuUserRouting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("menu_user_routing");

            entity.HasIndex(e => e.MenuId, "FK_menu_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Count)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("count");
            entity.Property(e => e.MenuId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_id");
            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .HasDefaultValueSql("''")
                .HasColumnName("username");
        });

        modelBuilder.Entity<MessageCustomerCircuit>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("message_customer_circuit");

            entity.Property(e => e.CircuitId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("circuit_id");
            entity.Property(e => e.MessageCustomerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("message_customer_id");
        });

        modelBuilder.Entity<MessageCustomerContact>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("message_customer_contact");

            entity.Property(e => e.ContactId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contact_id");
            entity.Property(e => e.MessageCustomerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("message_customer_id");
        });

        modelBuilder.Entity<MobilePhoneRegisNsd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("mobile_phone_regis_nsd");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.MacAddress)
                .HasMaxLength(45)
                .HasColumnName("mac_address");
            entity.Property(e => e.RegisDate)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("regis_date");
            entity.Property(e => e.RegisTime)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("regis_time");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PRIMARY");

            entity.ToTable("module");

            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.DataView)
                .HasMaxLength(45)
                .HasColumnName("data_view");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.LandingMenuId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("landing_menu_id");
            entity.Property(e => e.LookupAssociated)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("lookup_associated");
            entity.Property(e => e.LookupColumndate)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("lookup_columndate");
            entity.Property(e => e.LookupDashboard)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("lookup_dashboard");
            entity.Property(e => e.LookupLogType)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("lookup_log_type");
            entity.Property(e => e.LookupTbStatus)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("lookup_tb_status");
            entity.Property(e => e.MenuGroupId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_group_id");
            entity.Property(e => e.MenuId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_id");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("module_name");
            entity.Property(e => e.ModuleSequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_sequence");
            entity.Property(e => e.SqlDetailByCaseid)
                .HasDefaultValueSql("''")
                .HasColumnType("text")
                .HasColumnName("sql_detail_by_caseid");
        });

        modelBuilder.Entity<ModuleAdditionalColumns>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("module_additional_columns");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.DataView)
                .HasMaxLength(45)
                .HasColumnName("data_view");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.LandingMenuId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("landing_menu_id");
            entity.Property(e => e.LookupAssociated)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("lookup_associated");
            entity.Property(e => e.LookupColumndate)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("lookup_columndate");
            entity.Property(e => e.LookupDashboard)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("lookup_dashboard");
            entity.Property(e => e.LookupLogType)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("lookup_log_type");
            entity.Property(e => e.LookupTbStatus)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("lookup_tb_status");
            entity.Property(e => e.MenuGroupId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_group_id");
            entity.Property(e => e.MenuId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_id");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("module_name");
            entity.Property(e => e.ModuleSequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_sequence");
            entity.Property(e => e.SqlDetailByCaseid)
                .HasDefaultValueSql("''")
                .HasColumnType("text")
                .HasColumnName("sql_detail_by_caseid");
            entity.Property(e => e.SubDirectoryFtp)
                .HasMaxLength(15)
                .HasDefaultValueSql("''")
                .HasColumnName("sub_directory_ftp");
        });

        modelBuilder.Entity<ModuleDashboardProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("module_dashboard_profile");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AdHocReportModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ad_hoc_report_module_id");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(100)
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasColumnType("bit(1)")
                .HasColumnName("is_active");
            entity.Property(e => e.JsonData).HasColumnName("json_data");
            entity.Property(e => e.JsonTemplate).HasColumnName("json_template");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(100)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<ModuleLookup>(entity =>
        {
            entity.HasKey(e => e.ModuleLookupId).HasName("PRIMARY");

            entity.ToTable("module_lookup");

            entity.Property(e => e.ModuleLookupId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_lookup_id");
            entity.Property(e => e.TableCondition)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("table_condition");
            entity.Property(e => e.TableName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("table_name");
            entity.Property(e => e.TableRef)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("table_ref");
            entity.Property(e => e.TableTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("table_title");
        });

        modelBuilder.Entity<ModuleMappingView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("module_mapping_view");

            entity.Property(e => e.CaseLogType)
                .HasMaxLength(16)
                .HasDefaultValueSql("''")
                .HasColumnName("case_log_type");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("module_name");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(12)
                .HasDefaultValueSql("''")
                .HasColumnName("service_type");
        });

        modelBuilder.Entity<ModuleRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("module_role");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.FieldKey)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("field_key");
            entity.Property(e => e.FieldSelect)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("field_select");
            entity.Property(e => e.IsContact)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1) unsigned")
                .HasColumnName("is_contact");
            entity.Property(e => e.IsStaff)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1) unsigned")
                .HasColumnName("is_staff");
            entity.Property(e => e.ModuleId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("role_name");
            entity.Property(e => e.Table)
                .HasDefaultValueSql("''")
                .HasColumnType("text")
                .HasColumnName("table");
        });

        modelBuilder.Entity<NetkaProduct>(entity =>
        {
            entity.HasKey(e => new { e.Product, e.PartNumber })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("netka_product");

            entity.HasIndex(e => e.PartNumber, "part_number");

            entity.HasIndex(e => e.Product, "product");

            entity.Property(e => e.Product)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("product");
            entity.Property(e => e.PartNumber)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("part_number");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.LicenseInterface)
                .HasDefaultValueSql("-1")
                .HasColumnType("int(11)")
                .HasColumnName("license_interface");
            entity.Property(e => e.LicenseNode)
                .HasDefaultValueSql("-1")
                .HasColumnType("int(11)")
                .HasColumnName("license_node");
            entity.Property(e => e.Order)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("order");
            entity.Property(e => e.UsedInterfaceSql)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("used_interface_sql");
            entity.Property(e => e.UsedNodeSql)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("used_node_sql");
        });

        modelBuilder.Entity<NetworkServiceType>(entity =>
        {
            entity.HasKey(e => e.NwsrvTypeId).HasName("PRIMARY");

            entity.ToTable("network_service_type");

            entity.Property(e => e.NwsrvTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("nwsrv_type_id");
            entity.Property(e => e.Inactive)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.NwsrvTypeDescription)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("nwsrv_type_description");
            entity.Property(e => e.NwsrvTypeTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("nwsrv_type_title");
        });

        modelBuilder.Entity<NksfsrvFileCabinet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nksfsrv_file_cabinet");

            entity.HasIndex(e => e.Rng, "index_2");

            entity.HasIndex(e => e.Password, "password");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .HasColumnName("CATEGORY");
            entity.Property(e => e.CreateDateTime)
                .HasMaxLength(255)
                .HasColumnName("CREATE_DATE_TIME");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.FileSize)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("FILE_SIZE");
            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .HasColumnName("FILENAME");
            entity.Property(e => e.Mass).HasColumnName("MASS");
            entity.Property(e => e.Password).HasColumnName("PASSWORD");
            entity.Property(e => e.Rng).HasColumnName("RNG");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<Node>(entity =>
        {
            entity.HasKey(e => e.NodeId).HasName("PRIMARY");

            entity.ToTable("node");

            entity.Property(e => e.NodeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("node_id");
            entity.Property(e => e.Inactive)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.NodeDescription)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("node_description");
            entity.Property(e => e.NodeTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("node_title");
            entity.Property(e => e.Remark)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("remark");
        });

        modelBuilder.Entity<NodeCard>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("node_card");

            entity.HasIndex(e => e.CardId, "card_id");

            entity.HasIndex(e => e.NodeId, "node_id");

            entity.Property(e => e.CardId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("card_id");
            entity.Property(e => e.NodeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("node_id");
        });

        modelBuilder.Entity<NotificationTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("notification_task");

            entity.HasIndex(e => e.AlertDate, "alert_date");

            entity.HasIndex(e => e.Id, "id");

            entity.HasIndex(e => e.RecipientId, "recipient_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AlertDate)
                .HasColumnType("datetime")
                .HasColumnName("alert_date");
            entity.Property(e => e.IsDeleted)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("is_deleted");
            entity.Property(e => e.IsRead)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("is_read");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.MessageType)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("message_type");
            entity.Property(e => e.RecipientId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("recipient_id");
            entity.Property(e => e.SendById)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("send_by_id");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasColumnName("subject");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("url");
        });

        modelBuilder.Entity<NotificationTaskContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("notification_task_contact");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AlertDate)
                .HasColumnType("datetime")
                .HasColumnName("alert_date");
            entity.Property(e => e.IsDeleted)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("is_deleted");
            entity.Property(e => e.IsRead)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("is_read");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.MessageType)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("message_type");
            entity.Property(e => e.RecipientId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("recipient_id");
            entity.Property(e => e.SendById)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("send_by_id");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasColumnName("subject");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
        });

        modelBuilder.Entity<NsdFunction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nsd_function");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.FunctionDescription)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("function_description");
            entity.Property(e => e.FunctionName)
                .HasMaxLength(45)
                .HasColumnName("function_name");
        });

        modelBuilder.Entity<NsdImport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nsd_import", tb => tb.HasComment("Mapping table with webpage"));

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Tbname)
                .HasMaxLength(200)
                .HasColumnName("tbname");
            entity.Property(e => e.UniqueField)
                .HasMaxLength(50)
                .HasColumnName("unique_field");
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("url");
        });

        modelBuilder.Entity<NsdxDashboardProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nsdx_dashboard_profile");

            entity.HasIndex(e => new { e.Name, e.StaffId }, "nsdx_dashboard_profile_un").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("CREATE_BY");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("CREATE_DATE");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("IS_ACTIVE");
            entity.Property(e => e.JsonData)
                .HasDefaultValueSql("''")
                .HasColumnName("JSON_DATA");
            entity.Property(e => e.JsonTemplate)
                .HasDefaultValueSql("''")
                .HasColumnName("JSON_TEMPLATE");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("NAME");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("UPDATE_BY");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_DATE");
        });

        modelBuilder.Entity<NsdxErrorLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nsdx_error_log");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ErrorPage)
                .HasMaxLength(55)
                .HasDefaultValueSql("''")
                .HasColumnName("error_page");
            entity.Property(e => e.ErrorTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("error_time");
            entity.Property(e => e.Message)
                .HasDefaultValueSql("''")
                .HasColumnType("text")
                .HasColumnName("message");
        });

        modelBuilder.Entity<NsdxFileAttachmentFtp>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("PRIMARY");

            entity.ToTable("nsdx_file_attachment_ftp");

            entity.Property(e => e.FileId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("file_id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.FileCreateBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("file_create_by");
            entity.Property(e => e.FileCreateDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("file_create_date");
            entity.Property(e => e.FileDeletedBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("file_deleted_by");
            entity.Property(e => e.FileDeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("file_deleted_date");
            entity.Property(e => e.FileExtension)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("file_extension");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("file_name");
            entity.Property(e => e.FilePath)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("file_path");
            entity.Property(e => e.FileThumbnail)
                .HasDefaultValueSql("''")
                .HasColumnType("mediumtext")
                .HasColumnName("file_thumbnail");
            entity.Property(e => e.FileType)
                .HasMaxLength(100)
                .HasColumnName("file_type");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsPublic)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_public");
            entity.Property(e => e.MenuId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_id");
            entity.Property(e => e.UploadTableName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("upload_table_name");
        });

        modelBuilder.Entity<NsdxFileAttatchment>(entity =>
        {
            entity.HasKey(e => e.AttatchmentId).HasName("PRIMARY");

            entity.ToTable("nsdx_file_attatchment");

            entity.Property(e => e.AttatchmentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("attatchment_id");
            entity.Property(e => e.AttatchmentFileBase64)
                .HasDefaultValueSql("''")
                .HasColumnName("attatchment_file_base64");
            entity.Property(e => e.AttatchmentFileCreateBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("attatchment_file_create_by");
            entity.Property(e => e.AttatchmentFileCreateDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("attatchment_file_create_date");
            entity.Property(e => e.AttatchmentFileName)
                .HasMaxLength(100)
                .HasColumnName("attatchment_file_name");
            entity.Property(e => e.AttatchmentFileType)
                .HasMaxLength(100)
                .HasColumnName("attatchment_file_type");
        });

        modelBuilder.Entity<NsdxResetFactoryLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nsdx_reset_factory_log");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.DateTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("date_time");
            entity.Property(e => e.DeleteFlag)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("delete_flag");
            entity.Property(e => e.IsProcess)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_process");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("username");
        });

        modelBuilder.Entity<NsdxSystemLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nsdx_system_log");

            entity.Property(e => e.Adminsystemlogaction)
                .HasMaxLength(6)
                .HasColumnName("adminsystemlogaction");
            entity.Property(e => e.Adminsystemlogdatetime)
                .HasColumnType("datetime")
                .HasColumnName("adminsystemlogdatetime");
            entity.Property(e => e.Adminsystemlogdescription)
                .HasColumnType("text")
                .HasColumnName("adminsystemlogdescription");
            entity.Property(e => e.Adminsystemlogid)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("adminsystemlogid");
            entity.Property(e => e.Adminsystemlognewvalue)
                .HasMaxLength(200)
                .HasColumnName("adminsystemlognewvalue");
            entity.Property(e => e.Adminsystemlogoldvalue)
                .HasMaxLength(200)
                .HasColumnName("adminsystemlogoldvalue");
            entity.Property(e => e.Adminsystemlogpage)
                .HasMaxLength(45)
                .HasColumnName("adminsystemlogpage");
            entity.Property(e => e.Adminsystemlogtablename)
                .HasMaxLength(45)
                .HasColumnName("adminsystemlogtablename");
            entity.Property(e => e.Adminsystemlogusername)
                .HasMaxLength(20)
                .HasColumnName("adminsystemlogusername");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.OfficeId).HasName("PRIMARY");

            entity.ToTable("office");

            entity.HasIndex(e => e.Amphur, "amphur");

            entity.HasIndex(e => e.Country, "country");

            entity.HasIndex(e => e.Fax, "fax");

            entity.HasIndex(e => e.Province, "province");

            entity.HasIndex(e => e.Tambol, "tambol");

            entity.HasIndex(e => e.OfficeTitle, "unique").IsUnique();

            entity.Property(e => e.OfficeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("office_id");
            entity.Property(e => e.Address)
                .HasMaxLength(20)
                .HasColumnName("address");
            entity.Property(e => e.Amphur)
                .HasColumnType("int(5)")
                .HasColumnName("amphur");
            entity.Property(e => e.Building)
                .HasMaxLength(45)
                .HasColumnName("building");
            entity.Property(e => e.Country)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("country");
            entity.Property(e => e.Fax)
                .HasMaxLength(45)
                .HasColumnName("fax");
            entity.Property(e => e.Hq)
                .HasMaxLength(5)
                .HasDefaultValueSql("'No'")
                .HasColumnName("hq");
            entity.Property(e => e.Lat)
                .HasPrecision(10, 7)
                .HasColumnName("lat");
            entity.Property(e => e.Level)
                .HasMaxLength(5)
                .HasColumnName("level");
            entity.Property(e => e.Lng)
                .HasPrecision(10, 7)
                .HasColumnName("lng");
            entity.Property(e => e.OfficeTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("office_title");
            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .HasColumnName("phone");
            entity.Property(e => e.Province)
                .HasColumnType("int(10)")
                .HasColumnName("province");
            entity.Property(e => e.Street)
                .HasMaxLength(45)
                .HasColumnName("street");
            entity.Property(e => e.Tambol)
                .HasColumnType("int(5)")
                .HasColumnName("tambol");
            entity.Property(e => e.Web)
                .HasMaxLength(200)
                .HasColumnName("web");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .HasColumnName("zip");
        });

        modelBuilder.Entity<Ola>(entity =>
        {
            entity.HasKey(e => e.OlaId).HasName("PRIMARY");

            entity.ToTable("ola");

            entity.HasIndex(e => e.OlaTitle, "sla_title").IsUnique();

            entity.Property(e => e.OlaId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ola_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.OlaCode)
                .HasMaxLength(20)
                .HasColumnName("ola_code");
            entity.Property(e => e.OlaTitle)
                .HasMaxLength(45)
                .HasColumnName("ola_title");
        });

        modelBuilder.Entity<OlaDetail>(entity =>
        {
            entity.HasKey(e => e.OlaDetailId).HasName("PRIMARY");

            entity.ToTable("ola_detail");

            entity.Property(e => e.OlaDetailId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ola_detail_id");
            entity.Property(e => e.Autoclose)
                .HasMaxLength(45)
                .HasDefaultValueSql("'00:00'")
                .HasColumnName("autoclose");
            entity.Property(e => e.OlaId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ola_id");
            entity.Property(e => e.Onsite)
                .HasMaxLength(45)
                .HasDefaultValueSql("'00:00'")
                .HasColumnName("onsite");
            entity.Property(e => e.PriorityId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("priority_id");
            entity.Property(e => e.Resolve)
                .HasMaxLength(45)
                .HasDefaultValueSql("'00:00'")
                .HasColumnName("resolve");
            entity.Property(e => e.Response)
                .HasMaxLength(45)
                .HasDefaultValueSql("'00:00'")
                .HasColumnName("response");
            entity.Property(e => e._7x24)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("7x24");
        });

        modelBuilder.Entity<PageProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("page_product");

            entity.HasIndex(e => e.Page, "page").IsUnique();

            entity.Property(e => e.Page)
                .HasDefaultValueSql("''")
                .HasColumnName("page");
            entity.Property(e => e.Product)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("product");
        });

        modelBuilder.Entity<PageProductLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("page_product_log");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(500)
                .HasColumnName("change_desc");
            entity.Property(e => e.Date)
                .HasMaxLength(6)
                .HasColumnName("date");
            entity.Property(e => e.FilePath)
                .HasMaxLength(250)
                .HasColumnName("file_path");
            entity.Property(e => e.Time)
                .HasMaxLength(6)
                .HasColumnName("time");
            entity.Property(e => e.UpdatedStatus)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("updated_status");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");
        });

        modelBuilder.Entity<PartCodeScript>(entity =>
        {
            entity.HasKey(e => e.Script).HasName("PRIMARY");

            entity.ToTable("part_code_script");

            entity.HasIndex(e => e.PartCode, "product");

            entity.Property(e => e.Script)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("script");
            entity.Property(e => e.PartCode)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("part_code");
        });

        modelBuilder.Entity<PartnerProjectRegister>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("partner_project_register");

            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("project_id");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .HasColumnName("project_name");
        });

        modelBuilder.Entity<PlaningAnalysis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("planing_analysis");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("comment");
            entity.Property(e => e.IsAnalysis)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_analysis");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PRIMARY");

            entity.ToTable("position");

            entity.HasIndex(e => e.PositionTitle, "unique").IsUnique();

            entity.Property(e => e.PositionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("position_id");
            entity.Property(e => e.IsVip)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("is_vip");
            entity.Property(e => e.PositionTitle).HasColumnName("position_title");
        });

        modelBuilder.Entity<Prefix>(entity =>
        {
            entity.HasKey(e => e.PrefixId).HasName("PRIMARY");

            entity.ToTable("prefix");

            entity.HasIndex(e => e.PrefixTitle, "unique").IsUnique();

            entity.Property(e => e.PrefixId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("prefix_id");
            entity.Property(e => e.PrefixSequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("prefix_sequence");
            entity.Property(e => e.PrefixTitle)
                .HasMaxLength(32)
                .HasDefaultValueSql("''")
                .HasColumnName("prefix_title");
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.PriorityId).HasName("PRIMARY");

            entity.ToTable("priority");

            entity.HasIndex(e => e.PriorityTitle, "unique").IsUnique();

            entity.Property(e => e.PriorityId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("priority_id");
            entity.Property(e => e.AllowDelete)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("allow_delete");
            entity.Property(e => e.Autoclose)
                .HasMaxLength(10)
                .HasColumnName("autoclose");
            entity.Property(e => e.Color)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("color");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Onsite)
                .HasMaxLength(10)
                .HasColumnName("onsite");
            entity.Property(e => e.PrioritySequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("priority_sequence");
            entity.Property(e => e.PriorityTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("priority_title");
            entity.Property(e => e.Resolve)
                .HasMaxLength(10)
                .HasColumnName("resolve");
            entity.Property(e => e.Response)
                .HasMaxLength(10)
                .HasColumnName("response");
            entity.Property(e => e._7x24)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("7x24");
        });

        modelBuilder.Entity<PriorityLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("priority_level");

            entity.HasIndex(e => e.ImpactId, "FK_priority_level_impact");

            entity.HasIndex(e => e.PriorityId, "FK_priority_level_priority");

            entity.HasIndex(e => e.UrgencyId, "FK_priority_level_urgency");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.GridCode)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("grid_code");
            entity.Property(e => e.ImpactId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("impact_id");
            entity.Property(e => e.PriorityId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("priority_id");
            entity.Property(e => e.UrgencyId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("urgency_id");

            entity.HasOne(d => d.Impact).WithMany(p => p.PriorityLevel)
                .HasForeignKey(d => d.ImpactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_priority_level_impact");

            entity.HasOne(d => d.Priority).WithMany(p => p.PriorityLevel)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_priority_level_priority");

            entity.HasOne(d => d.Urgency).WithMany(p => p.PriorityLevel)
                .HasForeignKey(d => d.UrgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_priority_level_urgency");
        });

        modelBuilder.Entity<Privilege>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("privilege");

            entity.HasIndex(e => new { e.Level, e.MenuId }, "privilege_un").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Level)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("level");
            entity.Property(e => e.MenuId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_id");
        });

        modelBuilder.Entity<PrivilegeDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("privilege_detail");

            entity.Property(e => e.LevelId).HasColumnType("int(10) unsigned");
            entity.Property(e => e.LevelName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''");
            entity.Property(e => e.MenuId).HasColumnType("int(10) unsigned");
            entity.Property(e => e.MenuName).HasMaxLength(200);
            entity.Property(e => e.MenuUrl).HasMaxLength(255);
            entity.Property(e => e.ModuleId).HasColumnType("int(10) unsigned");
            entity.Property(e => e.PrivilegeId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10) unsigned");
        });

        modelBuilder.Entity<Probability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("probability");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ProbabilityTitle)
                .HasMaxLength(45)
                .HasColumnName("probability_title");
        });

        modelBuilder.Entity<ProductKeySale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product_key_sale");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("company");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.ExpiryDate)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("expiry_date");
            entity.Property(e => e.GeneratedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("generated_by");
            entity.Property(e => e.Ip)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("ip");
            entity.Property(e => e.Mac)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("mac");
            entity.Property(e => e.SaleProjectId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sale_project_id");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("type");
        });

        modelBuilder.Entity<ProductKeySaleDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("product_key_sale_detail");

            entity.HasIndex(e => new { e.RefId, e.ProductId }, "Index_1");

            entity.Property(e => e.ProductId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("product_id");
            entity.Property(e => e.ProductKey)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("product_key");
            entity.Property(e => e.RefId)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ref_id");
        });

        modelBuilder.Entity<ProductKeyTrial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product_key_trial");

            entity.HasIndex(e => e.Country, "country");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("city");
            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("company");
            entity.Property(e => e.Country)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("country");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("email");
            entity.Property(e => e.ExpiryDate)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("expiry_date");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("firstname");
            entity.Property(e => e.Ip)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("ip");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("lastname");
            entity.Property(e => e.Mac)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("mac");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("phone");
            entity.Property(e => e.Province)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("province");
            entity.Property(e => e.Purpose)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("purpose");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("zip");
        });

        modelBuilder.Entity<ProductKeyTrialDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("product_key_trial_detail");

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.HasIndex(e => e.RefId, "ref_id");

            entity.Property(e => e.ProductId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("product_id");
            entity.Property(e => e.ProductKey)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("product_key");
            entity.Property(e => e.RefId)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ref_id");
        });

        modelBuilder.Entity<ProductsIdentity>(entity =>
        {
            entity.HasKey(e => e.SysobjectId).HasName("PRIMARY");

            entity.ToTable("products_identity");

            entity.HasIndex(e => e.ProductType, "product_type");

            entity.Property(e => e.SysobjectId)
                .HasMaxLength(100)
                .HasColumnName("sysobject_id");
            entity.Property(e => e.CpuName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("cpu_name");
            entity.Property(e => e.CpuOid)
                .HasMaxLength(64)
                .HasDefaultValueSql("''")
                .HasColumnName("cpu_oid");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.MemFreeOid)
                .HasMaxLength(64)
                .HasDefaultValueSql("''")
                .HasColumnName("mem_free_oid");
            entity.Property(e => e.MemPercentageOid)
                .HasMaxLength(64)
                .HasDefaultValueSql("''")
                .HasColumnName("mem_percentage_oid");
            entity.Property(e => e.MemSizeOid)
                .HasMaxLength(64)
                .HasDefaultValueSql("''")
                .HasColumnName("mem_size_oid");
            entity.Property(e => e.MemUsedOid)
                .HasMaxLength(64)
                .HasDefaultValueSql("''")
                .HasColumnName("mem_used_oid");
            entity.Property(e => e.Product)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("product");
            entity.Property(e => e.ProductCategoryId)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("product_category_id");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("product_description");
            entity.Property(e => e.ProductType).HasColumnName("product_type");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("project");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("project_name");
        });

        modelBuilder.Entity<PropertyControlFiled>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("property_control_filed");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ControlType)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("control_type");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
        });

        modelBuilder.Entity<PropertyFieldConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("property_field_config");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AllowDelete)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("allow_delete");
            entity.Property(e => e.ControlType)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("control_type");
            entity.Property(e => e.Data)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("data");
            entity.Property(e => e.DefaultValue)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("default_value");
            entity.Property(e => e.DependFields)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("depend_fields");
            entity.Property(e => e.DisplayTitle)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("display_title");
            entity.Property(e => e.FieldName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("field_name");
            entity.Property(e => e.HintDisplay)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("hint_display");
            entity.Property(e => e.Inactive)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.IsReadOnly)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("is_read_only");
            entity.Property(e => e.IsRequired)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("is_required");
            entity.Property(e => e.MaxLength)
                .HasDefaultValueSql("'10'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("max_length");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<PropertyFieldValueMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("property_field_value_master");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.OrderNum)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("order_num");
            entity.Property(e => e.PropertyFieldId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("property_field_id");
            entity.Property(e => e.Text)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("text");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_date");
            entity.Property(e => e.Value)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("value");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.ProvinceId).HasName("PRIMARY");

            entity.ToTable("province");

            entity.HasIndex(e => e.CountryId, "FK_province_country");

            entity.HasIndex(e => e.GeoId, "FK_province_geography");

            entity.Property(e => e.ProvinceId)
                .HasColumnType("int(5)")
                .HasColumnName("PROVINCE_ID");
            entity.Property(e => e.CountryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("COUNTRY_ID");
            entity.Property(e => e.GeoId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("GEO_ID");
            entity.Property(e => e.ProvinceCode)
                .HasMaxLength(10)
                .HasColumnName("PROVINCE_CODE");
            entity.Property(e => e.ProvinceName)
                .HasMaxLength(150)
                .HasColumnName("PROVINCE_NAME");
            entity.Property(e => e.ProvinceNameEn)
                .HasMaxLength(150)
                .HasColumnName("PROVINCE_NAME_EN");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PRIMARY");

            entity.ToTable("region");

            entity.HasIndex(e => e.CustomerId, "customer_id");

            entity.HasIndex(e => new { e.RegionTitle, e.CustomerId }, "region_un").IsUnique();

            entity.Property(e => e.RegionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("region_id");
            entity.Property(e => e.CustomerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("customer_id");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.RegionTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("region_title");

            entity.HasOne(d => d.Customer).WithMany(p => p.Region)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_region_customer");
        });

        modelBuilder.Entity<ReportExportLog>(entity =>
        {
            entity.HasKey(e => new { e.Date, e.Time, e.Username })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("report_export_log");

            entity.Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("date");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("'00:00:00'")
                .HasColumnType("time")
                .HasColumnName("time");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("username");
            entity.Property(e => e.Detail)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("detail");
            entity.Property(e => e.Report)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("report");
        });

        modelBuilder.Entity<ReportViewLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("report_view_log");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("action");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("date");
            entity.Property(e => e.Detail)
                .HasDefaultValueSql("''")
                .HasColumnName("detail");
            entity.Property(e => e.MenuId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_id");
            entity.Property(e => e.Report)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("report");
            entity.Property(e => e.ReportViewLogConfigId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("report_view_log_config_id");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("'00:00:00'")
                .HasColumnType("time")
                .HasColumnName("time");
            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .HasDefaultValueSql("''")
                .HasColumnName("username");
        });

        modelBuilder.Entity<ReportViewLogConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("report_view_log_config");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Add).HasColumnName("add");
            entity.Property(e => e.Delete).HasColumnName("delete");
            entity.Property(e => e.Edit).HasColumnName("edit");
            entity.Property(e => e.Export).HasColumnName("export");
            entity.Property(e => e.Path)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("path");
            entity.Property(e => e.Table)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("table");
        });

        modelBuilder.Entity<ResolutionCategory>(entity =>
        {
            entity.HasKey(e => e.ResolutionCategoryId).HasName("PRIMARY");

            entity.ToTable("resolution_category");

            entity.HasIndex(e => e.ResolutionCategoryId, "resolution_category_id");

            entity.Property(e => e.ResolutionCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("resolution_category_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.ResolutionCategoryTitle)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("resolution_category_title");
        });

        modelBuilder.Entity<ResolutionType>(entity =>
        {
            entity.HasKey(e => e.ResolutionTypeId).HasName("PRIMARY");

            entity.ToTable("resolution_type");

            entity.HasIndex(e => new { e.ResolutionTypeTitle, e.ResolutionCategoryId }, "unique").IsUnique();

            entity.Property(e => e.ResolutionTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("resolution_type_id");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.ResolutionCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("resolution_category_id");
            entity.Property(e => e.ResolutionTypeTitle)
                .HasMaxLength(60)
                .HasDefaultValueSql("''")
                .HasColumnName("resolution_type_title");
            entity.Property(e => e.RootCauseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("root_cause_id");
        });

        modelBuilder.Entity<Risk>(entity =>
        {
            entity.HasKey(e => e.RiskId).HasName("PRIMARY");

            entity.ToTable("risk");

            entity.Property(e => e.RiskId)
                .HasColumnType("int(10)")
                .HasColumnName("risk_id");
            entity.Property(e => e.Color)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("color");
            entity.Property(e => e.MaxScore)
                .HasColumnType("int(10)")
                .HasColumnName("max_score");
            entity.Property(e => e.MinScore)
                .HasColumnType("int(10)")
                .HasColumnName("min_score");
            entity.Property(e => e.RiskTitle)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("risk_title");
        });

        modelBuilder.Entity<RiskAnalysis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("risk_analysis");

            entity.HasIndex(e => e.CaseId, "case_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("comment");
            entity.Property(e => e.IsAnalysis)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("is_analysis");
        });

        modelBuilder.Entity<RiskCaseLogType>(entity =>
        {
            entity.HasKey(e => e.RiskCaseLogTypeId).HasName("PRIMARY");

            entity.ToTable("risk_case_log_type");

            entity.Property(e => e.RiskCaseLogTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("risk_case_log_type_id");
            entity.Property(e => e.CaseLogCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_category_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.RiskCaseLogTypeTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("risk_case_log_type_title");
        });

        modelBuilder.Entity<RiskCategory>(entity =>
        {
            entity.HasKey(e => e.RiskCategoryId).HasName("PRIMARY");

            entity.ToTable("risk_category");

            entity.HasIndex(e => e.RiskCategoryTitle, "unique").IsUnique();

            entity.Property(e => e.RiskCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("risk_category_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.RiskCategoryTitle)
                .HasMaxLength(45)
                .HasColumnName("risk_category_title");
        });

        modelBuilder.Entity<RiskLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("risk_level");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.GridCode)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("grid_code");
            entity.Property(e => e.ImpactId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("impact_id");
            entity.Property(e => e.ProbabilityId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("probability_id");
            entity.Property(e => e.RiskLevel1)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("risk_level");
        });

        modelBuilder.Entity<RiskMitigation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("risk_mitigation");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Task)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("task");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("role");

            entity.HasIndex(e => e.RoleTitle, "unique").IsUnique();

            entity.Property(e => e.RoleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("role_id");
            entity.Property(e => e.RoleTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("role_title");
        });

        modelBuilder.Entity<RoleAuthorize>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("role_authorize");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ControlId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("control_id");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("type");
        });

        modelBuilder.Entity<RootCause>(entity =>
        {
            entity.HasKey(e => e.RootCauseId).HasName("PRIMARY");

            entity.ToTable("root_cause");

            entity.Property(e => e.RootCauseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("root_cause_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.Inactive)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.RootCauseTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("root_cause_title");
            entity.Property(e => e.ServiceTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("service_type_id");
        });

        modelBuilder.Entity<SaasCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("saas_customer");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CompanyLogo).HasColumnName("company_logo");
            entity.Property(e => e.Customercode)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("customercode");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("email");
            entity.Property(e => e.ExpireDate)
                .HasColumnType("datetime")
                .HasColumnName("expire_date");
            entity.Property(e => e.LoginBackground).HasColumnName("login_background");
            entity.Property(e => e.NumAgent)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("num_agent");
            entity.Property(e => e.Package)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("package");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PRIMARY");

            entity.ToTable("section");

            entity.HasIndex(e => e.DepartmentId, "department_id");

            entity.HasIndex(e => new { e.SectionTitle, e.DepartmentId }, "unique").IsUnique();

            entity.Property(e => e.SectionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("section_id");
            entity.Property(e => e.DepartmentId)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("department_id");
            entity.Property(e => e.SectionTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("section_title");

            entity.HasOne(d => d.Department).WithMany(p => p.Section)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("department_id");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.SectorId).HasName("PRIMARY");

            entity.ToTable("sector");

            entity.HasIndex(e => e.SectorTitle, "unique").IsUnique();

            entity.Property(e => e.SectorId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sector_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.SectorTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("sector_title");
        });

        modelBuilder.Entity<Select2Mapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("select2_mapping");

            entity.HasIndex(e => e.Name, "select2_mapping_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Filter)
                .HasMaxLength(1500)
                .HasDefaultValueSql("''")
                .HasColumnName("filter");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.PkKey)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("pk_key");
            entity.Property(e => e.QueryCount)
                .HasMaxLength(1500)
                .HasDefaultValueSql("''")
                .HasColumnName("query_count");
            entity.Property(e => e.QueryGroup)
                .HasMaxLength(1500)
                .HasDefaultValueSql("''")
                .HasColumnName("query_group");
            entity.Property(e => e.QueryOrderBy)
                .HasMaxLength(1500)
                .HasDefaultValueSql("''")
                .HasColumnName("query_order_by");
            entity.Property(e => e.QuerySearch)
                .HasMaxLength(1500)
                .HasDefaultValueSql("''")
                .HasColumnName("query_search");
            entity.Property(e => e.QueryWhere)
                .HasMaxLength(1500)
                .HasDefaultValueSql("''")
                .HasColumnName("query_where");
        });

        modelBuilder.Entity<SendEmailDebug>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("send_email_debug");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("action");
            entity.Property(e => e.CaseId)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("case_id");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<SendEmailSmsErrorLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("send_email_sms_error_log");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.DateTimestamp)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("date_timestamp");
            entity.Property(e => e.DebugMsg)
                .HasColumnType("text")
                .HasColumnName("debug_msg");
        });

        modelBuilder.Entity<ServiceCab>(entity =>
        {
            entity.HasKey(e => new { e.CaseTypeId, e.CabId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("service_cab");

            entity.HasIndex(e => e.CabId, "cab_id");

            entity.HasIndex(e => e.CaseTypeId, "case_type_id");

            entity.Property(e => e.CaseTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_type_id");
            entity.Property(e => e.CabId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("cab_id");
        });

        modelBuilder.Entity<ServiceTeam>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("service_team");

            entity.Property(e => e.CaseTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_type_id");
            entity.Property(e => e.TeamId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("team_id");
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.HasKey(e => e.ServiceTypeId).HasName("PRIMARY");

            entity.ToTable("service_type");

            entity.HasIndex(e => e.CaseIdFormat, "case_id_format");

            entity.HasIndex(e => e.IsImpactService, "is_impact_service");

            entity.HasIndex(e => e.ServiceTypeId, "service_type_id");

            entity.Property(e => e.ServiceTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("service_type_id");
            entity.Property(e => e.CaseIdFormat)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id_format");
            entity.Property(e => e.Inactive)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("inactive");
            entity.Property(e => e.IsImpactService)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("is_impact_service");
            entity.Property(e => e.ServiceTypeTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("service_type_title");

            entity.HasOne(d => d.CaseIdFormatNavigation).WithMany(p => p.ServiceType)
                .HasForeignKey(d => d.CaseIdFormat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("case_id_format");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.Date).HasName("PRIMARY");

            entity.ToTable("shift");

            entity.Property(e => e.Date)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("date");
            entity.Property(e => e._00)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("00");
            entity.Property(e => e._01)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("01");
            entity.Property(e => e._02)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("02");
            entity.Property(e => e._03)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("03");
            entity.Property(e => e._04)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("04");
            entity.Property(e => e._05)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("05");
            entity.Property(e => e._06)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("06");
            entity.Property(e => e._07)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("07");
            entity.Property(e => e._08)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("08");
            entity.Property(e => e._09)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("09");
            entity.Property(e => e._10)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("10");
            entity.Property(e => e._11)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("11");
            entity.Property(e => e._12)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("12");
            entity.Property(e => e._13)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("13");
            entity.Property(e => e._14)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("14");
            entity.Property(e => e._15)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("15");
            entity.Property(e => e._16)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("16");
            entity.Property(e => e._17)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("17");
            entity.Property(e => e._18)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("18");
            entity.Property(e => e._19)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("19");
            entity.Property(e => e._20)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("20");
            entity.Property(e => e._21)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("21");
            entity.Property(e => e._22)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("22");
            entity.Property(e => e._23)
                .HasMaxLength(45)
                .HasDefaultValueSql("'0'")
                .HasColumnName("23");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.HasKey(e => e.SiteId).HasName("PRIMARY");

            entity.ToTable("site");

            entity.HasIndex(e => e.Amphur, "FK_site_amphur");

            entity.HasIndex(e => e.Country, "FK_site_country");

            entity.HasIndex(e => e.Province, "FK_site_province");

            entity.HasIndex(e => e.Tambol, "FK_site_tambol");

            entity.HasIndex(e => e.CustomerId, "customer");

            entity.HasIndex(e => e.RegionId, "region");

            entity.HasIndex(e => new { e.SiteTitle, e.CustomerId, e.RegionId }, "unique").IsUnique();

            entity.Property(e => e.SiteId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("site_id");
            entity.Property(e => e.Address)
                .HasMaxLength(45)
                .HasColumnName("address");
            entity.Property(e => e.Amphur)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(5)")
                .HasColumnName("amphur");
            entity.Property(e => e.Building)
                .HasMaxLength(1000)
                .HasColumnName("building");
            entity.Property(e => e.Country)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("country");
            entity.Property(e => e.CustomerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("customer_id");
            entity.Property(e => e.Fax)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("fax");
            entity.Property(e => e.Hq)
                .HasMaxLength(5)
                .HasDefaultValueSql("'0'")
                .HasColumnName("hq");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.Lat)
                .HasPrecision(10, 7)
                .HasColumnName("lat");
            entity.Property(e => e.Level)
                .HasMaxLength(5)
                .HasDefaultValueSql("''")
                .HasColumnName("level");
            entity.Property(e => e.Lng)
                .HasPrecision(10, 7)
                .HasColumnName("lng");
            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("phone");
            entity.Property(e => e.Province)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(5)")
                .HasColumnName("province");
            entity.Property(e => e.RegionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("region_id");
            entity.Property(e => e.SiteTitle)
                .HasMaxLength(200)
                .HasColumnName("site_title");
            entity.Property(e => e.SiteTitleEn)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("site_title_en");
            entity.Property(e => e.Street)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("street");
            entity.Property(e => e.Tambol)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(5)")
                .HasColumnName("tambol");
            entity.Property(e => e.Web)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("web");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("zip");
        });

        modelBuilder.Entity<SiteZone>(entity =>
        {
            entity.HasKey(e => e.SiteId).HasName("PRIMARY");

            entity.ToTable("site_zone");

            entity.Property(e => e.SiteId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("site_id");
            entity.Property(e => e.SiteTitle)
                .HasMaxLength(150)
                .HasDefaultValueSql("''")
                .HasColumnName("site_title");
            entity.Property(e => e.Zone)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("zone");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PRIMARY");

            entity.ToTable("skill");

            entity.HasIndex(e => e.CaseSubCategoryId, "case_sub_category_id");

            entity.HasIndex(e => e.SkillLevelId, "skill_level_id");

            entity.HasIndex(e => e.StaffId, "staff_id");

            entity.Property(e => e.SkillId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("skill_id");
            entity.Property(e => e.CaseSubCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_sub_category_id");
            entity.Property(e => e.SkillLevelId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("skill_level_id");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.TierId)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("tier_id");
        });

        modelBuilder.Entity<SkillLevel>(entity =>
        {
            entity.HasKey(e => e.SkillLevelId).HasName("PRIMARY");

            entity.ToTable("skill_level");

            entity.HasIndex(e => e.SkillLevelTitle, "unique").IsUnique();

            entity.Property(e => e.SkillLevelId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("skill_level_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.SkillLevelTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("skill_level_title");
        });

        modelBuilder.Entity<SkillTraining>(entity =>
        {
            entity.HasKey(e => e.TrainingId).HasName("PRIMARY");

            entity.ToTable("skill_training");

            entity.Property(e => e.TrainingId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("training_id");
            entity.Property(e => e.CaseSubCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_sub_category_id");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.TrainingCode)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("training_code");
            entity.Property(e => e.TrainingCourse)
                .HasMaxLength(1000)
                .HasDefaultValueSql("''")
                .HasColumnName("training_course");
        });

        modelBuilder.Entity<Sla>(entity =>
        {
            entity.HasKey(e => e.SlaId).HasName("PRIMARY");

            entity.ToTable("sla");

            entity.HasIndex(e => e.SlaTitle, "sla_title").IsUnique();

            entity.Property(e => e.SlaId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sla_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.SlaCode)
                .HasMaxLength(20)
                .HasColumnName("sla_code");
            entity.Property(e => e.SlaTitle)
                .HasMaxLength(45)
                .HasColumnName("sla_title");
        });

        modelBuilder.Entity<SlaDetail>(entity =>
        {
            entity.HasKey(e => e.SlaDetailId).HasName("PRIMARY");

            entity.ToTable("sla_detail");

            entity.HasIndex(e => e.PriorityId, "priority_id");

            entity.HasIndex(e => e.SlaId, "sla_id");

            entity.Property(e => e.SlaDetailId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sla_detail_id");
            entity.Property(e => e.Autoclose)
                .HasMaxLength(45)
                .HasDefaultValueSql("'00:00'")
                .HasColumnName("autoclose");
            entity.Property(e => e.Onsite)
                .HasMaxLength(45)
                .HasDefaultValueSql("'00:00'")
                .HasColumnName("onsite");
            entity.Property(e => e.PriorityId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("priority_id");
            entity.Property(e => e.Resolve)
                .HasMaxLength(45)
                .HasDefaultValueSql("'00:00'")
                .HasColumnName("resolve");
            entity.Property(e => e.Response)
                .HasMaxLength(45)
                .HasDefaultValueSql("'00:00'")
                .HasColumnName("response");
            entity.Property(e => e.SlaId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sla_id");
            entity.Property(e => e._7x24)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("7x24");
        });

        modelBuilder.Entity<SmsTemplate>(entity =>
        {
            entity.HasKey(e => e.SmsTemplateId).HasName("PRIMARY");

            entity.ToTable("sms_template");

            entity.Property(e => e.SmsTemplateId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sms_template_id");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.SmsTemplateName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("sms_template_name");
            entity.Property(e => e.TemplateTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("template_type_id");
        });

        modelBuilder.Entity<Spare>(entity =>
        {
            entity.HasKey(e => e.SpareId).HasName("PRIMARY");

            entity.ToTable("spare");

            entity.HasIndex(e => e.AssetSubCategoryId, "asset_catogory_id");

            entity.HasIndex(e => e.OfficeId, "office_id");

            entity.HasIndex(e => e.PartNumber, "part_number");

            entity.HasIndex(e => e.SpareCode, "unique").IsUnique();

            entity.HasIndex(e => e.SerialNumber, "unique2").IsUnique();

            entity.HasIndex(e => e.VendorId, "vendor_id");

            entity.Property(e => e.SpareId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("spare_id");
            entity.Property(e => e.AssetSubCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("asset_sub_category_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Expire)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("expire");
            entity.Property(e => e.ExpireAlert)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("expire_alert");
            entity.Property(e => e.ItemStatusId)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("item_status_id");
            entity.Property(e => e.OfficeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("office_id");
            entity.Property(e => e.PartNumber)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("part_number");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("serial_number");
            entity.Property(e => e.SpareCode)
                .HasMaxLength(45)
                .HasColumnName("spare_code");
            entity.Property(e => e.SpareTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("spare_title");
            entity.Property(e => e.Start)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("start");
            entity.Property(e => e.VendorId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("vendor_id");
        });

        modelBuilder.Entity<SpareLog>(entity =>
        {
            entity.HasKey(e => e.SpareLogId).HasName("PRIMARY");

            entity.ToTable("spare_log");

            entity.HasIndex(e => e.ItemStatusId, "item_status_id");

            entity.HasIndex(e => e.SpareId, "spare_id");

            entity.Property(e => e.SpareLogId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("spare_log_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ItemStatusId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("item_status_id");
            entity.Property(e => e.LoggedBy)
                .HasMaxLength(32)
                .HasDefaultValueSql("''")
                .HasColumnName("logged_by");
            entity.Property(e => e.SpareId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("spare_id");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("'00:00:00'")
                .HasColumnType("time")
                .HasColumnName("time");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PRIMARY");

            entity.ToTable("staff");

            entity.HasIndex(e => e.DepartmentId, "department_id");

            entity.HasIndex(e => e.OfficeId, "office_id");

            entity.HasIndex(e => e.PrefixId, "prefix_id");

            entity.HasIndex(e => e.RoleId, "role_id");

            entity.HasIndex(e => e.SectionId, "section_id");

            entity.HasIndex(e => e.StaffStatusId, "staff_status_id");

            entity.HasIndex(e => e.TeamId, "team_id");

            entity.HasIndex(e => new { e.Firstname, e.Lastname }, "unique").IsUnique();

            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.BisHourProfileId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("bis_hour_profile_id");
            entity.Property(e => e.BossId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("boss_id");
            entity.Property(e => e.BusinessProfileId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("business_profile_id");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.DepartmentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("department_id");
            entity.Property(e => e.Email)
                .HasMaxLength(1500)
                .HasColumnName("email");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(20)
                .HasDefaultValueSql("'0'")
                .HasColumnName("employee_id");
            entity.Property(e => e.Firstname)
                .HasMaxLength(32)
                .HasDefaultValueSql("''")
                .HasColumnName("firstname");
            entity.Property(e => e.GenderId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("gender_id");
            entity.Property(e => e.HireDate)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("hire_date");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.InactiveChatbot)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive_chatbot");
            entity.Property(e => e.Lastname)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("lastname");
            entity.Property(e => e.Mobile)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("mobile");
            entity.Property(e => e.OfficeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("office_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("phone");
            entity.Property(e => e.PositionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("position_id");
            entity.Property(e => e.PrefixId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("prefix_id");
            entity.Property(e => e.ProfileImage)
                .HasDefaultValueSql("''")
                .HasColumnName("profile_image");
            entity.Property(e => e.RoleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("role_id");
            entity.Property(e => e.SectionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("section_id");
            entity.Property(e => e.SeeCasesAll).HasColumnName("see_cases_all");
            entity.Property(e => e.SeeCasesInDepartment).HasColumnName("see_cases_in_department");
            entity.Property(e => e.SeeCasesInSection).HasColumnName("see_cases_in_section");
            entity.Property(e => e.SeeCasesInTeam).HasColumnName("see_cases_in_team");
            entity.Property(e => e.StaffStatusId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_status_id");
            entity.Property(e => e.TeamId)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("team_id");
        });

        modelBuilder.Entity<StaffLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("staff_location");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Lat)
                .HasPrecision(10, 7)
                .HasColumnName("lat");
            entity.Property(e => e.Lng)
                .HasPrecision(10, 7)
                .HasColumnName("lng");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<StaffLocationLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("staff_location_log");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseLogId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_id");
            entity.Property(e => e.Lat)
                .HasPrecision(10, 7)
                .HasColumnName("lat");
            entity.Property(e => e.Lng)
                .HasPrecision(10, 7)
                .HasColumnName("lng");
            entity.Property(e => e.Remark)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("remark");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<StaffLocationTracking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("staff_location_tracking");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.Lat)
                .HasPrecision(10, 7)
                .HasColumnName("lat");
            entity.Property(e => e.Lng)
                .HasPrecision(10, 7)
                .HasColumnName("lng");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<StaffProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("staff_profile");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CalendarNoti)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("calendar_noti");
            entity.Property(e => e.MenuId)
                .HasColumnType("int(11)")
                .HasColumnName("menu_id");
            entity.Property(e => e.PrivateMsgNoti)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("private_msg_noti");
            entity.Property(e => e.StaffId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.TaskAssignNoti)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("task_assign_noti");
            entity.Property(e => e.TaskEscalationNoti)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("task_escalation_noti");
        });

        modelBuilder.Entity<StaffStatus>(entity =>
        {
            entity.HasKey(e => e.StaffStatusId).HasName("PRIMARY");

            entity.ToTable("staff_status");

            entity.HasIndex(e => e.StaffStatusTitle, "unique").IsUnique();

            entity.Property(e => e.StaffStatusId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_status_id");
            entity.Property(e => e.StaffStatusTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("staff_status_title");
        });

        modelBuilder.Entity<StatusMappingSdIncident>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status_mapping_sd_incident");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.IncidentStatusId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("incident_status_id");
            entity.Property(e => e.SdStatusId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sd_status_id");
        });

        modelBuilder.Entity<SubCategoryTeam>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("sub_category_team");

            entity.Property(e => e.CaseSubCateogryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_sub_cateogry_id");
            entity.Property(e => e.TeamId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("team_id");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity.ToTable("supplier");

            entity.HasIndex(e => e.Amphur, "amphur");

            entity.HasIndex(e => e.Country, "country");

            entity.HasIndex(e => e.Inactive, "inactive");

            entity.HasIndex(e => e.Province, "province");

            entity.HasIndex(e => e.SupplierCode, "supplier_code").IsUnique();

            entity.HasIndex(e => e.SupplierName, "supplier_name").IsUnique();

            entity.HasIndex(e => e.Tambol, "tambol");

            entity.Property(e => e.SupplierId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("supplier_id");
            entity.Property(e => e.Address)
                .HasMaxLength(20)
                .HasColumnName("address");
            entity.Property(e => e.Amphur)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("amphur");
            entity.Property(e => e.Building)
                .HasMaxLength(45)
                .HasColumnName("building");
            entity.Property(e => e.Country)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("country");
            entity.Property(e => e.Fax)
                .HasMaxLength(45)
                .HasColumnName("fax");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.Lat)
                .HasPrecision(10, 7)
                .HasColumnName("lat");
            entity.Property(e => e.Level)
                .HasMaxLength(5)
                .HasColumnName("level");
            entity.Property(e => e.Lng)
                .HasPrecision(10, 7)
                .HasColumnName("lng");
            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .HasColumnName("phone");
            entity.Property(e => e.Province)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("province");
            entity.Property(e => e.Street)
                .HasMaxLength(45)
                .HasColumnName("street");
            entity.Property(e => e.SupplierCode)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("supplier_code");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("supplier_name");
            entity.Property(e => e.Tambol)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("tambol");
            entity.Property(e => e.Web)
                .HasMaxLength(200)
                .HasColumnName("web");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .HasColumnName("zip");
        });

        modelBuilder.Entity<SupplierContact>(entity =>
        {
            entity.HasKey(e => e.SupplierContactId).HasName("PRIMARY");

            entity.ToTable("supplier_contact");

            entity.HasIndex(e => e.Inactive, "inactive");

            entity.HasIndex(e => e.SupplierId, "supplier_id");

            entity.Property(e => e.SupplierContactId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("supplier_contact_id");
            entity.Property(e => e.ContactName)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("contact_name");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("email");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.Mobile)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("mobile");
            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .HasColumnName("phone");
            entity.Property(e => e.Position)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("position");
            entity.Property(e => e.ProfileImage).HasColumnName("profile_image");
            entity.Property(e => e.Remark)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("remark");
            entity.Property(e => e.SupplierId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("supplier_id");
        });

        modelBuilder.Entity<SupplierContactProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("supplier_contact_profile");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CalendarNoti)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("calendar_noti");
            entity.Property(e => e.MenuId)
                .HasColumnType("int(11)")
                .HasColumnName("menu_id");
            entity.Property(e => e.PrivateMsgNoti)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("private_msg_noti");
            entity.Property(e => e.SupplierContactId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("supplier_contact_id");
            entity.Property(e => e.TaskAssignNoti)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("task_assign_noti");
            entity.Property(e => e.TaskEscalationNoti)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("task_escalation_noti");
        });

        modelBuilder.Entity<SymptomType>(entity =>
        {
            entity.HasKey(e => e.SymptomTypeId).HasName("PRIMARY");

            entity.ToTable("symptom_type");

            entity.Property(e => e.SymptomTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("symptom_type_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.Inactive)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.SymptomTypeTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("symptom_type_title");
        });

        modelBuilder.Entity<Tambol>(entity =>
        {
            entity.HasKey(e => e.TambolId).HasName("PRIMARY");

            entity.ToTable("tambol");

            entity.HasIndex(e => e.AmphurId, "FK_tambol_amphur");

            entity.HasIndex(e => e.CountryId, "FK_tambol_country");

            entity.HasIndex(e => e.GeoId, "FK_tambol_geography");

            entity.HasIndex(e => e.ProvinceId, "FK_tambol_province");

            entity.Property(e => e.TambolId)
                .HasColumnType("int(5)")
                .HasColumnName("TAMBOL_ID");
            entity.Property(e => e.AmphurId)
                .HasColumnType("int(5)")
                .HasColumnName("AMPHUR_ID");
            entity.Property(e => e.CountryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("COUNTRY_ID");
            entity.Property(e => e.GeoId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("GEO_ID");
            entity.Property(e => e.ProvinceId)
                .HasColumnType("int(5)")
                .HasColumnName("PROVINCE_ID");
            entity.Property(e => e.TambolCode)
                .HasMaxLength(6)
                .HasColumnName("TAMBOL_CODE");
            entity.Property(e => e.TambolName)
                .HasMaxLength(150)
                .HasColumnName("TAMBOL_NAME");
            entity.Property(e => e.TambolNameEn)
                .HasMaxLength(150)
                .HasDefaultValueSql("''")
                .HasColumnName("TAMBOL_NAME_EN");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PRIMARY");

            entity.ToTable("team");

            entity.HasIndex(e => e.TeamTitle, "unique").IsUnique();

            entity.Property(e => e.TeamId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("team_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.LineToken)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("line_token");
            entity.Property(e => e.TeamTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("team_title");
        });

        modelBuilder.Entity<Template>(entity =>
        {
            entity.HasKey(e => e.TemplateId).HasName("PRIMARY");

            entity.ToTable("template");

            entity.Property(e => e.TemplateId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("template_id");
            entity.Property(e => e.AlertTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("alert_type_id");
            entity.Property(e => e.ImgFooter)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("img_footer");
            entity.Property(e => e.Message)
                .HasDefaultValueSql("''")
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.Subject)
                .HasDefaultValueSql("''")
                .HasColumnType("text")
                .HasColumnName("subject");
            entity.Property(e => e.TemplateTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("template_title");
        });

        modelBuilder.Entity<TestStartFinish>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("test_start_finish");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DateFinish)
                .HasColumnType("datetime")
                .HasColumnName("date_finish");
            entity.Property(e => e.DateStart)
                .HasColumnType("datetime")
                .HasColumnName("date_start");
        });

        modelBuilder.Entity<Tier>(entity =>
        {
            entity.HasKey(e => e.TierId).HasName("PRIMARY");

            entity.ToTable("tier");

            entity.HasIndex(e => e.TierTitle, "unique").IsUnique();

            entity.Property(e => e.TierId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("tier_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Inactive)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.TierSequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("tier_sequence");
            entity.Property(e => e.TierTitle)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("tier_title");
        });

        modelBuilder.Entity<Translate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("translate");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .HasColumnName("code");
            entity.Property(e => e.Icon).HasColumnName("icon");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasColumnName("title");
            entity.Property(e => e.Words).HasColumnName("words");
        });

        modelBuilder.Entity<Tutorial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tutorial");

            entity.HasIndex(e => new { e.Title, e.Description }, "title").HasAnnotation("MySql:FullTextIndex", true);

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
        });

        modelBuilder.Entity<TypeOfService>(entity =>
        {
            entity.HasKey(e => e.TypeOfServiceId).HasName("PRIMARY");

            entity.ToTable("type_of_service");

            entity.Property(e => e.TypeOfServiceId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("type_of_service_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.Inactive)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("inactive");
            entity.Property(e => e.IsSlaEffect)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("is_sla_effect");
            entity.Property(e => e.TypeOfServiceTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("type_of_service_title");
        });

        modelBuilder.Entity<Urgency>(entity =>
        {
            entity.HasKey(e => e.UrgencyId).HasName("PRIMARY");

            entity.ToTable("urgency");

            entity.HasIndex(e => e.UrgencyTitle, "unique").IsUnique();

            entity.Property(e => e.UrgencyId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("urgency_id");
            entity.Property(e => e.AllowDelete)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("allow_delete");
            entity.Property(e => e.AnalyzeDuration)
                .HasMaxLength(10)
                .HasColumnName("analyze_duration");
            entity.Property(e => e.ApproveDuration)
                .HasMaxLength(10)
                .HasColumnName("approve_duration");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ReviewDuration)
                .HasMaxLength(10)
                .HasColumnName("review_duration");
            entity.Property(e => e.UrgencySequence)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("urgency_sequence");
            entity.Property(e => e.UrgencyTitle)
                .HasMaxLength(45)
                .HasColumnName("urgency_title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .HasDefaultValueSql("''")
                .HasColumnName("username");
            entity.Property(e => e.AcceptCase)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("accept_case");
            entity.Property(e => e.AddKm)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("add_km");
            entity.Property(e => e.ApproveKm)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("approve_km");
            entity.Property(e => e.AssignCase)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("assign_case");
            entity.Property(e => e.ChangepwDay)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("changepw_day");
            entity.Property(e => e.CloseCase)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("close_case");
            entity.Property(e => e.ContactId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("contact_id");
            entity.Property(e => e.CreateCase)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("create_case");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("created_datetime");
            entity.Property(e => e.DeleteCase)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("delete_case");
            entity.Property(e => e.Disable)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("disable");
            entity.Property(e => e.EditLog)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("edit_log");
            entity.Property(e => e.ExpiryDate).HasColumnName("expiry_date");
            entity.Property(e => e.Export)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("export");
            entity.Property(e => e.InProgressCase)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("in_progress_case");
            entity.Property(e => e.KioskId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("kiosk_id");
            entity.Property(e => e.LdapName)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("ldap_name");
            entity.Property(e => e.LdapPath)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("ldap_path");
            entity.Property(e => e.LevelId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("level_id");
            entity.Property(e => e.LockNum)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("lock_num");
            entity.Property(e => e.LockScreen)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("lock_screen");
            entity.Property(e => e.Objectsid)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("objectsid");
            entity.Property(e => e.OnsiteCase)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("onsite_case");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("password");
            entity.Property(e => e.PasswordResetToken)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("password_reset_token");
            entity.Property(e => e.PasswordUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("password_update_date");
            entity.Property(e => e.PendingCase)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("pending_case");
            entity.Property(e => e.Print)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("print");
            entity.Property(e => e.ReadOnly)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("read_only");
            entity.Property(e => e.ResolveCase)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("resolve_case");
            entity.Property(e => e.ResponseCase)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("response_case");
            entity.Property(e => e.StaffId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("staff_id");
            entity.Property(e => e.SupplierContactId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("supplier_contact_id");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("updated_datetime");
            entity.Property(e => e.UserLineId)
                .HasMaxLength(255)
                .HasColumnName("user_line_id");
            entity.Property(e => e.Useraccountcontrol)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("useraccountcontrol");
        });

        modelBuilder.Entity<UserControl>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PRIMARY");

            entity.ToTable("user_control");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("username");
            entity.Property(e => e.Msg)
                .HasMaxLength(5)
                .HasDefaultValueSql("'true'")
                .HasColumnName("msg");
            entity.Property(e => e.Nav)
                .HasMaxLength(5)
                .HasDefaultValueSql("'true'")
                .HasColumnName("nav");
        });

        modelBuilder.Entity<Variables>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PRIMARY");

            entity.ToTable("variables");

            entity.HasIndex(e => e.Category, "category");

            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.Category)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("category");
            entity.Property(e => e.Datatype)
                .HasMaxLength(45)
                .HasColumnName("datatype");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.Hidden)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("hidden");
            entity.Property(e => e.OrderNum)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("order_num");
            entity.Property(e => e.Value)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("value");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PRIMARY");

            entity.ToTable("vendor");

            entity.HasIndex(e => e.VendorName, "unique").IsUnique();

            entity.Property(e => e.VendorId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("vendor_id");
            entity.Property(e => e.VendorCode)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("vendor_code");
            entity.Property(e => e.VendorName)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .HasColumnName("vendor_name");
        });

        modelBuilder.Entity<Watcher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("watcher");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.ContactId)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("contact_id");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.StaffId)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("staff_id");
            entity.Property(e => e.SupplierContactId)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("supplier_contact_id");
        });

        modelBuilder.Entity<Webboard>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PRIMARY");

            entity.ToTable("webboard");

            entity.Property(e => e.TopicId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("topic_id");
            entity.Property(e => e.Author)
                .HasMaxLength(32)
                .HasDefaultValueSql("''")
                .HasColumnName("author");
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("category_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("date");
            entity.Property(e => e.Locks)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("locks");
            entity.Property(e => e.Pin)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("pin");
            entity.Property(e => e.Posts)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("posts");
            entity.Property(e => e.ReadNum)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("read_num");
            entity.Property(e => e.Subject)
                .HasColumnType("text")
                .HasColumnName("subject");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("'00:00:00'")
                .HasColumnType("time")
                .HasColumnName("time");
        });

        modelBuilder.Entity<WebboardCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("webboard_category");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(45)
                .HasColumnName("category_name");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
        });

        modelBuilder.Entity<WebboardReply>(entity =>
        {
            entity.HasKey(e => e.ReplyId).HasName("PRIMARY");

            entity.ToTable("webboard_reply");

            entity.HasIndex(e => e.TopicId, "topic_id");

            entity.Property(e => e.ReplyId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("reply_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("date");
            entity.Property(e => e.EditBy)
                .HasMaxLength(32)
                .HasDefaultValueSql("''")
                .HasColumnName("edit_by");
            entity.Property(e => e.EditDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("edit_date");
            entity.Property(e => e.EditTime)
                .HasDefaultValueSql("'00:00:00'")
                .HasColumnType("time")
                .HasColumnName("edit_time");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("'00:00:00'")
                .HasColumnType("time")
                .HasColumnName("time");
            entity.Property(e => e.TopicId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("topic_id");
            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .HasColumnName("username");
        });

        modelBuilder.Entity<WorkCategory>(entity =>
        {
            entity.HasKey(e => e.WorkCategoryId).HasName("PRIMARY");

            entity.ToTable("work_category");

            entity.Property(e => e.WorkCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("work_category_id");
            entity.Property(e => e.WorkCategoryTitle)
                .HasMaxLength(45)
                .HasColumnName("work_category_title");
        });

        modelBuilder.Entity<WorkDay>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("work_day");

            entity.Property(e => e.Friday)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.Monday)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.Thrusday)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.Tuesday)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.Wednesday)
                .IsRequired()
                .HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<WorkflowParticipate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("workflow_participate");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Index).HasColumnType("int(10) unsigned");
            entity.Property(e => e.ModuleSrcId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_src_id");
            entity.Property(e => e.Pid)
                .HasMaxLength(255)
                .HasColumnName("PID");
            entity.Property(e => e.SrcId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("src_id");
            entity.Property(e => e.Uid)
                .HasMaxLength(255)
                .HasColumnName("UID");
        });

        modelBuilder.Entity<WorkflowRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("workflow_rule");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CaseLogTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_type_id");
            entity.Property(e => e.CaseStatusId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_status_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.Inactive).HasColumnName("inactive");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("module_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
            entity.Property(e => e.WorkflowId)
                .HasMaxLength(255)
                .HasColumnName("workflow_id");
        });

        modelBuilder.Entity<WorkflowRuleCondition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("workflow_rule_condition");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ColumnName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("column_name");
            entity.Property(e => e.ColumnOperator)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("column_operator");
            entity.Property(e => e.ColumnValue)
                .HasColumnType("text")
                .HasColumnName("column_value");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Inactive).HasColumnName("inactive");
            entity.Property(e => e.WorkflowRuleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workflow_rule_id");
        });

        modelBuilder.Entity<WorkingLogDeleted>(entity =>
        {
            entity.HasKey(e => e.CaseLogId).HasName("PRIMARY");

            entity.ToTable("working_log_deleted");

            entity.HasIndex(e => new { e.CaseId, e.CaseLogTypeId }, "Index_couple");

            entity.HasIndex(e => e.CaseId, "case_id");

            entity.HasIndex(e => e.CaseLogCategoryId, "case_log_category_id");

            entity.HasIndex(e => e.CaseLogTypeId, "case_log_type_id");

            entity.Property(e => e.CaseLogId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_id");
            entity.Property(e => e.CaseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_id");
            entity.Property(e => e.CaseLogCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_category_id");
            entity.Property(e => e.CaseLogDescription)
                .HasColumnType("text")
                .HasColumnName("case_log_description");
            entity.Property(e => e.CaseLogTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("case_log_type_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnName("date");
            entity.Property(e => e.LoggedBy)
                .HasMaxLength(32)
                .HasDefaultValueSql("'0'")
                .HasColumnName("logged_by");
            entity.Property(e => e.Reference)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("reference");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("'00:00:00'")
                .HasColumnType("time")
                .HasColumnName("time");
        });
    }
}
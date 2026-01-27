using AuxiliumSoftware.AuxiliumServices.Common.DataStructures;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection.Emit;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework;

public class AuxiliumDbContext : DbContext
{
    public AuxiliumDbContext(DbContextOptions<AuxiliumDbContext> options)
        : base(options)
    {
    }

    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        Converters = { new JsonStringEnumConverter() }
    };






    public DbSet<AuditLogEntryEntityModel> AuditLog { get; set; }
    public DbSet<SystemBulletinEntryEntityModel> SystemBulletin { get; set; }
    public DbSet<UserEntityModel> Users { get; set; }
    public DbSet<CaseEntityModel> Cases { get; set; }
    public DbSet<CaseWorkerEntityModel> CaseWorkers { get; set; }
    public DbSet<CaseClientEntityModel> CaseClients { get; set; }
    public DbSet<CaseAdditionalPropertyEntityModel> CaseAdditionalProperties { get; set; }
    public DbSet<UserAdditionalPropertyEntityModel> UserAdditionalProperties { get; set; }
    public DbSet<CaseMessageEntityModel> CaseMessages { get; set; }
    public DbSet<CaseMessageReadByEntityModel> CaseMessagesReadBys { get; set; }
    public DbSet<CaseFileEntityModel> CaseFiles { get; set; }
    public DbSet<UserFileEntityModel> UserFiles { get; set; }
    public DbSet<CaseTodoEntityModel> CaseTodos { get; set; }
    public DbSet<CaseTimelineItemEntityModel> CaseTimeline { get; set; }
    public DbSet<RefreshTokenEntityModel> RefreshTokens { get; set; }
    public DbSet<WEMWBSEntityModel> WEMWBSAssessments { get; set; }





    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // audit_log
        modelBuilder.Entity<AuditLogEntryEntityModel>(entity =>
        {
            entity.ToTable("audit_log");
            entity.HasKey(e => e.Id);



            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)")                                                                                                          .IsRequired();
            
            entity.Property(e => e.EventType)                       .HasColumnName("event_type")                                .HasColumnType("text")                  .HasConversion<string>()                                                                    .IsRequired();
            entity.Property(e => e.ClientIPAddress)                 .HasColumnName("client_ip_address")                         .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.Metadata)                        .HasColumnName("metadata")                                  .HasColumnType("json")                  .HasConversion(
                                                                                                                                                                            v => JsonSerializer.Serialize(
                                                                                                                                                                                v.ToDictionary(k => k.Key.ToString(), k => k.Value),
                                                                                                                                                                                _jsonOptions),
                                                                                                                                                                            v => string.IsNullOrEmpty(v)
                                                                                                                                                                            ? new Dictionary<AuditLogEntryMetadataKey, object>()
                                                                                                                                                                            : JsonSerializer.Deserialize<Dictionary<string, object>>(v, _jsonOptions) == null
                                                                                                                                                                            ? new Dictionary<AuditLogEntryMetadataKey, object>()
                                                                                                                                                                            : JsonSerializer.Deserialize<Dictionary<string, object>>(v, _jsonOptions)!
                                                                                                                                                                            .ToDictionary(
                                                                                                                                                                                k => Enum.Parse<AuditLogEntryMetadataKey>(k.Key),
                                                                                                                                                                                k => k.Value)
                                                                                                                                                                            )                                                                                       .IsRequired();



            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.Cascade);
        });

        // system_bulletin
        modelBuilder.Entity<SystemBulletinEntryEntityModel>(entity =>
        {
            entity.ToTable("system_bulletin");
            entity.HasKey(e => e.Id);



            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");
            
            entity.Property(e => e.Severity)                        .HasColumnName("severity")                                  .HasColumnType("text")                  .HasConversion<string>()                                                                    .IsRequired();
            entity.Property(e => e.Title)                           .HasColumnName("title")                                     .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.Content)                         .HasColumnName("content")                                   .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.IsActive)                        .HasColumnName("is_active")                                 .HasColumnType("tinyint(1)")                                                          .HasDefaultValueSql("false")                  .IsRequired();
            entity.Property(e => e.IsDismissable)                   .HasColumnName("is_dismissable")                            .HasColumnType("tinyint(1)")                                                                                                        .IsRequired();
            entity.Property(e => e.StartsAt)                        .HasColumnName("starts_at")                                 .HasColumnType("datetime")                                                                                                          .IsRequired();
            entity.Property(e => e.EndsAt)                          .HasColumnName("ends_at")                                   .HasColumnType("datetime");
            entity.Property(e => e.SpecificUserId)                  .HasColumnName("specific_user_id")                          .HasColumnType("char(36)");


            
            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.SpecificUser)                      .WithMany()                                                 .HasForeignKey(e => e.SpecificUserId)   .OnDelete(DeleteBehavior.SetNull);
        });

        // users
        modelBuilder.Entity<UserEntityModel>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(e => e.Id);



            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");
            entity.Property(e => e.LastUpdatedAt)                   .HasColumnName("last_updated_at")                           .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)                   .HasColumnName("last_updated_by")                           .HasColumnType("char(36)");

            entity.Property(e => e.EmailAddress)                    .HasColumnName("email_address")                             .HasColumnType("text");
            entity.Property(e => e.PasswordHash)                    .HasColumnName("password_hash")                             .HasColumnType("text");
            entity.Property(e => e.FullName)                        .HasColumnName("full_name")                                 .HasColumnType("text")                                                                                                              .IsRequired();

            entity.Property(e => e.FullAddress)                     .HasColumnName("full_address")                              .HasColumnType("text");
            entity.Property(e => e.TelephoneNumber)                 .HasColumnName("telephone_number")                          .HasColumnType("text");
            entity.Property(e => e.Gender)                          .HasColumnName("gender")                                    .HasColumnType("text");
            entity.Property(e => e.DateOfBirth)                     .HasColumnName("date_of_birth")                             .HasColumnType("date");
            entity.Property(e => e.HowDidYouFindOutAboutOurService) .HasColumnName("how_did_you_find_out_about_our_service")    .HasColumnType("text");
            entity.Property(e => e.LanguagePreference)              .HasColumnName("language_preference")                       .HasColumnType("text")                                                          .HasDefaultValue("en-GB")                           .IsRequired();

            entity.Property(e => e.AllowLogin)                      .HasColumnName("allow_login")                               .HasColumnType("tinyint(1)")                                                    .HasDefaultValue(true)                              .IsRequired();
            entity.Property(e => e.IsAdmin)                         .HasColumnName("is_admin")                                  .HasColumnType("tinyint(1)")                                                    .HasDefaultValue(false)                             .IsRequired();
            entity.Property(e => e.IsCaseWorker)                    .HasColumnName("is_case_worker")                            .HasColumnType("tinyint(1)")                                                    .HasDefaultValue(false)                             .IsRequired();



            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.LastUpdatedByUser)                 .WithMany()                                                 .HasForeignKey(e => e.LastUpdatedBy)    .OnDelete(DeleteBehavior.SetNull);



            entity.HasIndex(e => e.EmailAddress).IsUnique();
        });

        // wemwbs
        modelBuilder.Entity<WEMWBSEntityModel>(entity =>
        {
            entity.ToTable("wemwbs_assessments");
            entity.HasKey(e => e.Id);



            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");
            
            entity.Property(e => e.OptimismScore)                   .HasColumnName("optimism_score")                            .HasColumnType("int")                                                                                                               .IsRequired();
            entity.Property(e => e.UsefulnessScore)                 .HasColumnName("usefulness_score")                          .HasColumnType("int")                                                                                                               .IsRequired();
            entity.Property(e => e.RelaxedScore)                    .HasColumnName("relaxed_score")                             .HasColumnType("int")                                                                                                               .IsRequired();
            entity.Property(e => e.InterestedInPeopleScore)         .HasColumnName("interested_in_people_score")                .HasColumnType("int")                                                                                                               .IsRequired();
            entity.Property(e => e.SpareEnergyScore)                .HasColumnName("spare_energy_score")                        .HasColumnType("int")                                                                                                               .IsRequired();
            entity.Property(e => e.ProblemHandlingScore)            .HasColumnName("problem_handling_score")                    .HasColumnType("int")                                                                                                               .IsRequired();
            entity.Property(e => e.ClearThoughtScore)               .HasColumnName("clear_thought_score")                       .HasColumnType("int")                                                                                                               .IsRequired();
            entity.Property(e => e.FeelingGoodSelfScore)            .HasColumnName("feeling_good_self_score")                   .HasColumnType("int")                                                                                                               .IsRequired();
            entity.Property(e => e.FeelingCloseToPeopleScore)       .HasColumnName("feeling_close_to_people_score")             .HasColumnType("int")                                                                                                               .IsRequired();
            entity.Property(e => e.ConfidenceScore)                 .HasColumnName("confidence_score")                          .HasColumnType("int")                                                                                                               .IsRequired();
            entity.Property(e => e.MakingUpOwnMindScore)            .HasColumnName("making_up_own_mind_score")                  .HasColumnType("int")                                                                                                               .IsRequired();
            entity.Property(e => e.FeelingLovedScore)               .HasColumnName("feeling_loved_score")                       .HasColumnType("int")                                                                                                               .IsRequired();
            entity.Property(e => e.InterestedInNewThingsScore)      .HasColumnName("interested_in_new_things_score")            .HasColumnType("int")                                                                                                               .IsRequired();
            entity.Property(e => e.FeelingCheerfulScore)            .HasColumnName("feeling_cheerful_score")                    .HasColumnType("int")                                                                                                               .IsRequired();



            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.SetNull);
        });

        // cases
        modelBuilder.Entity<CaseEntityModel>(entity =>
        {
            entity.ToTable("cases");
            entity.HasKey(e => e.Id);


            
            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");
            entity.Property(e => e.LastUpdatedAt)                   .HasColumnName("last_updated_at")                           .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)                   .HasColumnName("last_updated_by")                           .HasColumnType("char(36)");

            entity.Property(e => e.Title)                           .HasColumnName("title")                                     .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.Description)                     .HasColumnName("description")                               .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.Status)                          .HasColumnName("status")                                    .HasColumnType("text")                  .HasConversion<string>()                .HasDefaultValue(CaseStatusEnum.Open)               .IsRequired();
            entity.Property(e => e.Sensitivity)                     .HasColumnName("sensitivity")                               .HasColumnType("text")                  .HasConversion<string>()                .HasDefaultValue(CaseSensitivityEnum.Confidential)  .IsRequired();


            
            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.LastUpdatedByUser)                 .WithMany()                                                 .HasForeignKey(e => e.LastUpdatedBy)    .OnDelete(DeleteBehavior.SetNull);
            entity.HasMany(e => e.Workers)                          .WithOne(w => w.Case)                                       .HasForeignKey(w => w.CaseId)           .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.Clients)                          .WithOne(c => c.Case)                                       .HasForeignKey(c => c.CaseId)           .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.AdditionalProperties)             .WithOne(p => p.Case)                                       .HasForeignKey(p => p.CaseId)           .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.Messages)                         .WithOne(m => m.Case)                                       .HasForeignKey(m => m.CaseId)           .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.Files)                            .WithOne(f => f.Case)                                       .HasForeignKey(f => f.CaseId)           .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.Todos)                            .WithOne(t => t.Case)                                       .HasForeignKey(t => t.CaseId)           .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.Timeline)                         .WithOne(t => t.Case)                                       .HasForeignKey(t => t.CaseId)           .OnDelete(DeleteBehavior.Cascade);
        });

        // case_workers
        modelBuilder.Entity<CaseWorkerEntityModel>(entity =>
        {
            entity.ToTable("case_workers");
            entity.HasKey(e => e.Id);


            
            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");

            entity.Property(e => e.CaseId)                          .HasColumnName("case_id")                                   .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.UserId)                          .HasColumnName("user_id")                                   .HasColumnType("char(36)")                                                                                                          .IsRequired();


            
            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.Case)                              .WithMany(c => c.Workers)                                   .HasForeignKey(e => e.CaseId);
            entity.HasOne(e => e.User)                              .WithMany(u => u.WorkerOnCases)                             .HasForeignKey(e => e.UserId);
        });

        // case_clients
        modelBuilder.Entity<CaseClientEntityModel>(entity =>
        {
            entity.ToTable("case_clients");
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");

            entity.Property(e => e.CaseId)                          .HasColumnName("case_id")                                   .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.UserId)                          .HasColumnName("user_id")                                   .HasColumnType("char(36)")                                                                                                          .IsRequired();
            
            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.Case)                              .WithMany(c => c.Clients)                                   .HasForeignKey(e => e.CaseId);
            entity.HasOne(e => e.User)                              .WithMany(u => u.ClientOnCases)                             .HasForeignKey(e => e.UserId);
        });

        // case_additional_properties
        modelBuilder.Entity<CaseAdditionalPropertyEntityModel>(entity =>
        {
            entity.ToTable("case_additional_properties");
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");
            entity.Property(e => e.LastUpdatedAt)                   .HasColumnName("last_updated_at")                           .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)                   .HasColumnName("last_updated_by")                           .HasColumnType("char(36)");

            entity.Property(e => e.CaseId)                          .HasColumnName("case_id")                                   .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.Name)                            .HasColumnName("name")                                      .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.Content)                         .HasColumnName("content")                                   .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.ContentType)                     .HasColumnName("content_type")                              .HasColumnType("text")                                                                                                              .IsRequired();
            
            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.LastUpdatedByUser)                 .WithMany()                                                 .HasForeignKey(e => e.LastUpdatedBy)    .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.Case)                              .WithMany(c => c.AdditionalProperties)                      .HasForeignKey(e => e.CaseId);
        });

        // user_additional_properties
        modelBuilder.Entity<UserAdditionalPropertyEntityModel>(entity =>
        {
            entity.ToTable("user_additional_properties");
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");
            entity.Property(e => e.LastUpdatedAt)                   .HasColumnName("last_updated_at")                           .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)                   .HasColumnName("last_updated_by")                           .HasColumnType("char(36)");

            entity.Property(e => e.UserId)                          .HasColumnName("user_id")                                   .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.Name)                            .HasColumnName("name")                                      .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.Content)                         .HasColumnName("content")                                   .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.ContentType)                     .HasColumnName("content_type")                              .HasColumnType("text")                                                                                                              .IsRequired();
            
            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.LastUpdatedByUser)                 .WithMany()                                                 .HasForeignKey(e => e.LastUpdatedBy)    .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.User)                              .WithMany(c => c.AdditionalProperties)                      .HasForeignKey(e => e.UserId);
        });

        // case_messages
        modelBuilder.Entity<CaseMessageEntityModel>(entity =>
        {
            entity.ToTable("case_messages");
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");
            entity.Property(e => e.LastUpdatedAt)                   .HasColumnName("last_updated_at")                           .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)                   .HasColumnName("last_updated_by")                           .HasColumnType("char(36)");

            entity.Property(e => e.CaseId)                          .HasColumnName("case_id")                                   .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.SenderId)                        .HasColumnName("sender_id")                                 .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.Subject)                         .HasColumnName("subject")                                   .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.Content)                         .HasColumnName("content")                                   .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.IsUrgent)                        .HasColumnName("is_urgent")                                 .HasColumnType("tinyint(1)")                                                    .HasDefaultValue(false)                             .IsRequired();
            
            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.LastUpdatedByUser)                 .WithMany()                                                 .HasForeignKey(e => e.LastUpdatedBy)    .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.Case)                              .WithMany(c => c.Messages)                                  .HasForeignKey(e => e.CaseId);
            entity.HasOne(e => e.Sender)                            .WithMany()                                                 .HasForeignKey(e => e.SenderId);
        });

        // case_messages_read_bys
        modelBuilder.Entity<CaseMessageReadByEntityModel>(entity =>
        {
            entity.ToTable("case_messages_read_bys");
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");

            entity.Property(e => e.MessageId)                       .HasColumnName("message_id")                                .HasColumnType("char(36)")                                                                                                          .IsRequired();
            
            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.Message)                           .WithMany()                                                 .HasForeignKey(e => e.MessageId)        .OnDelete(DeleteBehavior.Cascade);
        });

        // case_todos
        modelBuilder.Entity<CaseTodoEntityModel>(entity =>
        {
            entity.ToTable("case_todos");
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");
            entity.Property(e => e.LastUpdatedAt)                   .HasColumnName("last_updated_at")                           .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)                   .HasColumnName("last_updated_by")                           .HasColumnType("char(36)");

            entity.Property(e => e.CaseId)                          .HasColumnName("case_id")                                   .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.Summary)                         .HasColumnName("summary")                                   .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.Description)                     .HasColumnName("description")                               .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.Status)                          .HasColumnName("status")                                    .HasColumnType("text")                  .HasConversion<string>()                                                                    .IsRequired();
            entity.Property(e => e.Priority)                        .HasColumnName("priority")                                  .HasColumnType("text")                  .HasConversion<string>()                                                                    .IsRequired();
            entity.Property(e => e.DueDate)                         .HasColumnName("due_date")                                  .HasColumnType("datetime");
            entity.Property(e => e.AssignedTo)                      .HasColumnName("assigned_to")                               .HasColumnType("char(36)");
            entity.Property(e => e.Reminder)                        .HasColumnName("reminder")                                  .HasColumnType("datetime");
            entity.Property(e => e.CompletedAt)                     .HasColumnName("completed_at")                              .HasColumnType("datetime");
            entity.Property(e => e.CompletedBy)                     .HasColumnName("completed_by")                              .HasColumnType("char(36)");
            entity.Property(e => e.CompletionNote)                  .HasColumnName("completion_note")                           .HasColumnType("text");
            
            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.LastUpdatedByUser)                 .WithMany()                                                 .HasForeignKey(e => e.LastUpdatedBy)    .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.Case)                              .WithMany(c => c.Todos)                                     .HasForeignKey(e => e.CaseId)           .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.AssignedToUser)                    .WithMany()                                                 .HasForeignKey(e => e.AssignedTo)       .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.CompletedByUser)                   .WithMany()                                                 .HasForeignKey(e => e.CompletedBy)      .OnDelete(DeleteBehavior.Restrict);
        });

        // case_timeline
        modelBuilder.Entity<CaseTimelineItemEntityModel>(entity =>
        {
            entity.ToTable("case_timeline");
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");
            entity.Property(e => e.LastUpdatedAt)                   .HasColumnName("last_updated_at")                           .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)                   .HasColumnName("last_updated_by")                           .HasColumnType("char(36)");
            
            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.LastUpdatedByUser)                 .WithMany()                                                 .HasForeignKey(e => e.LastUpdatedBy)    .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.Case)                              .WithMany(c => c.Timeline)                                  .HasForeignKey(e => e.CaseId)           .OnDelete(DeleteBehavior.Restrict);
        });

        // case_files
        modelBuilder.Entity<CaseFileEntityModel>(entity =>
        {
            entity.ToTable("case_files");
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");
            entity.Property(e => e.LastUpdatedAt)                   .HasColumnName("last_updated_at")                           .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)                   .HasColumnName("last_updated_by")                           .HasColumnType("char(36)");

            entity.Property(e => e.CaseId)                          .HasColumnName("case_id")                                   .HasColumnType("char(36)");
            entity.Property(e => e.Filename)                        .HasColumnName("filename")                                  .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.ContentType)                     .HasColumnName("content_type")                              .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.Size)                            .HasColumnName("size")                                      .HasColumnType("bigint")                                                                                                            .IsRequired();
            entity.Property(e => e.Hash)                            .HasColumnName("hash")                                      .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.LfsPath)                         .HasColumnName("lfs_path")                                  .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.Description)                     .HasColumnName("description")                               .HasColumnType("text")                                                                                                              .IsRequired();
            
            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.LastUpdatedByUser)                 .WithMany()                                                 .HasForeignKey(e => e.LastUpdatedBy)    .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.Case)                              .WithMany(c => c.Files)                                     .HasForeignKey(e => e.CaseId)           .OnDelete(DeleteBehavior.Cascade);
        });

        // user_files
        modelBuilder.Entity<UserFileEntityModel>(entity =>
        {
            entity.ToTable("user_files");
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");
            entity.Property(e => e.LastUpdatedAt)                   .HasColumnName("last_updated_at")                           .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)                   .HasColumnName("last_updated_by")                           .HasColumnType("char(36)");

            entity.Property(e => e.UserId)                          .HasColumnName("user_id")                                   .HasColumnType("char(36)");
            entity.Property(e => e.Filename)                        .HasColumnName("filename")                                  .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.ContentType)                     .HasColumnName("content_type")                              .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.Size)                            .HasColumnName("size")                                      .HasColumnType("bigint")                                                                                                            .IsRequired();
            entity.Property(e => e.Hash)                            .HasColumnName("hash")                                      .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.LfsPath)                         .HasColumnName("lfs_path")                                  .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.Description)                     .HasColumnName("description")                               .HasColumnType("text")                                                                                                              .IsRequired();
            
            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.LastUpdatedByUser)                 .WithMany()                                                 .HasForeignKey(e => e.LastUpdatedBy)    .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.User)                              .WithMany(c => c.Files)                                     .HasForeignKey(e => e.UserId)           .OnDelete(DeleteBehavior.Cascade);
        });

        // refresh_tokens
        modelBuilder.Entity<RefreshTokenEntityModel>(entity =>
        {
            entity.ToTable("refresh_tokens");
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id)                              .HasColumnName("id")                                        .HasColumnType("char(36)")                                                                                                          .IsRequired();
            entity.Property(e => e.CreatedAt)                       .HasColumnName("created_at")                                .HasColumnType("datetime")                                                      .HasDefaultValueSql("UTC_TIMESTAMP()")              .IsRequired();
            entity.Property(e => e.CreatedBy)                       .HasColumnName("created_by")                                .HasColumnType("char(36)");

            entity.Property(e => e.TokenHash)                       .HasColumnName("token_hash")                                .HasColumnType("text")                                                                                                              .IsRequired();
            entity.Property(e => e.ExpiresAt)                       .HasColumnName("expires_at")                                .HasColumnType("datetime")                                                                                                          .IsRequired();

            entity.HasOne(e => e.CreatedByUser)                     .WithMany()                                                 .HasForeignKey(e => e.CreatedBy)        .OnDelete(DeleteBehavior.Cascade);
        });
    }
}

﻿// <auto-generated />
using System;
using CaseTracker.DataAccessLayer.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CaseTracker.DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CaseTracker.DataAccessLayer.Models.AttachmentModel", b =>
                {
                    b.Property<int>("AttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttachmentId"), 1L, 1);

                    b.Property<string>("AttachmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttachmentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConsultantId")
                        .HasColumnType("int");

                    b.HasKey("AttachmentId");

                    b.HasIndex("ConsultantId");

                    b.ToTable("AttachmentModels");
                });

            modelBuilder.Entity("CaseTracker.DataAccessLayer.Models.CommunicationUpdates", b =>
                {
                    b.Property<int>("CommunicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommunicationId"), 1L, 1);

                    b.Property<DateTime>("CommunicatioUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommunicationUpdate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConsultantId")
                        .HasColumnType("int");

                    b.HasKey("CommunicationId");

                    b.HasIndex("ConsultantId");

                    b.ToTable("CommunicationUpdates");
                });

            modelBuilder.Entity("CaseTracker.DataAccessLayer.Models.Consultant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AssistantConsultant")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CaseSummary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsultationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ConsultationStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfTransfer")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeadlineForDocumentSubmission")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FilingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HearingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LeadConsultant")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PaymentReceived")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeShareLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeShareName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Consultants");
                });

            modelBuilder.Entity("CaseTracker.DataAccessLayer.Models.NextSteps", b =>
                {
                    b.Property<int>("NextStepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NextStepId"), 1L, 1);

                    b.Property<int>("ConsultantId")
                        .HasColumnType("int");

                    b.Property<string>("NextStep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NextStepTime")
                        .HasColumnType("datetime2");

                    b.HasKey("NextStepId");

                    b.HasIndex("ConsultantId");

                    b.ToTable("NextSteps");
                });

            modelBuilder.Entity("CaseTracker.DataAccessLayer.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmailConfirmed")
                        .HasColumnType("int");

                    b.Property<string>("HashPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AuthUsers");
                });

            modelBuilder.Entity("CaseTracker.DataAccessLayer.Models.AttachmentModel", b =>
                {
                    b.HasOne("CaseTracker.DataAccessLayer.Models.Consultant", "Consultant")
                        .WithMany("AttachmentModels")
                        .HasForeignKey("ConsultantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consultant");
                });

            modelBuilder.Entity("CaseTracker.DataAccessLayer.Models.CommunicationUpdates", b =>
                {
                    b.HasOne("CaseTracker.DataAccessLayer.Models.Consultant", "Consultant")
                        .WithMany("CommunicationUpdates")
                        .HasForeignKey("ConsultantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consultant");
                });

            modelBuilder.Entity("CaseTracker.DataAccessLayer.Models.NextSteps", b =>
                {
                    b.HasOne("CaseTracker.DataAccessLayer.Models.Consultant", "Consultant")
                        .WithMany("NextSteps")
                        .HasForeignKey("ConsultantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consultant");
                });

            modelBuilder.Entity("CaseTracker.DataAccessLayer.Models.Consultant", b =>
                {
                    b.Navigation("AttachmentModels");

                    b.Navigation("CommunicationUpdates");

                    b.Navigation("NextSteps");
                });
#pragma warning restore 612, 618
        }
    }
}

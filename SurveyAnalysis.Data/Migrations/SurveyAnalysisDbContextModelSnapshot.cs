﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyAnalysis.Data;

namespace SurveyAnalysis.Data.Migrations
{
    [DbContext(typeof(SurveyAnalysisDbContext))]
    partial class SurveyAnalysisDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SurveyAnalysis.Core.Country_Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cCode")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<string>("cName_A")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<string>("cName_E")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<string>("cNationality_A")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("cNationality_E")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("SurveyAnalysis.Core.Employee_Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmpEmail")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("EmpName_A");

                    b.Property<string>("EmpName_E")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("EmpNetID");

                    b.Property<string>("EmpNo")
                        .IsRequired();

                    b.Property<int>("ManagerID");

                    b.Property<int>("OrgId");

                    b.HasKey("Id");

                    b.HasIndex("EmpNetID");

                    b.HasIndex("OrgId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SurveyAnalysis.Core.Organization_Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("orgCode");

                    b.Property<string>("orgName_A")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<string>("orgName_E")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<string>("partner")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("SurveyAnalysis.Core.Employee_Survey", b =>
                {
                    b.HasOne("SurveyAnalysis.Core.Country_Survey", "Country_Survey")
                        .WithMany()
                        .HasForeignKey("EmpNetID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurveyAnalysis.Core.Organization_Survey", "Organization_Survey")
                        .WithMany()
                        .HasForeignKey("OrgId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

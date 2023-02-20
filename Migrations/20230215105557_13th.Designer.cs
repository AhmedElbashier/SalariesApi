﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalariesApi.Domain.Helpers;

#nullable disable

namespace SalariesApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230215105557_13th")]
    partial class _13th
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.BookAndSearch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BookAndSearches");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.DegreeRoller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EmpType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Exp")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PrimarySalary")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DegreeRollers");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BOK")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Dept")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Exp")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FIB")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("InternalExp")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RecuirtDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.FirstSocialInsurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("FirstSocialInsurances");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.InternalExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("InternalExperiences");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.LastSocialInsurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("LastSocialInsurances");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstMonth")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Program")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SecondMonth")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sylbus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ThirdMonth")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.PayRoll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DegreeRoller")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DeportationExpense")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmpId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmpType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmployeeCost")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FinalNetSalary")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FinalNetSalaryBeforeDiscount")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FinalSalaryAfterDeduction")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FinalSalaryDeduction")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstInsurance")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HousingExpense")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastInsurance")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LivingExpense")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NetBaseSalary")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NetBaseVariableAllowance")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PersonalTax")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PrimarySalary")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StampBase")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StartingSalary")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TaxOnVariableAllowanceResult")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TaxTotal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TheBaseSubjectTax")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Valid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VariableTax")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PayRolls");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.PerformanceIncentive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PerformanceIncentives");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.PersonalIncomeTax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PersonalIncomeTaxes");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.StampBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("StampBases");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.StampSign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("StampSigns");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.TaxAllowance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TaxAllowances");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Dept")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("SalariesApi.Domain.Models.Settings.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

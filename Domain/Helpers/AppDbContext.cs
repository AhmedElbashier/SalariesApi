using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Helpers
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaxAllowance> TaxAllowances { get; set; }
        public DbSet<StampSign> StampSigns { get; set; }
        public DbSet<StampBase> StampBases { get; set; }
        public DbSet<PerformanceIncentive> PerformanceIncentives { get; set; }
        public DbSet<LastSocialInsurance> LastSocialInsurances { get; set; }
        public DbSet<FirstSocialInsurance> FirstSocialInsurances { get; set; }
        public DbSet<InternalExperience> InternalExperiences { get; set; }
        public DbSet<DegreeRoller> DegreeRollers { get; set; }
        public DbSet<BookAndSearch> BookAndSearches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PackagePayRoll> PackagePayRolls { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PersonalIncomeTax> PersonalIncomeTaxes { get; set; }
        public DbSet<PayRoll> PayRolls { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingPayRoll> TrainingPayRolls { get; set; }
        public DbSet<Advance> Advances { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Partial> Partials { get; set; }
        public DbSet<PartialPayRoll> PartialPayRolls { get; set; }
        public DbSet<AdvanceAccount> AdvanceAccounts { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
         
            base.OnModelCreating(builder);
        }
    }
}
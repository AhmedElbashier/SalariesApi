using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Installers
{
    public class DbInstaller: IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                // options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                    //     new MariaDbServerVersion(new Version(8, 0, 21)),
                    //     mySqlOptions => mySqlOptions
                    //         .CharSetBehavior(CharSetBehavior.NeverAppend))
                    // .EnableSensitiveDataLogging()
                    // .EnableDetailedErrors());
                      options  .UseMySql(configuration.GetConnectionString("DefaultConnection"),  ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")))
                        .LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors()
                );


            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaxAllowanceRepository, TaxAllowanceRepository>();
            services.AddScoped<IStampSignRepository, StampSignRepository>();
            services.AddScoped<IStampBaseRepository, StampBaseRepository>();
            services.AddScoped<IPerformanceIncentiveRepository, PerformanceIncentiveRepository>();
            services.AddScoped<ILastSocialInsuranceRepository, LastSocialInsuranceRepository>();
            services.AddScoped<IInternalExperienceRepository, InternalExperienceRepository>();
            services.AddScoped<IFirstSocialInsuranceRepository, FirstSocialInsuranceRepository>();
            services.AddScoped<IDegreeRollerRepository, DegreeRollerRepository>();
            services.AddScoped<IBookAndSearchRepository, BookAndSearchRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IPackagePayRollRepository, PackagePayRollRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPayRollRepository, PayRollRepository>();
            services.AddScoped<IPersonalIncomeTaxRepository, PersonalIncomeTaxRepository>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<ITrainingPayRollRepository, TrainingPayRollRepository>();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalariesApi.Domain.Services;

namespace SalariesApi.Domain.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen();

             services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaxAllowanceService, TaxAllowanceService>();
            services.AddScoped<IStampSignService, StampSignService>();
            services.AddScoped<IStampBaseService, StampBaseService>();
            services.AddScoped<IStampSignService, StampSignService>();
            services.AddScoped<IPerformanceIncentiveService, PerformanceIncentiveService>();
            services.AddScoped<ILastSocialInsuranceService, LastSocialInsuranceService>();
            services.AddScoped<IFirstSocialInsuranceService, FirstSocialInsuranceService>();
            services.AddScoped<IInternalExperienceService, InternalExperienceService>();
            services.AddScoped<IDegreeRollerService, DegreeRollerService>();
            services.AddScoped<IBookAndSearchService, BookAndSearchService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<IPackagePayRollService, PackagePayRollService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPayRollService, PayRollService>();
            services.AddScoped<IPersonalIncomeTaxService, PersonalIncomeTaxService>();
            services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<ITrainingPayRollService, TrainingPayRollService>();
            services.AddScoped<IAdvanceService, AdvanceService>();
            services.AddScoped<IAdvanceAccountService, AdvanceAccountService>();
            services.AddScoped<IAbsenceService, AbsenceService>();
            services.AddScoped<IAllowanceService, AllowanceService>();
            services.AddScoped<IPartialService, PartialService>();
            services.AddScoped<IPartialPayRollService, PartialPayRollService>();
            services.AddScoped<IRoleService, RoleService>();
        }
    }
}
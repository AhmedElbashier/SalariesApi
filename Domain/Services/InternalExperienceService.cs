using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IInternalExperienceService
    {
        InternalExperience GetInternalExperience(int id);
        List<InternalExperienceDto> GetALl();
        InternalExperience CreateInternalExperience(InternalExperienceDto InternalExperienceDto);
        List<InternalExperience> GetInternalExperienceByName(string Name);

    }
    public class InternalExperienceService : IInternalExperienceService
    {
        private readonly IInternalExperienceRepository _InternalExperienceRepository;

        public InternalExperienceService(IInternalExperienceRepository InternalExperienceRepository)
        {
            _InternalExperienceRepository = InternalExperienceRepository;    
        }
        
       
        public InternalExperience GetInternalExperience(int id)
        {
            return _InternalExperienceRepository.GetInternalExperience(id);
        }

        public List<InternalExperience> GetInternalExperienceByName(string Name)
        {
            return _InternalExperienceRepository.GetInternalExperienceByName(Name);
        }

        public InternalExperience CreateInternalExperience(InternalExperienceDto InternalExperienceDto)
        {
            return _InternalExperienceRepository.CreateInternalExperience(InternalExperienceDto);
        }
        public List<InternalExperienceDto> GetALl()
        {
            return _InternalExperienceRepository.GetAll().Select(_InternalExperienceRepository.ToInternalExperienceDto).ToList();
        }

    }
}
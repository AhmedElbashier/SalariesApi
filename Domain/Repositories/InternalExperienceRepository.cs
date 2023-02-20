using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IInternalExperienceRepository
    {
        List<InternalExperience> GetAll();
        InternalExperience Find(int id);
        InternalExperience CreateInternalExperience(InternalExperienceDto InternalExperienceDto);
        InternalExperienceDto ToInternalExperienceDto(InternalExperience InternalExperience);
        InternalExperience GetInternalExperience(int id);
        List<InternalExperience> GetInternalExperienceByName(string Name);


    }

    public class InternalExperienceRepository : IInternalExperienceRepository
    {
        private readonly AppDbContext _context;
        public InternalExperienceRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<InternalExperience> GetAll()
        {
            return _context.InternalExperiences.ToList();
        }

        public InternalExperience Find(int id)
        {
            return _context.InternalExperiences.Find(id);
        }

        public InternalExperience CreateInternalExperience(InternalExperienceDto InternalExperienceDto)
        {   
            var InternalExperience = ToInternalExperience(InternalExperienceDto);
            _context.InternalExperiences.Add(InternalExperience);
            this._context.SaveChanges();
            return InternalExperience;
        }

        private InternalExperience ToInternalExperience(InternalExperienceDto InternalExperienceDto)
        {
            return new InternalExperience
            {   

                Name= InternalExperienceDto.Name,
                Value = InternalExperienceDto.Value,
                
            };
        }

        public InternalExperienceDto ToInternalExperienceDto(InternalExperience InternalExperience)
        {
            return new InternalExperienceDto
            {
                Id= InternalExperience.Id,
                Name= InternalExperience.Name,
                Value = InternalExperience.Value,
            };
        }
         public List<InternalExperience> GetInternalExperienceByName(string Name)
        {
        
            return _context.InternalExperiences.Where(x =>
                x.Name==(Name)).ToList();

        }
          public InternalExperience GetInternalExperience(int id)
        {
            return _context.InternalExperiences.Find(id);
        }
         public List<InternalExperience> GetALL()
        {
            return _context.InternalExperiences.ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IPerformanceIncentiveRepository
    {
        List<PerformanceIncentive> GetAll();
        PerformanceIncentive Find(int id);
        PerformanceIncentive CreatePerformanceIncentive(PerformanceIncentiveDto PerformanceIncentiveDto);
        PerformanceIncentiveDto ToPerformanceIncentiveDto(PerformanceIncentive PerformanceIncentive);
        PerformanceIncentive GetPerformanceIncentive(int id);
        List<PerformanceIncentive> GetPerformanceIncentiveByName(string Name);


    }

    public class PerformanceIncentiveRepository : IPerformanceIncentiveRepository
    {
        private readonly AppDbContext _context;
        public PerformanceIncentiveRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<PerformanceIncentive> GetAll()
        {
            return _context.PerformanceIncentives.ToList();
        }

        public PerformanceIncentive Find(int id)
        {
            return _context.PerformanceIncentives.Find(id);
        }

        public PerformanceIncentive CreatePerformanceIncentive(PerformanceIncentiveDto PerformanceIncentiveDto)
        {   
            var PerformanceIncentive = ToPerformanceIncentive(PerformanceIncentiveDto);
            _context.PerformanceIncentives.Add(PerformanceIncentive);
            this._context.SaveChanges();
            return PerformanceIncentive;
        }

        private PerformanceIncentive ToPerformanceIncentive(PerformanceIncentiveDto PerformanceIncentiveDto)
        {
            return new PerformanceIncentive
            {   

                Name= PerformanceIncentiveDto.Name,
                Value = PerformanceIncentiveDto.Value,

                
            };
        }

        public PerformanceIncentiveDto ToPerformanceIncentiveDto(PerformanceIncentive PerformanceIncentive)
        {
            return new PerformanceIncentiveDto
            {
                Id= PerformanceIncentive.Id,
                Name= PerformanceIncentive.Name,
                Value = PerformanceIncentive.Value,
            };
        }
         public List<PerformanceIncentive> GetPerformanceIncentiveByName(string Name)
        {
        
            return _context.PerformanceIncentives.Where(x =>
                x.Name==(Name)).ToList();

        }
          public PerformanceIncentive GetPerformanceIncentive(int id)
        {
            return _context.PerformanceIncentives.Find(id);
        }
         public List<PerformanceIncentive> GetALL()
        {
            return _context.PerformanceIncentives.ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IStampBaseRepository
    {
        List<StampBase> GetAll();
        StampBase Find(int id);
        StampBase CreateStampBase(StampBaseDto StampBaseDto);
        StampBaseDto ToStampBaseDto(StampBase StampBase);
        StampBase GetStampBase(int id);
        List<StampBase> GetStampBaseByName(string Name);


    }

    public class StampBaseRepository : IStampBaseRepository
    {
        private readonly AppDbContext _context;
        public StampBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<StampBase> GetAll()
        {
            return _context.StampBases.ToList();
        }

        public StampBase Find(int id)
        {
            return _context.StampBases.Find(id);
        }

        public StampBase CreateStampBase(StampBaseDto StampBaseDto)
        {   
            var StampBase = ToStampBase(StampBaseDto);
            _context.StampBases.Add(StampBase);
            this._context.SaveChanges();
            return StampBase;
        }

        private StampBase ToStampBase(StampBaseDto StampBaseDto)
        {
            return new StampBase
            {   

                Name= StampBaseDto.Name,
                Value = StampBaseDto.Value,
                
            };
        }

        public StampBaseDto ToStampBaseDto(StampBase StampBase)
        {
            return new StampBaseDto
            {
                Id= StampBase.Id,
                Name= StampBase.Name,
                Value = StampBase.Value,
            };
        }
         public List<StampBase> GetStampBaseByName(string Name)
        {
        
            return _context.StampBases.Where(x =>
                x.Name==(Name)).ToList();

        }
          public StampBase GetStampBase(int id)
        {
            return _context.StampBases.Find(id);
        }
         public List<StampBase> GetALL()
        {
            return _context.StampBases.ToList();
        }
    }
}
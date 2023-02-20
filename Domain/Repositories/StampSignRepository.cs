using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IStampSignRepository
    {
        List<StampSign> GetAll();
        StampSign Find(int id);
        StampSign CreateStampSign(StampSignDto StampSignDto);
        StampSignDto ToStampSignDto(StampSign StampSign);
        StampSign GetStampSign(int id);
        List<StampSign> GetStampSignByName(string Name);


    }

    public class StampSignRepository : IStampSignRepository
    {
        private readonly AppDbContext _context;
        public StampSignRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<StampSign> GetAll()
        {
            return _context.StampSigns.ToList();
        }

        public StampSign Find(int id)
        {
            return _context.StampSigns.Find(id);
        }

        public StampSign CreateStampSign(StampSignDto StampSignDto)
        {   
            var StampSign = ToStampSign(StampSignDto);
            _context.StampSigns.Add(StampSign);
            this._context.SaveChanges();
            return StampSign;
        }

        private StampSign ToStampSign(StampSignDto StampSignDto)
        {
            return new StampSign
            {   

                Name= StampSignDto.Name,
                Value = StampSignDto.Value,
                
            };
        }

        public StampSignDto ToStampSignDto(StampSign StampSign)
        {
            return new StampSignDto
            {
                Id= StampSign.Id,
                Name= StampSign.Name,
                Value = StampSign.Value,
            };
        }
         public List<StampSign> GetStampSignByName(string Name)
        {
        
            return _context.StampSigns.Where(x =>
                x.Name==(Name)).ToList();

        }
          public StampSign GetStampSign(int id)
        {
            return _context.StampSigns.Find(id);
        }
         public List<StampSign> GetALL()
        {
            return _context.StampSigns.ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface ITrainingPayRollRepository
    {
        List<TrainingPayRoll> GetAll();
        TrainingPayRoll Find(int id);
        TrainingPayRoll CreateTrainingPayRoll(TrainingPayRollDto TrainingPayRollDto);
        TrainingPayRollDto ToTrainingPayRollDto(TrainingPayRoll TrainingPayRoll);
        TrainingPayRoll GetTrainingPayRoll(int id);
        List<TrainingPayRoll> GetTrainingPayRollById(int TrainingPayRollId);
        List<TrainingPayRoll> GetTrainingPayRollByIdAndMonth(string TrainingId, string Month);



    }

    public class TrainingPayRollRepository : ITrainingPayRollRepository
    {
        private readonly AppDbContext _context;
        public TrainingPayRollRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<TrainingPayRoll> GetAll()
        {
            return _context.TrainingPayRolls.ToList();
        }

        public TrainingPayRoll Find(int id)
        {
            return _context.TrainingPayRolls.Find(id);
        }

        public TrainingPayRoll CreateTrainingPayRoll(TrainingPayRollDto TrainingPayRollDto)
        {   
            var TrainingPayRoll = ToTrainingPayRoll(TrainingPayRollDto);
            _context.TrainingPayRolls.Add(TrainingPayRoll);
            this._context.SaveChanges();
            return TrainingPayRoll;
        }

        private TrainingPayRoll ToTrainingPayRoll(TrainingPayRollDto TrainingPayRollDto)
        {
            return new TrainingPayRoll
            {   

                TrainingId= TrainingPayRollDto.TrainingId,
                Name= TrainingPayRollDto.Name,
                Dept= TrainingPayRollDto.Dept,
                Amount= TrainingPayRollDto.Amount,
                Month= TrainingPayRollDto.Month,
                Year= TrainingPayRollDto.Year,
                User= TrainingPayRollDto.User,
                
            };
        }

        public TrainingPayRollDto ToTrainingPayRollDto(TrainingPayRoll TrainingPayRoll)
        {
            return new TrainingPayRollDto
            {
                Id= TrainingPayRoll.Id,
                TrainingId= TrainingPayRoll.TrainingId,
                Name= TrainingPayRoll.Name,
                Dept= TrainingPayRoll.Dept,
                Amount= TrainingPayRoll.Amount,
                Month= TrainingPayRoll.Month,
                Year= TrainingPayRoll.Year,
                User= TrainingPayRoll.User,
            };
        }
        public List<TrainingPayRoll> GetTrainingPayRollByIdAndMonth(string TrainingId, string Month)
        {
        
            return _context.TrainingPayRolls.Where(x =>
                x.TrainingId==TrainingId&&x.Month==Month).ToList();

        }
         public List<TrainingPayRoll> GetTrainingPayRollById(int TrainingPayRollId)
        {
        
            return _context.TrainingPayRolls.Where(x =>
                x.Id==(TrainingPayRollId)).ToList();

        }
          public TrainingPayRoll GetTrainingPayRoll(int id)
        {
            return _context.TrainingPayRolls.Find(id);
        }
         public List<TrainingPayRoll> GetALL()
        {
            return _context.TrainingPayRolls.ToList();
        }
    }
}
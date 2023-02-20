using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface ITrainingRepository
    {
        List<Training> GetAll();
        Training Find(int id);
        Training CreateTraining(TrainingDto TrainingDto);
        TrainingDto ToTrainingDto(Training Training);
        Training GetTraining(int id);
        List<Training> GetTrainingById(int TrainingId);


    }

    public class TrainingRepository : ITrainingRepository
    {
        private readonly AppDbContext _context;
        public TrainingRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Training> GetAll()
        {
            return _context.Trainings.ToList();
        }

        public Training Find(int id)
        {
            return _context.Trainings.Find(id);
        }

        public Training CreateTraining(TrainingDto TrainingDto)
        {   
            var Training = ToTraining(TrainingDto);
            _context.Trainings.Add(Training);
            this._context.SaveChanges();
            return Training;
        }

        private Training ToTraining(TrainingDto TrainingDto)
        {
            return new Training
            {   

                Name= TrainingDto.Name,
                Dept= TrainingDto.Dept,
                Amount= TrainingDto.Amount,
                
            };
        }

        public TrainingDto ToTrainingDto(Training Training)
        {
            return new TrainingDto
            {
                Id= Training.Id,
                Name= Training.Name,
                Dept= Training.Dept,
                Amount= Training.Amount,
            };
        }
         public List<Training> GetTrainingById(int TrainingId)
        {
        
            return _context.Trainings.Where(x =>
                x.Id==(TrainingId)).ToList();

        }
          public Training GetTraining(int id)
        {
            return _context.Trainings.Find(id);
        }
         public List<Training> GetALL()
        {
            return _context.Trainings.ToList();
        }
    }
}
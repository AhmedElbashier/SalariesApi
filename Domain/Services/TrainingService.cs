using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface ITrainingService
    {
        Training GetTraining(int id);
        List<TrainingDto> GetALl();
        Training CreateTraining(TrainingDto TrainingDto);
        List<Training> GetTrainingById(int TrainingId);

    }
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _TrainingRepository;

        public TrainingService(ITrainingRepository TrainingRepository)
        {
            _TrainingRepository = TrainingRepository;    
        }
        
       
        public Training GetTraining(int id)
        {
            return _TrainingRepository.GetTraining(id);
        }

        public List<Training> GetTrainingById(int TrainingId)
        {
            return _TrainingRepository.GetTrainingById(TrainingId);
        }

        public Training CreateTraining(TrainingDto TrainingDto)
        {
            return _TrainingRepository.CreateTraining(TrainingDto);
        }
        public List<TrainingDto> GetALl()
        {
            return _TrainingRepository.GetAll().Select(_TrainingRepository.ToTrainingDto).ToList();
        }

    }
}
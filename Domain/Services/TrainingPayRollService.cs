using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface ITrainingPayRollService
    {
        TrainingPayRoll GetTrainingPayRoll(int id);
        List<TrainingPayRollDto> GetALl();
        TrainingPayRoll CreateTrainingPayRoll(TrainingPayRollDto TrainingPayRollDto);
        List<TrainingPayRoll> GetTrainingPayRollById(int TrainingPayRollId);
        List<TrainingPayRoll> GetTrainingPayRollByIdAndMonth(string TrainingId, string Month);

    }
    public class TrainingPayRollService : ITrainingPayRollService
    {
        private readonly ITrainingPayRollRepository _TrainingPayRollRepository;

        public TrainingPayRollService(ITrainingPayRollRepository TrainingPayRollRepository)
        {
            _TrainingPayRollRepository = TrainingPayRollRepository;    
        }
        
       
        public TrainingPayRoll GetTrainingPayRoll(int id)
        {
            return _TrainingPayRollRepository.GetTrainingPayRoll(id);
        }

        public List<TrainingPayRoll> GetTrainingPayRollByIdAndMonth(string TrainingId, string Month)
        {
            return _TrainingPayRollRepository.GetTrainingPayRollByIdAndMonth(TrainingId,Month);
        }
        public List<TrainingPayRoll> GetTrainingPayRollById(int TrainingPayRollId)
        {
            return _TrainingPayRollRepository.GetTrainingPayRollById(TrainingPayRollId);
        }

        public TrainingPayRoll CreateTrainingPayRoll(TrainingPayRollDto TrainingPayRollDto)
        {
            return _TrainingPayRollRepository.CreateTrainingPayRoll(TrainingPayRollDto);
        }
        public List<TrainingPayRollDto> GetALl()
        {
            return _TrainingPayRollRepository.GetAll().Select(_TrainingPayRollRepository.ToTrainingPayRollDto).ToList();
        }

    }
}
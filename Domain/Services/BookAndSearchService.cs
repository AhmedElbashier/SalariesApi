using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IBookAndSearchService
    {
        BookAndSearch GetBookAndSearch(int id);
        List<BookAndSearchDto> GetALl();
        BookAndSearch CreateBookAndSearch(BookAndSearchDto BookAndSearchDto);
        List<BookAndSearch> GetBookAndSearchByName(string Name);

    }
    public class BookAndSearchService : IBookAndSearchService
    {
        private readonly IBookAndSearchRepository _BookAndSearchRepository;

        public BookAndSearchService(IBookAndSearchRepository BookAndSearchRepository)
        {
            _BookAndSearchRepository = BookAndSearchRepository;    
        }
        
       
        public BookAndSearch GetBookAndSearch(int id)
        {
            return _BookAndSearchRepository.GetBookAndSearch(id);
        }

        public List<BookAndSearch> GetBookAndSearchByName(string Name)
        {
            return _BookAndSearchRepository.GetBookAndSearchByName(Name);
        }

        public BookAndSearch CreateBookAndSearch(BookAndSearchDto BookAndSearchDto)
        {
            return _BookAndSearchRepository.CreateBookAndSearch(BookAndSearchDto);
        }
        public List<BookAndSearchDto> GetALl()
        {
            return _BookAndSearchRepository.GetAll().Select(_BookAndSearchRepository.ToBookAndSearchDto).ToList();
        }

    }
}
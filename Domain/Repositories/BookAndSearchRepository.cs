using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IBookAndSearchRepository
    {
        List<BookAndSearch> GetAll();
        BookAndSearch Find(int id);
        BookAndSearch CreateBookAndSearch(BookAndSearchDto BookAndSearchDto);
        BookAndSearchDto ToBookAndSearchDto(BookAndSearch BookAndSearch);
        BookAndSearch GetBookAndSearch(int id);
        List<BookAndSearch> GetBookAndSearchByName(string Name);


    }

    public class BookAndSearchRepository : IBookAndSearchRepository
    {
        private readonly AppDbContext _context;
        public BookAndSearchRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<BookAndSearch> GetAll()
        {
            return _context.BookAndSearches.ToList();
        }

        public BookAndSearch Find(int id)
        {
            return _context.BookAndSearches.Find(id);
        }

        public BookAndSearch CreateBookAndSearch(BookAndSearchDto BookAndSearchDto)
        {   
            var BookAndSearch = ToBookAndSearch(BookAndSearchDto);
            _context.BookAndSearches.Add(BookAndSearch);
            this._context.SaveChanges();
            return BookAndSearch;
        }

        private BookAndSearch ToBookAndSearch(BookAndSearchDto BookAndSearchDto)
        {
            return new BookAndSearch
            {   

                Name= BookAndSearchDto.Name,
                Value = BookAndSearchDto.Value,
                
            };
        }

        public BookAndSearchDto ToBookAndSearchDto(BookAndSearch BookAndSearch)
        {
            return new BookAndSearchDto
            {
                Id= BookAndSearch.Id,
                Name= BookAndSearch.Name,
                Value = BookAndSearch.Value,
            };
        }
         public List<BookAndSearch> GetBookAndSearchByName(string Name)
        {
        
            return _context.BookAndSearches.Where(x =>
                x.Name==(Name)).ToList();

        }
          public BookAndSearch GetBookAndSearch(int id)
        {
            return _context.BookAndSearches.Find(id);
        }
         public List<BookAndSearch> GetALL()
        {
            return _context.BookAndSearches.ToList();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using segfy.youtube.backend.Models;

namespace segfy.youtube.backend.Repository
{
    public class SearchLogRepository : ISearchLogRepository
    {
        private readonly YoutubeDbContext _context;

        public SearchLogRepository(YoutubeDbContext context)
        {
            _context = context;
        }

        public void DeleteSearch(int id)
        {
            var term = _context.SearchTerm.FirstOrDefault(s => s.Id == id);
            if (term != null)
            {
                foreach(var log in term.SearchLog) {
                    _context.SearchLogs.Remove(log);
                }
                _context.SearchTerm.Remove(term);
                _context.SaveChanges();
            }
        }

        public SearchTerm GetSearch(int id)
        {
            return _context.SearchTerm
                .Include(s => s.SearchLog)
                .AsNoTracking()
                .FirstOrDefault(s => s.Id == id);
        }

        public ICollection<SearchTerm> GetSearch(int offset = 0, int limit = 10)
        {
            return _context.SearchTerm.OrderByDescending(s => s.SearchedAt)
                .Include(s => s.SearchLog)
                .AsNoTracking()
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        public void SaveSearch(SearchTerm term)
        {
            _context.SearchTerm.AddRange(term);
            _context.SaveChanges();
        }

        public void UpdateSearch(SearchLog log)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System.Collections.Generic;
using segfy.youtube.backend.Models;

namespace segfy.youtube.backend.Repository
{
    public interface ISearchLogRepository
    {
         ICollection<SearchTerm> GetSearch(int offset = 0, int limit = 10);
        SearchTerm GetSearch(int id);
        void DeleteSearch(int id);
        void UpdateSearch(SearchLog log);
        void SaveSearch(SearchTerm log);
    }
}
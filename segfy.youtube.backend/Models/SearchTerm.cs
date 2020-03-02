using System;
using System.Collections.Generic;

namespace segfy.youtube.backend.Models
{
    public class SearchTerm
    {
        public SearchTerm()
        {
            SearchLog = new HashSet<SearchLog>();
        }
        
        public int Id { get; set; }
        public string Term { get; set; }
        public DateTime SearchedAt { get; set; }
        public virtual ICollection<SearchLog> SearchLog { get; set; }
    }
}
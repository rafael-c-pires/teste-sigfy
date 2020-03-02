using System.ComponentModel.DataAnnotations.Schema;

namespace segfy.youtube.backend.Models
{
    [NotMapped]
    public class SearchRequest
    {
        public string Term { get; set; }
    }
}
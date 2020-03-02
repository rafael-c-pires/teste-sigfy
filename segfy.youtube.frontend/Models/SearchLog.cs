using System;

namespace segfy.youtube.frontend.Models
{
    public class SearchLog
    {
        public int Id { get; set; }
        public string VideoId { get; set; }
        public string ChannelId { get; set; }
        public string ChannelTitle { get; set; }
        public string VideoTitle { get; set; }
        public string Description { get; set; }
        public string Thumbnails { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int SearchTermId { get; set; }

        public virtual SearchTerm SearchTerm { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using segfy.youtube.backend.Models;

namespace segfy.youtube.backend.Repository
{
    public class YoutubeDbContext : DbContext
    {
        public YoutubeDbContext(DbContextOptions<YoutubeDbContext> options) : base(options)
        {

        }

        public DbSet<SearchTerm> SearchTerm { get; set; }
        public DbSet<SearchLog> SearchLogs { get; set; }
    }
}
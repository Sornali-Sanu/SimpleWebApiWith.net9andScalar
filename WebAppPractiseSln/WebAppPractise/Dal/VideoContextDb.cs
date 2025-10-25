using Microsoft.EntityFrameworkCore;

namespace WebAppPractise.Dal
{
    public class VideoContextDb(DbContextOptions<VideoContextDb> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGame>().HasData(new VideoGame
            {
                Id = 1,
                Platform = "PS5",
                Title = "SpiderMan",
                Developer = "Insomic",
                Publisher = "sony"
            },
              new VideoGame
              {
                  Id = 2,
                  Platform = "PS3",
                  Title = "SpiderMan-2",
                  Developer = "Insomic Inc",
                  Publisher = "Nintendo"
              },
                new VideoGame
                {
                    Id = 3,
                    Platform = "CyberPunk",
                    Title = "The Brothers",
                    Developer = "soCD Project",
                    Publisher = "soCD Project"
                }
                );
        }
    }
  
}

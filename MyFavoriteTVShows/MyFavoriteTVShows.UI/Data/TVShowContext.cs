using Microsoft.EntityFrameworkCore;
using MyFavoriteTVShows.UI.Models;

namespace MyFavoriteTVShows.UI.Data
{
    public class TVShowContext : DbContext
    {
        public TVShowContext (DbContextOptions<TVShowContext> options)
            : base(options)
        {
        }

        public DbSet<TVShow> TVShow { get; set; }
    }
}

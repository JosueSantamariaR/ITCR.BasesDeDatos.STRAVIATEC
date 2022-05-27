using Microsoft.EntityFrameworkCore;

namespace Api_Stravia_Tec.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Athlete> Athletes { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<ActivityType> ActivityTypes { get; set; }

        public DbSet<Race> Races { get; set; }

        public DbSet<Challenge> Challenges { get; set; }

        public DbSet<Group> Groups { get; set; }

    }
}

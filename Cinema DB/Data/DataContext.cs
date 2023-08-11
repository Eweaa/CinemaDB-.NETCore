using Cinema_DB.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Cinema_DB.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Movie>()
                .HasMany(M => M.Actors)
                .WithMany(M => M.Movies)
                .UsingEntity<ActorMovie>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actor>().HasData(SeedActorData());
            modelBuilder.Entity<Director>().HasData(SeedDirectorData());
            modelBuilder.Entity<Movie>().HasData(SeedMovieData());
            modelBuilder.Entity<ActorMovie>().HasData(SeedActorMovieData());
            modelBuilder.Entity<User>().HasData(SeedUserData());
        }

        public List<Actor> SeedActorData()
        {
            var actors = new List<Actor>();
            StreamReader r = new StreamReader("G:\\Projects\\Web Designs\\BackEnd\\Cinema DB\\Cinema DB\\Data\\Actors.json");
            string json = r.ReadToEnd();
            return actors = JsonConvert.DeserializeObject<List<Actor>>(json);
        }
        public List<Director> SeedDirectorData()
        {
            var directors = new List<Director>();
            StreamReader r = new StreamReader("G:\\Projects\\Web Designs\\BackEnd\\Cinema DB\\Cinema DB\\Data\\Directors.json");
            string json = r.ReadToEnd();
            return directors = JsonConvert.DeserializeObject<List<Director>>(json);
        }
        public List<Movie> SeedMovieData()
        {
            var movies = new List<Movie>();
            StreamReader r = new StreamReader("G:\\Projects\\Web Designs\\BackEnd\\Cinema DB\\Cinema DB\\Data\\Movies.json");
            string json = r.ReadToEnd();
            return movies = JsonConvert.DeserializeObject<List<Movie>>(json);
        }
        public List<ActorMovie> SeedActorMovieData()
        {
            var actormovies = new List<ActorMovie>();
            StreamReader r = new StreamReader("G:\\Projects\\Web Designs\\BackEnd\\Cinema DB\\Cinema DB\\Data\\ActorMovie.json");
            string json = r.ReadToEnd();
            return actormovies = JsonConvert.DeserializeObject<List<ActorMovie>>(json);
        }
        public List<User> SeedUserData()
        {
            var users = new List<User>();
            StreamReader r = new StreamReader("G:\\Projects\\Web Designs\\BackEnd\\Cinema DB\\Cinema DB\\Data\\Users.json");
            string json = r.ReadToEnd();
            return users = JsonConvert.DeserializeObject<List<User>>(json);
        }

    }
}

using Cinema_DB.Data.Models;
using Newtonsoft.Json;

namespace Cinema_DB.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }
        
        //StreamReader r =  new StreamReader(@"G:\Projects\Web Designs\BackEnd\Cinema DB\Cinema DB\Data\Data.json");
        //string moviesJSON = System.IO.File.ReadAllText(@"" + Path.DirectorySeparatorChar + "Data.json");
        //List<Movie> MovieList = JsonConvert.DeserializeObject<List<Movie>>(moviesJSON);

        //public List<Actor> SeedActorData()
        //{
        //    var actors = new List<Actor>();
        //    StreamReader r = new StreamReader("G:\\Projects\\Web Designs\\BackEnd\\Cinema DB\\Cinema DB\\Data\\Actors.json");
        //    string json = r.ReadToEnd();
        //    actors = JsonConvert.DeserializeObject<List<Actor>>(json);
        //    return actors;
        //}
    }
}

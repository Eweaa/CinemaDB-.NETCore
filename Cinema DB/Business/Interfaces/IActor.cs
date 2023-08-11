using Cinema_DB.Data.Models;
using Cinema_DB.Helper.ViewModels;

namespace Cinema_DB.Business.Interfaces
{
    public interface IActor
    {
        ICollection<ActorVM> GetActors(); 
        Actor GetActor(int Id);
        bool ActorExists(int Id);
        bool CreateActor(Actor actor);
        bool DeleteActor(Actor actor);
        bool Save();
    }
}

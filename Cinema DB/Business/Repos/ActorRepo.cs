using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cinema_DB.Business.Interfaces;
using Cinema_DB.Data;
using Cinema_DB.Data.Models;
using Cinema_DB.Helper.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Cinema_DB.Business.Repos
{
    public class ActorRepo : IActor
    {
        private readonly DataContext _context;
        private readonly IMapper mapper;

        public ActorRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public Actor GetActor(int Id) => _context.Actors.Where(A => A.Id == Id).FirstOrDefault();
        public ICollection<ActorVM> GetActors()
        {
             var data=  _context.Actors.Include(a => a.Movies);
             var data2 =  _context.Actors.Include(a => a.Movies).ToList();
            return data.ProjectTo<ActorVM>(mapper.ConfigurationProvider).ToList();
        }

        public bool CreateActor(Actor actor)
        {
            _context.Actors.Add(actor);
            return Save();
        }

        public bool DeleteActor(Actor actor)
        {
            _context.Actors.Remove(actor);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool ActorExists(int Id) => _context.Actors.Where(A => A.Id != Id).Any();
    }
}

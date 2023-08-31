using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cinema_DB.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema_DB.Application.ActorsNS.Queries
{
    public record GetActorQuery(long Id) : IRequest<ActorDto>;

    public class GetActorQueryHandler : IRequestHandler<GetActorQuery, ActorDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GetActorQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActorDto> Handle(GetActorQuery request, CancellationToken cancellationToken)
        {
            var entity = _context.Actors.Where(A => A.Id == request.Id).Include(a => a.Movies).FirstOrDefault();
            var actorvm = _mapper.Map<ActorDto>(entity);
            return actorvm;
        }
    }
}

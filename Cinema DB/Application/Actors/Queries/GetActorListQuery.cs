using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cinema_DB.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema_DB.Application.Actors.Queries
{
    public record GetActorListQuery: IRequest<List<ActorDto>>;
    public class GetActorListQueryHandler : IRequestHandler<GetActorListQuery, List<ActorDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GetActorListQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ActorDto>> Handle(GetActorListQuery request, CancellationToken cancellationToken) 
        {
            var data = _context.Actors.Include(a => a.Movies);
            var data2 = _context.Actors.Include(a => a.Movies).ToList();
            return data.ProjectTo<ActorDto>(_mapper.ConfigurationProvider).ToList();
        }
    }
}

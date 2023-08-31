using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cinema_DB.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema_DB.Application.Movies.Queries
{
    public record GetMovieListQuery : IRequest<List<MovieDto>>;

    public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, List<MovieDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GetMovieListQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MovieDto>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Movies.Include(M => M.Director).ToList();
            var moviesvm = _mapper.Map<List<MovieDto>>(data);
            return moviesvm;
        }
    }
}

using AutoMapper;
using Cinema_DB.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema_DB.Application.Movies.Queries
{
    public record GetMovieQuery(long Id) : IRequest<MovieDto>;
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GetMovieQueryHandler(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<MovieDto> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movie = _context.Movies.Where(M => M.Id == request.Id).Include(M => M.Director).FirstOrDefault();
            var movievm = _mapper.Map<MovieDto>(movie);
            return movievm;
        }
    }
}

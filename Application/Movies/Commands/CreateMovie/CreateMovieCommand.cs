using Cinema_DB.Domain.Entities;
using Cinema_DB.Infrastructure.Persistence;
using MediatR;

namespace Cinema_DB.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<long>
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public long DirectorId { get; init; }
    }

    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, long>
    {
        private readonly DataContext _context;

        public CreateMovieCommandHandler(DataContext context) { _context = context; }

        public async Task<long> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = new Movie
            {
                Name = request.Name,
                DirectorId = request.DirectorId,
            };

            _context.Movies.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

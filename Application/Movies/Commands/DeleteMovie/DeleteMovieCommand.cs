using Cinema_DB.Application.Actors.Commands.DeleteActor;
using Cinema_DB.Infrastructure.Persistence;
using MediatR;
using System.Threading;

namespace Cinema_DB.Application.Movies.Commands.DeleteMovie
{
    public record DeleteMovieCommand(long Id) : IRequest;
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly DataContext _context;
        public DeleteMovieCommandHandler(DataContext context) {  _context = context; }
        public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Movies.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {

            }

            _context.Movies.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}

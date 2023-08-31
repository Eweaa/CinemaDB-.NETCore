using Cinema_DB.Infrastructure.Persistence;
using MediatR;

namespace Cinema_DB.Application.Directors.Commands.DeleteDirector
{
    public record DeleteDirectorCommand(long Id) : IRequest;

    public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand>
    {
        private readonly DataContext _context;

        public DeleteDirectorCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteDirectorCommand request, CancellationToken cancellationToken) 
        {
            var entity = await _context.Directors.FindAsync(new object[] {request.Id}, cancellationToken);

            if (entity == null) { }

            _context.Directors.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

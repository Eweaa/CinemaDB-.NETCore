using Cinema_DB.Domain.Entities;
using Cinema_DB.Infrastructure.Persistence;
using MediatR;

namespace Cinema_DB.Application.ActorsNS.Commands.DeleteActor
{
    public record DeleteActorCommand(long Id) : IRequest;
    public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand>
    {
        private readonly DataContext _context;
        public DeleteActorCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Actors.FindAsync(new object[] { request.Id }, cancellationToken);
            
            if (entity == null)
            {

            }

            _context.Actors.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

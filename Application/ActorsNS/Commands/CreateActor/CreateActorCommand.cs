using Cinema_DB.Domain.Entities;
using Cinema_DB.Infrastructure.Persistence;
using MediatR;

namespace Cinema_DB.Application.ActorsNS.Commands.CreateActor
{
    public record CreateActorCommand : IRequest<long>
    {
        public long Id { get; init; }
        public string Name { get; init; }
    }
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, long>
    {
        private readonly DataContext _context;
        public CreateActorCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<long> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var entity = new Actor
            {
                Name = request.Name
            };

            _context.Actors.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

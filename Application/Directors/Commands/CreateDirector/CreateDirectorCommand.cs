using Cinema_DB.Domain.Entities;
using Cinema_DB.Infrastructure.Persistence;
using MediatR;

namespace Cinema_DB.Application.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommand : IRequest<long>
    {
        public long Id { get; init; }
        public string Name { get; init; }
    }
    public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, long> 
    {
        private readonly DataContext _context;
        public CreateDirectorCommandHandler(DataContext context) { _context = context; }

        public async Task<long> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            var entity = new Director
            {
                Name = request.Name
            };

            _context.Directors.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            
            return entity.Id;
        }
    }
}

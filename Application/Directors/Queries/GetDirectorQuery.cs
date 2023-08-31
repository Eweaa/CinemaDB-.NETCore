using Cinema_DB.Domain.Entities;
using Cinema_DB.Infrastructure.Persistence;
using MediatR;

namespace Cinema_DB.Application.Directors.Queries
{
    public record GetDirectorQuery(long Id) : IRequest<Director>;

    public class GetDirectorQueryHandler : IRequestHandler<GetDirectorQuery, Director>
    {
        private readonly DataContext _context;
        public GetDirectorQueryHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Director> Handle(GetDirectorQuery request, CancellationToken cancellationToken)
        {
            return _context.Directors.Where(D => D.Id == request.Id).FirstOrDefault();
        }
    }
}

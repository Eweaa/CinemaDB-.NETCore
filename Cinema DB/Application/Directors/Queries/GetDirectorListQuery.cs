using Cinema_DB.Domain.Entities;
using Cinema_DB.Infrastructure.Persistence;
using MediatR;

namespace Cinema_DB.Application.Directors.Queries
{
    public record GetDirectorListQuery : IRequest<List<Director>>;
    
    public class GetDirectorListQueryHandler : IRequestHandler<GetDirectorListQuery, List<Director>>
    {
        private readonly DataContext _context;
        public GetDirectorListQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Director>> Handle(GetDirectorListQuery request, CancellationToken cancellationToken)
        {
            return _context.Directors.ToList();
        }
    }
}

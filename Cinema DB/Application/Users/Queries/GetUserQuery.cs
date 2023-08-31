using Cinema_DB.Domain.Entities;
using Cinema_DB.Helper;
using Cinema_DB.Infrastructure.Persistence;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Cinema_DB.Application.Users.Queries
{
    public record GetUserQuery(string Name, string Password) : IRequest<UserT>;
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserT>
    {
        private readonly DataContext _context;
        public GetUserQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<UserT> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var exist = _context.Users.Where(U => U.Name == request.Name).Any();
            var user = _context.Users.Where(U => U.Name == request.Name).FirstOrDefault();
            UserT userT = new UserT();

            if (user.Name == request.Name && user.Password == request.Password)
            {
                userT.UserId = user.Id;
                userT.Role = user.Role;
                userT.Name = user.Name;
                userT.Token = JWTTokenGenerator.Generate(user.Name, user.Password, user.Role);
                return userT;
            }
            else
            {
                return userT;
            }
        }
    }
}

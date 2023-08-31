using Cinema_DB.Domain.Entities;
using Cinema_DB.Helper;
using Cinema_DB.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Cinema_DB.Application.Users.Queries
{
    public record GetUserQuery(string Name, string Password) : IRequest<string>;
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, string>
    {
        private readonly DataContext _context;
        public GetUserQueryHandler(DataContext context)
        {
            _context = context;
        }
        //public Task<dynamic> Handle(GetUserQuery request, CancellationToken cancellationToken)
        //{
        //    var exist = _context.Users.Where(U => U.Name == request.Name).Any();
        //    var user = _context.Users.Where(U => U.Name == request.Name).FirstOrDefault();

        //    if (!exist)
        //    {
        //        return "this user Does not exist";
        //    }

        //    if (user.Name == request.Name && user.Password == request.Password)
        //    {
        //        return Tuple.Create(user.Role, JWTTokenGenerator.Generate(request.Name, request.Password));
        //    }

        //    if (user.Name == request.Name && user.Password != request.Password)
        //    {
        //        return "You've Entered An Incorrect Password";
        //    }
        //}

        public async Task<string> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var exist = _context.Users.Where(U => U.Name == request.Name).Any();
            var user = _context.Users.Where(U => U.Name == request.Name).FirstOrDefault();

            if (user.Name == request.Name && user.Password == request.Password)
            {
                //var token = await JWTTokenGenerator.Generate(request.Name, request.Password);
                //return token;
                return JWTTokenGenerator.Generate(user.Name, user.Password, user.Role);
            }
            else
            {
                string work = "did not work";
                return work;
            }
        }
    }
}

using ApiControlUsers.Context;
using ApiControlUsers.Models;
using System.Linq.Expressions;

namespace ApiControlUsers.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        { }
    }
}

using ApiControlUsers.Context;
using ApiControlUsers.Models;

namespace ApiControlUsers.Repository
{
    public class SocialMediaRepository : Repository<SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(AppDbContext context) : base(context)
        {
        }
    }
}

using ApiControlUsers.Context;
using ApiControlUsers.Models;

namespace ApiControlUsers.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }
    }
}

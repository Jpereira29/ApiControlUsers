using ApiControlUsers.Context;

namespace ApiControlUsers.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserRepository _userRepository;
        private ProjectRepository _projectRepository;
        private SocialMediaRepository _socialMediaRepository;
        public AppDbContext _context;

        public IUserRepository UserRepository
        {
            get {
                return _userRepository = _userRepository ?? new UserRepository(_context);
            }
        }

        public IProjectRepository ProjectRepository
        {
            get
            {
                return _projectRepository = _projectRepository ?? new ProjectRepository(_context);
            }
        }

        public ISocialMediaRepository SocialMediaRepository
        {
            get
            {
                return _socialMediaRepository = _socialMediaRepository ?? new SocialMediaRepository(_context);
            }
        }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

namespace ApiControlUsers.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProjectRepository ProjectRepository { get; }
        ISocialMediaRepository SocialMediaRepository { get; }
        Task Commit();
    }
}

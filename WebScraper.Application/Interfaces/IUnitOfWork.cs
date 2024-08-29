namespace WebScraper.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitChangesAsync();
    }
}

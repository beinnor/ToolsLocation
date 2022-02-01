using ToolsLocation.Models;

namespace ToolsLocation.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Tool> Tools { get; }
        IGenericRepository<Location> Locations { get; }
    }
}

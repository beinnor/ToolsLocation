using Microsoft.EntityFrameworkCore;
using ToolsLocation.Data;
using ToolsLocation.Models;

namespace ToolsLocation.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Tool> _tools;
        private IGenericRepository<Location> _locations;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Tool> Tools
            => _tools ??= new GenericRepository<Tool>(_context);

        public IGenericRepository<Location> Locations
            => _locations ??= new GenericRepository<Location>(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {            
            await _context.SaveChangesAsync();
        }
    }
}
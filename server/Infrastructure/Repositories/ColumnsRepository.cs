using server.Core.Entities;
using server.Core.Interfaces.Repositories;
using server.Infrastructure.Data;

namespace server.Infrastructure.Repositories;

public class ColumnsRepository : IColumnsRepository
{
    private readonly ApplicationDbContext _context;

    public ColumnsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateColumnAsync(Column column)
    {
        await _context.Columns.AddAsync(column);
        await _context.SaveChangesAsync();
    }
}
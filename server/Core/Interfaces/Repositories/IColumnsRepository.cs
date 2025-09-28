using server.Core.Entities;

namespace server.Core.Interfaces.Repositories;

public interface IColumnsRepository
{
    Task CreateColumnAsync(Column column);
}

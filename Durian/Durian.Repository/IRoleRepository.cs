using Durian.Core.Repository;
using Durian.Entity;

namespace Durian.Repository
{
    public interface IRoleRepository : IRepository<Role>
    {
        int GetById(int id);
    }
}
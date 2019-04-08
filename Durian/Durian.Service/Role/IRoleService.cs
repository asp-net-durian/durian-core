using System;

namespace Durian.Service.Role
{
    public interface IRoleService 
    {
        Entity.Role GetRoleByGuid(Guid guid);
    }
}
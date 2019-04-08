using System;
using Durian.Core.Repository;
using Durian.Entity;
using Microsoft.EntityFrameworkCore;

namespace Durian.Repository
{
    public class RoleRepository : Repository<Role>,IRoleRepository
    {

        public int GetById(int id)
        {
            return 1;
        }

        public RoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
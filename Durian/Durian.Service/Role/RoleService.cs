using System;
using CacheManager.Core;
using Durian.Core.Helper;
using Durian.Core.Repository;
using Durian.Repository;
using Durian.Web.Common;

namespace Durian.Service.Role
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;
        private readonly ICacheManager<Entity.Role> _roleCache;

        public RoleService(IUnitOfWork unitOfWork,IRoleRepository roleRepository, ICacheManager<Entity.Role> roleCache)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;
            _roleCache = roleCache;
        }

        public Entity.Role GetRoleByGuid(Guid guid)
        {
            _roleCache.TryGetOrAdd(CacheConst.KeyRoleGuid.MergeParameter(guid), 
                p => _roleRepository.Find(guid), 
                out var roleData);
            
            return roleData;
        }
        
    }
}
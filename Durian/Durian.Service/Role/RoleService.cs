using System;
using Durian.Core.Repository;
using Durian.Repository;

namespace Durian.Service.Role
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;

        public RoleService(IUnitOfWork unitOfWork,IRoleRepository roleRepository)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;
        }

        public Entity.Role GetRoleByGuid(Guid guid)
        {
            return _roleRepository.Find(guid);
        }
        
    }
}
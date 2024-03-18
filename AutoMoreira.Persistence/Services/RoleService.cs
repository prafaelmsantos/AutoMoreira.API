namespace AutoMoreira.Persistence.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, IUserRepository userRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
            _mapper = mapper;       
        }

        public async Task<RoleDTO> AddRoleAsync(RoleDTO roleDTO)
        {
            try
            {
                Role role = new(roleDTO.Name);

                await _roleRepository.AddAsync(role);

                return _mapper.Map<RoleDTO>(role);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RoleDTO> UpdateRoleAsync(RoleDTO roleDTO)
        {
            try
            {
                Role role = await _roleRepository.FindByIdAsync(roleDTO.Id) ?? throw new Exception("Cargo não encontrado.");
                role.UpdateRole(roleDTO.Name);

                await _roleRepository.UpdateAsync(role);

                return _mapper.Map<RoleDTO>(role);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<RoleDTO>> GetAllRolesAsync()
        {
            try
            {
                List<Role> roles = await _roleRepository
                    .GetAll()
                    .OrderBy(x => x.Id)
                    .ToListAsync();

                return _mapper.Map<List<RoleDTO>>(roles);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RoleDTO> GetRoleByIdAsync(int roleId)
        {
            try
            {
                Role role = await _roleRepository.FindByIdAsync(roleId);

                return role == null ? throw new Exception("Cargo não encontrado.") : _mapper.Map<RoleDTO>(role);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ResponseMessageDTO>> DeleteRolesAsync(List<int> rolesIds)
        {
            List<ResponseMessageDTO> responseMessageDTOs = new();

            foreach (int roleId in rolesIds)
            {
                ResponseMessageDTO responseMessageDTO = new() { Entity = new MinimumDTO() { Id = roleId }, OperationSuccess = false };
                try
                {
                    Role? role = await _roleRepository.FindByIdAsync(roleId);

                    if (role is not null)
                    {
                        responseMessageDTO.Entity.Name = role.Name;

                        if (role.IsReadOnly || role.IsDefault)
                        {
                            responseMessageDTO.ErrorMessage = "O Cargo não pode ser apagado porque pertence ao sistema.";
                        }
                        else
                        {
                            await UpdateUserWithDefaultRole(roleId);
                            await _roleRepository.RemoveAsync(role);
                            responseMessageDTO.OperationSuccess = true;
                        }   
                    }
                    else
                    {
                        responseMessageDTO.ErrorMessage = "Cargo não encontrado.";
                    }
                }

                catch (Exception ex)
                {
                    responseMessageDTO.ErrorMessage = ex.Message;
                }

                responseMessageDTOs.Add(responseMessageDTO);
            }

            return responseMessageDTOs;
        }

        private async Task UpdateUserWithDefaultRole(long roleId)
        {
            List<UserRole> userRoles = await _userRoleRepository
                .GetAll()
                .Where(x => x.RoleId == roleId)
                .ToListAsync();

            Role? defaultRole = await _roleRepository
                .GetAll()
                .Where(x => x.IsDefault)
                .FirstOrDefaultAsync() ?? throw new Exception("Cargo não encontrado.");

            foreach (UserRole userRole in userRoles)
            {
                User? user = await _userRepository.FindByIdAsync(userRole.UserId) ?? throw new Exception("Utilizador não encontrado.");
                await _userRoleRepository.RemoveRangeAsync(userRoles.Where(x => x.UserId ==  userRole.UserId));
                user.SetRoles(new List<Role> { defaultRole });
                await _userRepository.UpdateAsync(user);

            }
 
        }
    }
}

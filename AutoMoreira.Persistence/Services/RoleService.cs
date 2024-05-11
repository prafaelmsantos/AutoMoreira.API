namespace AutoMoreira.Persistence.Services
{
    public class RoleService : IRoleService
    {
        #region Private variables

        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;

        #endregion

        #region Constructors
        public RoleService(IMapper mapper, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
        }
        #endregion

        #region Public methods

        public async Task<List<RoleDTO>> GetAllRolesAsync()
        {
            try
            {
                List<Role> roles = await _roleRepository
                    .GetAll()
                    .OrderBy(x => x.Id)
                    .AsNoTracking()
                    .ToListAsync();

                return _mapper.Map<List<RoleDTO>>(roles);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetAllRolesAsyncException} {ex.Message}");
            }
        }

        public async Task<RoleDTO> GetRoleByIdAsync(int roleId)
        {
            try
            {
                Role role = await _roleRepository.FindByIdAsync(roleId);

                role.ThrowIfNull(() => throw new Exception(DomainResource.RoleNotFoundException));

                return _mapper.Map<RoleDTO>(role);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetRoleByIdAsyncException} {ex.Message}");
            }
        }

        public async Task<RoleDTO> AddRoleAsync(RoleDTO roleDTO)
        {
            try
            {
                RoleExistsAsync(roleDTO).Result
                    .Throw(() => throw new Exception(DomainResource.RoleAlreadyExistsException))
                    .IfTrue();

                Role role = new(roleDTO.Name);

                await _roleRepository.AddAsync(role);

                return _mapper.Map<RoleDTO>(role);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.AddRoleAsyncException} {ex.Message}");
            }
        }

        public async Task<RoleDTO> UpdateRoleAsync(RoleDTO roleDTO)
        {
            try
            {
                Role role = await _roleRepository.FindByIdAsync(roleDTO.Id);

                role.ThrowIfNull(() => throw new Exception(DomainResource.RoleNotFoundException));

                RoleExistsAsync(roleDTO).Result
                    .Throw(() => throw new Exception(DomainResource.RoleAlreadyExistsException))
                    .IfTrue();

                (role.IsDefault || role.IsReadOnly)
                    .Throw(() => throw new Exception(DomainResource.UpdateDefaultRoleException))
                    .IfTrue();

                role.SetName(roleDTO.Name);

                await _roleRepository.UpdateAsync(role);

                return _mapper.Map<RoleDTO>(role);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.UpdateRoleAsyncException} {ex.Message}");
            }
        }

        public async Task<List<ResponseMessageDTO>> DeleteRolesAsync(List<int> rolesIds)
        {
            return await DeleteAsync(rolesIds);
        }

        #endregion

        #region Private methods

        private async Task UpdateUserWithDefaultRoleAsync(long roleId)
        {
            List<UserRole> userRoles = await _userRoleRepository
                .GetAll()
                .Where(x => x.RoleId == roleId)
                .ToListAsync();

            Role? defaultRole = await _roleRepository
                .GetAll()
                .Where(x => x.IsDefault && !x.IsReadOnly)
                .FirstOrDefaultAsync();

            defaultRole.ThrowIfNull(() => throw new Exception(DomainResource.DefaultRoleNotFoundException));

            foreach (UserRole userRole in userRoles)
            {
                User? user = await _userRepository.FindByIdAsync(userRole.UserId);

                user.ThrowIfNull(() => throw new Exception(DomainResource.UserNotFoundException));

                await _userRoleRepository.RemoveRangeAsync(userRoles.Where(x => x.UserId == userRole.UserId));

                user.SetRoles(new List<Role> { defaultRole });
                await _userRepository.UpdateAsync(user);
            }
        }

        private async Task<bool> RoleExistsAsync(RoleDTO roleDTO)
        {
            return await _roleRepository
                    .GetAll()
                    .AnyAsync(x => x.Id != roleDTO.Id && x.Name.Trim().ToLower() == roleDTO.Name.ToLower());
        }

        private async Task<List<ResponseMessageDTO>> DeleteAsync(List<int> rolesIds)
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
                            responseMessageDTO.ErrorMessage = DomainResource.DeleteDefaultRoleAsyncException;
                        }
                        else
                        {
                            await UpdateUserWithDefaultRoleAsync(roleId);
                            responseMessageDTO.OperationSuccess = await _roleRepository.RemoveAsync(role);
                        }
                    }
                    else
                    {
                        responseMessageDTO.ErrorMessage = DomainResource.RoleNotFoundException;
                    }
                }
                catch (Exception)
                {
                    responseMessageDTO.ErrorMessage = DomainResource.DeleteRolesAsyncException;
                }

                responseMessageDTOs.Add(responseMessageDTO);
            }

            return responseMessageDTOs;
        }

        #endregion
    }
}

﻿using AutoMapper;
using AutoMoreira.Core.Domains.Identity;
using AutoMoreira.Core.Dto;
using AutoMoreira.Core.Dto.Identity;
using AutoMoreira.Persistence.Interfaces.Repositories;
using AutoMoreira.Persistence.Interfaces.Services;
using AutoMoreira.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AutoMoreira.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper,
            IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDTO userUpdateDto, string password)
        {
            try
            {
                var user = await _userManager.Users
                                             .SingleOrDefaultAsync(user => user.UserName == userUpdateDto.UserName.ToLower());

                return await _signInManager
                               .CheckPasswordSignInAsync(user, password, false);

            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar password. Erro: {ex.Message}");

            }
        }

        public async Task<UserUpdateDTO> CreateAccountAsync(UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if (result.Succeeded)
                {
                    var userToReturn = _mapper.Map<UserUpdateDTO>(user);
                    return userToReturn;
                }
                return null;

            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar criar conta de utilizador!. Erro: {ex.Message}");

            }
        }

        public async Task<UserUpdateDTO> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var user = await _userRepository.GetUserByUserNameAsync(userName);
                //Se não encontrar manda null
                if (user == null)
                {
                    return null;
                }

                var userUpdateDto = _mapper.Map<UserUpdateDTO>(user);
                return userUpdateDto;

            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar procurar utilizador por Username. Erro: {ex.Message}");

            }
        }

        public async Task<UserUpdateDTO> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);
                //Se não encontrar manda null
                if (user == null)
                {
                    return null;
                }

                var userUpdateDto = _mapper.Map<UserUpdateDTO>(user);
                return userUpdateDto;

            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar procurar utilizador por Username. Erro: {ex.Message}");

            }
        }
        public async Task<UserUpdateDTO[]> GetAllUsersAsync()
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();
                if (users == null) return null;

                var resultado = _mapper.Map<UserUpdateDTO[]>(users);
                return resultado;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<UserUpdateDTO> UpdateAccount(UserUpdateDTO userUpdateDTO)
        {
            try
            {
                var user = await _userRepository.GetUserByUserNameAsync(userUpdateDTO.UserName);
                if (user == null)
                {
                    return null;
                }
                //Para não colocar o "id" no model userupdate no FE
                userUpdateDTO.Id = user.Id;

                _mapper.Map(userUpdateDTO, user);

                if (userUpdateDTO.Password != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    await _userManager.ResetPasswordAsync(user, token, userUpdateDTO.Password);
                }
                
                _userRepository.Update<User>(user);

                if (await _userRepository.SaveChangesAsync())
                {
                    var userRetorno = await _userRepository.GetUserByUserNameAsync(user.UserName);
                    return _mapper.Map<UserUpdateDTO>(userRetorno);
                }
                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar utilizador. Erro: {ex.Message}");

            }
        }

        public async Task<bool> UserExists(string userName)
        {
            try
            {
                return await _userManager.Users
                                         .AnyAsync(user => user.UserName == userName.ToLower());

            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar se o utilizador existe. Erro: {ex.Message}");

            }
        }
    }
}

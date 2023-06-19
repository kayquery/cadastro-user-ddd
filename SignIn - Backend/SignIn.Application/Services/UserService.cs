using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignIn.Application.Interfaces;
using SignIn.Domain.DTO;
using SignIn.Domain.Entities;
using SignIn.Infra.Interfaces;
using SignIn.Presentation.Models;

namespace SignIn.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddressService _addressService;

        public UserService(IUserRepository userRepository, IAddressService addressService)
            => (_userRepository, _addressService) = (userRepository, addressService);


        public async Task<Result> CreateUser(UserDTO userDTO)
        {
            try
            {
                Address address = await _addressService.GetAddress(userDTO.ZipCode);

                if (!await IsAddressFromAmazonas(address.UF))
                    return new Result("O CEP deve ser do Amazonas/BR");

                if (await IsUserUnique(userDTO))
                    return new Result("Usuário já cadastrado");

                User user = new(userDTO);
                await _userRepository.Add(user);
                return new Result(user);
            }
            catch
            {
                return new Result("Houve um problema, usuário não criado");
            }
        }

        public async Task<Result> GetUser(string userId)
        {
            User user = await _userRepository.GetById(userId);
            return new Result(user);
        }

        public async Task<IEnumerable<User>> GetUsers()
            => await _userRepository.GetAll();

        public async Task<Result> UpdateUser(string userId, UserDTO userDTO)
        {
            Address address = await _addressService.GetAddress(userDTO.ZipCode);

            if (!await IsAddressFromAmazonas(address.UF))
                return new Result("O CEP deve ser do Amazonas/BR");

            if (!await UserExists(userId))
                return new Result(null);

            User user = new(userDTO);

            user.Update(userDTO);

            return new Result(await _userRepository.Update(user));
        }

        private async Task<bool> UserExists(string userId)
            => (await _userRepository.Find(user => user.Id == userId)).Any();

        private async Task<bool> IsUserUnique(UserDTO userDTO)
            => (await _userRepository.Find(user => user.Document == userDTO.Document || user.Email == userDTO.Email)).Any();

        private async Task<bool> IsAddressFromAmazonas(string uf)
            => uf.ToUpper() == "AM";
    }
}
using WebApplication1.DataAccessLayer.Repositories;
using System.Collections.Generic;
using WebApplication1.DataAccessLayer.Models;

namespace WebApplication1.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers() => _userRepository.GetAll();

        public User GetUserById(Guid id) => _userRepository.GetById(id);

        public User Register(User user)
        {
            // Проверьте уникальность адреса электронной почты перед добавлением
            var existingUser = _userRepository.FindByEmail(user.Email);
            if (existingUser != null)
                throw new Exception("Пользователь с указанным e-mail уже существует.");

            _userRepository.Add(user);
            _userRepository.SaveChanges();
            return user;
        }

        public User Authenticate(string email, string password)
        {
            var user = _userRepository.FindByEmail(email);
            if (user == null || !user.VerifyPassword(password))
                return null;
            return user;
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
            _userRepository.SaveChanges();
        }

        public void DeleteUser(Guid id)
        {
            var user = _userRepository.GetById(id);
            if (user != null)
            {
                _userRepository.Delete(user);
                _userRepository.SaveChanges();
            }
        }
    }
}
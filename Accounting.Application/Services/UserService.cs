using System;
using System.Collections.Generic;
using Accounting.Application.Interfaces;
using Accounting.Application.Utilities;
using Accounting.Domain.Interfaces;
using Accounting.Domain.Models.Users;
using Accounting.Domain.ViewModel.Account;
using Accounting.Domain.ViewModel.User;

namespace Accounting.Application.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public bool IsExistUserName(int userId, string userName)
        {
            return _userRepository.IsExistUserName(userId, userName);
        }

        public void Add(User user)
        {
            user.Password = SecurityHelper.GetSha256Hash(user.Password);
            _userRepository.Add(user);
        }

        public UserViewModel GetUserViewModel(int userId)
        {
            return _userRepository.GetUserViewModel(userId);
        }

        public void UpdateUser(UserViewModel user)
        {
            var userUpdate = GetById(user.UserId);
            if (userUpdate == null)
                return;


            userUpdate.Name = user.Name;
            userUpdate.IsActive = user.IsActive;
            if (user.Password.HasValue())
                userUpdate.Password = SecurityHelper.GetSha256Hash(user.Password);

            Update(userUpdate);
        }

        public void Update(User user)
        {
            user.UpdateDate = DateTime.Now;
            _userRepository.Update(user);
        }

        public User GetById(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public bool Delete(int userId)
        {
            var user = GetById(userId);
            if (user == null)
                return false;

            user.DeleteDate = DateTime.Now;

            Update(user);

            return true;
        }

        public User LoginUser(LoginViewModel login)
        {
            login.Password = SecurityHelper.GetSha256Hash(login.Password);
            login.UserName = login.UserName.Trim();
            return _userRepository.LoginUser(login);
        }

        public bool CompareOldPassword(int userId, string oldPassword)
        {
            var password = SecurityHelper.GetSha256Hash(oldPassword);
            return _userRepository.CompareOldPassword(userId, password);
        }

        public void ChangeUserPassword(int userId, string newPassword)
        {
            var user = GetById(userId);

            if (user == null)
                return;

            var password = SecurityHelper.GetSha256Hash(newPassword);
            user.Password = password;
            Update(user);
        }
    }
}
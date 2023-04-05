using System.Collections.Generic;
using Accounting.Domain.Models.Users;
using Accounting.Domain.ViewModel.Account;
using Accounting.Domain.ViewModel.User;

namespace Accounting.Domain.Interfaces
{

    public interface IUserRepository
    {
        List<User> GetAllUsers();
        bool IsExistUserName(int userId, string userName);
        void AddUser(User user);
        UserViewModel GetUserViewModel(int userId);
        void UpdateUser(User user);
        User GetUserById(int userId);
        User LoginUser(LoginViewModel login);
        bool CompareOldPassword(int userId, string oldPassword);
    }
}
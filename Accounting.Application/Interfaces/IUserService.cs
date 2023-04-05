using System.Collections.Generic;
using Accounting.Domain.Models.Users;
using Accounting.Domain.ViewModel.Account;
using Accounting.Domain.ViewModel.User;

namespace Accounting.Application.Interfaces
{

    public interface IUserService
    {
        List<User> GetAllUsers();
        bool IsExistUserName(int userId, string userName);
        void AddUser(User user);

        UserViewModel GetUserViewModel(int userId);

        void UpdateUser(UserViewModel user);
        void UpdateUser(User user);
        User GetUserById(int userId);
        bool DeleteUser(int userId);
        User LoginUser(LoginViewModel login);
        bool CompareOldPassword(int userId, string oldPassword);
        void ChangeUserPassword(int userId, string newPassword);
    }
}
using System.Collections.Generic;
using Accounting.Domain.Models.Users;
using Accounting.Domain.ViewModel.Account;
using Accounting.Domain.ViewModel.User;

namespace Accounting.Application.Interfaces
{

    public interface IUserService
    {
        List<User> GetAll();
        bool IsExistUserName(int userId, string userName);
        void Add(User user);

        UserViewModel GetUserViewModel(int userId);

        void UpdateUser(UserViewModel user);
        void Update(User user);
        User GetById(int userId);
        bool Delete(int userId);
        User LoginUser(LoginViewModel login);
        bool CompareOldPassword(int userId, string oldPassword);
        void ChangeUserPassword(int userId, string newPassword);
    }
}
using System.Collections.Generic;
using Accounting.Domain.Models.Users;
using Accounting.Domain.ViewModel.Account;
using Accounting.Domain.ViewModel.User;

namespace Accounting.Domain.Interfaces
{

    public interface IUserRepository
    {
        List<User> GetAll();
        bool IsExistUserName(int userId, string userName);
        void Add(User user);
        UserViewModel GetUserViewModel(int userId);
        void Update(User user);
        User GetById(int userId);
        User LoginUser(LoginViewModel login);
        bool CompareOldPassword(int userId, string oldPassword);
    }
}
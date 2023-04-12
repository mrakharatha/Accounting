using System.Collections.Generic;
using System.Linq;
using Accounting.Domain.Interfaces;
using Accounting.Domain.Models.Users;
using Accounting.Domain.ViewModel.Account;
using Accounting.Domain.ViewModel.User;
using Accounting.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Infra.Data.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public User LoginUser(LoginViewModel login)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == login.UserName && u.Password == login.Password);
        }

        public List<User> GetAll()
        {
            return _context.Users
                .Where(x => x.UserId != 1)
                .OrderByDescending(x => x.UserId).ToList();
        }

        public bool IsExistUserName(int userId, string userName)
        {
            return userId == 0 ? _context.Users.Any(x => x.UserName == userName) : _context.Users.Any(x => x.UserName == userName && x.UserId != userId);
        }

        public void Add(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }


        public UserViewModel GetUserViewModel(int userId)
        {
            return _context.Users
                .Include(x => x.UserRoles)
                .Select(u => new UserViewModel()
                {
                    UserName = u.UserName,
                    Name = u.Name,
                    IsActive = u.IsActive,
                    UserId = u.UserId,
                    UserRoles = u.UserRoles.Select(r => r.RoleId).ToList(),

                })
                .SingleOrDefault(u => u.UserId == userId);

        }

        public void Update(User user)
        {

            _context.Update(user);
            _context.SaveChanges();
        }

        public bool CompareOldPassword(int userId, string oldPassword)
        {
            return _context.Users.Any(u => u.UserId == userId && u.Password == oldPassword);

        }

        public User GetById(int userId)
        {
            return _context.Users.Find(userId);
        }
    }
}
using System.ComponentModel.DataAnnotations;
using Accounting.Domain.Models.Permissions;

namespace Accounting.Domain.Models.Users
{

    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }


        #region Relations

        public User User { get; set; }
        public Role Role { get; set; }

        #endregion
    }
}
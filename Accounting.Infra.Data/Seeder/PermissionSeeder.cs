using System.Collections.Generic;
using Accounting.Domain.Models.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounting.Infra.Data.Seeder
{
    public class PermissionSeeder : IEntityTypeConfiguration<Permission>
    {
        //سطح دسترسی
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasData(new List<Permission>()
            {
                new Permission(){PermissionId = 1,Title = "داشبورد",ParentId = null},
                new Permission(){PermissionId = 2,Title = "تنظییمات",ParentId = null},

                new Permission(){PermissionId = 3,Title = "کاربران",ParentId = 2},
                new Permission(){PermissionId = 4,Title = "افزودن کاربر",ParentId = 3},
                new Permission(){PermissionId = 5,Title = "ویرایش کاربر ",ParentId = 3},
                new Permission(){PermissionId = 6,Title = "حذف کاربر",ParentId = 3}, 
                
                new Permission(){PermissionId = 7,Title = "سطح دسترسی",ParentId = 2},
                new Permission(){PermissionId = 8,Title = "افزودن سطح دسترسی",ParentId = 7},
                new Permission(){PermissionId = 9,Title = "ویرایش سطح دسترسی",ParentId = 7},
                new Permission(){PermissionId = 10,Title = "حذف سطح دسترسی",ParentId = 7},

                new Permission(){PermissionId = 11,Title = "ویرایش پروفایل",ParentId = 2},


                new Permission(){PermissionId =12,Title = "تعاریف",ParentId = null},

               


            });
        }
    }
}
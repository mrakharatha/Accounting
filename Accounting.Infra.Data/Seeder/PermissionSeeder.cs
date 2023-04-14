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
                new Permission(){PermissionId = 13,Title = "مشتریان",ParentId = 12},
                new Permission(){PermissionId = 14,Title = "افزودن مشتری",ParentId = 13},
                new Permission(){PermissionId = 15,Title = "ویرایش مشتری ",ParentId = 13},
                new Permission(){PermissionId = 16,Title = "حذف مشتری",ParentId = 13},

                new Permission(){PermissionId =17,Title = "منو",ParentId = 12},

                new Permission(){PermissionId = 18,Title = "گروه منو",ParentId = 17},
                new Permission(){PermissionId = 19,Title = "افزودن گروه منو",ParentId = 18},
                new Permission(){PermissionId = 20,Title = "ویرایش گروه منو ",ParentId = 18},
                new Permission(){PermissionId = 21,Title = "حذف گروه منو",ParentId = 18},

                new Permission(){PermissionId = 22,Title = "مواد اولیه",ParentId = 12},
                new Permission(){PermissionId = 23,Title = "افزودن مواد اولیه",ParentId = 22},
                new Permission(){PermissionId = 24,Title = "ویرایش مواد اولیه ",ParentId = 22},
                new Permission(){PermissionId = 25,Title = "حذف مواد اولیه",ParentId = 22},


                new Permission(){PermissionId = 26,Title = "غذا",ParentId = 17},
                new Permission(){PermissionId = 27,Title = "افزودن غذا",ParentId = 26},
                new Permission(){PermissionId = 28,Title = "ویرایش غذا ",ParentId = 26},
                new Permission(){PermissionId = 29,Title = "حذف غذا",ParentId = 26}, 
                
                
                new Permission(){PermissionId = 30,Title = "سفارش",ParentId = null},
                new Permission(){PermissionId = 31,Title = "افزودن سفارش",ParentId = 30},
                new Permission(){PermissionId = 32,Title = "ویرایش سفارش ",ParentId = 30},
                new Permission(){PermissionId = 33,Title = "حذف سفارش",ParentId = 30},

            });
        }
    }
}
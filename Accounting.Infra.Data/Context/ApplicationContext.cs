using System.Linq;
using System.Reflection;
using Accounting.Application.Utilities;
using Accounting.Domain.Models.Customers;
using Accounting.Domain.Models.Menus;
using Accounting.Domain.Models.Permissions;
using Accounting.Domain.Models.RawMaterials;
using Accounting.Domain.Models.Users;
using Accounting.Infra.Data.Seeder;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Infra.Data.Context
{

    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Permission> Permission { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<GroupMenu> GroupMenus { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;



            var assembly = typeof(PermissionSeeder).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Role>().HasQueryFilter(c => c.DeleteDate == null);
            modelBuilder.Entity<User>().HasQueryFilter(c => c.DeleteDate == null);
            modelBuilder.Entity<Customer>().HasQueryFilter(c => c.DeleteDate == null);
            modelBuilder.Entity<GroupMenu>().HasQueryFilter(c => c.DeleteDate == null);
            modelBuilder.Entity<RawMaterial>().HasQueryFilter(c => c.DeleteDate == null);
            modelBuilder.Entity<Food>().HasQueryFilter(c => c.DeleteDate == null);



        }

        public override int SaveChanges()
        {
            _cleanString();
            return base.SaveChanges();
        }


        private void _cleanString()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var item in changedEntities)
            {
                var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var propName = property.Name;
                    var val = (string)property.GetValue(item.Entity, null)!;

                    if (val.HasValue())
                    {
                        var newVal = val.Fa2En().FixPersianChars();
                        if (newVal == val)
                            continue;
                        property.SetValue(item.Entity, newVal, null);
                    }
                }
            }
        }

    }
}
﻿// <auto-generated />
using System;
using Accounting.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Accounting.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230412105358_AddTblRawMaterial")]
    partial class AddTblRawMaterial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Accounting.Domain.Models.Customers.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Accounting.Domain.Models.Menus.GroupMenu", b =>
                {
                    b.Property<int>("GroupMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("GroupMenuId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupMenus");
                });

            modelBuilder.Entity("Accounting.Domain.Models.Permissions.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PermissionId");

                    b.HasIndex("ParentId");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            PermissionId = 1,
                            Title = "داشبورد"
                        },
                        new
                        {
                            PermissionId = 2,
                            Title = "تنظییمات"
                        },
                        new
                        {
                            PermissionId = 3,
                            ParentId = 2,
                            Title = "کاربران"
                        },
                        new
                        {
                            PermissionId = 4,
                            ParentId = 3,
                            Title = "افزودن کاربر"
                        },
                        new
                        {
                            PermissionId = 5,
                            ParentId = 3,
                            Title = "ویرایش کاربر "
                        },
                        new
                        {
                            PermissionId = 6,
                            ParentId = 3,
                            Title = "حذف کاربر"
                        },
                        new
                        {
                            PermissionId = 7,
                            ParentId = 2,
                            Title = "سطح دسترسی"
                        },
                        new
                        {
                            PermissionId = 8,
                            ParentId = 7,
                            Title = "افزودن سطح دسترسی"
                        },
                        new
                        {
                            PermissionId = 9,
                            ParentId = 7,
                            Title = "ویرایش سطح دسترسی"
                        },
                        new
                        {
                            PermissionId = 10,
                            ParentId = 7,
                            Title = "حذف سطح دسترسی"
                        },
                        new
                        {
                            PermissionId = 11,
                            ParentId = 2,
                            Title = "ویرایش پروفایل"
                        },
                        new
                        {
                            PermissionId = 12,
                            Title = "تعاریف"
                        },
                        new
                        {
                            PermissionId = 13,
                            ParentId = 12,
                            Title = "مشتریان"
                        },
                        new
                        {
                            PermissionId = 14,
                            ParentId = 13,
                            Title = "افزودن مشتری"
                        },
                        new
                        {
                            PermissionId = 15,
                            ParentId = 13,
                            Title = "ویرایش مشتری "
                        },
                        new
                        {
                            PermissionId = 16,
                            ParentId = 13,
                            Title = "حذف مشتری"
                        },
                        new
                        {
                            PermissionId = 17,
                            ParentId = 12,
                            Title = "منو"
                        },
                        new
                        {
                            PermissionId = 18,
                            ParentId = 17,
                            Title = "گروه منو"
                        },
                        new
                        {
                            PermissionId = 19,
                            ParentId = 18,
                            Title = "افزودن گروه منو"
                        },
                        new
                        {
                            PermissionId = 20,
                            ParentId = 18,
                            Title = "ویرایش گروه منو "
                        },
                        new
                        {
                            PermissionId = 21,
                            ParentId = 18,
                            Title = "حذف گروه منو"
                        },
                        new
                        {
                            PermissionId = 22,
                            ParentId = 12,
                            Title = "مواد اولیه"
                        },
                        new
                        {
                            PermissionId = 23,
                            ParentId = 22,
                            Title = "افزودن مواد اولیه"
                        },
                        new
                        {
                            PermissionId = 24,
                            ParentId = 22,
                            Title = "ویرایش مواد اولیه "
                        },
                        new
                        {
                            PermissionId = 25,
                            ParentId = 22,
                            Title = "حذف مواد اولیه"
                        });
                });

            modelBuilder.Entity("Accounting.Domain.Models.Permissions.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Accounting.Domain.Models.Permissions.RolePermission", b =>
                {
                    b.Property<int>("RolePermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RolePermissionId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("Accounting.Domain.Models.RawMaterials.RawMaterial", b =>
                {
                    b.Property<int>("RawMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RawMaterialId");

                    b.HasIndex("UserId");

                    b.ToTable("RawMaterials");
                });

            modelBuilder.Entity("Accounting.Domain.Models.Users.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreateDate = new DateTime(2022, 3, 2, 19, 56, 32, 968, DateTimeKind.Local).AddTicks(1379),
                            IsActive = true,
                            Name = "سید محمد رضا آزاد",
                            Password = "zlccbhGKkL1OKwMSZApYsIdBeTLlMwWoh573hL/kKaI=",
                            UserName = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("Accounting.Domain.Models.Users.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Accounting.Domain.Models.Customers.Customer", b =>
                {
                    b.HasOne("Accounting.Domain.Models.Users.User", "User")
                        .WithMany("Customers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Accounting.Domain.Models.Menus.GroupMenu", b =>
                {
                    b.HasOne("Accounting.Domain.Models.Users.User", "User")
                        .WithMany("GroupMenus")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Accounting.Domain.Models.Permissions.Permission", b =>
                {
                    b.HasOne("Accounting.Domain.Models.Permissions.Permission", null)
                        .WithMany("Permissions")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Accounting.Domain.Models.Permissions.RolePermission", b =>
                {
                    b.HasOne("Accounting.Domain.Models.Permissions.Permission", "Permission")
                        .WithMany("RolePermission")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Accounting.Domain.Models.Permissions.Role", "Role")
                        .WithMany("RolePermission")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Accounting.Domain.Models.RawMaterials.RawMaterial", b =>
                {
                    b.HasOne("Accounting.Domain.Models.Users.User", "User")
                        .WithMany("RawMaterials")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Accounting.Domain.Models.Users.UserRole", b =>
                {
                    b.HasOne("Accounting.Domain.Models.Permissions.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Accounting.Domain.Models.Users.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Accounting.Domain.Models.Permissions.Permission", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("RolePermission");
                });

            modelBuilder.Entity("Accounting.Domain.Models.Permissions.Role", b =>
                {
                    b.Navigation("RolePermission");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Accounting.Domain.Models.Users.User", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("GroupMenus");

                    b.Navigation("RawMaterials");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}

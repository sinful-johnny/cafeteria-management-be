﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CafeteriaDB;
using Microsoft.Extensions.Configuration;
using api.Dtos.Account;
using api.Dtos.USER;
using IdentityCafeteriaModel;
using api.Models.AuthModels;
using api.Models;

namespace api.Identity
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        //private readonly string _connectionString;
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        //private string BuildConnectionString(string baseConnectionString, string userId, string password)
        //{
        //    return baseConnectionString
        //        .Replace("{UserId}", userId)
        //        .Replace("{Password}", password);
        //}

        // New constructor for SQL Authentication
        //public ApplicationDBContext(LoginDto loginDto, IConfiguration configuration)
        //{
        //    // Build the connection string with SQL Authentication credentials
        //    var baseConnectionString = configuration.GetConnectionString("LoginConnection");
        //    _connectionString = BuildConnectionString(baseConnectionString, loginDto.EmailAddress, loginDto.Password);
        //}

        //Entity for API Authentication
        public DbSet<V_TakePermission_From_UserAndApiAndRole> V_TakePermission {  get; set; }
        public DbSet<V_TakeRole_From_UserAndApi> V_TakeRole { get; set; }

        public DbSet<UserRolesModel> userRolesModels { get; set; }

        public DbSet<V_Role> RoleModels { get; set; }

        public DbSet<RoleMenuPermAll> rolemenupermAll {  get; set; }


        //Entity for Identity
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuPermission> MenuPermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ApplicationRoleMenu> RoleMenus { get; set; }
        public DbSet<ApplicationAPI> APIs { get; set; }
        public DbSet<ApplicationRoleAPI> RoleAPIs { get; set; }
        public DbSet<APIPermission> ApiPermissions { get; set; }

        //View for Identity
        public DbSet<V_Menu> VMenus { get; set; }
        public DbSet<V_Permission_RoleMenu> VPermission_Roles { get; set; }
        public DbSet<V_Role_Menu> VRole_Menus { get; set; }
        public DbSet<V_User> V_Users { get; set; }
        public DbSet<V_UserId_RoleId> V_UserId_RoleIds { get; set; }

        //Entity for Db
        public DbSet<UserRole> userRoles { get; set; }
        public DbSet<ADMIN> Admin { get; set; }

        public DbSet<CANVA> Canva { get; set; }

        public DbSet<FOOD_TYPE> FoodType { get; set; }

        public DbSet<SHAPE_TYPE> ShapeType { get; set; }

        public DbSet<CAFETERIA_TABLE> CafeteriaTable { get; set; }

        public DbSet<V_ADMIN_TABLEInCANVA> V_TableInCanva { get; set; }

        public DbSet<V_ADMIN_FOODsOnTABLE> V_FoodsOnTable { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured && !string.IsNullOrEmpty(_connectionString))
        //    {
        //        optionsBuilder.UseSqlServer(_connectionString);
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Constraints for Identity

            modelBuilder.Entity<ApplicationAPI>(item =>
            {
                item.ToTable("AspNetAPI");

                item.HasMany(t => t.RoleApis)
                    .WithOne(u => u.API)
                    .HasForeignKey(r => r.ApiId)
                    .OnDelete(DeleteBehavior.NoAction);
            });


            modelBuilder.Entity<MenuItem>(item =>
            {
                item.ToTable("AspNetMenu");
                item.HasMany(y => y.Children)
                    .WithOne(r => r.ParentItem)
                    .HasForeignKey(u => u.ParentId);

                item.HasMany(t => t.RoleMenus)
                    .WithOne(u => u.MenuItem)
                    .HasForeignKey(r => r.MenuId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<APIPermission>(mp =>
            {
                mp.ToTable("ApiPermission");

                mp.HasKey(l => new { l.RoleApiId, l.PermissionId });
            });

            modelBuilder.Entity<MenuPermission>(mp =>
            {
                mp.ToTable("MenuPermission");

                mp.HasKey(l => new { l.RoleMenuId, l.PermissionId });

                mp.HasOne(o => o.Permission)
                    .WithMany(i => i.MenuPermissions)
                    .IsRequired();

                mp.HasOne(o => o.RoleMenu)
                    .WithMany(i => i.Permissions)
                    .IsRequired();
            });

            modelBuilder.Entity<Permission>(mp =>
            {
                mp.ToTable("Permission");

                mp.HasKey(l => l.Id);

                mp.HasMany(o => o.MenuPermissions)
                    .WithOne(i => i.Permission)
                    .HasForeignKey(y => y.PermissionId);
            });

            modelBuilder.Entity<V_TakeRole_From_UserAndApi>()
                .HasKey(v => new { v.RoleName }); // Composite key for V_Menu

            modelBuilder.Entity<V_TakePermission_From_UserAndApiAndRole>()
                .HasKey(v => new { v.Permission }); // Composite key for V_Menu

            modelBuilder.Entity<V_Menu>()
                .HasKey(v => new { v.menuID }); // Composite key for V_Menu
            
            modelBuilder.Entity<V_Role>()
                .HasKey(v => new { v.RoleID }); // Composite key for V_Role

            modelBuilder.Entity<V_Permission_RoleMenu>()
                .HasKey(v => new { v.rolemenuID, v.permissionID }); // Composite key for V_Permission_RoleMenu

            modelBuilder.Entity<V_Role_Menu>()
                .HasKey(v => new { v.menuID, v.rolemenuID, v.permissionID }); // Composite key for V_Role_Menu
            
            modelBuilder.Entity<UserRolesModel>()
                .HasKey(v => new { v.Role }); // Composite key for V_Role_Menu

            modelBuilder.Entity<RoleMenuPermAll>()
                .HasKey(rmpa => new { rmpa.RoleId, rmpa.MenuId, rmpa.PermId }); // Composite key for V_Menu
            
                modelBuilder.Entity<V_UserId_RoleId>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            //Constraints for CafeteriaDB

            modelBuilder.Entity<UserRole>()
                .HasNoKey();

            modelBuilder.Entity<V_ADMIN_TABLEInCANVA>()
                .HasKey(v => new { v.ID_TABLE }); // Composite key for V_ADMIN_TABLEInCANVA

            modelBuilder.Entity<V_ADMIN_FOODsOnTABLE>()
                .HasKey(v => new { v.ID_FOOD, v.ID_TABLE }); // Composite key for V_FoodsOnTable

            modelBuilder.Entity<FOOD_TABLE>()
                .HasKey(ct => new { ct.ID_FOOD, ct.ID_TABLE }); // Composite key for FOOD_TABLE

            modelBuilder.Entity<CANVA_ADMIN>()
                .HasKey(ca => new { ca.ID_CANVA, ca.ID_ADMIN }); // Composite key for CANVA_ADMIN

            modelBuilder.Entity<ADMIN>()
                .HasKey(a => new { a.ID_ADMIN }); // Composite key for ADMIN

            modelBuilder.Entity<CAFETERIA_TABLE>()
                .HasKey(ct => new { ct.ID_TABLE }); // Composite key for CAFETERIA_TABLE

            modelBuilder.Entity<CANVA>()
                .HasKey(c => new { c.ID_CANVA }); // Composite key for CANVA

            modelBuilder.Entity<FOOD_TYPE>()
                .HasKey(f => new { f.ID_FOOD }); // Composite key for FOOD_TYPE

            modelBuilder.Entity<SHAPE_TYPE>()
                .HasKey(s => new { s.ID_SHAPE }); // Composite key for SHAPE_TYPE

            modelBuilder.Entity<FOOD_TABLE>()
                .HasOne(u => u.FOOD_TYPE)
                .WithMany(u => u.FOOD_TABLE)
                .HasForeignKey(p => p.ID_FOOD);

            modelBuilder.Entity<FOOD_TABLE>()
                .HasOne(u => u.CAFETERIA_TABLE)
                .WithMany(u => u.FOOD_TABLE)
                .HasForeignKey(p => p.ID_TABLE);

            //Privileges
            //Stocks.FromSqlRaw

            //List<IdentityRole> roles = new List<IdentityRole>
            //{
            //    new IdentityRole
            //    {
            //        Name = "Admin",
            //        NormalizedName = "ADMIN"
            //    },

            //    new IdentityRole
            //    {
            //        Name = "User",
            //        NormalizedName = "USER"
            //    }
            //};

            //modelBuilder.Entity<IdentityRole>().HasData(roles); //Add data into roles
        }
    }
}

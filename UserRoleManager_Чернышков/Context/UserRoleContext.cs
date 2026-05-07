using Microsoft.EntityFrameworkCore;
using UserRoleManager_Чернышков.Classes.Database;
using UserRoleManager_Чернышков.Models;

namespace UserRoleManager_Чернышков.Context
{
    public class UserRoleContext : DbContext
    {
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Roles> Roles { get; set; } = null!;

        public UserRoleContext()
        {
            Database.EnsureCreated();
            Set<Users>().Load();
            Set<Roles>().Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(Config.connection, Config.version);
    }
}
using System.Reflection;
using Domain.Players;
using Domain.Teams;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Domain.Infra
{
    public class BrasileiraoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        
        // override, pois estamos sobrescrevando o comportamento/método padrão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Initial Catalog = nome do banco de dados que será criado
            // PWD = password
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;PWD=some(!)Password;Initial Catalog=Brasileirao");
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        } 
    }
}
using System;
using AutoEncontredotnet.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoEncontredotnet.Database
{
	public class ConnectionContext : DbContext
	{
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql(
               "Server=localhost;" +
               "Port=5432;" +
               "Database=autoencontre;" +
               "Username=autoencontre;" +
               "Password=autoencontre;"
               );
    }
}


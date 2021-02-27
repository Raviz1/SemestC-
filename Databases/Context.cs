using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

using System.ComponentModel.DataAnnotations.Schema;


/// <summary>
/// Dziedziczenie z na ORM wraz z inicjalizacją
/// </summary>

namespace FootballTeam.Databases
{
/// <summary>
///  odziedziczony context
/// </summary>
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<SportClub> SportClubs { get; set; }
        public DbSet<TransferHistory> TransferHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

   

}

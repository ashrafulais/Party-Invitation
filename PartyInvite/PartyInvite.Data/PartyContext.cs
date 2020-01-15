using Microsoft.EntityFrameworkCore;
using PartyInvite.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyInvite.Data
{
    public class PartyContext : DbContext
    {
        readonly string _connectionString, _migrationAssembly;

        public PartyContext(string conn, string migassembly)
        {
            _connectionString = conn;
            _migrationAssembly = migassembly;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    m=>m.MigrationsAssembly(_migrationAssembly));
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<GuestResponse> GuestResponses { get; set; }
        public DbSet<Gift> Gifts { get; set; }
    }
}

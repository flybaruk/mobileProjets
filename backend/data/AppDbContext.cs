using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.models;
using Microsoft.EntityFrameworkCore;

namespace backend.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CabeloModel> Cabelos { get; set;}
        public DbSet<TratamentoModel> Tratamentos { get; set;}
        public DbSet<CabeloTratamentoModel> CabeloTratamento{ get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("tembo"); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
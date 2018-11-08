
using Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;

namespace Contexto
{
    public class MonedaDb : DbContext
    {
        public MonedaDb(DbContextOptions<MonedaDb> options) : base(options)
        {

        }
        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<MonedaDb>
        {
            public MonedaDb CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<MonedaDb>();
                optionsBuilder.UseSqlServer(
                    "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MonedaDb; Integrated Security = True; MultipleActiveResultSets = True");

                return new MonedaDb(optionsBuilder.Options);
            }
        }
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<FactorConversion> ConversionFactores { get; set; }
       
        public DbSet<Pais> Pais { get; set; }

        public static implicit operator List<object>(MonedaDb v)
        {
            throw new NotImplementedException();
        }
    }
}

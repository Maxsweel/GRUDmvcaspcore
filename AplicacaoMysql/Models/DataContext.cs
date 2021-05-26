using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoMysql.Models
{
    public class DataContext : DbContext
    {



        // Caso não exista a tabela e/ou a database, iremos criar na hora
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //public DataContext(DbContextOptions<DataContext> options) : base(options)
        //{}





        // Caso não exista a tabela ele irá criar
        public DbSet<Contato> Contato { get; set; }
    
    
    }
}

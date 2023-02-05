using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmes.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Api.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts) 
        : base(opts)
        {
            
        }

        public DbSet<Filme> Filmes { get; set; }

        // private DbSet<Filme> filmes;

        // public DbSet<Filme> GetFilmes()
        // {
        //     return filmes;
        // }

        // public void SetFilmes(DbSet<Filme> value)    
        // {
        //     filmes = value;
        // }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_Projet.Models;

namespace API_Projet.Data
{
    public class API_ProjetContext : DbContext
    {
        public API_ProjetContext (DbContextOptions<API_ProjetContext> options)
            : base(options)
        {
        }

        public DbSet<API_Projet.Models.ConsoleJeu> Console { get; set; } = default!;

        public DbSet<API_Projet.Models.Constructor>? Constructor { get; set; }

        public DbSet<API_Projet.Models.Sales>? Sales { get; set; }
    }
}

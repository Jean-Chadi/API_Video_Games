using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API_Projet.Data;
using System;
using System.Linq;
namespace API_Projet.Models;
public static class SeedData // Ajout d’une nouvelle classe SeedData dans Models pour créer la base et ajouter un film si besoin
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new API_ProjetContext(
        serviceProvider.GetRequiredService<
        DbContextOptions<API_ProjetContext>>()))
        {
            context.Database.EnsureCreated();
            
            context.SaveChanges();
        }
    }
}

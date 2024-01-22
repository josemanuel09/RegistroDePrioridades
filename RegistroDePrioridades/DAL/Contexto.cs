using Microsoft.EntityFrameworkCore;
using RegistroDePrioridades.Models;

namespace RegistroDePrioridades.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Prioridades> Prioridades { get; set; }
        public DbSet<Prioridades> Clientes { get; set; }


    }
}

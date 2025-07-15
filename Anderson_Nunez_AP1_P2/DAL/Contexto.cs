using Anderson_Nunez_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace Anderson_Nunez_AP1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Entradas> Entradas { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<EntradasDetalle> EntradasDetalles { get; set; }

    
}




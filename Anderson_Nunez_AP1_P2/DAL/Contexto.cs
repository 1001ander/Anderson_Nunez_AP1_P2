using Anderson_Nunez_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace Anderson_Nunez_AP1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Entradas> Entradas { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<EntradasDetalle> EntradasDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 

        
        modelBuilder.Entity<Productos>().HasData(
            new Productos
            {
                ProductoId = 1,
                Descripcion = "Maní",
                Peso = 0.25m, 
                Existencia = 100,
                EsCompuesto = false
            },
            new Productos
            {
                ProductoId = 2,
                Descripcion = "Pistachos",
                Peso = 0.20m,
                Existencia = 100,
                EsCompuesto = false
            },
            new Productos
            {
                ProductoId = 3,
                Descripcion = "Almendras",
                Peso = 0.15m,
                Existencia = 100,
                EsCompuesto = false
            },
            new Productos
            {
                ProductoId = 4,
                Descripcion = "Frutos Mixtos 200gr",
                Peso = 0.20m, 
                Existencia = 0,
                EsCompuesto = true
            },
            new Productos
            {
                ProductoId = 5,
                Descripcion = "Frutos Mixtos 400gr",
                Peso = 0.40m,
                Existencia = 0,
                EsCompuesto = true
            },
            new Productos
            {
                ProductoId = 6,
                Descripcion = "Frutos Mixtos 600gr",
                Peso = 0.60m,
                Existencia = 0,
                EsCompuesto = true
            }
        );

        
        modelBuilder.Entity<Entradas>()
            .HasMany(e => e.Detalles)
            .WithOne(d => d.Entrada)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EntradasDetalle>()
            .HasOne(d => d.Producto)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }
}




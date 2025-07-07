using Anderson_Nunez_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace Anderson_Nunez_AP1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Parcial> Parcial { get; set; }

}

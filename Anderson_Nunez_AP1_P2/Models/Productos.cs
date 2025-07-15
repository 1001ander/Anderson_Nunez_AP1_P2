using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Anderson_Nunez_AP1_P2.Models;

public class Productos
{
   
    [Key]
    public int ProductoId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public decimal Peso { get; set; } 
    public int Existencia { get; set; }
    public bool EsCompuesto { get; set; }

    
    public ICollection<EntradasDetalle> EntradasDetalles { get; set; } = new List<EntradasDetalle>();
    public ICollection<Entradas> EntradasProducidas { get; set; } = new List<Entradas>();
}
    
  


    

   



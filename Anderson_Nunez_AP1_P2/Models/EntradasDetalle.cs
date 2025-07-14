using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Anderson_Nunez_AP1_P2.Models
{
    public class EntradasDetalle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Entrada")]
        public int EntradaId { get; set; }  

        [Required]
        [ForeignKey("Producto")]
        public int ProductoId { get; set; } 

        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public decimal Cantidad { get; set; } 

        
        public Entradas? Entrada { get; set; }
        public Productos? Producto { get; set; }
    }
}


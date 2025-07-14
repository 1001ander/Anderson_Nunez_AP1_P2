using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Anderson_Nunez_AP1_P2.Models
{
    public class Entradas
    {
        [Key]
        public int EntradaId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El concepto es obligatorio.")]
        [StringLength(200, ErrorMessage = "El concepto no puede exceder 200 caracteres.")]
        public string Concepto { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "El peso total debe ser mayor que cero.")]
        public decimal PesoTotal { get; set; } 

        
        [ForeignKey("Producto")]
        public int IdProducido { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad producida debe ser al menos 1.")]
        public int CantidadProducida { get; set; }

        
        public Productos? Producto { get; set; }

        
        public List<EntradasDetalle>? Detalles { get; set; }
    }
}


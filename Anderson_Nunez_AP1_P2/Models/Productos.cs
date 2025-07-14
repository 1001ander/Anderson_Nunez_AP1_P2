using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Anderson_Nunez_AP1_P2.Models;

public class Productos
{
    [Key]
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [StringLength(100, ErrorMessage = "La descripción no puede exceder 100 caracteres.")]
    public string Descripcion { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "El peso debe ser mayor que cero.")]
    public decimal Peso { get; set; } // En kilogramos (ej: 0.5 kg)

    [Range(0, int.MaxValue, ErrorMessage = "La existencia no puede ser negativa.")]
    public int Existencia { get; set; }

    public bool EsCompuesto { get; set; } 

    
  
}

    

   



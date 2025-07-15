using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Anderson_Nunez_AP1_P2.Models;

public class Entradas
{
    [Key]
    public int EntradaId { get; set; }
    public DateOnly Fecha { get; set; }
    public string Concepto { get; set; } = string.Empty;
    public decimal PesoTotal { get; set; } // En gramos

    public int ProductoId { get; set; }        // Producto que se está produciendo
    public int CantidadProducida { get; set; }

    // Detalles
    public ICollection<EntradasDetalle> Detalles { get; set; } = new List<EntradasDetalle>();
}
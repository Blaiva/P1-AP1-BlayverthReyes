using System.ComponentModel.DataAnnotations;

namespace P1_AP1_BlayverthReyes.Models;

public class EntradasHuacales
{
    [Key]
    public int IdEntrada { get; set; }

    [Required(ErrorMessage = "La fecha de entrada es requerida")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "El nombre del cliente es requerido")]
    [StringLength(50, ErrorMessage = "El tamaño del nombre debe ser menor a 50 caracteres")]
    public string NombreCliente { get; set; }

    [Required(ErrorMessage = "La cantidad de huacales es requerida")]
    [Range(0, int.MaxValue, ErrorMessage = "La cantidad de huacales debe ser mayor que cero")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El precio de los huacales es requerido")]
    [Range(0, int.MaxValue, ErrorMessage = "El precio de los huacales debe ser negativo")]
    public double Precio { get; set; }
}

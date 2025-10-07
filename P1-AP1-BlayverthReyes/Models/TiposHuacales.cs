using System.ComponentModel.DataAnnotations;

namespace P1_AP1_BlayverthReyes.Models;

public class TiposHuacales
{
    [Key]
    public int TipoId { get; set; }

    [Required]
    public string Descripcion {  get; set; }
}

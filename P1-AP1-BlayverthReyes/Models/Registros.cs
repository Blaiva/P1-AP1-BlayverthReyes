using System.ComponentModel.DataAnnotations;

namespace P1_AP1_BlayverthReyes.Models;

public class Registros
{
    [Key]
    public int RegistroId { get; set; }

    [Required]
    public string Nombres { get; set; }
}

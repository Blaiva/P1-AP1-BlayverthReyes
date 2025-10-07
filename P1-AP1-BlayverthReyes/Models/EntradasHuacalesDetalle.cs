using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace P1_AP1_BlayverthReyes.Models
{
    public class EntradasHuacalesDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        public int EntradaId { get; set; }

        public int TipoId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de huacales debe ser mayor que cero")]
        public int Cantidad { get; set; }

        [Range(0.01, int.MaxValue, ErrorMessage = "El precio de los huacales debe ser mayor que cero")]
        public string Precio { get; set; }

        [ForeignKey("EntradaId")]
        [InverseProperty("EntradasHuacalesDetalle")]
        public virtual EntradasHuacales EntradaHuacal { get; set; } = null!;
    }
}

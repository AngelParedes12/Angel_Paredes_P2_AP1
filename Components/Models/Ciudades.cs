using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Angel_Paredes_P2_AP1.Components.Models
{

    public class Ciudad
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Mínimo 3 caracteres")]
        public string Nombre { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El monto no puede ser negativo")]
        public decimal MontoTotal { get; set; }

        public List<Detalle> Detalles { get; set; } = new List<Detalle>();
        public List<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
    }
}

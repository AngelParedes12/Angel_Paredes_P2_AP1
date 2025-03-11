
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Modelo
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nombre es requerido")]
    public string Nombre { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Monto inválido")]
    public decimal MontoTotal { get; set; }
    public object Detalles { get; internal set; }
}

public class Detalle
{
    public int Id { get; set; }

    [Required]
    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Asignatura es requerida")]
    public string Asignatura { get; set; }

    [Range(0.01, 1000000, ErrorMessage = "Monto debe ser mayor a 0")]
    public decimal Monto { get; set; }

    [ForeignKey("Ciudad")]
    public int CiudadId { get; set; }
    public Ciudad Ciudad { get; set; }
}

public class Proyecto
{
    public int Id { get; set; }
    public decimal Presupuesto { get; set; }
    public int CiudadId { get; set; }
    public Ciudad Ciudad { get; set; }
}
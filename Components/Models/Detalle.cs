using System.ComponentModel.DataAnnotations;
namespace Angel_Paredes_P2_AP1.Components.Models;

public class Detalle
{
    public int Id { get; set; }

    [Required(ErrorMessage = "La fecha es requerida")]
    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "La asignatura es obligatoria")]
    [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
    public string Asignatura { get; set; }

    [Range(0.01, 1000000, ErrorMessage = "El monto debe ser mayor a 0")]
    public decimal Monto { get; set; }

    public int CiudadId { get; set; }
}
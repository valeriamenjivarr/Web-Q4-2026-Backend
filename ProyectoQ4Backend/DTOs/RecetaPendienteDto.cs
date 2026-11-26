namespace ProyectoQ4Backend.DTOs;

public class RecetaPendienteDto
{
    public string RecetaId { get; set; } = string.Empty; // Identifica la receta
   
    public string NombrePaciente { get; set; } = string.Empty; // Dato "armado"
    
    public DateTime FechaCreacion { get; set; } // Cuando se emitió la receta, la lista se ordena
                                                // con las más antiguas primero
    
    public string EstadoEntrega { get; set; } = string.Empty; // Pendiente o Parcial
    
    public List<ItemRecetaPendienteDto> Items { get; set; } = new(); // Los meds de esta receta que todavía faltan
                                                                     // En este DTO hay una lista de otros DTOs
}

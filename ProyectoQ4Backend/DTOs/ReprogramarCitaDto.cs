namespace ProyectoQ4Backend.DTOs;

public class ReprogramarCitaDto
{
    public DateTime? NuevaFechaHora { get; set; } // El ? hace que el campo pueda ser null
    
    public string Justificacion { get; set; } = string.Empty; // Espacio para escribir el motivo del cambio
}
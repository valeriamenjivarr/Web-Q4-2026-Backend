namespace ProyectoQ4Backend.DTOs;

public class RegistrarAjusteDto
{
    public string DispensacionId { get; set; } = string.Empty; // Cuál entrega se corrige
    
    public int DiferenciaCantidad { get; set; } // Cuánto cambia
    public string Motivo { get; set; } = string.Empty; // Por qué se hace la corrección
}
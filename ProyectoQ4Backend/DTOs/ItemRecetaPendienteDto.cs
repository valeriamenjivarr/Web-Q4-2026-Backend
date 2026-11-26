namespace ProyectoQ4Backend.DTOs;

public class ItemRecetaPendienteDto
{
    public string ItemRecetaId { get; set; } = string.Empty; // Lo que el botón "Entregar" de esa fila
                                                             // envía en RegistrarEntregaDto
    
    public string NombreMedicamento { get; set; } = string.Empty; // Para mostrarlo en la tabla
    
    public int CantidadRecetada { get; set; } // Cuánto indicó el dr
    
    public int CantidadEntregada { get; set; } // Cuánto se ha entregado hasta ahora
    
    public int CantidadPendiente { get; set; } // Lo que falta
                                               // Aclaración: en este DTO es una porpiedad normal,
                                               // luego el Service copia el resultado del cálculo que hace ItemReceta
    
    public string Dosis { get; set; } = string.Empty; // Indicación de usom para que el personal al vea al entregar
}
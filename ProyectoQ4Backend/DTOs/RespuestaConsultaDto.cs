namespace ProyectoQ4Backend.DTOs;

public class RespuestaConsultaDto
{
    public string ConsultaId { get; set; } = string.Empty; // Identificador de la consulta creada
    
    public string? RecetaId { get; set; } // Se utiliza ? para que pueda quedar vacío
                                          // por si no se recetó ningún medicamento
    
    public string Mensaje { get; set; } = string.Empty; // Aqui va el texto que se le muestra al personal como
                                                        // confirmación, depende si hay receta o no
                                                        // ej: "Consulta registrada y receta emitida con entrega pendiente"
}
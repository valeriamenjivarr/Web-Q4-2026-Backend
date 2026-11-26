namespace ProyectoQ4Backend.DTOs;

public class RespuestaAjusteDto // Respuesta de la dispensación del medicamento
{
    public string AjusteDispensacionId { get; set; } = string.Empty; // Identificador del registro de ajuste creado
    
    public int CantidadEntregadaDelItem { get; set; } // Cuánto queda entregado de ese medicamento después del ajuste
    
    public int CantidadPendienteDelItem { get; set; } // Cuánto queda pendiente después del ajuste
    
    public string EstadoEntregaReceta { get; set; } = string.Empty; // Estado recalculado de la receta; puede volver de
                                                                    //  Completa a Parcial
    public int ExistenciaActual { get; set; } // Stock resultante en el centro
    
    public string Mensaje { get; set; } = string.Empty; // Texto de confirmación
}
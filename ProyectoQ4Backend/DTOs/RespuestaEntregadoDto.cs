namespace ProyectoQ4Backend.DTOs;

public class RespuestaEntregadoDto
{
    public string DispensacionId { get; set; } = string.Empty; //Identificador de la entrega recién creada
    
    public string NombreMedicamento { get; set; } = string.Empty;//Para mostrar el nombre sin que angular lo busque
    
    public int CantidadEntregada { get; set; }//Lo que se entregó en este refistro
    
    public int CantidadPendiente { get; set; } // Lo que aún falta de ese medicamento (el faltante)
    
    public string EstadoEntregaReceta { get; set; } = string.Empty; // estado: Pendiente, Parcial o Completa
    
    public int ExistenciaRestante { get; set; } // Cuánto queda de stock en el centro
    
    public string Mensaje { get; set; } = string.Empty; // Espacio de texto para mostrar
}
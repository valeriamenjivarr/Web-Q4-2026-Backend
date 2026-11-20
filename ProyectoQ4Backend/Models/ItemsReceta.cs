namespace ProyectoQ4Backend.Models;

public class ItemsReceta
{
    public string ItemRecetaId { get; set; } = string.Empty;
    
    public string MedicamentoId { get; set; } = string.Empty; //Conexión al catálogo de med, CONSULTAR CON KENER

    public int CantidadRecetada { get; set; } // Cuánto se recetó (8 tabletas)
    
    public int CantidadEntregada { get; set; } //Cuánto se entregó hasta ahora (se conecta con dispensación)
    
    public int CantidadPendiente => CantidadRecetada - CantidadEntregada;
    
    public string Dosis { get; set; } = string.Empty; //Indicaciones de uso (3 tabs c/8hrs)
}
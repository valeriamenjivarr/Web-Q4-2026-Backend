namespace ProyectoQ4Backend.Models;

// Es la entrega física de un medicamento
// init (modificador de acceso, asigna el valor solo al
// crear el objeto): una vez creada, no se modifica
// El Service ya buscó la receta, el item y su existencia
public class Dispensacion
{
    public string DispensacionId { get; init; }  = string.Empty;// Identifica la entrega
    
    public string RecetaId { get; init; }  = string.Empty; //A qué receta pertenece
    
    public string ItemRecetaId { get; init; }  = string.Empty; // A cuál medicamente de la receta corresponde
    
    public string MedicamentoId { get; init; }  = string.Empty;// El med que se entegó, para cuestiones de invetario es mejor tener una propiedad a parte
    
    public string CentroSaludId { get; init; }  = string.Empty; // Desde qupe centró se entregó, de este mismo centro se descuenta del inventario
    
    public string PacienteId { get; init; }  = string.Empty; // A quién se le entregó
    
    public int CantidadEntregada { get; set; } // Unidades que se entregaron
    
    public DateTime FechaEntrega { get; set; } = DateTime.UtcNow; //Cuando se hizo la entrega
}
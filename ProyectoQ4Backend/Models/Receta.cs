namespace ProyectoQ4Backend.Models;

public class Receta
{
    public string RecetaId { get; set; } = string.Empty; //Idetifica la receta
    
    public string ConsultaId { get; set; } = string.Empty; //Identifica la consulta dnode se recetó
     
    public string PacienteId { get; set; } = string.Empty;// Id paciente de la receta
    
    public string CetroSalud { get; set; } = string.Empty;// Centro donde se entregará el med

    public string EstadoEntrega { get; set; } = ListasValidaciones.EstadoEntregaMed.Pendiente;

    public List<ItemsReceta> ItemEnReceta { get; set; } = new(); // Los meds que incluye la receta

    public DateTime FechaCreacionRec { get; set; } = DateTime.UtcNow;  // Cuando se recetó

}
namespace ProyectoQ4Backend.Models;

public class Citas
{
   public string CitaId { get; set; } = string.Empty;

   public string PacienteId {get; set;} = string.Empty; //Quién pidió la cita
   
   public string CentroSaludId {get; set;} = string.Empty; //En qué centro será la cita
   
   public string Servicio { get; set; } = string.Empty; //medicinal general, pediatría, ginecologia, cardiología

   public string? PersonalSaludId { get; set; }  // Quién la atendió. Queda vacío hasta que se atiende (? = puede estar vacío)
   
   public DateTime ProgramadaPara { get; set; } 
   
   public  DateTime FechaCreacion { get; set; } = DateTime.UtcNow; //Utc.Now: Fecha y hora actual en hora universal
   
   public DateTime FechaModificacion { get; set; } =  DateTime.UtcNow;

   public string Estado { get; set; } = ListasValidaciones.EstadoCita.Pendiente;
}
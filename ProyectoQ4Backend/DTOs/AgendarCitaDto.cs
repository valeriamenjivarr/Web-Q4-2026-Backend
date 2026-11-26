namespace ProyectoQ4Backend.DTOs;

public class AgendarCitaDto // Muestra solo una fila de la agenda
{
    public string CitaId { get; set; } = string.Empty; // Identidicadir de la cita
    
    public string PacienteId { get; set; } = string.Empty; //Identificador del paciente
    
    public string NombrePaciente { get; set; } = string.Empty; // Para mostrar el nombre del paciente, se hace en el dto
                                                               // para que la pantalla muestre texto legible, se obtiene
                                                               // del usuario, tmb oara que el nombre no se repita en 
                                                               // cada cita
    
    public DateTime FechaHoraProgramada{ get; set; } // Fecha y hora de la cita
    
    public string Servicio { get; set; } = string.Empty; // Medicinal general, gineco, etc
    
    public string Estado { get; set; } = string.Empty; // Programada, atendida, cancelada o NoAsistió
}
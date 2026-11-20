namespace ProyectoQ4Backend.Models;

/*
 * Se utiliza "static" para que no se pueda convertir en objetos
 * ni heredar
 */
public static class ListasValidaciones //Están todas las opciones permitidas, Si algo se cambia, solo se cambia aquí
{
    // Roles
    
    /*
     * const: significa que es una constante, o sea, que es un valor
     * fijo y no se puede modificar; se utiliza para que, mientras el
     * programa corre, el rol no pueda cambiar
     */

    public static class RolesUsuario
    {
        public const string Administrador = "Administrador";
        public const string PersonalSalud = "PersonalSalud";
        public const string Paciente = "Paciente";

        public static readonly List<string> Roles = new()
        {
            Administrador, PersonalSalud, Paciente
        };
    }

    // Estados de la cita

    public static class EstadoCita
    {
        public const string Pendiente = "Pendiente";
        public const string Programada = "Programada";
        public const string Atendida = "Atendida";
        public const string Cancelada = "Cancelada";
        public const string NoAsistio = "NoAsistio"; //El paciente no asistió a la cita

        public static readonly List<string> EstadosCita = new()
        {
            Programada, Atendida, Cancelada, NoAsistio
        };
    } 
    
    
    // Estado de entrega de medicamentos
    public static class EstadoEntregaMed
    {
        public const string Parcial = "Parcial";
        public const string Pendiente = "Pendiente";
        public const string Completa = "Completa";

        public static readonly List<string> EstadoMed = new()
        {
            Parcial, Pendiente, Completa
        };
    }

}
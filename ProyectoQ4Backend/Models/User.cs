namespace ProyectoQ4Backend.Models;

public class User
{
    public string Id { get; set; } = string.Empty;
    
    public string FullName { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public string PasswordHash { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    /*
     * 
public class Usuario
{
    public string Id { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;

    // Solo si tú verificas la contraseña. Si usas Firebase Authentication, bórralo
    public string HashContrasena { get; set; } = string.Empty;

    // Debe ser uno de ListasValidas.Roles. Por defecto es paciente
    public string Rol { get; set; } = ListasValidas.Paciente;

    public bool Activo { get; set; } = true;

    // Solo se llena para personal de salud
    public string? CentroSaludId { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
     */
}

namespace ProyectoQ4Backend.DTOs;

/**
 * DTO significa Data Transfer Object (Objeto de Transferencia de Datos)
 * es una clase que describe SOLO los datos que el FE sebe enviar
 * Id o la fecha ñas debe asignar - calcular el servidor
 */

public class RegisterDtos
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
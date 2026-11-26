namespace ProyectoQ4Backend.DTOs;

public class RegistrarEntregaDto
{
    public string RecetaId { get; set; } = string.Empty; //Identifica a qué receta se refiere
    
    public string ItemRecetaId { get; set; } = string.Empty; // Cuál medicamento de esa receta se entrega
    
    public int CantidadEntregada { get; set; } // Cuántas unidades se entregan
}
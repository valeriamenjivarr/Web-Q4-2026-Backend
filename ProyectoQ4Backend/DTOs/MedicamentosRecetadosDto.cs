namespace ProyectoQ4Backend.DTOs;

public class MedicamentosRecetadosDto
{
    public string MedicamentoId { get; set; } = string.Empty; // Cuál med del catálogo se receta
    
    /*
     * Angular lo toma de un desplegable que muestra los nombres
     */
    
    public int Cantidad {  get; set; } // Cuántas unidades se recetan
    
    public string Dosis { get; set; } = string.Empty; // Cómo se toma
    
}
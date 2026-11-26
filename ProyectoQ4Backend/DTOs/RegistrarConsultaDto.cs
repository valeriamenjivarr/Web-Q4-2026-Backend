namespace ProyectoQ4Backend.DTOs;

public class RegistrarConsultaDto
{
    public string Motivo  { get; set; } = string.Empty; // Racón de la consulta de pte
    
    public string Indicaciones { get; set; } = string.Empty; // Indicaciones dejadas por el médico

    public List<MedicamentosRecetadosDto> Medicamentos { get; set; } = new(); // El form puede traer varios medicamentos, o ninguno (lista vacía)
                                                                              // = new () = significa que empieza con una lista vacía.
                                                                              // Si el médico no receta nada, llega vacía y el Service no crea receta.
    /*
     * Una lista de medicamentos: el formulario puede traer varios. List<...> es una colección que guarda objetos de ese tipo.
     */
}
using System.ComponentModel.DataAnnotations;

namespace Filmes.Api.Data.Dtos
{
    public class CreateFilmeDto
    {    
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    [StringLength(50, ErrorMessage = "O título do filme não pode exceder 50 caracteres")]
    public string Titulo { get; set; } ="";   
    
    [Required(ErrorMessage = "O campo de duração é obrigatório")]
    [Range(1, 360, ErrorMessage = "A duração deve ter no mínimo 1 minuto e no máximo 360")]
    public int Duracao { get; set; }    
    
    [Required(ErrorMessage = "O Diretor do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O Diretor do filme não pode exceder 50 caracteres")]
    public string Diretor { get; set; } ="";   
    
    [Required(ErrorMessage = "O Gênero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O Gênero do filme não pode exceder 50 caracteres")]
    public string Genero { get; set; } = "";
    }
}
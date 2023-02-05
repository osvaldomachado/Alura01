using System.ComponentModel.DataAnnotations;

namespace Filmes.Api.Data.Dtos
{
    public class ReadFilmeDto
    {    
    public string Titulo { get; set; } ="";    
    public int Duracao { get; set; }    
    public string Diretor { get; set; } ="";    
    public string Genero { get; set; } = "";
    }
}
using AutoMapper;
using Filmes.Api.Data;
using Filmes.Api.Data.Dtos;
using Filmes.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace Filmes.Api.Controllers;

[ApiController]
//[Route("[controller]")]

public class FilmeContoller :ControllerBase
{
    private readonly FilmeContext _context;
    private readonly IMapper _mapper;
   
    public FilmeContoller(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]  
    [Route("/adiciona")]  
    public IActionResult AdicionarFilme(CreateFilmeDto filmeDto)
    {
         Filme filme = _mapper.Map<Filme>(filmeDto);

        if (filme is null)
            return NotFound();

        _context.Filmes.Add(filme); 
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaFilmePorId),new {filme.Id}, filme);          
    }

    [HttpGet]
    [Route("/recupera")]  
    public IEnumerable<ReadFilmeDto> RecuperaFilmes(int skip, int take)
    {   
        var filmes = _context.Filmes.Skip(skip).Take(take);

         return _mapper.Map<List<ReadFilmeDto>>(filmes);       
         
    }

    [HttpGet("{id}")]    
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

        if(filme is null)
            return NotFound();

        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        
        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, UpdateFilmeDto filmeDto)
    {
         var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

         if(filme is null)
            return NotFound();

         _mapper.Map(filmeDto,filme);
         _context.SaveChanges();

         return NoContent();  
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmePacial(int id, JsonPatchDocument<UpdateFilmeDto> parcial )
    {
         var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

         if(filme is null) return NotFound();
         
         var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

         parcial.ApplyTo(filmeParaAtualizar, ModelState);

         if(!TryValidateModel(filmeParaAtualizar))
         {
            return ValidationProblem(ModelState);

         }

         _mapper.Map(filmeParaAtualizar,filme);
         _context.SaveChanges();

         return NoContent();  
    }

    [HttpDelete("{id}")]
    public IActionResult ApagarFilme(int id)
    {
         var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

         if(filme is null)
            return NotFound();
         
         _context.Remove(filme);
         _context.SaveChanges();

         return NoContent();  
    }
}

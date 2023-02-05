using AutoMapper;
using Filmes.Api.Data.Dtos;
using Filmes.Api.Models;

namespace Filmes.Api.Profiles
{
    public class FilmeProfiles : Profile
    {
        public FilmeProfiles()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, UpdateFilmeDto>();
            CreateMap<Filme,ReadFilmeDto>();
        }
    }
}
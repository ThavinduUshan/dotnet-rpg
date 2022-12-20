using AutoMapper;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.models;

namespace dotnet_rpg
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}
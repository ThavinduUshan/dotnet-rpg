using AutoMapper;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.enums;
using dotnet_rpg.models;
using dotnet_rpg.Wrappers;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
            
        }

        private static List<Character> characters = new List<Character>{
            new Character{
            Id = 1,
            Name="Frodo",
            Strength=10,
            Defense=10,
            Intelligence=10,
            RpgClass = RpgClass.knight
        },
        new Character{
            Id = 2,
            Name="Sam",
            Strength=5,
            Defense=6,
            Intelligence=8,
            RpgClass = RpgClass.Cleric
        }
        };

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {

            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var newCharacter = _mapper.Map<Character>(character);
            newCharacter.Id = characters.Max(c => c.Id) + 1;
            characters.Add(newCharacter);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault<Character>(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }
    }
}
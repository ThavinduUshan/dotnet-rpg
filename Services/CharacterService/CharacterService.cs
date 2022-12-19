using dotnet_rpg.enums;
using dotnet_rpg.models;
using dotnet_rpg.Wrappers;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
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

        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character character)
        {

            var serviceResponse = new ServiceResponse<List<Character>>();
            characters.Add(character);
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<Character>();
            var character = characters.FirstOrDefault<Character>(c => c.Id == id);
            serviceResponse.Data = character;
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<List<Character>>> GetCharacters()
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data =characters;
            return serviceResponse;
        }
    }
}
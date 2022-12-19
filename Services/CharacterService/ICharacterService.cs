using dotnet_rpg.models;
using dotnet_rpg.Wrappers;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<Character>>> GetCharacters();

        Task<ServiceResponse<Character>> GetCharacterById(int id);

        Task<ServiceResponse<List<Character>>> AddCharacter(Character character);
    }
}
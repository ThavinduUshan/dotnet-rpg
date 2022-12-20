using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Wrappers;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters();

        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);

        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character);
    }
}
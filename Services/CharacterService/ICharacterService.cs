using dotnet_rpg.models;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        List<Character> GetCharacters();

        Character GetCharacterById(int id);

        List<Character> AddCharacter(Character character);
    }
}
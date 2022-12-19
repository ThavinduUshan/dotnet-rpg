using dotnet_rpg.enums;
using dotnet_rpg.models;

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

        public List<Character> AddCharacter(Character character)
        {
            characters.Add(character);
            return characters;
        }

        public Character GetCharacterById(int id)
        {
            return characters.FirstOrDefault<Character>(c => c.Id == id)!;
        }

        public List<Character> GetCharacters()
        {
            return characters;
        }
    }
}
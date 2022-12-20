using dotnet_rpg.enums;

namespace dotnet_rpg.Dtos.Character
{
    public class AddCharacterDto
    {

        public string? Name { get; set; }

        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }

        public RpgClass RpgClass { get; set; }
    }
}
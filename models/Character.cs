
using dotnet_rpg.enums;

namespace dotnet_rpg.models
{
    public class Character
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }

        public RpgClass RpgClass { get; set; }
    }
}
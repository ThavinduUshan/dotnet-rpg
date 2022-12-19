using System.Text.Json.Serialization;

namespace dotnet_rpg.enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        knight = 1,
        Mage = 2,
        Cleric=3,
    }
}
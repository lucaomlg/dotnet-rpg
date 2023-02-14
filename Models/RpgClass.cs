using System.Text.Json.Serialization;

namespace dotnet_rpg.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knigth = 1,
        Mage = 2,
        Cleric = 3,
        Assasin = 4,
        Hunter = 5

    }
}
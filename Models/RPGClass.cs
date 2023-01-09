using System.Text.Json.Serialization;

namespace Role_playing_game.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RPGClass
    {
        Knight =1,
        Mage =2,
        Cleric =3

    }
}
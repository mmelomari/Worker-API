using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Worker_CRUD.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartmentEnum
    {
        Tecnologia,
        Suporte,
        Marketing,
        Jornalismo,
        Almoxarifado
    }
}

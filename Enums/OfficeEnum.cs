using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Worker_CRUD.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OfficeEnum
    {
        Diretor,
        Pleno,
        Sênior,
        Junior,
        Gerente,
        Encarregado,
        Técnico,
        Vendedor
    }
}

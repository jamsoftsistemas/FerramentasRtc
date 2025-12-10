using System.Text.Json.Serialization;

namespace SincApiSefaz.Models.TabNBS;

public class Nbs
{
    [JsonPropertyName("Item_LC_116")]
    public string? Item_LC_116 { get; set; }

    [JsonPropertyName("Descricao_Item")]
    public string? Descricao_Item { get; set; }

    [JsonPropertyName("NBS")]
    public string? CodigoNbs { get; set; }

    [JsonPropertyName("Descricao_NBS")]
    public string? Descricao_NBS { get; set; }

    [JsonPropertyName("IndOP")]
    public string? IndOP { get; set; }

    [JsonPropertyName("Local_Incidencia_IBS")]
    public string? Local_Incidencia_IBS { get; set; }

    //[JsonPropertyName("cClassTrib")]
    //public string? CClassTrib { get; set; }

    //[JsonPropertyName("Nome_cClassTrib")]
    //public string? Nome_cClassTrib { get; set; }
}

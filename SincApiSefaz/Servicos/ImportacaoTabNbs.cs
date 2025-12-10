using SincApiSefaz.Models.TabNBS;
using SincApiSefaz.Repositorios;
using System.Text.Json;

namespace SincApiSefaz.Servicos;

public static class ImportacaoTabNbs
{
    public static async Task<string> BaixarJsonOnline(string url)
    {
        using var http = new HttpClient();
        try
        {
            string json = await http.GetStringAsync(url);
            return json;
        }
        catch
        {
            return string.Empty;
        }
    }
    public static List<Nbs> ExtrairDadosJson(string arquivoJson)
    {
        var lista = JsonSerializer.Deserialize<List<Nbs>>(arquivoJson);

        if (lista is null || !lista.Any())
            throw new JsonException("JSON inválido");

        return lista;
    }

    public static async Task AtualizarTabNBS(List<Nbs> dadosNBS)
    {
        var nbsRepository = new NbsRepository();
        nbsRepository.DeleteTudo();
        await nbsRepository.Salvar(dadosNBS);
    }

}

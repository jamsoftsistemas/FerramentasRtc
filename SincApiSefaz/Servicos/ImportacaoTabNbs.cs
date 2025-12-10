using SincApiSefaz.Models.TabNBS;
using SincApiSefaz.Repositorios;
using System.Text.Json;

namespace SincApiSefaz.Servicos;

public class ImportacaoTabNbs
{
    public List<Nbs> ExtrairDadosJson(string arquivoJson)
    {
        var lista = JsonSerializer.Deserialize<List<Nbs>>(File.ReadAllText(arquivoJson));
        return lista;
    }

    public void AtualizarTabNBS(List<Nbs> dadosNBS)
    {
        var nbsRepository = new NbsRepository();
        nbsRepository.DeleteTudo();
        nbsRepository.Salvar(dadosNBS);
    }

}

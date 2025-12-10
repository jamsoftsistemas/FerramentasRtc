using SincApiSefaz.Models.TabNBS;
using SincApiSefaz.Dao;
using Dapper;

namespace SincApiSefaz.Repositorios;

public class NbsRepository
{
    public async Task Salvar(List<Nbs> listaNbs)
    {
        foreach (var item in listaNbs)
            await Salvar(item);
    }

    public async Task Salvar(Nbs Nbs)
    {
        var cnx = Conexao.ObterConexao();

        var comando = @"INSERT INTO Cbslbs_Nbs
                        (
                            [Item_LC_116],
                            [Descricao_Item],
                            [CodigoNbs],
                            [Descricao_NBS],
                            [IndOp],
                            [Local_Incidencia_IBS]
                        ) 
                         VALUES
                        (
                            REPLACE(@Item_LC_116, '.', ''),
                            @Descricao_Item,
                            REPLACE(@CodigoNbs, '.', ''),
                            @Descricao_NBS,
                            @IndOp,
                            @Local_Incidencia_IBS
                        ); ";

        await cnx.ExecuteAsync(comando, Nbs);
    }

    public void DeleteTudo()
    {
        var cnx = Conexao.ObterConexao();

        var comando = @" Delete from Cbslbs_Nbs";

        cnx.Execute(comando);
    }
}

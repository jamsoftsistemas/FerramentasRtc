using SincApiSefaz.Models.TabIndOp;
using SincApiSefaz.Dao;
using Dapper;

namespace SincApiSefaz.Repositorios;

public class IndicadorDaOperacaoRepository
{
    public void Salvar(List<IndicadorDaOperacao> listaIndOp)
    {
        foreach (var item in listaIndOp)
            Salvar(item);
    }

    public void Salvar(IndicadorDaOperacao indOp)
    {
        var cnx = Conexao.ObterConexao();

        var comando = @"INSERT INTO IndicadorDaOperacao_ISS
                        (
                            [CodigoIndOp],
                            [DescricaoTipoOperacao],
                            [LocalFornecimento]
                        ) 
                         VALUES
                        (
                            @CodigoIndOp,
                            @TipoOperacao,
                            @LocalFornecimento
                        ); ";

        cnx.Execute(comando, indOp);
    }

    public void DeleteTudo()
    {
        var cnx = Conexao.ObterConexao();

        var comando = @" Delete from IndicadorDaOperacao_ISS";

        cnx.Execute(comando);
    }
}

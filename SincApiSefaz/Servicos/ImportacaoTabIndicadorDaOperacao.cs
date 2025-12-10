using ClosedXML.Excel;
using SincApiSefaz.Models.TabIndOp;
using SincApiSefaz.Repositorios;

namespace SincApiSefaz.Servicos
{
    public static class ImportacaoTabIndicadorDaOperacao
    {
        public static List<IndicadorDaOperacao> LerExcel(string arquivo)
        {
            var listaIndOp = new List<IndicadorDaOperacao>();
            using (var workbook = new XLWorkbook(arquivo))
            {
                var planilha = workbook.Worksheet(1);
                var tipoOperacao = string.Empty;
                var codigoIndOp = string.Empty;
                var localFornecimento = string.Empty;

                foreach (var linha in planilha.RowsUsed().Skip(1))
                {
                    if (!string.IsNullOrWhiteSpace(linha.Cell("B").GetString()))
                        tipoOperacao = linha.Cell("B").GetString();

                    codigoIndOp = linha.Cell("G").GetString();
                    if (string.IsNullOrWhiteSpace(codigoIndOp))
                        break;

                    localFornecimento = linha.Cell("H").GetString();

                    listaIndOp.Add(new()
                    {
                        CodigoIndOp = codigoIndOp,
                        TipoOperacao = tipoOperacao,
                        LocalFornecimento = localFornecimento
                    });
                }

            }
            return listaIndOp;
        }

        public static void AtualizarTabIndOp(List<IndicadorDaOperacao> dadosIndOp)
        {
            var indicadorDaOperacaoRepository = new IndicadorDaOperacaoRepository();
            indicadorDaOperacaoRepository.DeleteTudo();
            indicadorDaOperacaoRepository.Salvar(dadosIndOp);
        }
    }
}

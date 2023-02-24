using f29Reader.Domain;
using f29Reader.Domain.Table;
using f29Reader.Textract.Tables;
using UglyToad.PdfPig.Content;

namespace f29Reader.Textract;

internal abstract class BaseExtractTable
{
    public static readonly int RangeError = 2;
    protected IEnumerable<Word> Words;
    protected abstract TableColumnReader ColumnCode { get; set; }
    protected abstract TableColumnReader ColumnGlosas { get; set; }
    protected abstract TableColumnReader ColumnValor { get; set; }

    protected BaseExtractTable(IEnumerable<Word> words)
    {
        Words = words;
    }

    public IEnumerable<string> ExtractColumnCodigos() => ColumnCode.ExtractColumn();
    public IEnumerable<string> ExtractColumnGlosas() => ColumnGlosas.ExtractColumn();
    public IEnumerable<string> ExtractColumnValor() => ColumnValor.ExtractColumn();

    public IEnumerable<CompraVentaBase> Extract()
    {
        var codigos = ExtractColumnCodigos().ToArray();
        var glosas = ExtractColumnGlosas().ToArray();
        var valores = ExtractColumnValor().ToArray();

        if (codigos.Count() != glosas.Count() || codigos.Count() != valores.Count())
        {
            throw new Exception("Error en la extracción de datos");
        }

        var creditos = new List<CompraVentaBase>();

        for (int i = 0; i < codigos.Count(); i++)
        {
            if (valores.ElementAt(i).Contains(","))
                throw new Exception("Error en la extracción de datos, número con coma");

            var credito = new CompraVentaBase
            (
                Convert.ToInt32(valores.ElementAt(i).Replace(".", "")),
                Convert.ToInt32(codigos.ElementAt(i)),
                glosas.ElementAt(i)
            );

            creditos.Add(credito);
        }

        return creditos;
    }
}
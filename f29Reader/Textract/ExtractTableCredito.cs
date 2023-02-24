using f29Reader.Textract.Tables;
using f29Reader.Textract.Tables.Ingreso;
using UglyToad.PdfPig.Content;

namespace f29Reader.Textract;

internal class ExtractTableCredito : BaseExtractTable
{
    protected sealed override TableColumnReader ColumnCode { get; set; }
    protected sealed override TableColumnReader ColumnGlosas { get; set; }
    protected sealed override TableColumnReader ColumnValor { get; set; }

    public ExtractTableCredito(IEnumerable<Word> words) : base(words)
    {
        ColumnCode = new ColumnCode(Words);
        ColumnGlosas = new ColumnGlosa(Words);
        ColumnValor = new ColumnValor(Words);
    }
}
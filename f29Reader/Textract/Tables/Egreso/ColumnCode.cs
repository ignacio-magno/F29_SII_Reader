using UglyToad.PdfPig.Content;

namespace f29Reader.Textract.Tables.Egreso;

internal sealed class ColumnCode : TableColumnReader
{
    protected override double SideCoordinate => 34.106;

    protected override string HeaderTable => "Código";

    public ColumnCode(IEnumerable<Word> words) : base(words)
    {
    }

    public override IEnumerable<string> ExtractColumn() => ExtractCode();
}
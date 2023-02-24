using f29Reader.Domain;
using UglyToad.PdfPig.Content;

namespace f29Reader.Textract.Tables.Ingreso;

internal sealed class ColumnValor : TableColumnReader
{
    protected override double SideCoordinate => 622.486;

    protected override string HeaderTable => "Valor";

    public ColumnValor(IEnumerable<Word> words) : base(words)
    {
    }

    public override IEnumerable<string> ExtractColumn() =>
        ExtractTextOverEachRowInColumn(Orientation.Right, Jump);
}
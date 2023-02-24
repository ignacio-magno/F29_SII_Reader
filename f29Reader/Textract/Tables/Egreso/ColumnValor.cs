using f29Reader.Domain;
using UglyToad.PdfPig.Content;

namespace f29Reader.Textract.Tables.Egreso;

internal sealed class ColumnValor : TableColumnReader
{
    protected override double SideCoordinate => 322.588001;
    protected override string HeaderTable => "Valor";


    public override IEnumerable<string> ExtractColumn() =>
        ExtractTextOverEachRowInColumn(Orientation.Right, Jump);

    public ColumnValor(IEnumerable<Word> words) : base(words)
    {
    }
}
using f29Reader.Domain;
using UglyToad.PdfPig.Content;

namespace f29Reader.Textract.Tables.Ingreso;

internal sealed class ColumnGlosa : TableColumnReader
{
    protected override double SideCoordinate => 359.056;

    protected override string HeaderTable => "Glosa";

    public ColumnGlosa(IEnumerable<Word> words) : base(words)
    {
    }

    public override IEnumerable<string> ExtractColumn() =>
        ExtractTextOverEachRowInColumn(Orientation.Left, Jump);
}
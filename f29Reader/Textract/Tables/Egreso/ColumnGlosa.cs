using System.Collections;
using f29Reader.Domain;
using UglyToad.PdfPig.Content;

namespace f29Reader.Textract.Tables.Egreso;

internal sealed class ColumnGlosa : TableColumnReader
{
    protected override double SideCoordinate => 59.158;

    protected override string HeaderTable => "Glosa";

    public ColumnGlosa(IEnumerable<Word> words) : base(words)
    {
    }

    public override IEnumerable<string> ExtractColumn() =>
        ExtractTextOverEachRowInColumn(Orientation.Left, Jump);
}
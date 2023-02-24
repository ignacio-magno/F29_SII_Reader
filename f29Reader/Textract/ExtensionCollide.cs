using f29Reader.Domain;
using UglyToad.PdfPig.Content;

namespace f29Reader.Textract;

internal static partial class Extension
{
    public static bool CollideField(this Word word, Orientation orientation, double candidateCoordinate,
        int? additionalRangeError = 0)
    {
        var difLabels = Math.Abs(orientation.GetCoordinate(word) - candidateCoordinate);
        return difLabels < BaseExtractTable.RangeError + (additionalRangeError ?? 0);
    }
}
using f29Reader.Domain;
using UglyToad.PdfPig.Content;

namespace f29Reader.Textract;

internal class BoxNotCollide
{
    private Word Original;
    private Word Candidate;
    private bool _pass = true;
    private IEnumerable<Word> Words;

    private bool Pass
    {
        set
        {
            if (!_pass) return;
            _pass = value;
        }
        get => _pass;
    }

    public BoxNotCollide(Word original, Word candidate, IEnumerable<Word> words)
    {
        Original = original;
        Candidate = candidate;
        Words = words;
    }

    public BoxNotCollide WithLeft(int? aditionalRangeError = null)
    {
        Pass = CollideField(Orientation.Left, aditionalRangeError);
        return this;
    }

    public BoxNotCollide WithRight(int? aditionalRangeError = null)
    {
        Pass = CollideField(Orientation.Right, aditionalRangeError);
        return this;
    }

    public bool CollideField(Orientation orientation, int? aditionalRangeError = 0)
    {
        var difLabels = Math.Abs(orientation.GetCoordinate(Original) - orientation.GetCoordinate(Candidate));
        return difLabels < BaseExtractTable.RangeError + aditionalRangeError;
    }

    public bool CollideField(Orientation orientation, double candidateCoordinate, int? additionalRangeError = 0)
    {
        var difLabels = Math.Abs(orientation.GetCoordinate(Candidate) - candidateCoordinate);
        return difLabels < BaseExtractTable.RangeError + (additionalRangeError ?? 0);
    }

    public bool CollideField(Orientation orientation,
        int? aditionalRangeError, double? originalAditional, double? candidateAditional = 0)
    {
        var originalValue = orientation.GetCoordinate(Original) + (originalAditional ?? 0);
        var candidateValue = orientation.GetCoordinate(Candidate) + (candidateAditional ?? 0);
        var difLabels = Math.Abs(originalValue - candidateValue);
        return difLabels < BaseExtractTable.RangeError + (aditionalRangeError ?? 0);
    }

    private bool CollideWithLimitUpper(Word original, Word candidate) =>
        original.BoundingBox.Bottom > candidate.BoundingBox.Top;


    public BoxNotCollide NotUpperOriginalBox()
    {
        Pass = CollideWithLimitUpper(Original, Candidate);
        return this;
    }

    private bool CollideWithLimitInferiorTable(Word j) =>
        j.BoundingBox.Bottom >
        Words.FindBySentence("TOTAL A PAGAR DENTRO DEL PLAZO LEGAL").First().BoundingBox.Top;

    public BoxNotCollide NotBelowLimitInferior()
    {
        Pass = CollideWithLimitInferiorTable(Candidate);
        return this;
    }

    public bool Verify() => Pass;

    public BoxNotCollide WithTop(int? aditionalRangeError = null, int? originalAditional = null,
        double? candidateAditional = null)
    {
        Pass = CollideField(Orientation.Top, aditionalRangeError, originalAditional,
            candidateAditional);
        return this;
    }

    public BoxNotCollide WithBottom(int? aditionalRangeError = null, int? originalAditional = null,
        double? candidateAditional = null)
    {
        Pass = CollideField(Orientation.Bottom, aditionalRangeError, originalAditional,
            candidateAditional);
        return this;
    }

    public BoxNotCollide CandidateMustCollideWith(Orientation orientation, double customCoordinate,
        int? aditionalRangeError = null)
    {
        Pass = CollideField(orientation, customCoordinate, aditionalRangeError);
        return this;
    }
}
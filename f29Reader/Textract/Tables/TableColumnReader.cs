using f29Reader.Domain;
using UglyToad.PdfPig.Content;

namespace f29Reader.Textract.Tables;

public abstract class TableColumnReader
{
    protected const double Jump = 8.5;
    protected abstract double SideCoordinate { get; }
    public abstract IEnumerable<string> ExtractColumn();
    private readonly IEnumerable<Word> _words;
    protected abstract string HeaderTable { get; }

    protected TableColumnReader(IEnumerable<Word> words) => _words = words;

    //TODO: upgrade this method
    protected List<string> ExtractTextOverEachRowInColumn(Orientation orientation,
        double jump)
    {
        var headerField = _words.FindWord(HeaderTable);
        var results = new List<string>();
        const int aditionalRangeError = 3;

        for (var indexWord = 0; indexWord < _words.Count(); indexWord++)
        {
            if (!new BoxNotCollide(headerField, _words.ElementAt(indexWord), _words)
                    .CandidateMustCollideWith(orientation, SideCoordinate, 2).Verify())
                continue;
            for (var step = jump; step < 400; step += jump)
            {
                if (!new BoxNotCollide(headerField, _words.ElementAt(indexWord), _words)
                        .WithTop(aditionalRangeError, null, step)
                        .WithBottom(aditionalRangeError, null, step)
                        .NotUpperOriginalBox().NotBelowLimitInferior()
                        .CandidateMustCollideWith(orientation, SideCoordinate, 2)
                        .Verify()) continue;

                results.Add(_words.FindCompleteWordByIndex(indexWord).ConcatenarString());
                break;
            }
        }

        return results;
    }

    protected IEnumerable<string> ExtractCode()
    {
        var headerTableWords = _words.FindWordAll(HeaderTable);
        var headerTableWord = headerTableWords.First(j => j.CollideField(Orientation.Left, SideCoordinate));
        const int aditionalRangeError = 3;

        return _words.Where(j =>
            new BoxNotCollide(headerTableWord, j, _words)
                .WithLeft(aditionalRangeError)
                .WithRight(aditionalRangeError)
                .NotUpperOriginalBox().NotBelowLimitInferior().Verify()
        ).Select(word => word.Text);
    }
}
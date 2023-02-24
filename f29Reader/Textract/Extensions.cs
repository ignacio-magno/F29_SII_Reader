using f29Reader.Domain;
using UglyToad.PdfPig.Content;

namespace f29Reader.Textract;

internal static partial class Extensions
{
    public static double GetCoordinate(this Orientation orientation, Word word)
    {
        switch (orientation)
        {
            case Orientation.Left:
                return word.BoundingBox.Left;
            case Orientation.Right:
                return word.BoundingBox.Right;
            case Orientation.Top:
                return word.BoundingBox.Top;
            case Orientation.Bottom:
                return word.BoundingBox.Bottom;
            default:
                throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null);
        }
    }

    public static string ConcatenarString(this IEnumerable<Word> words)
    {
        return words.Select(j => j.Text).Aggregate((i, j) => i + " " + j);
    }

    public static Word FindWord(this IEnumerable<Word> words, string textField)
    {
        var headerCodigo = words.First(j => j.Text == textField);
        if (headerCodigo == null) throw new ArgumentNullException(nameof(headerCodigo));
        return headerCodigo;
    }

    public static IEnumerable<Word> FindWordAll(this IEnumerable<Word> words, string textField)
    {
        var headerCodigo = words.Where(j => j.Text == textField);
        if (headerCodigo == null) throw new ArgumentNullException(nameof(headerCodigo));
        return headerCodigo;
    }


    public static IEnumerable<Word> FindCompleteWordByIndex(this IEnumerable<Word> words, int indexArray)
    {
        var result = new List<Word>();
        var enumerable = words.ToArray();

        double space = 0;
        var index = 0;
        while (space < 4)
        {
            var currentWord = enumerable.ElementAt(indexArray + index);
            var nextWord = enumerable.ElementAt(indexArray + index + 1);

            result.Add(currentWord);
            space = Math.Abs(currentWord.BoundingBox.Right - nextWord.BoundingBox.Left);
            index++;
        }

        return result;
    }

    // return the sequences of words that match the sentence
    public static IEnumerable<Word> FindBySentence(this IEnumerable<Word> words, string sentence)
    {
        var sentenceSplit = sentence.Split(" ");
        var wordsWithIndex = words.Select((item, index) => new { item, index }).ToList();

        var total = wordsWithIndex.Where(j => j.item.Text.Equals(sentenceSplit.First()));

        foreach (var var in total)
        {
            var range = wordsWithIndex.GetRange(var.index, sentenceSplit.Length);
            var text = range.Select(j => j.item.Text).Aggregate((i, j) => i + " " + j);

            if (text.Contains(sentence))
                return range.Select(j => j.item);
        }

        throw new Exception("Not found");
    }
}
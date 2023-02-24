using f29Reader.Domain;
using UglyToad.PdfPig.Content;

namespace f29Reader.Textract;

public class Extracter
{
    public Page _page;
    internal BaseExtractTable ExtractTableDebito;
    internal BaseExtractTable ExtractTableCredito;

    private DateTime Period
    {
        get
        {
            var period = ExtractPeriodo();
            var month = period.Substring(0, 4);
            var year = period.Substring(4, 2);

            var date = DateTime.Parse($"{month}/{year}");
            return date;
        }
    }

    public readonly IEnumerable<Word> Words;

    public Extracter(Page page)
    {
        _page = page;
        Words = page.GetWords();
        ExtractTableDebito = new ExtractTableDebito(Words);
        ExtractTableCredito = new ExtractTableCredito(Words);
    }


    public string ExtractFolio() => ExtractF29Credentials("FOLIO").Last().Text;

    public string ExtractRut() => ExtractF29Credentials("RUT").Last().Text;

    public string ExtractPeriodo() => ExtractF29Credentials("PERIODO").Last().Text;

    private IEnumerable<Word> ExtractF29Credentials(string field)
    {
        var folio = Words.FindWord(field);
        return Words.Where(j => new BoxNotCollide(folio, j, Words).WithTop().WithBottom().Verify());
    }

    public F29 MakeF29()
    {
        var date = Period;

        return new F29.Builder()
            .WithFolio(Int64.Parse(ExtractFolio()))
            .WithRut(ExtractRut())
            .WithPeriod(date)
            .WithCreditos(ExtractTableCredito.Extract())
            .WithDebitos(ExtractTableDebito.Extract())
            .Build();
    }
}
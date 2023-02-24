using f29Reader.Domain;
using UglyToad.PdfPig;

namespace f29Reader;

public class F29Reader
{
    public F29Reader()
    {
    }

    public F29 ReadFile(string path)
    {
        using var document = PdfDocument.Open(path);
        var extracter = new Textract.Extracter(document.GetPage(1));
        return extracter.MakeF29();
    }

    public F29 ReadFile(Stream stream)
    {
        using var document = PdfDocument.Open(stream);
        var extracter = new Textract.Extracter(document.GetPage(1));
        return extracter.MakeF29();
    }
}
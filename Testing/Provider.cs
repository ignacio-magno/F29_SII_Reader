using f29Reader.Textract;
using Newtonsoft.Json;
using Testing.Textract;
using UglyToad.PdfPig;

namespace Testing;

public static class Provider
{
    public static string PathF29Pdf = "filesTemplate/test.pdf";
    public static string PathF29Json = PathF29Pdf + ".json";
    public static ProviderTemplate providerTemplate = JsonConvert.DeserializeObject<ProviderTemplate>(File.ReadAllText(PathF29Json));

    public static Extracter Extracter()
    {
        using var document = PdfDocument.Open(PathF29Pdf);
        return new(document.GetPage(1));
    }

    // Extracter is singleton

    public static List<Expected> Expecteds = new()
    {
        DefaultExpected()
    };

    public static Expected DefaultExpected()
    {
        var f29Correct = providerTemplate;
        var builder = new Expected.Builder()
            .WithRut(f29Correct.rut)
            .WithFolio(f29Correct.folio)
            .WithPeriodo(f29Correct.periodo);

        foreach (var debito in f29Correct.debito)
        {
            builder.WithDebito(debito.code, debito.glosa, debito.value);
        }

        foreach (var credito in f29Correct.credito)
        {
            builder.WithCredito(credito.code, credito.glosa, credito.value);
        }

        return builder.Build();
    }
}
using f29Reader.Textract;
using FluentAssertions;

namespace Testing.Textract;

public class CreditoTable
{
    private BaseExtractTable TableCredito = Provider.Extracter().ExtractTableCredito;
    private Expected.Table ExpectedTableCredito = Provider.DefaultExpected().TablaCredito;

    [DatapointSource]
    DebitoCodigo[] codigos => TableCredito.ExtractColumnCodigos()
        .Select((j, index) => new DebitoCodigo(j, index)).ToArray();

    [DatapointSource]
    DebitoGlosa[] glosas => TableCredito.ExtractColumnGlosas()
        .Select((j, index) => new DebitoGlosa(j, index)).ToArray();

    [DatapointSource]
    DebitoValor[] valores => TableCredito.ExtractColumnValor()
        .Select((j, index) => new DebitoValor(j, index)).ToArray();

    [Test]
    public void CountCodigo() => TableCredito.ExtractColumnCodigos().Count()
        .Should().Be(ExpectedTableCredito.Codigo.Count);

    [Theory]
    public void TableDebitoCodigo(DebitoCodigo data)
        => data.Item.Should().Be(ExpectedTableCredito.Codigo.ElementAt(data.IndexArray));

    [Test]
    public void CountGlosa() => TableCredito.ExtractColumnGlosas().Count()
        .Should().Be(ExpectedTableCredito.Glosa.Count);

    [Theory]
    public void TableDebitoGlosa(DebitoGlosa data)
        => data.Item.Should().Be(ExpectedTableCredito.Glosa.ElementAt(data.IndexArray));

    [Test]
    public void CountValor() => TableCredito.ExtractColumnValor().Count().Should()
        .Be(ExpectedTableCredito.Valor.Count);

    [Theory]
    public void TableDebitoValor(DebitoValor data)
        => data.Item.Should().Be(ExpectedTableCredito.Valor.ElementAt(data.IndexArray));
}
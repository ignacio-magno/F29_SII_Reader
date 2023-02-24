using FluentAssertions;

namespace Testing.Textract;

public class DebitoTable
{
    [DatapointSource]
    DebitoCodigo[] codigos => Provider.Extracter().ExtractTableDebito.ExtractColumnCodigos()
        .Select((j, index) => new DebitoCodigo(j, index)).ToArray();

    [DatapointSource]
    DebitoGlosa[] glosas => Provider.Extracter().ExtractTableDebito.ExtractColumnGlosas()
        .Select((j, index) => new DebitoGlosa(j, index)).ToArray();

    [DatapointSource]
    DebitoValor[] valores => Provider.Extracter().ExtractTableDebito.ExtractColumnValor()
        .Select((j, index) => new DebitoValor(j, index)).ToArray();


    [Theory]
    public void TableDebitoCodigo(DebitoCodigo data)
        => data.Item.Should().Be(Provider.DefaultExpected().TablaDebito.Codigo.ElementAt(data.IndexArray));

    [Theory]
    public void TableDebitoGlosa(DebitoGlosa data)
        => data.Item.Should().Be(Provider.DefaultExpected().TablaDebito.Glosa.ElementAt(data.IndexArray));

    [Theory]
    public void TableDebitoValor(DebitoValor data)
        => data.Item.Should().Be(Provider.DefaultExpected().TablaDebito.Valor.ElementAt(data.IndexArray));
}


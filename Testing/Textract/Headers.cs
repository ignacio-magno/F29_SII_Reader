using FluentAssertions;

namespace Testing.Textract;

public class Headers
{
    [Test]
    public void Folio() => Provider.Extracter().ExtractFolio().Should().Be(Provider.providerTemplate.folio);

    [Test]
    public void Rut() => Provider.Extracter().ExtractRut().Should().Be(Provider.providerTemplate.rut);

    [Test]
    public void Periodo() => Provider.Extracter().ExtractPeriodo().Should().Be(Provider.providerTemplate.periodo);
}
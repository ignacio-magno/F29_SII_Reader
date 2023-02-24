using f29Reader;
using f29Reader.Domain;
using FluentAssertions;
using Testing.Textract;

namespace Testing;

public class Main
{
    private F29 f29 = new F29Reader().ReadFile(Provider.PathF29Pdf);
    private static Expected ExpectedF29 = Provider.DefaultExpected();

    [Test]
    public void Folio() => f29.Folio.ToString().Should().Be(ExpectedF29.Folio);

    [Test]
    public void Rut() => f29.Rut.Should().Be(ExpectedF29.Rut);

    [Test]
    public void Period() => f29.Period.Should().Be(ExpectedF29.PeriodoDate);

    [DatapointSource] private CodesDebitoFacade[] codesDebito = Enum.GetValues<CodesDebito>()
        .Select(j => new CodesDebitoFacade((int)j, ExpectedF29.TablaDebito.CodigoInt.Exists(k => k == (int)j)))
        .ToArray();

    [DatapointSource] private CodesCreditoFacade[] codesCredito = Enum.GetValues<CodesCredito>()
        .Select(j => new CodesCreditoFacade((int)j, ExpectedF29.TablaCredito.CodigoInt.Exists(k => k == (int)j)))
        .ToArray();

    [Theory]
    public void CreditosValor(CodesCreditoFacade code)
    {
        var index = ExpectedF29.TablaCredito.CodigoInt.IndexOf(code.Code);
        f29.Creditos.ByCode(code.Code)?.Valor.Should()
            .Be(int.Parse(ExpectedF29.TablaCredito.Valor[index].Replace(".", "")));
    }

    [Theory]
    public void CreditNull(CodesCreditoFacade code)
    {
        if (code.Exist) f29.Creditos.ByCode(code.Code).Should().NotBeNull();
        else f29.Creditos.ByCode(code.Code).Should().BeNull();
    }

    [Theory]
    public void DebitNull(CodesDebitoFacade code)
    {
        if (code.Exist) f29.Debitos.ByCode(code.Code).Should().NotBeNull();
        else f29.Debitos.ByCode(code.Code).Should().BeNull();
    }

    [Theory]
    public void CreditosCode(CodesCreditoFacade code)
    {
        var index = ExpectedF29.TablaCredito.CodigoInt.IndexOf(code.Code);
        f29.Creditos.ByCode(code.Code)?.Code.Should().Be(ExpectedF29.TablaCredito.CodigoInt[index]);
    }

    [Theory]
    public void CreditosGlosa(CodesCreditoFacade code)
    {
        var index = ExpectedF29.TablaCredito.CodigoInt.IndexOf(code.Code);
        f29.Creditos.ByCode(code.Code)?.Glosa.Should().Be(ExpectedF29.TablaCredito.Glosa[index]);
    }

    [Theory]
    public void DebitoCode(CodesDebitoFacade code)
    {
        var index = ExpectedF29.TablaDebito.CodigoInt.IndexOf(code.Code);
        f29.Debitos.ByCode(code.Code)?.Code.Should().Be(ExpectedF29.TablaDebito.CodigoInt[index]);
    }

    [Theory]
    public void DebitoGlosa(CodesDebitoFacade code)
    {
        var index = ExpectedF29.TablaDebito.CodigoInt.IndexOf(code.Code);
        f29.Debitos.ByCode(code.Code)?.Glosa.Should().Be(ExpectedF29.TablaDebito.Glosa[index]);
    }

    [Theory]
    public void DebitoValor(CodesDebitoFacade code)
    {
        var index = ExpectedF29.TablaDebito.CodigoInt.IndexOf(code.Code);
        f29.Debitos.ByCode(code.Code)?.Valor.Should()
            .Be(int.Parse(ExpectedF29.TablaDebito.Valor[index].Replace(".", "")));
    }
}

public class CompraVentaCode
{
    public int Code { get; }
    public bool Exist { get; }

    public CompraVentaCode(int codes, bool exist)
    {
        Code = codes;
        Exist = exist;
    }
}

public class CodesCreditoFacade : CompraVentaCode
{
    public CodesCreditoFacade(int codes, bool exist) : base(codes, exist)
    {
    }
}

public class CodesDebitoFacade : CompraVentaCode
{
    public CodesDebitoFacade(int codes, bool exist) : base(codes, exist)
    {
    }
}
namespace f29Reader.Domain.Table;

public sealed class Debito : CompraVentaBase
{
    public Debito(int valor, int code, string glosa) : base(valor, code, glosa)
    {
    }
}
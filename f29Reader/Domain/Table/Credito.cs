namespace f29Reader.Domain.Table;

public sealed  class Credito : CompraVentaBase
{
    public Credito(int valor, int code, string glosa) : base(valor, code, glosa)
    {
    }
}
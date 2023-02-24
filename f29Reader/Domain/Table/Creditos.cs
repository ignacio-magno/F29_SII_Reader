namespace f29Reader.Domain.Table;

public sealed class Creditos : ComprasVentasBase
{
    public Creditos(IEnumerable<CompraVentaBase> creditos) : base(creditos)
    {
    }
}
namespace f29Reader.Domain.Table;

public sealed class Debitos: ComprasVentasBase
{
    public Debitos(IEnumerable<CompraVentaBase> creditos) : base(creditos)
    {
    }
}
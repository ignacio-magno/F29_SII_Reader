namespace f29Reader.Domain.Table;

public class ComprasVentasBase
{
    private IEnumerable<CompraVentaBase> _creditos;

    public ComprasVentasBase(IEnumerable<CompraVentaBase> creditos)
    {
        _creditos = creditos;
    }

    public CompraVentaBase? ByCode(int code)
    {
        return _creditos.FirstOrDefault(j => j.Code == code);
    }
}
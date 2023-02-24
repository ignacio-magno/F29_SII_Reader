namespace f29Reader.Domain.Table;

public class CompraVentaBase
{
    public int Valor { get; }

    public int Code { get; }

    public string Glosa { get; }

    public CompraVentaBase(int valor, int code, string glosa)
    {
        Valor = valor;
        Glosa = glosa;
        Code = code;
    }
}
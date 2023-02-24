using f29Reader.Domain.Table;

namespace f29Reader.Domain;

public partial class F29
{
    public long Folio { get; private set; }
    public string Rut { get; private set; }
    public DateTime Period { get; private set; }
    public Creditos Creditos { get; private set; }
    public Debitos Debitos { get; private set; }
}
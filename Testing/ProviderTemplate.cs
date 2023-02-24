namespace Testing;

public class ProviderTemplate
{
    public string rut { get; set; }
    public string folio { get; set; }
    public string periodo { get; set; }
    public List<Debito> debito { get; set; }
    public List<Credito> credito { get; set; }
}

public class Credito
{
    public string code { get; set; }
    public string glosa { get; set; }
    public string value { get; set; }
}

public class Debito
{
    public string code { get; set; }
    public string glosa { get; set; }
    public string value { get; set; }
}
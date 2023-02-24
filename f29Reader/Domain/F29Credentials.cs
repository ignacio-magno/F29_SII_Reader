using f29Reader.Textract;

namespace f29Reader.Domain;

public class F29Credentials
{
    public F29TextCoordinate Folio { get; set; }
    public F29TextCoordinate Rut { get; set; }
    public F29TextCoordinate Period { get; set; }
}
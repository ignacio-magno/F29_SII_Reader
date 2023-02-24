namespace Testing.Textract;

public abstract class Data
{
    public Data(string s, int index)
    {
        Item = s;
        IndexArray = index;
    }

    public int IndexArray { get; set; }

    public string Item { get; set; }
}

public class DebitoCodigo : Data
{
    public DebitoCodigo(string s, int index) : base(s, index)
    {
    }
}

public class DebitoGlosa : Data
{
    public DebitoGlosa(string s, int index) : base(s, index)
    {
    }
}

public class DebitoValor : Data
{
    public DebitoValor(string s, int index) : base(s, index)
    {
    }
}
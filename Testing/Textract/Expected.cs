namespace Testing.Textract;

public class Expected
{
    public string Folio { get; set; }
    public string Rut { get; set; }
    public string Periodo { get; set; }

    public DateTime PeriodoDate
    {
        get
        {
            var month = Periodo.Substring(0, 4);
            var year = Periodo.Substring(4, 2);
            return DateTime.Parse($"{month}/{year}");
        }
    }

    public Table TablaCredito = new();
    public Table TablaDebito = new();

    public class Table
    {
        public List<string> Codigo { get; set; }

        public List<int> CodigoInt => Codigo.Select(int.Parse).ToList();

        public List<string> Glosa { get; set; }
        public List<string> Valor { get; set; }

        public Table()
        {
            Codigo = new List<string>();
            Glosa = new List<string>();
            Valor = new List<string>();
        }

        public void AddItem(string codigo, string glosa, string valor)
        {
            Codigo.Add(codigo);
            Glosa.Add(glosa);
            Valor.Add(valor);
        }
    }

    public class Builder
    {
        private Expected expected;

        public Builder()
        {
            expected = new Expected();
        }

        public Builder WithFolio(string folio)
        {
            expected.Folio = folio;
            return this;
        }

        public Builder WithRut(string rut)
        {
            expected.Rut = rut;
            return this;
        }

        public Builder WithPeriodo(string periodo)
        {
            expected.Periodo = periodo;
            return this;
        }

        public Builder WithCredito(string codigo, string glosa, string valor)
        {
            expected.TablaCredito.AddItem(codigo, glosa, valor);
            return this;
        }

        public Builder WithDebito(string codigo, string glosa, string valor)
        {
            expected.TablaDebito.AddItem(codigo, glosa, valor);
            return this;
        }

        public Expected Build()
        {
            return expected;
        }
    }
}
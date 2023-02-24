using f29Reader.Domain.Table;

namespace f29Reader.Domain;

public partial class F29
{
    public class Builder
    {
        private F29 f29;

        public Builder()
        {
            f29 = new F29();
        }

        public Builder WithFolio(long folio)
        {
            f29.Folio = folio;
            return this;
        }

        public Builder WithRut(string rut)
        {
            f29.Rut = rut;
            return this;
        }

        public Builder WithPeriod(DateTime period)
        {
            f29.Period = period;
            return this;
        }

        public Builder WithCreditos(IEnumerable<CompraVentaBase> creditos)
        {
            f29.Creditos = new Creditos(creditos);
            return this;
        }

        public Builder WithDebitos(IEnumerable<CompraVentaBase> debitos)
        {
            f29.Debitos = new Debitos(debitos);
            return this;
        }

        public F29 Build()
        {
            return f29;
        }
    }
}
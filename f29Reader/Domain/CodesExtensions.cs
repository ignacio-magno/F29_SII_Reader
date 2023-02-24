namespace f29Reader.Domain;

public static class CodesExtensions
{
    public static string GetDescription(this CodesCredito code)
    {
        return code switch
        {
            CodesCredito.DebitoFacturasEmitidas => "DÉBITOS FACTURAS EMITIDAS",
            CodesCredito.TotalDebitos => "TOTAL DÉBITOS",
            CodesCredito.CreditoRec => "CRÉDITO REC. Y REINT./FACT. DEL GIRO",
            CodesCredito.CuotaIvaPostergado => "Monto cuota a pagar por IVA Postergado",
            CodesCredito.MontoIvaPostergado6O12Cuotas => "Monto de IVA postergado 6 o 12 cuotas",
            CodesCredito.MontoTotalIvaPostergado6O12Cuotas => "Monto Total IVA postergado 6 o 12 cuotas",
            CodesCredito.TotalCreditos => "TOTAL CRÉDITOS",
            CodesCredito.ImpuestoDeterminadoIva => "IMP. DETERM. IVA",
            CodesCredito.CuotaAPagarLey21207 => "Cuota a pagar por IVA Post. Ley 21.207",
            CodesCredito.TotalIvaPostergadoLey21207 => "Total IVA post. 6 o 12 cuotas Ley 21.207",
            CodesCredito.MontoPostergado => "Monto postergado pendeinte de cobro",
            CodesCredito.PpmNetoDeterminado => "PPM NETO DETERMINADO",
            CodesCredito.SubTotalImpuestoDeterminadoAdverso => "SUB TOTAL IMP. DETERMINADO ANVERSO",
            CodesCredito.TotalDeterminado => "TOTAL DETERMINADO",
            _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
        };
    }

    public static string GetDescription(this CodesDebito code) => code switch
    {
        CodesDebito.CantidadFacturasEmitidas => "CANTIDAD FACTURAS EMITIDAS",
        CodesDebito.CreditoIvaDocumentosElectronicos => "CRÉDITO IVA DOCUMENTOS ELECTRÓNICOS",
        CodesDebito.CantidadFacturasRecibidosDelGiro => "CANTIDAD FACTURAS RECIBIDAS DEL GIRO",
        CodesDebito.BaseImponible => "BASE IMPONIBLE",
        CodesDebito.TasaPpmPrimeraCategoria => "TASA PPM PRIMERA CATEGORÍA",
        CodesDebito.Retencion3PorcPrimeraCategoria => "Ret. 3% 1ra cat. Reint. prest. Tasa 0%",
        CodesDebito.RetencionLey21133SobreRentas => "Ret. Ley 21.133 sobre rentas",
        _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
    };

    public static CodesCredito Parse(this CodesCredito _, int code) => code switch
    {
        502 => CodesCredito.DebitoFacturasEmitidas,
        538 => CodesCredito.TotalDebitos,
        520 => CodesCredito.CreditoRec,
        780 => CodesCredito.CuotaIvaPostergado,
        779 => CodesCredito.MontoIvaPostergado6O12Cuotas,
        777 => CodesCredito.MontoTotalIvaPostergado6O12Cuotas,
        537 => CodesCredito.TotalCreditos,
        089 => CodesCredito.ImpuestoDeterminadoIva,
        785 => CodesCredito.CuotaAPagarLey21207,
        784 => CodesCredito.TotalIvaPostergadoLey21207,
        794 => CodesCredito.MontoPostergado,
        062 => CodesCredito.PpmNetoDeterminado,
        595 => CodesCredito.SubTotalImpuestoDeterminadoAdverso,
        547 => CodesCredito.TotalDeterminado,
        _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
    };

    public static CodesDebito Parse(this CodesDebito _, int code) => code switch
    {
        563 => CodesDebito.BaseImponible,
        115 => CodesDebito.TasaPpmPrimeraCategoria,
        503 => CodesDebito.CantidadFacturasEmitidas,
        511 => CodesDebito.CreditoIvaDocumentosElectronicos,
        519 => CodesDebito.CantidadFacturasRecibidosDelGiro,
        151 => CodesDebito.RetencionLey21133SobreRentas,
        156 => CodesDebito.Retencion3PorcPrimeraCategoria,
        _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
    };
}
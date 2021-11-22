#nullable disable

namespace NFRestAPI.Infrastructure.EntityTypes
{
    public partial class Notafiscalitens
    {
        public int Coditem { get; set; }
        public int? Codnota { get; set; }
        public int? Codpro { get; set; }
        public string Descrpro { get; set; }
        public string Unidade { get; set; }
        public double? Qtde { get; set; }
        public double? Valortotal { get; set; }
        public string Codigoprodutoexterno { get; set; }
        public double? Valorunitario { get; set; }

        public virtual NotaFiscal CodnotaNavigation { get; set; }
    }
}
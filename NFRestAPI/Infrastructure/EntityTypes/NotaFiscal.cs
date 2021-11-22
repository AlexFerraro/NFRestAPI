using System;
using System.Collections.Generic;

#nullable disable

namespace NFRestAPI.Infrastructure.EntityTypes
{
    public partial class NotaFiscal
    {
        public NotaFiscal()
        {
            Notafiscalitens = new HashSet<Notafiscalitens>();
        }

        public int Codnota { get; set; }
        public int? Codvenda { get; set; }
        public string Destinatarioremetente { get; set; }
        public DateTime? Dtemissao { get; set; }
        public DateTime? Dtsaidaentrada { get; set; }
        public int? Numnota { get; set; }
        public double? Valortotalprodutos { get; set; }
        public double? Valortotalnota { get; set; }
        public int? Transfrete { get; set; }
        public string Numerorecibo { get; set; }

        public virtual ICollection<Notafiscalitens> Notafiscalitens { get; set; }
    }
}
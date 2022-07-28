using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace currency_quote_console_version_2.Models
{
    public class DataQuoteModel
    {      
        [Name("vlr_cotacao;cod_cotacao;dat_cotacao")]
        public string VLR_COTACAO_COD_COTACAO_DAT_COTACAO { get; set; }
    }
}

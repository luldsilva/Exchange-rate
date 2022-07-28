using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace currency_quote_console_version_2.Models
{
    public class DataModel
    {
        [Name("ID_MOEDA;DATA_REF")]
        public string ID_MOEDA_REF_DATE { get; set; }
    }
}

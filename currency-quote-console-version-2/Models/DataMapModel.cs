using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace currency_quote_console_version_2.Models
{
    public class DataMapModel : ClassMap<DataModel>
    {
        public DataMapModel()
        {
            Map(m => m.ID_MOEDA_REF_DATE).Name("ID_MOEDA_REF_DATE");
        }
    }
}

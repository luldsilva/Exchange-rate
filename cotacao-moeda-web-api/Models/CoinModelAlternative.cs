using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cotacao_moeda_web_api.Models
{
    public class CoinModelAlternative
    {
        public string coin { get; set; }

        public DateTime date_begin { get; set; }

        public DateTime date_final { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using currency_quote_console_version_2.Repositories;

namespace currency_quote_console_version_2
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            RequestRepository.RunAsync().Wait();
        }
    }
}

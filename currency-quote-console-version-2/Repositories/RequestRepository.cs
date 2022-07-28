using CsvHelper;
using CsvHelper.Configuration;
using currency_quote_console_version_2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace currency_quote_console_version_2.Repositories
{
    public class RequestRepository
    {
        public static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44373/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Coin/GetItem");

                if (response.IsSuccessStatusCode)
                {  //GET

                    var Response = await response.Content.ReadAsStringAsync();

                    ReadFile(Response);
                }
            }
        }

        public static void ReadFile(string data)
        {
            List<string> listMatch = new List<string>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (var reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "DadosMoeda.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                var dataArq = csv.GetRecords<DataModel>();

                foreach (var d in dataArq)
                {
                    string[] vs = d.ID_MOEDA_REF_DATE.Split(';');

                    if (data.Contains(vs[1]))
                    {
                        listMatch.Add(d.ID_MOEDA_REF_DATE);
                    }
                }

                ReadQuoteFile(listMatch);

            }
        }
        
        public static void ReadQuoteFile(List<string> data)
        {
            List<string> listMatch = new List<string>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (var reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "DadosCotacao.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                var dataArq = csv.GetRecords<DataQuoteModel>();

                foreach (var d in dataArq)
                {
                    string[] vs = d.VLR_COTACAO_COD_COTACAO_DAT_COTACAO.Split(';');

                    foreach(var i in data)
                    {
                        string[] vsdata = i.Split(';');

                        if (data.Contains(vs[2]))
                        {
                            listMatch.Add($@"{i};{vs[2]}");
                        }
                    }
                }

                CreateFinalFile(listMatch);

            }
        }

        public static void CreateFinalFile(List<string>  listData)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            List<DataModel> data;

            using (var reader = new StreamReader("QuoteResult.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<DataMapModel>();

                data = csv.GetRecords<DataModel>().ToList();

            }

            using (var writer = new StreamWriter("QuoteResult02.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<DataMapModel>();

                csv.WriteHeader<DataModel>();
                csv.NextRecord();

                csv.WriteRecords(data);
            }
        }
    }
}

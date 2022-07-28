using cotacao_moeda_web_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cotacao_moeda_web_api.Services
{
    public interface ICoinServices
    {
        IActionResult AddCoin(List<CoinModel> coin);
    }
}

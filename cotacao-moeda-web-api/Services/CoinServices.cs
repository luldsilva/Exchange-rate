using cotacao_moeda_web_api.DataDbContext;
using cotacao_moeda_web_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cotacao_moeda_web_api.Services
{
    public class CoinServices : ControllerBase, ICoinServices
    {
        private readonly DataContext _context;

        public CoinServices(DataContext context)
        {
            _context = context;
        }

        public IActionResult AddCoin(List<CoinModel> coin)
        {
            FluentResults.Result res = new FluentResults.Result();
            foreach (CoinModel c in coin)
            {
                res = _context.AddItemInDb(c);
                if (res.IsFailed) return BadRequest(res.Errors);
            }
        
            return Ok(res.Successes);
        }

        public IEnumerable<CoinModel> GetItem()
        {
            IEnumerable<CoinModel> ListCoin = _context.Coin.ToList();

            IEnumerable<CoinModel> query = from Coin in ListCoin
                                            select Coin;
            ListCoin = query.ToList();

            return ListCoin;
        }

        public void DeleteCoin(CoinModel coin)
        {
            _context.DeleteItemInDb(coin);
        }
    }
}

using cotacao_moeda_web_api.Models;
using cotacao_moeda_web_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cotacao_moeda_web_api.Repositories
{
    public class QueueRepository
    {
        private CoinServices _coinService;

        public QueueRepository(CoinServices coinService)
        {
            _coinService = coinService;
        }

        public Queue<CoinModel> AddItemQueue(List<CoinModel> coin)
        {
            Queue<CoinModel> coins = new Queue<CoinModel>();

            foreach (CoinModel c in coin)
            {
                coins.Enqueue(c);
            }

            return coins;
        }

        public CoinModel GetItemQueue()
        {
            var testeListCoins = _coinService.GetItem();

            Queue<CoinModel> coins = new Queue<CoinModel>();

            foreach (CoinModel c in testeListCoins)
            {
                coins.Enqueue(c);
            }

            _coinService.DeleteCoin(coins.Peek());

            return coins.Dequeue();
        }
    }
}

using cotacao_moeda_web_api.Models;
using cotacao_moeda_web_api.Repositories;
using cotacao_moeda_web_api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cotacao_moeda_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        private QueueRepository _queueRepo;
        private ICoinServices _coinService;

        public CoinController(QueueRepository queueRepo, ICoinServices coinService)
        {
            _queueRepo = queueRepo;
            _coinService = coinService;
        }

        [HttpPost("AddCoin")]
        public IActionResult AddItemQueue(List<CoinModel> coin)
        {
            try
            {
                var msgReturn =  _coinService.AddCoin(coin);       

                return Ok("Item added succefully.");
            }
            catch
            {
                return BadRequest("Invalid request");
            }
        }

        [HttpGet("GetItem")]
        public IActionResult GetItemQueue()
        {
            return Ok(_queueRepo.GetItemQueue());
        }
    }
}

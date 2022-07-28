using cotacao_moeda_web_api.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cotacao_moeda_web_api.DataDbContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }

        public DbSet<CoinModel> Coin { get; set; }

        public Result AddItemInDb(CoinModel coinModel)
        {
            Coin.Add(coinModel);
            SaveChanges();
            return Result.Ok();
        }

        public void DeleteItemInDb(CoinModel coinModel)
        {
            Remove(coinModel);
            SaveChanges();
        }
    }
}

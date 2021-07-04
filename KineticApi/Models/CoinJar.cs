using KineticApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KineticApi.Models
{
    public class CoinJar : ICoinJar
    {
        public void AddCoin(ICoin coin)
        {
            Service.Add(coin);
        }
        public decimal GetTotalAmount()
        {
            return Service.ListCoin.Sum(x => x.Key);
        }
        public void Reset()
        {
            Service.Reset();
        }

    }
}
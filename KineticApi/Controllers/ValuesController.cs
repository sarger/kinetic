using KineticApi.Helper;
using KineticApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Coin = KineticApi.Models.Coin;

namespace KineticApi.Controllers
{
    public class ValuesController : ApiController
    {
        CoinJar coin = new CoinJar();
        // GET api/values
        [HttpGet]
        public decimal Get()
        {
           return coin.GetTotalAmount();
        }

        // POST api/values
        [HttpPost]
        public void Add([FromBody] Coin _coin)
        {
            coin.AddCoin(_coin);
        }


        // DELETE api/values/5
        [HttpDelete]
        public void Reset()
        {
            coin.Reset();
        }
    }
}

using KineticApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KineticApi.Helper
{
    public class Service
    {

        //Currency // volume
        private static decimal maxvolume = 42;
        private static Dictionary<decimal, decimal> cache;

        private static object cacheLock = new object();
        public static Dictionary<decimal, decimal> ListCoin
        {
            get
            {
                return Coins();

            }
        }

        private static Dictionary<decimal, decimal> Coins()
        {
            lock (cacheLock)
            {
                if (cache == null)
                {
                    cache = new Dictionary<decimal, decimal>();
                }

                return cache;
            }
        }

        public static void Add(ICoin coin)
        {
            var sum = Coins().Sum(x=> x.Key);
            if (sum >= maxvolume)
            {
                throw new Exception($"coins exced { maxvolume } , please reset coins ");
            }

            cache.Add(coin.Amount, coin.Volume);
        }

        public static void Reset()
        {
            cache = null;
        }

    }
}
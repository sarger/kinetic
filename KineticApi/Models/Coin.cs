using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KineticApi.Models
{
    public class Coin: ICoin
    {
       public decimal Amount { get; set; }
     public   decimal Volume { get; set; }
    }
}
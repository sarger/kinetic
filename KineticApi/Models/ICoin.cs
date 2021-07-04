using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KineticApi.Models
{
    public interface ICoin
    {
        decimal Amount { get; set; }
        decimal Volume { get; set; }
    }
}
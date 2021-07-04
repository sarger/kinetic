using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KineticApi.Models
{
    public interface ICoinJar
    {
        void AddCoin(ICoin coin);
        decimal GetTotalAmount();
        void Reset();
    }
}
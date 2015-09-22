﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Monastery : IRealEstate
    {
        public Monastery(decimal area, decimal price)
        {
            this.AreaSquareMetters = area;
            this.PriceDollars = price;
        }

        public decimal AreaSquareMetters { get; set; }

        public decimal PriceDollars { get; set; }
    }
}

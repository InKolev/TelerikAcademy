using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    interface IRealEstate
    {
        decimal PriceDollars { get; set; }

        decimal AreaSquareMetters { get; set; }
    }
}

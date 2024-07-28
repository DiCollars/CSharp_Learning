using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum OrderStatus : int
    {
        NotOrdered = -1,
        Ordered = 1,
        Canceled = 2,
        InDelivery = 3,
        Finished = 4
    }
}

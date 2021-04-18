using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public static class OrderStatus
    {
        public const int PreParation = 1;
        public const int Dispatching = 2;
        public const int AgentDelivary = 3;
        public const int CustomerDelivary = 4;
    }
}

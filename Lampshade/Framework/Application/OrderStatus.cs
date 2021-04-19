using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public static class OrderStatus
    {
        public const int Transaction = 1;
        public const int PreParation = 2;
        public const int Dispatching = 3;
        public const int AgentDelivary = 4;
        public const int CustomerDelivary = 5;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
   public static class PaymentMethod
    {
        public static int Online { get; private set; } = 1;
        public static int Cash { get; private set; } = 2;

    }
}

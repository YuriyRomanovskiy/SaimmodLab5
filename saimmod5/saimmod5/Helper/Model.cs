using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saimmod5.Helper
{
    class Model
    {
        public static int successRequestsCount = 0;
        public static int failRequestsCount = 0;

        public static void clear()
        {
            successRequestsCount = 0;
            failRequestsCount = 0;
        }
    }
}

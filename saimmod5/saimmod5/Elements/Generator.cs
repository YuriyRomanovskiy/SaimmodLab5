using saimmod5.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saimmod5.Elements
{
    class Generator
    {
        float lambda;
        CustomRandom randUtil;


        public Generator(float lambda)
        {
            this.lambda = lambda;
            randUtil = CustomRandom.Instance;
        }


        public float WaitTime
        {
            get;
            private set;
        }


        public void sendRequest()
        {
            WaitTime = randUtil.GetNext(lambda);
        }


    }
}

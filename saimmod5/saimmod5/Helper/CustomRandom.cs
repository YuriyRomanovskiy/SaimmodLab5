using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saimmod5.Helper
{
    class CustomRandom
    {
        static CustomRandom instance;

        Random rand = null;

        public static CustomRandom Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomRandom();
                }
                return instance;
            }
        }


        public Random Rand
        {
            get
            {
                if (rand == null)
                {
                    rand = new Random();
                }

                return rand;
            }
        }


        public float GetNext(float lambda = 0f)
        {
            float result = Convert.ToSingle(Rand.NextDouble());
            //Debug.WriteLine(result);
            return (-1.0f / lambda) * (float)Math.Log(1f - result);
        }

    }
}

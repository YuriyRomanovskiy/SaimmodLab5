using saimmod5.Enums;
using saimmod5.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saimmod5.Elements
{
    class Channel
    {
        private State state;
        private float processingTime;
        private float lambda;
        private CustomRandom randUtil = new CustomRandom();

        public Channel(float lambda)
        {
            state = State.FREE;
            this.lambda = lambda;
        }

        public State getState()
        {
            return state;
        }

        public float getProcessingTime()
        {
            return processingTime;
        }

        public void doProcessing(float time)
        {
            if (state == State.PROCESSING)
            {
                processingTime -= time;
                if (processingTime <= 0f + float.Epsilon)
                {
                    state = State.FREE;
                    processingTime = 0;

                    Model.successRequestsCount += 1;
                }
            }
        }

        public bool sendRequest()
        {
            if (state == State.FREE)
            {
                state = State.PROCESSING;
                this.processingTime = randUtil.GetNext(lambda);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

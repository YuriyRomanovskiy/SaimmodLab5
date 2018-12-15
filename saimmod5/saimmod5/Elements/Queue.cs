using saimmod5.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saimmod5.Elements
{
    class Queue
    {
        private int maxLength;
        private int length;
        private List<Channel> channels;
        private float waitTime;
        private float lambda;
        private CustomRandom randUtil = new CustomRandom();
        Generator generator = null;



        public Queue(int maxLength, float lambda, Generator generator)
        {
            this.maxLength = maxLength;
            this.lambda = lambda;
            this.generator = generator;
        }

        public void setChannels(List<Channel> channels)
        {
            this.channels = channels;
        }

        public float getWaitTime()
        {
            return waitTime;
        }

        public void doProcessing(float time)
        {
            waitTime -= time;
            if (waitTime == 0)
            {
                waitTime = 0;
            }

            foreach (Channel channel in channels)
            {
                if (length > 0 && channel.sendRequest())
                {
                    length -= 1;
                }
            }
        }

        public void sendRequest()
        {
            generator.sendRequest();
            waitTime = generator.WaitTime;

            if (length < maxLength)
            {
                bool isSendToChannel = false;

                foreach (Channel channel in channels)
                {
                    if (!isSendToChannel && channel.sendRequest())
                    {
                        isSendToChannel = true;
                    }
                }

                if (!isSendToChannel)
                {
                    length += 1;
                }
            }
            else
            {
                Model.failRequestsCount += 1;
            }
        }
    }
}

using saimmod5.Elements;
using saimmod5.Enums;
using saimmod5.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saimmod5
{
    class Manager
    {
        public event Action<String> OnResultReady;

        public void Process(float lambda = 2f, float u = 1f, int itterationsCount = 2000000)
        {
            int k = 1;
            float outputIntensity = 0f;

            while (outputIntensity < 0.95f)
            {
                Generator generator = new Generator(lambda);
                Queue queue = new Queue(3, lambda, generator);
                List<Channel> channels = new List<Channel>();
                for (int i = 0; i < k; i++)
                {
                    Channel channel = new Channel(u);
                    channels.Add(channel);
                }
                queue.setChannels(channels);

                queue.sendRequest();

                for (int j = 0; j < itterationsCount; j++)
                {
                    float minTime = queue.getWaitTime();
                    foreach (Channel channel in channels)
                    {
                        if (channel.getState() == State.PROCESSING && channel.getProcessingTime() < minTime)
                        {
                            minTime = channel.getProcessingTime();
                        }
                    }

                    foreach (Channel channel in channels)
                    {
                        channel.doProcessing(minTime);
                    }
                    queue.doProcessing(minTime);

                    if (queue.getWaitTime() <= 0f + float.Epsilon)
                    {
                        queue.sendRequest();
                    }
                }

                //Debug.WriteLine("Количество испытательных стендов: " + k + ", Вероятность отказа: " + (float)Model.failRequestsCount / (Model.successRequestsCount + Model.failRequestsCount));

                string res = "stends count: " + k + ", probability: " + (float)Model.failRequestsCount / (Model.successRequestsCount + Model.failRequestsCount);

                if (OnResultReady != null)
                {
                    OnResultReady(res);
                }

                k++;
                outputIntensity = (float)Model.successRequestsCount / (Model.successRequestsCount + Model.failRequestsCount);

                Model.clear();
            }
        }
    }
}

using System;
using System.Threading;

namespace MemoryLeak
{
    public class ShortLivedEventBusSubscriber
    {
        public static int Count;
        public string LatestMessage { get; private set; }

        public ShortLivedEventBusSubscriber(IEventPublisher publisher)
        {
            Interlocked.Increment(ref Count);
            publisher.GetEvent<string>().Subscribe(s => LatestMessage = s);
        }

        ~ShortLivedEventBusSubscriber()
        {
            Interlocked.Decrement(ref Count);
        }
    }
}
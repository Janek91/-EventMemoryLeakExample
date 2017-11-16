using System.Threading;

namespace MemoryLeak
{
    public class ShortLivedEventPublisher
    {
        public static int Count;
        private readonly IEventPublisher publisher;

        public ShortLivedEventPublisher(IEventPublisher publisher)
        {
            this.publisher = publisher;
            Interlocked.Increment(ref Count);
        }

        public void PublishSomething()
        {
            publisher.Publish("Hello world");
        }

        ~ShortLivedEventPublisher()
        {
            Interlocked.Decrement(ref Count);
        }
    }
}
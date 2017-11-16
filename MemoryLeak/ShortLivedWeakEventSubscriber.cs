using System.Threading;

namespace MemoryLeak
{
    public class ShortLivedWeakEventSubscriber
    {
        public static int Count;
        public string LatestMessage { get; private set; }

        public ShortLivedWeakEventSubscriber(WeakEventAggregator weakEventAggregator)
        {
            Interlocked.Increment(ref Count);
            weakEventAggregator.Subscribe<string>(OnMessageReceived);
        }

        private void OnMessageReceived(string s)
        {
            LatestMessage = s;
        }

        ~ShortLivedWeakEventSubscriber()
        {
            Interlocked.Decrement(ref Count);
        }
    }
}
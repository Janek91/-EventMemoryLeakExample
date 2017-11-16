using System;
using System.Threading;

namespace MemoryLeak
{
    public class ShortLivedEventRaiser
    {
        public static int Count;

        public event EventHandler OnSomething;

        public ShortLivedEventRaiser()
        {
            Interlocked.Increment(ref Count);
        }

        public void RaiseOnSomething(EventArgs e)
        {
            EventHandler handler = OnSomething;
            handler?.Invoke(this, e);
        }

        ~ShortLivedEventRaiser()
        {
            Interlocked.Decrement(ref Count);
        }
    }
}
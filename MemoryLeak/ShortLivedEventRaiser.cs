using System;
using System.Threading;
using System.Windows.Navigation;

namespace MemoryLeak
{
    public class ShortLivedEventRaiser
    {
        public static int Count;

        public event EventHandler<ReturnEventArgs<int>> OnSomething;

        public ShortLivedEventRaiser()
        {
            Interlocked.Increment(ref Count);
        }

        public void RaiseOnSomething(ReturnEventArgs<int> e)
        {
            EventHandler<ReturnEventArgs<int>> handler = OnSomething;
            handler?.Invoke(this, e);
        }

        ~ShortLivedEventRaiser()
        {
            Interlocked.Decrement(ref Count);
        }
    }
}
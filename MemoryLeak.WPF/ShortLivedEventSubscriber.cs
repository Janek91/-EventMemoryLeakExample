using System;
using System.Threading;

namespace MemoryLeak.WPF
{
    public class ShortLivedEventSubscriber
    {
        public static int Count;

        public string LatestText { get; private set; }

        public ShortLivedEventSubscriber(ViewModelBase c)
        {
            Interlocked.Increment(ref Count);
            c.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, EventArgs eventArgs)
        {
            LatestText = ((ViewModelBase)sender).Text;
        }

        ~ShortLivedEventSubscriber()
        {
            Interlocked.Decrement(ref Count);
        }
    }
}
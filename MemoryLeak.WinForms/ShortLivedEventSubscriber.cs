using System;
using System.Threading;
using System.Windows.Forms;

namespace MemoryLeak.WinForms
{
    public class ShortLivedEventSubscriber
    {
        public static int Count;

        public string LatestText { get; private set; }

        public ShortLivedEventSubscriber(Control c)
        {
            Interlocked.Increment(ref Count);
            c.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, EventArgs eventArgs)
        {
            LatestText = ((Control)sender).Text;
        }

        ~ShortLivedEventSubscriber()
        {
            Interlocked.Decrement(ref Count);
        }
    }
}
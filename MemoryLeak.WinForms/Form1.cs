using System;
using System.Windows.Forms;

namespace MemoryLeak.WinForms
{
    public partial class Form1 : Form
    {
        private int shortlivedEventRaiserCreated;
        private int shortlivedEventSubscriberCreated;
        private int shortlivedEventPublisherCreated;
        private int shortlivedEventBusSubscriberCreated;
        private int shortlivedWeakEventSubscriberCreated;
        private readonly EventPublisher publisher1;
        private readonly EventPublisher publisher2;
        private readonly WeakEventAggregator weakEventAggregator;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1;
            timer1.Start();
            OnTimerTick(this, EventArgs.Empty);
            publisher1 = new EventPublisher();
            publisher2 = new EventPublisher();
            weakEventAggregator = new WeakEventAggregator();
            //timer1.TrayLocation =new System.Drawing.Point(17, 17);
        }

        private void OnSubscribeToShortlivedObjects(object sender, EventArgs e)
        {
            int count = 10000;
            for (int n = 0; n < count; n++)
            {
                ShortLivedEventRaiser shortlived = new ShortLivedEventRaiser();
                shortlived.OnSomething += ShortlivedOnOnSomething;
            }
            shortlivedEventRaiserCreated += count;
        }

        private void ShortlivedOnOnSomething(object sender, EventArgs eventArgs)
        {
            // just to prove that there is no smoke and mirrors, our event handler will do something involving the form
            Text = "Got an event from a short-lived event raiser";
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            labelShortLived.Text = $"{shortlivedEventRaiserCreated} created, {ShortLivedEventRaiser.Count} still alive";
            labelShortLivedEventSubscribers.Text = $"{shortlivedEventSubscriberCreated} created, {ShortLivedEventSubscriber.Count} still alive";
            labelShortLivedPublishers.Text = $"{shortlivedEventPublisherCreated} created, {ShortLivedEventPublisher.Count} still alive";
            labelShortLivedSubscribers.Text = $"{shortlivedEventBusSubscriberCreated} created, {ShortLivedEventBusSubscriber.Count} still alive";
            labelShortLivedWeakSubscribers.Text = $"{shortlivedWeakEventSubscriberCreated} created, {ShortLivedWeakEventSubscriber.Count} still alive";
        }

        private void OnShortlivedEventSubscribersClick(object sender, EventArgs e)
        {
            int count = 10000;
            for (int n = 0; n < count; n++)
            {
                ShortLivedEventSubscriber shortlived2 = new ShortLivedEventSubscriber(this);
            }
            shortlivedEventSubscriberCreated += count;
        }

        private void OnForceGcClick(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void OnShortlivedEventPublishersClick(object sender, EventArgs e)
        {
            int count = 10000;
            for (int n = 0; n < count; n++)
            {
                ShortLivedEventPublisher shortlived3 = new ShortLivedEventPublisher(publisher1);
            }
            shortlivedEventPublisherCreated += count;
        }

        private void OnShortLivedEventBusSubscribersClick(object sender, EventArgs e)
        {
            int count = 10000;
            for (int n = 0; n < count; n++)
            {
                ShortLivedEventBusSubscriber shortlived4 = new ShortLivedEventBusSubscriber(publisher2);
            }
            shortlivedEventBusSubscriberCreated += count;
        }

        private void OnShortLivedWeakSubscribersClick(object sender, EventArgs e)
        {
            int count = 10000;
            for (int n = 0; n < count; n++)
            {
                ShortLivedWeakEventSubscriber shortlived5 = new ShortLivedWeakEventSubscriber(weakEventAggregator);
            }
            shortlivedWeakEventSubscriberCreated += count;
        }
    }
}

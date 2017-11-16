using System;
using System.Threading;

namespace MemoryLeak.WPF
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _shortLivedEventRaisers;

        private Timer _timer;

        public MainWindowViewModel()
        {
            ShortLivedEventRaisers = "{code}";
            ShortLivedEventSubscribers = "{code}";
            ShortLivedPublishers = "{code}";
            ShortLivedSubscribers = "{code}";
            ShortLivedWeakSubscribers = "{code}";
            _timer = new Timer(Callback, this, 0, 16);
            publisher1 = new EventPublisher();
            publisher2 = new EventPublisher();
            weakEventAggregator = new WeakEventAggregator();
        }

        private void Callback(object state)
        {
            OnTimerTick();
        }

        public string ShortLivedEventRaisers
        {
            get { return _shortLivedEventRaisers; }
            set { SetProperty(ref _shortLivedEventRaisers, value); }
        }

        private string _shortLivedEventSubscribers;

        public string ShortLivedEventSubscribers
        {
            get { return _shortLivedEventSubscribers; }
            set { SetProperty(ref _shortLivedEventSubscribers, value); }
        }

        private string _shortLivedPublishers;

        public string ShortLivedPublishers
        {
            get { return _shortLivedPublishers; }
            set { SetProperty(ref _shortLivedPublishers, value); }
        }

        private string _shortLivedSubscribers;

        public string ShortLivedSubscribers
        {
            get { return _shortLivedSubscribers; }
            set { SetProperty(ref _shortLivedSubscribers, value); }
        }

        private string _shortLivedWeakSubscribers;

        public string ShortLivedWeakSubscribers
        {
            get { return _shortLivedWeakSubscribers; }
            set { SetProperty(ref _shortLivedWeakSubscribers, value); }
        }

        private int shortlivedEventRaiserCreated;
        private int shortlivedEventSubscriberCreated;
        private int shortlivedEventPublisherCreated;
        private int shortlivedEventBusSubscriberCreated;
        private int shortlivedWeakEventSubscriberCreated;
        private readonly EventPublisher publisher1;
        private readonly EventPublisher publisher2;
        private readonly WeakEventAggregator weakEventAggregator;

        public void OnSubscribeToShortlivedObjects()
        {
            int count = 10000;
            for (int n = 0; n < count; n++)
            {
                ShortLivedEventRaiser shortlived = new ShortLivedEventRaiser();
                shortlived.OnSomething += ShortlivedOnOnSomething;
                shortlived.RaiseOnSomething(EventArgs.Empty);
                shortlivedEventRaiserCreated++;
            }
        }

        private void ShortlivedOnOnSomething(object sender, EventArgs eventArgs)
        {
            // just to prove that there is no smoke and mirrors, our event handler will do something involving the window
            Text = "Got an event from a short-lived event raiser";
        }

        private void OnTimerTick()
        {
            ShortLivedEventRaisers = $"{shortlivedEventRaiserCreated} created, {ShortLivedEventRaiser.Count} still alive";
            ShortLivedEventSubscribers = $"{shortlivedEventSubscriberCreated} created, {ShortLivedEventSubscriber.Count} still alive";
            ShortLivedPublishers = $"{shortlivedEventPublisherCreated} created, {ShortLivedEventPublisher.Count} still alive";
            ShortLivedSubscribers = $"{shortlivedEventBusSubscriberCreated} created, {ShortLivedEventBusSubscriber.Count} still alive";
            ShortLivedWeakSubscribers = $"{shortlivedWeakEventSubscriberCreated} created, {ShortLivedWeakEventSubscriber.Count} still alive";
        }

        public void OnShortlivedEventSubscribersClick()
        {
            int count = 10000;
            for (int n = 0; n < count; n++)
            {
                ShortLivedEventSubscriber shortlived2 = new ShortLivedEventSubscriber(this);
            }
            shortlivedEventSubscriberCreated += count;
        }

        public void OnForceGcClick()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public void OnShortlivedEventPublishersClick()
        {
            int count = 10000;
            for (int n = 0; n < count; n++)
            {
                ShortLivedEventPublisher shortlived3 = new ShortLivedEventPublisher(publisher1);
            }
            shortlivedEventPublisherCreated += count;
        }

        public void OnShortLivedEventBusSubscribersClick()
        {
            int count = 10000;
            for (int n = 0; n < count; n++)
            {
                ShortLivedEventBusSubscriber shortlived4 = new ShortLivedEventBusSubscriber(publisher2);
            }
            shortlivedEventBusSubscriberCreated += count;
        }

        public void OnShortLivedWeakSubscribersClick()
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


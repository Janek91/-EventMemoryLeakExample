using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reactive.Subjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemoryLeakTest
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
            timer1.Interval = 1000;
            timer1.Start();
            OnTimerTick(this, EventArgs.Empty);
            publisher1 = new EventPublisher();
            publisher2 = new EventPublisher();
            weakEventAggregator = new WeakEventAggregator();
        }

        private void OnSubscribeToShortlivedObjects(object sender, EventArgs e)
        {
            int count = 10000;
            for (int n = 0; n < count; n++)
            {
                var shortlived = new ShortLivedEventRaiser();
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
            labelShortLived.Text = String.Format("{0} created, {1} still alive", shortlivedEventRaiserCreated, ShortLivedEventRaiser.Count);
            labelShortLivedEventSubscribers.Text = String.Format("{0} created, {1} still alive", shortlivedEventSubscriberCreated, ShortLivedEventSubscriber.Count);
            labelShortLivedPublishers.Text = String.Format("{0} created, {1} still alive", shortlivedEventPublisherCreated, ShortLivedEventPublisher.Count);
            labelShortLivedSubscribers.Text = String.Format("{0} created, {1} still alive", shortlivedEventBusSubscriberCreated, ShortLivedEventBusSubscriber.Count);
            labelShortLivedWeakSubscribers.Text = String.Format("{0} created, {1} still alive", shortlivedWeakEventSubscriberCreated, ShortLivedWeakEventSubscriber.Count);
        }

        private void OnShortlivedEventSubscribersClick(object sender, EventArgs e)
        {
            int count = 10000;
            for (int n = 0; n < count; n++)
            {
                var shortlived2 = new ShortLivedEventSubscriber(this);
            }
            shortlivedEventSubscriberCreated += count;
        }

        private void OnForceGcClick(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void OnShortlivedEventPublishersClick(object sender, EventArgs e)
        {
            int count = 10000;
            for (int n = 0; n < count; n++)
            {
                var shortlived3 = new ShortLivedEventPublisher(publisher1);
            }
            shortlivedEventPublisherCreated += count;
        }

        private void OnShortLivedEventBusSubscribersClick(object sender, EventArgs e)
        {
            int count = 10000;
            for (int n = 0; n < count; n++)
            {
                var shortlived4 = new ShortLivedEventBusSubscriber(publisher2);
            }
            shortlivedEventBusSubscriberCreated += count;
        }

        private void OnShortLivedWeakSubscribersClick(object sender, EventArgs e)
        {
            int count = 10000;
            for (int n = 0; n < count; n++)
            {
                var shortlived5 = new ShortLivedWeakEventSubscriber(weakEventAggregator);
            }
            shortlivedWeakEventSubscriberCreated += count;
        }

    }

    public class ShortLivedEventRaiser
    {
        public static int Count;
        
        public event EventHandler OnSomething;

        public ShortLivedEventRaiser()
        {
            Interlocked.Increment(ref Count);
        }

        protected void RaiseOnSomething(EventArgs e)
        {
            EventHandler handler = OnSomething;
            if (handler != null) handler(this, e);
        }

        ~ShortLivedEventRaiser()
        {
            Interlocked.Decrement(ref Count);
        }
    }

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
            LatestText = ((Control) sender).Text;
        }

        ~ShortLivedEventSubscriber()
        {
            Interlocked.Decrement(ref Count);
        }
    }


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

    public interface IEventPublisher
    {
        void Publish<TEvent>(TEvent sampleEvent);
        IObservable<TEvent> GetEvent<TEvent>();
    }

    public class EventPublisher : IEventPublisher
    {
        private readonly ConcurrentDictionary<Type, object> subjects
            = new ConcurrentDictionary<Type, object>();

        public IObservable<TEvent> GetEvent<TEvent>()
        {
            var subject =
                (ISubject<TEvent>)subjects.GetOrAdd(typeof(TEvent),
                            t => new Subject<TEvent>());
            return subject.AsObservable();
        }

        public void Publish<TEvent>(TEvent sampleEvent)
        {
            object subject;
            if (subjects.TryGetValue(typeof(TEvent), out subject))
            {
                ((ISubject<TEvent>)subject)
                    .OnNext(sampleEvent);
            }
        }
    }

    public class WeakEventAggregator
    {
        class WeakAction
        {
            private WeakReference weakReference;
            public WeakAction(object action)
            {
                weakReference = new WeakReference(action);
            }

            public bool IsAlive
            {
                get { return weakReference.IsAlive; }
            }

            public void Execute<TEvent>(TEvent param)
            {
                var action = (Action<TEvent>) weakReference.Target;
                action.Invoke(param);
            }
        }

        private readonly ConcurrentDictionary<Type, List<WeakAction>> subscriptions
            = new ConcurrentDictionary<Type, List<WeakAction>>();

        public void Subscribe<TEvent>(Action<TEvent> action)
        {
            var subscribers = subscriptions.GetOrAdd(typeof (TEvent), t => new List<WeakAction>());
            subscribers.Add(new WeakAction(action));

        }

        public void Publish<TEvent>(TEvent sampleEvent)
        {
            List<WeakAction> subscribers;
            if (subscriptions.TryGetValue(typeof(TEvent), out subscribers))
            {
                subscribers.RemoveAll(x => !x.IsAlive);
                subscribers.ForEach(x => x.Execute<TEvent>(sampleEvent));
            }
        }
    }

    [TestClass]
    public class WeakAggregatorTests
    {

        [TestMethod]
        public void TestWeakAggregator()
        {
            string message1 = "x";
            string message2 = "y";
            string message3 = "z";
            
            var weakAggregator = new WeakEventAggregator();
            weakAggregator.Subscribe<string>(s => message1 = "Subscriber 1 got " + s);
            weakAggregator.Subscribe<string>(s => message2 = "Subscriber 2 got " + s);
            weakAggregator.Subscribe<DateTime>(s => message3 = "Subscriber 3 got called");
            weakAggregator.Publish("hello world");
            Assert.AreEqual("Subscriber 1 got hello world", message1);
            Assert.AreEqual("Subscriber 2 got hello world", message2);
            Assert.AreEqual("z", message3);
        }
    }
    
}

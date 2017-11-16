using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MemoryLeak
{
    public class WeakEventAggregator
    {
        private readonly ConcurrentDictionary<Type, List<WeakAction>> subscriptions
            = new ConcurrentDictionary<Type, List<WeakAction>>();

        public void Subscribe<TEvent>(Action<TEvent> action)
        {
            List<WeakAction> subscribers = subscriptions.GetOrAdd(typeof(TEvent), t => new List<WeakAction>());
            subscribers.Add(new WeakAction(action));
        }

        public void Publish<TEvent>(TEvent sampleEvent)
        {
            List<WeakAction> subscribers;
            if (subscriptions.TryGetValue(typeof(TEvent), out subscribers))
            {
                subscribers.RemoveAll(x => !x.IsAlive);
                subscribers.ForEach(x => x.Execute(sampleEvent));
            }
        }
    }
}
using System;

namespace MemoryLeak
{
    internal class WeakAction
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
            Action<TEvent> action = (Action<TEvent>)weakReference.Target;
            action.Invoke(param);
        }
    }
}
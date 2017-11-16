using ReactiveUI;
using System;
using System.Runtime.CompilerServices;

namespace MemoryLeak.WPF
{
    public class ViewModelBase : ReactiveObject
    {
        public EventHandler TextChanged;

        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                if (SetProperty(ref _text, value))
                {
                    TextChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public bool SetProperty<TRet>(ref TRet backingField, TRet newValue, [CallerMemberName] string propertyName = null)
        {
            ViewModelBase sender = this;
            return sender.SetProperty<ViewModelBase, TRet>(ref backingField, newValue, propertyName);
        }
    }
}

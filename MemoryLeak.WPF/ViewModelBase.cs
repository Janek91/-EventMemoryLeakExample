using ReactiveUI;
using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace MemoryLeak.WPF
{
    public class ViewModelBase : ReactiveObject
    {
        public EventHandler TextChanged;

        public StringBuilder TextBuilder;

        private string _text;

        public ViewModelBase()
        {
            TextBuilder = new StringBuilder();
        }

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

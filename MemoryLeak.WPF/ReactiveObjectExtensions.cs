using ReactiveUI;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MemoryLeak.WPF
{
    public static class ReactiveObjectExtensions
    {
        public static bool SetProperty<TObj, TRet>(this TObj sender, ref TRet backingField, TRet newValue, [CallerMemberName] string propertyName = null)
            where TObj : IReactiveObject
        {
            if (propertyName != null && !EqualityComparer<TRet>.Default.Equals(backingField, newValue))
            {
                sender.RaiseAndSetIfChanged(ref backingField, newValue, propertyName);
                return true;
            }
            return false;
        }
    }
}

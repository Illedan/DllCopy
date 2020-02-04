using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DllCopy.Extensions
{
    public static class PropertyChangedExtensions
    {
        public static void Set<S>(this INotifyPropertyChanged vm, ref S property, S value, PropertyChangedEventHandler propertyChanged, [CallerMemberName] string propertyName = "")
        {
            property = value;
            vm.OnPropertyChanged(propertyChanged, propertyName);
        }

        public static void OnPropertyChanged(this INotifyPropertyChanged vm, PropertyChangedEventHandler propertyChanged, string propertyName = "")
        {
            propertyChanged?.Invoke(vm, new PropertyChangedEventArgs(propertyName));
        }

        public static void OnMultiplePropertiesChanged(this INotifyPropertyChanged vm, PropertyChangedEventHandler propertyChanged, params string [] properties)
        {
            foreach(var property in properties)
            {
                propertyChanged?.Invoke(vm, new PropertyChangedEventArgs(property));
            }
        }
    }
}
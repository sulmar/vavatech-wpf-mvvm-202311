using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ViewModels;

public static class ObservableCollectionExtensions
{
    public static ObservableCollection<T> AddItemPropertyChanged<T>(this ObservableCollection<T> items,
        PropertyChangedEventHandler handler)
        where T : INotifyPropertyChanged
    {
        foreach (var item in items)
        {
            item.PropertyChanged += handler;
        }
        return items;
    }

}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ToDoV2.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            // Initialize the collection with some items
            items = new ObservableCollection<string>();
            
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        [RelayCommand]
        void Add()
        {
            //add our item
            if(!string.IsNullOrWhiteSpace(Text))
            {
                items.Add(Text);
            }

            
            Text = string.Empty;
        }

        [RelayCommand]
        void Delete(string s)
        {
           if(items.Contains(s))
            {
                items.Remove(s);
            }
        }

    }
}

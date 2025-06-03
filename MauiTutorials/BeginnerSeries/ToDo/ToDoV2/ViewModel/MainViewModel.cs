using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ToDoV2.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity;
        public MainViewModel(IConnectivity connectivity)
        {
            // Initialize the collection with some items
            items = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        [RelayCommand]
        async void Add()
        {
            if(connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                // Show an alert or message to the user about no internet connection
                await Shell.Current.DisplayAlert("No Internet", "Please check your internet connection.", "OK");
                return;
            }

            //add our item
            if (!string.IsNullOrWhiteSpace(Text))
            {
                items.Add(Text);
            }


            Text = string.Empty;
        }

        [RelayCommand]
        void Delete(string s)
        {
            if (items.Contains(s))
            {
                items.Remove(s);
            }
        }

        [RelayCommand]
        async Task Tap(string s)
        {
            // Navigate to the detail page with the selected item
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
            
        }
    }
}

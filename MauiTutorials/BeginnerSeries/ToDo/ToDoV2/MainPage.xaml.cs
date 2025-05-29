using ToDoV2.ViewModel;

namespace ToDoV2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

       
    }
}

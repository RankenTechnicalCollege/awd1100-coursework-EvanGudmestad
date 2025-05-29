using ToDoV2.ViewModel;

namespace ToDoV2;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}
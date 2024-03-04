using TodoList.ViewModel;

namespace TodoList.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
		BindingContext = new RegisterViewModel(Navigation);
	}
}
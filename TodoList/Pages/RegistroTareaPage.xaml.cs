using TodoList.ViewModel;

namespace TodoList.Pages;

public partial class RegistroTareaPage : ContentPage
{
	public RegistroTareaPage(RegistroTareaViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

}

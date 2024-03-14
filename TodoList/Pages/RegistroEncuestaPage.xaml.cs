using TodoList.ViewModel;

namespace TodoList.Pages;

public partial class RegistroEncuestaPage : ContentPage
{
    public RegistroEncuestaPage(TodoViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
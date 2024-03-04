using Microsoft.Maui.Controls;
using TodoList.ViewModel;

namespace TodoList.Pages;


public partial class TodoPage : ContentPage
{
    public TodoPage(TodoViewModel mv)
    {
        InitializeComponent();
        BindingContext = mv;
    }

    protected override void OnAppearing()
    {

        base.OnAppearing();

        TodoViewModel mViewModel = ((TodoViewModel)BindingContext);

        if (mViewModel.AgregarTareasCommand.CanExecute(null))

            mViewModel.AgregarTareasCommand.Execute(null);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }

}
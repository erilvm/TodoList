using System.ComponentModel;
using System.Windows.Input;
using TodoList.Models.Encuestas;
using TodoList.ViewModel;

namespace TodoList.Pages
{
    public partial class RegistroPreguntasPage : ContentPage
    {
        public RegistroPreguntasPage(RegistroTareaViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }

}

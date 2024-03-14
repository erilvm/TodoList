using TodoList.Pages;
using TodoList.ViewModel;

namespace TodoList
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("TodoPage", typeof(TodoPage));
            Routing.RegisterRoute("RegistroTareaPage", typeof(RegistroTareaPage));
            Routing.RegisterRoute("RegistroPreguntasPage", typeof(RegistroPreguntasPage));
            Routing.RegisterRoute("RegistroEncuestaPage", typeof(RegistroEncuestaPage));

        }
    }
}

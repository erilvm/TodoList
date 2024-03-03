using TodoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoList.Models;
using TodoList.Services;
using TodoList.Models.Encuestas;
using TodoList.Pages;

namespace TodoList.ViewModel
{
    public partial class RegistroTareaViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Tarea tarea;

        private IDataService fakeService;

        public string[] TiposTareas { get; set; } = (string[])Enum.GetNames(typeof(eTipoTarea));

        public RegistroTareaViewModel(IDataService service)
        {
            tarea = new Tarea();
            fakeService = service;
        }

        [RelayCommand]
        private void Guardar()
        {
            fakeService.AddTask(Tarea);
            Shell.Current.GoToAsync("..");
        }


        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            object value = null;
            if (query.TryGetValue("TAREA", out value))
            {
                Tarea = value as Tarea;
            }
            if (query.TryGetValue("ENCUESTA", out value))
            {
                Tarea.Encuesta = value as Encuesta;
            }
        }

        [RelayCommand]
        public void AbrirRegistroEncuesta()
        {
            Shell.Current.GoToAsync(nameof(RegistroEncuestaPage));
        }

    }
}
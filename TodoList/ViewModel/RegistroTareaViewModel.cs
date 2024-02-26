using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.ViewModel
{
    public partial class RegistroTareaViewModel : ObservableObject, IQueryAttributable
    {

        public List<string> Estado{ get; } = new List<string> { "Inicial", "Activo", "Completado", "Cancelado" };
        public List<string> TipoTarea { get; } = new List<string> { "Normal", "Encuesta", "Archivo" };
        public List<string> Prioridad { get; } = new List<string> { "Baja", "Media", "Alta" };



        //Es la propiedad 
        [ObservableProperty]
        public Tarea tarea;

        private IDataService fakeservice;


        public RegistroTareaViewModel(IDataService service)
        {
            tarea = new Tarea();
            fakeservice = service;
        }


        [RelayCommand]
        private void Guardar()
        {
            fakeservice.AddTask(Tarea);
            Shell.Current.GoToAsync("..");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("TAREA", out object value))
            {
                Tarea = value as Tarea;
            }

        }

    }
}


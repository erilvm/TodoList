
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.ViewModel
{
    public partial class MainTodoView : ObservableObject

    {
        [ObservableProperty]
        private string mensaje = "Click";

        private int count;

        public MainTodoView()
        {

        }
        [RelayCommand]
        private void Increment()
        {
            count = count + 1;
            Mensaje = "Clicks" + count;

        }

        [RelayCommand]
        private void StartApp()
        {
            Shell.Current.GoToAsync("TodoPage");
        }
    }
}

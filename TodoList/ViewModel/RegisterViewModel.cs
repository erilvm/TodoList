using Firebase.Auth;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.ViewModel
{
    internal class RegisterViewModel : INotifyPropertyChanged
    {
        private string webApiKey = "AIzaSyCyrO5kPgtWuMToM4d259K1rucOAqikGpc";

        private INavigation _navigation;
        private string email;
        private string password;

        public event PropertyChangedEventHandler? PropertyChanged;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string Password
        {
            get => password; set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }


        public Command RegisterUser { get; }


        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }


        public RegisterViewModel(INavigation navigation)
        {
            this._navigation = navigation;
            RegisterUser = new Command(RegisterUserTappedAsync);
        }

        private async void RegisterUserTappedAsync(object obj)
        {
            // Validar que se haya ingresado un correo electrónico
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Por favor, ingresa un correo electrónico", "OK");
                return;
            }

            // Validar que se haya ingresado una contraseña
            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Por favor, ingresa una contraseña", "OK");
                return;
            }

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));

                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);

                string token = auth.FirebaseToken;
                if (token != null)
                {
                    await App.Current.MainPage.DisplayAlert("Alerta", "Usuario registrado exitosamente.", "OK");
                    await this._navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alerta", $"Error al registrar al usuario: {ex.Message}", "OK");
            }
        }
    }
}

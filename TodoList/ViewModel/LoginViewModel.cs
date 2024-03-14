using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Pages;

namespace TodoList.ViewModel
{
    internal class LoginViewModel : INotifyPropertyChanged
    {
        private string webApiKey = "AIzaSyCyrO5kPgtWuMToM4d259K1rucOAqikGpc";
        private INavigation _navigation;
        private string userName;
        private string userPassword;


        public event PropertyChangedEventHandler PropertyChanged;

        public Command RegisterBtn { get; }
        public Command LoginBtn { get; }

        public string UserName
        {
            get => userName; set
            {
                userName = value;
                RaisePropertyChanged("UserName");
            }
        }
        public string UserPassword
        {
            get => userPassword; set
            {
                userPassword = value;
                RaisePropertyChanged("UserPassword");
            }
        }




        public LoginViewModel(INavigation navigation)
        {
            this._navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAsync);
        }
        private async void LoginBtnTappedAsync(object obj)
        {
            if (string.IsNullOrEmpty(UserName))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Por favor, ingresa tu correo electronico", "OK");
                return;
            }

            if (string.IsNullOrEmpty(UserPassword))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Por favor, ingresa tu contraseña.", "OK");
                return;
            }

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserName, UserPassword);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("FreshFirebaseToken", serializedContent);
                // await this._navigation.PushAsync(new TodoPage());
                await Shell.Current.GoToAsync(nameof(TodoPage));

                // Aquí muestro una alerta en lugar de enviar un SMS después de iniciar sesión correctamente
                await App.Current.MainPage.DisplayAlert("Éxito", "Inicio de sesión exitoso. ¡Bienvenido!", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                throw;
            }
        }



        private async void RegisterBtnTappedAsync(object obj)
        {
            // Navegar a la página de registro
            await this._navigation.PushAsync(new RegisterPage());

            // No se deben realizar validaciones de inicio de sesión aquí, este método es para el registro
        }
      
        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}

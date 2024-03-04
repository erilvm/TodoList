namespace TodoList
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new AppShell());
            MainPage = new NavigationPage(new MainPage());
        }
    }
}

﻿using TodoList.ViewModel;

namespace TodoList
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }


    }

}




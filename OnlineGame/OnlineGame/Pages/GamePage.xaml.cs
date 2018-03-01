﻿using OnlineGame.Service;
using OnlineGame.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineGame.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : ContentPage
	{
		public GamePage ()
		{
            BindingContext = new GameViewModel(new Navigation());
            InitializeComponent ();
        }
	}
}
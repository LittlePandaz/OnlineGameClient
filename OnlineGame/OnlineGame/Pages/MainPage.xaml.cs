using OnlineGame.Pages;
using OnlineGame.Service;
using OnlineGame.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnlineGame.Pages
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
        {
            BindingContext = new MainViewModel(new Navigation());
            InitializeComponent();
        }
	}
}

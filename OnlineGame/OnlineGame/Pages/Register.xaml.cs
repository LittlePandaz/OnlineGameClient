using OnlineGame.Service;
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
	public partial class Register : ContentPage
	{
		public Register ()
		{
            BindingContext = new RegisterViewModel(new Navigation());
			InitializeComponent ();
		}
    }
}
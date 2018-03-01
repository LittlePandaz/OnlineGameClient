using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Newtonsoft.Json;
using OnlineGame.Interfaces;
using OnlineGame.Models;
using OnlineGame.Pages;
using Xamarin.Forms;

namespace OnlineGame.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; set; }
        public ICommand SignUpCommand { get; set; }

        private string _NicknameOrEmail;

        public string NicknameOrEmail
        {
            get { return _NicknameOrEmail; }
            set
            {
                _NicknameOrEmail = value;
                OnPropertyChanged();
                (LoginCommand as Command).ChangeCanExecute();
            }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged();
                (LoginCommand as Command).ChangeCanExecute();
            }
        }

        public MainViewModel(Interfaces.INavigation navigation) : base(navigation)
        {
            LoginCommand = new Command(x => { Login(); }, y => { return !string.IsNullOrEmpty(NicknameOrEmail) && !string.IsNullOrEmpty(Password); });
            SignUpCommand = new Command(SignUp);
        }

        private async void Login()
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri($"http://localhost:53485/api/playerapi?nicknameoremail={NicknameOrEmail}&password={Password}");

                try
                {
                    HttpResponseMessage message = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
                    if(message.IsSuccessStatusCode)
                    {
                        string json = await message.Content.ReadAsStringAsync();
                        Player p = JsonConvert.DeserializeObject<Player>(json);
                        if (p != null)
                        {
                            
                            await _Navigation.Push(new GamePage());
                        }
                        else
                        {
                            await _Navigation.DisplayAlert("Error", "Wrong Credentials", "OK", "CANCEL");
                        }
                       
                    }
                }
                catch(HttpRequestException e)
                {
                    await _Navigation.DisplayAlert("Error", e.Message, "Ok", "Cancel");
                }
                catch(ArgumentNullException e)
                {
                    await _Navigation.DisplayAlert("Error", e.Message, "Ok", "Cancel");
                }
            }
        }

        private async void SignUp()
        {
             await _Navigation.PushModal(new Register());
        }
    }
}

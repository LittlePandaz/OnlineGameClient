using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using OnlineGame.Interfaces;
using OnlineGame.Models;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace OnlineGame.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        public ICommand RegisterCommand { get; set; }

        private Player _Player;

        public Player Player
        {
            get { return _Player; }
            set { _Player = value; }
        }


        private string _Nickname;

        public string Nickname
        {
            get { return _Nickname; }
            set
            {
                _Nickname = value;
                OnPropertyChanged();
                (RegisterCommand as Command).ChangeCanExecute();
            }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged();
                (RegisterCommand as Command).ChangeCanExecute();
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
                (RegisterCommand as Command).ChangeCanExecute();
            }
        }

        private string _ConfirmPassword;

        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set
            {
                _ConfirmPassword = value;
                OnPropertyChanged();
                (RegisterCommand as Command).ChangeCanExecute();
            }
        }


        public RegisterViewModel(Interfaces.INavigation navigation) : base(navigation)
        {
            _Player = new Player();
            RegisterCommand = new Command(x => { Register(); }, y => { return (!string.IsNullOrEmpty(Nickname) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword)) && (Password.Equals(ConfirmPassword)); });
        }

        private async void Register()
        {
            using (HttpClient client = new HttpClient())
            {
                Player p = new Player() { Nickname = Nickname, Email = Email.ToLower(), Password = Password };
                Uri uri = new Uri("http://localhost:53485/api/playerapi/");
                string json = JsonConvert.SerializeObject(p);

                try
                {
                    HttpResponseMessage message = await client.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
                    if(message.IsSuccessStatusCode)
                    {
                        p.Id = int.Parse(await message.Content.ReadAsStringAsync());
                        await _Navigation.PopModal();
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
    }
}

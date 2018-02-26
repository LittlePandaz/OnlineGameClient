using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using OnlineGame.Interfaces;
using OnlineGame.Pages;
using Xamarin.Forms;

namespace OnlineGame.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

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
            LoginCommand = new Command(x => { }, y => { return !string.IsNullOrEmpty(NicknameOrEmail) && !string.IsNullOrEmpty(Password); });
            RegisterCommand = new Command(SignUp);
        }

        private async void SignUp()
        {
            await _Navigation.Push(new Register());
        }
    }
}

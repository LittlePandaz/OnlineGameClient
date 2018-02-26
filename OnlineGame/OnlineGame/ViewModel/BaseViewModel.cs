using OnlineGame.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace OnlineGame.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly INavigation _Navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public BaseViewModel(INavigation navigation)
        {
            _Navigation = navigation;
        }
    }
}

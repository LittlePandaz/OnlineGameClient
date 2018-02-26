using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnlineGame.Interfaces
{
    public interface INavigation
    {
        Task Push(Page o);
        Task<Page> Pop();
        Task PushModal(Page o);
        Task<Page> PopModal();
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        void Subscribe<TObservable, TEventArgs>(TObservable obs, string topic, Action<TObservable, TEventArgs> callback);
        void Send(object sender, string topic, object result);
        void UnSubscribe<TObservable, TEventArgs>(TObservable obs, string topic);
    }
}

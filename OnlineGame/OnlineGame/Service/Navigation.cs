using OnlineGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnlineGame.Service
{
    public class Navigation : Interfaces.INavigation
    {
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task<Page> Pop()
        {
            return await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task<Page> PopModal()
        {
            return await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public async Task Push(Page o)
        {
            await Application.Current.MainPage.Navigation.PushAsync(o);
        }

        public async Task PushModal(Page o)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(o);
        }

        public void Send(object sender, string topic, object result)
        {
            MessagingCenter.Send(sender, topic, result);
        }

        public void Subscribe<TObservable, TEventArgs>(TObservable obs, string topic, Action<TObservable, TEventArgs> callback)
        {
            //MessagingCenter.Subscribe<TObservable, TEventArgs>(obs, topic, callback);
        }

        public void UnSubscribe<TObservable, TEventArgs>(TObservable obs, string topic)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using OnlineGame.Interfaces;
using OnlineGame.Models;

namespace OnlineGame.ViewModel
{
    class GameViewModel : BaseViewModel
    {
        private List<Player> _Players;

        public List<Player> Players
        {
            get { return _Players; }
            set { _Players = value; }
        }


        public GameViewModel(INavigation navigation) : base(navigation)
        {
            //_Players = navigation.
            HubConnection conn = new HubConnection("http://localhost:53485/");
            IHubProxy hub = conn.CreateHubProxy("GameHub");
            conn.Start().Wait();
            hub.Invoke("Enter", new Player() { Nickname = "Greg" });
            hub.On<List<Player>>("Test", x => 
            {
                Players = x;
            });

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGame.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

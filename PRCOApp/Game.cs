﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRCOApp
{
    public class Game
    {
        string gameGame;
        string gameGameMode;


        public Game(string theGame, string theGameMode)
        {
            gameGame = theGame;
            gameGameMode = theGameMode;
        }

        public Game()
        {
            gameGame = null;
            gameGameMode = null;
        }
    }
}

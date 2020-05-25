using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace PRCOApp
{
    public class Game
    {
        DataTable gameGame;
        DataTable gameGameMode;


        public Game(DataTable theGame, DataTable theGameMode)
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

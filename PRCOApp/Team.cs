﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PRCOApp
{
    public class Team
    {
        int teamID;
        int teamGameID;
        //populate, have a getter/setter for TeamID, team name, team gameID

        public Team(int theID, int theteamGameID)
        {
            teamID = theID;
            teamGameID = theteamGameID;
        }

        public Team()
        {
            teamID = 0;
            teamGameID = 0;
        }

        public void setTeamID(int theID)
        {
            teamID = theID;
        }

        public int getTeamID()
        {
            return teamID;
        }

        public void setteamGameID(int theGameID)
        {
            teamGameID = theGameID;
        }

        public int getGameID()
        {
            return teamGameID;
        }

    }
}

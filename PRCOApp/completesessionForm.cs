using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRCOApp
{
    public partial class completesessionForm : Form
    {
        Game runninggame;
        Team runningteam;
        string startdatetime;
        string enddatetime;
        public completesessionForm(Game selectedGame, Team selectedTeam, string startdatetime, string enddatetime)
        {
            InitializeComponent();
            this.runninggame = selectedGame;
            this.runningteam = selectedTeam;
            this.startdatetime = startdatetime;
            this.enddatetime = enddatetime;
        }

        private void completesessionForm_Load(object sender, EventArgs e)
        {
            //okay solution: dropdown to select a value, label that displays value of committed value, save button to commit to memory and submit button that sends query

            //needed new values to pull:
            //statistic types associated with specific game-mode (GAME MODE STATS, STAT TYPES, USE AN SQL JOIN?)
            
            //final result will be an insert query into game session, then
            //multiple statistics for every single statistic committed to memory

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //consider spawning a class and creating just a shitload of them?
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //THE FINAL QUERY, INSERT INTO GAMING SESSION, STATISTICS INSERTS (will need sessionID associated with it too)
            //POTENTIAL SOLUTION FOR STATS, FOR EVERY STATISTIC TYPE IN DATATABLE/COUNTER/ETC, CALL A METHOD THAT WILL INSERT INTO THE TABLE

            //insert, follwowed by select so that i can pull the sessionID(?)
            //use a unique traits to select, start+end+playerID
        }
    }
}

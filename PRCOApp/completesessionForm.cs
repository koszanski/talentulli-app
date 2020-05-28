using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRCOApp
{
    public partial class completesessionForm : Form
    {
        Game runninggame;
        Team runningteam;
        Login runninglogin;
        DataTable stattypeTable;
        string startdatetime;
        string enddatetime;
        string successfulconn;
        public completesessionForm(Game selectedGame, Team selectedTeam, Login selectedlogin, string startdatetime, string enddatetime, string connstring)
        {
            InitializeComponent();
            this.runninggame = selectedGame;
            this.runningteam = selectedTeam;
            this.startdatetime = startdatetime;
            this.enddatetime = enddatetime;
            this.runninglogin = selectedlogin;
            this.successfulconn = connstring;
        }

        private void completesessionForm_Load(object sender, EventArgs e)
        {
            string dropdownQuer = "SELECT stattype.statTypeID, stattype.statName FROM stattype INNER JOIN game_mode_stats ON stattype.statTypeID=game_mode_stats.gameStatTypeID WHERE game_mode_stats.gamemodeID = " + runninggame.getGameMode().Trim() + ";";

            MySqlConnection conn = new MySqlConnection(successfulconn);
            MySqlDataAdapter myda = new MySqlDataAdapter(dropdownQuer, conn);
            stattypeTable = new DataTable();
            myda.Fill(stattypeTable);

            stattypeDropdown.DataSource = stattypeTable.DefaultView;
            stattypeDropdown.DisplayMember = "statName";
            stattypeDropdown.BindingContext = this.BindingContext;


            //final result will be an insert query into game session, then
            //multiple statistics for every single statistic committed to memory

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //consider spawning a class and creating just a shitload of them?
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

            string sessionQuer = "INSERT INTO gaming_session (gamingSessionStart, gamingSessionEnd, gamingsessionPlayerID) VALUES ('" + startdatetime.Trim() + "', '" + enddatetime.Trim() + "', '" + runninglogin.getID().ToString().Trim() + "');";
            //THE FINAL QUERY, INSERT INTO GAMING SESSION, STATISTICS INSERTS (will need sessionID associated with it too)
            //POTENTIAL SOLUTION FOR STATS, FOR EVERY STATISTIC TYPE IN DATATABLE/COUNTER/ETC, CALL A METHOD THAT WILL INSERT INTO THE TABLE

            //insert, follwowed by select so that i can pull the sessionID(?)
            //use a unique traits to select, start+end+playerID
        }
    }
}

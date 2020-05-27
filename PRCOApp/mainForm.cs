using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//uses FontAwesome.Sharp. https://github.com/awesome-inc/FontAwesome.Sharp

namespace PRCOApp
{
    public partial class mainForm : Form
    {
        string successfulConn;
        Login currentlogin;
        Team currentTeam = new Team();
        DataTable gamemodeTable;
        DataTable teamTable;
        DataTable teamPlayerTable;
        DataTable gameTable;
        //datatable for teams?

        public mainForm(Login newlogin, string SQLConnString)
        {
            InitializeComponent();
            this.currentlogin = newlogin;
            this.successfulConn = SQLConnString;
        }


        //needed pulled sql database objects:
        //teams, potentially for verification against possible games that one can select
        //game, gamemode, dropdown before initiating a sesh

        //pull statistics types matching to game mode (AND IDEALLY CHECK AGAINST GAME)

        //session (obvious to alter)
        //stats (obvious to alter)

        //potentially: upcoming event display by pulling event?
        //announcements

        //most likely will not be implemented: checking against objective, seeing whether its met, congratulating if met


        private void homeBtn_Click(object sender, EventArgs e)
        {
            //show/hide form elements
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            //show hide form elements
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            loginLbl.Text = "Welcome, " + currentlogin.dispLoggedin() + ".";
            try
            {
                 
                string quer1 = "SELECT * FROM team_players WHERE teamPlayerID = '" + (currentlogin.getID()).ToString().Trim() + "'";

                MySqlConnection conn = new MySqlConnection(successfulConn);
                MySqlDataAdapter myda = new MySqlDataAdapter(quer1, conn);
                teamPlayerTable = new DataTable();
                myda.Fill(teamPlayerTable);

                teamDropdown.DataSource = teamPlayerTable.DefaultView;
                teamDropdown.DisplayMember = "teamID";
                teamDropdown.BindingContext = this.BindingContext;

                labelQuery();
                                           
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Something went wrong! " + ex.ToString());
            }

        }

        public void labelQuery()
        {
            int savedID = int.Parse(teamDropdown.Text);
            currentTeam.setTeamID(savedID);


            string quer2 = "SELECT * FROM team WHERE teamID = '" + currentTeam.getTeamID().ToString().Trim() + "'";
            MySqlConnection conn2 = new MySqlConnection(successfulConn);
            MySqlDataAdapter myda2 = new MySqlDataAdapter(quer2, conn2);
            teamTable = new DataTable();
            myda2.Fill(teamTable);

            string teamname = (string)teamTable.Rows[0][1];
            teamnameLbl.Text = teamname;

            int initialGameID = int.Parse(teamTable.Rows[0][2].ToString());
            currentTeam.setteamGameID(initialGameID);

            string quer3 = "SELECT * FROM game WHERE gameID = '" + currentTeam.getGameID().ToString().Trim() + "'";
            MySqlConnection conn3 = new MySqlConnection(successfulConn);
            MySqlDataAdapter myda3 = new MySqlDataAdapter(quer3, conn3);
            gameTable = new DataTable();
            myda3.Fill(gameTable);

            string gameName = (string)gameTable.Rows[0][1];
            gamenameLbl.Text = gameName;
        }
           

        private void sessionstartBtn_Click(object sender, EventArgs e)
        {
            string selectedTeam = teamDropdown.SelectedItem.ToString();
            string selectedGameMode = gamemodeDropdown.SelectedItem.ToString();

            Game newgame = new Game();
            newgame.setGameMode(selectedTeam);

            this.Hide();
            var runningsessionform = new runningsessionForm(newgame);
            runningsessionform.FormClosed += (s, args) => this.Close();
            runningsessionform.Show();

        }

        private void saveteamBtn_Click(object sender, EventArgs e)
        {
            labelQuery();

            //gamemode query

            gamemodeDropdown.Enabled = true;
            sessionstartBtn.Enabled = true;

        }
        //lookup gameid associated with team table, then lookup game name from gameid
        //lookup gamemodes associated with gameid field
    }
}

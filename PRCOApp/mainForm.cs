using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        DataTable gameTable;
        DataTable gamemodeTable;
        DataTable teamTable;
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
                teamTable = new DataTable();
                myda.Fill(teamTable);


                //lookup player/team by user ID name, drop all of the teams player is assigned to into data table, drop that into combo box somehow
                
                
                //lookup gameid associated with team table, then lookup game name from gameid
                //lookup gamemodes associated with gameid field
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Something went wrong! " + ex.ToString());
            }

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

            //commit selected team value to Team class.

            string quer2 = "SELECT * FROM ";
            MySqlConnection conn2 = new MySqlConnection(successfulConn);
            MySqlDataAdapter myda2 = new MySqlDataAdapter(quer2, conn2);
            gameTable = new DataTable();
            myda2.Fill(gameTable);
        }
        //pull contents from database into dropdown
        //CRUD functions depending on what is in the dropdown box
    }
}

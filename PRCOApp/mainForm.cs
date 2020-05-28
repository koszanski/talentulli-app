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

//uses FontAwesome.Sharp. https://www.nuget.org/packages/FontAwesome.Sharp/5.12.1
//uses MySQL.Data. https://www.nuget.org/packages/MySql.Data/8.0.20

namespace PRCOApp
{
    public partial class mainForm : Form
    {
        //predefining some public variables that get used across various methods.
        string successfulConn;
        Login currentlogin;
        Team currentTeam = new Team();
        DataTable teamTable;
        DataTable teamPlayerTable;
        DataTable gameTable;

        //a constructor is made to pass variables from the previous form over to this one, with the values being saved to public variables successfulconn and currentlogin.
        public mainForm(Login newlogin, string SQLConnString)
        {
            InitializeComponent();
            this.currentlogin = newlogin;
            this.successfulConn = SQLConnString;
        }

        public mainForm()
        {
            InitializeComponent();
        }

        
        //a home and start session button show/hide form elements for aesthetic purposes.
        //this can potentially allow acommodation of different UX elements outside of just starting a game session.
        private void homeBtn_Click(object sender, EventArgs e)
        {
            teamDropdown.Hide();
            gamenameLbl.Hide();
            saveteamBtn.Hide();
            teamnameLbl.Hide();
            gamemodeDropdown.Hide();
            sessionstartBtn.Hide();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            teamDropdown.Show();
            gamenameLbl.Show();
            saveteamBtn.Show();
            teamnameLbl.Show();
            gamemodeDropdown.Show();
            sessionstartBtn.Show();

            initQuery();
        }

        //username of the current person logged in is displayed as feedback in a form.
        private void mainForm_Load(object sender, EventArgs e)
        {
            loginLbl.Text = "Welcome, " + currentlogin.dispLoggedin() + ".";
           
        }

        //an initial query that is run every time the start button to show the start sesion form is pressed.
        //this is because this cannot be loaded on form_load, as form items pertaining to this are hidden by default.
        public void initQuery()
        {
            try
            {
                //the compound team_players table is looked up on the basis of the logged in player to discern what teams he is in.
                string quer1 = "SELECT * FROM team_players WHERE teamPlayerID = '" + (currentlogin.getID()).ToString().Trim() + "'";

                MySqlConnection conn = new MySqlConnection(successfulConn);
                MySqlDataAdapter myda = new MySqlDataAdapter(quer1, conn);
                teamPlayerTable = new DataTable();
                myda.Fill(teamPlayerTable);

                //the datatable is then projected onto the dropdown/combobox for team selection.
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

        //a query that is referred to multiple times to feed information into labels on the form.
        public void labelQuery()
        {
            try
            {
                //the currently selected teamID from the dropdown is saved to a team object.
                int savedID = int.Parse(teamDropdown.Text);
                currentTeam.setTeamID(savedID);

                //a query is ran, calling a getter within the class method to get a parameter of the object.
                //this simply puts the current team into a datatable...
                string quer2 = "SELECT * FROM team WHERE teamID = '" + currentTeam.getTeamID().ToString().Trim() + "'";
                MySqlConnection conn2 = new MySqlConnection(successfulConn);
                MySqlDataAdapter myda2 = new MySqlDataAdapter(quer2, conn2);
                teamTable = new DataTable();
                myda2.Fill(teamTable);
                //...so that the name of the team can be pulled from an adjacent column and appended to a label.
                string teamname = (string)teamTable.Rows[0][1];
                teamnameLbl.Text = teamname;

                //similarly the int for the associated gameID is pulled from this same team datatable.
                int initialGameID = int.Parse(teamTable.Rows[0][2].ToString());
                currentTeam.setteamGameID(initialGameID);

                //a query is ran to find the name of the game and then added to a string value to be printed onto a label.
                string quer3 = "SELECT * FROM game WHERE gameID = '" + currentTeam.getGameID().ToString().Trim() + "'";
                MySqlConnection conn3 = new MySqlConnection(successfulConn);
                MySqlDataAdapter myda3 = new MySqlDataAdapter(quer3, conn3);
                gameTable = new DataTable();
                myda3.Fill(gameTable);

                string gameName = (string)gameTable.Rows[0][1];
                gamenameLbl.Text = gameName;
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Something went wrong! " + ex.ToString());
            }          
        }
           
        //to move on, the selected game mode is 
        private void sessionstartBtn_Click(object sender, EventArgs e)
        {
            string selectedGameMode = gamemodeDropdown.Text;

            Game newgame = new Game();
            newgame.setGameMode(selectedGameMode);

            this.Hide();
            var runningsessionform = new runningsessionForm(newgame, currentTeam, currentlogin, successfulConn);
            runningsessionform.FormClosed += (s, args) => this.Close();
            runningsessionform.Show();

        }

        private void saveteamBtn_Click(object sender, EventArgs e)
        {
            labelQuery();

            //similarly as above, the current game id is used to look up related gamemodes appropriate to that game and placed in a dropdown/combobox for the user to select.
            try
            {
                string quer4 = "SELECT * FROM game_mode WHERE gameID = '" + currentTeam.getGameID().ToString().Trim() + "'";
                MySqlConnection conn4 = new MySqlConnection(successfulConn);
                MySqlDataAdapter myda4 = new MySqlDataAdapter(quer4, conn4);
                DataTable gamemodeTable = new DataTable();
                myda4.Fill(gamemodeTable);

                gamemodeDropdown.DataSource = gamemodeTable.DefaultView;
                gamemodeDropdown.DisplayMember = "gamemodeName";
                gamemodeDropdown.BindingContext = this.BindingContext;

                //to prevent premature access or errors, the boxes for selecting game-mode are initially grayed out, enabled once a team is selected.
                gamemodeDropdown.Enabled = true;
                sessionstartBtn.Enabled = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Something went wrong! " + ex.ToString());
            }
            

        }
    }
}

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

        //potentially: upcoming event display by pulling event?
        //announcements

        //most likely will not be implemented: checking against objective, seeing whether its met, congratulating if met


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

        private void mainForm_Load(object sender, EventArgs e)
        {
            loginLbl.Text = "Welcome, " + currentlogin.dispLoggedin() + ".";
            

        }

        public void initQuery()
        {
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
            try
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

            catch (MySqlException ex)
            {
                MessageBox.Show("Something went wrong! " + ex.ToString());
            }          
        }
           

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

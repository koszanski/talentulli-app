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
using System.Data.SqlClient;
using MySqlX.XDevAPI;

//uses MySQL.Data. https://www.nuget.org/packages/MySql.Data/8.0.20

//this is the "final" submission form that is designed to aggregate all existing data, let the user populate the statistics that he achieved in a game,
//and then post it to the database along with his session.

namespace PRCOApp
{
    public partial class completesessionForm : Form
    {
        Game runninggame;
        Login runninglogin;
        DataTable statTable;
        string startdatetime;
        string enddatetime;
        string successfulconn;
        public completesessionForm(Game selectedGame,  Login selectedlogin, string startdatetime, string enddatetime, string connstring)
        {
            InitializeComponent();
            this.runninggame = selectedGame;
            this.startdatetime = startdatetime;
            this.enddatetime = enddatetime;
            this.runninglogin = selectedlogin;
            this.successfulconn = connstring;
        }

        private void completesessionForm_Load(object sender, EventArgs e)
        {
            try
            {
                //a select with multiple JOINS is used here to narrow down the stat-types belonging to a specific game mode, and by extension, specific game, stattype, etc.
                string dropdownQuer = "SELECT stattype.statTypeID, stattype.statName FROM stattype INNER JOIN game_mode_stats ON stattype.statTypeID=game_mode_stats.gameStatTypeID INNER JOIN game_mode ON game_mode_stats.gamemodeID=game_mode.gamemodeID WHERE game_mode.gamemodeName = '" + runninggame.getGameMode().Trim() + "';";

                MySqlConnection conn = new MySqlConnection(successfulconn);
                MySqlDataAdapter myda = new MySqlDataAdapter(dropdownQuer, conn);
                statTable = new DataTable();
                myda.Fill(statTable);

                //a column is added to a newly generated data table and a columns for the values themselves of the statistics are added.
                //a dropdown now contains the names of the statistics types
                statTable.Columns.Add("statValue", typeof(Int32));

                stattypeDropdown.DataSource = statTable.DefaultView;
                stattypeDropdown.DisplayMember = "statName";
                stattypeDropdown.BindingContext = this.BindingContext;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Something went wrong! " + ex.ToString());
            }
           
        }

        //a row data type is created at the location of the statistic type, however said row already exists, merely adding the chosen value for that stat from the textbox on the form.
        //this is then reflected on a label on the form.
        private void saveBtn_Click(object sender, EventArgs e)
        {
            DataRow statrow = statTable.Rows[int.Parse(stattypeDropdown.SelectedIndex.ToString())];
            statrow[2] = desiredvalTxt.Text;
            currentvalTxt.Text = statrow[2].ToString();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //first, known session parameters, such as timestamp and player ID are used to insert a query in the database.
                string sessionQuer = "INSERT INTO gaming_session (gamingSessionStart, gamingSessionEnd, gamingsessionPlayerID) VALUES ('" + startdatetime.Trim() + "', '" + enddatetime.Trim() + "', '" + runninglogin.getID().ToString().Trim() + "');";
                MySqlConnection conn = new MySqlConnection(successfulconn);
                MySqlCommand submissioncommand = new MySqlCommand(sessionQuer, conn);
                submissioncommand.ExecuteNonQuery();


                //these same parameters are used again to search for the just-created session entry.
                string selectQuer = "SELECT * FROM gaming_session WHERE gamingSessionStart='" + startdatetime.Trim() + "' AND gamingSessionEnd='" + enddatetime.Trim() + "' AND gamingsessionPlayerID='" + runninglogin.getID().ToString().Trim() + "';";
                MySqlConnection conn2 = new MySqlConnection(successfulconn);
                MySqlDataAdapter myda = new MySqlDataAdapter(selectQuer, conn2);
                DataTable selectionTable = new DataTable();
                myda.Fill(selectionTable);

                //datatable for aformentioned search is used to find the primary key ID for the session.
                //the amount of rows for the statistics type table is also counted, with an integer "i" that serves as a counter is initialised.
                string sessionID = selectionTable.Rows[0].Field<string>(0);
                int rowamount = statTable.Rows.Count;
                int i = 0;


                //as the row amount of statistic types should be the same as the amount of stats per session, its used as a reference to a while loop with a counter for i that increments.
                //during the while loop, a query is inserted for every statistic created in the statTable that also houses stattypes.
                //said query contains the session id, the stattypeid, and it's value defined earlier by the player. after the loop ends, a quit to main menu is called.
                while (i != rowamount)
                {
                    string submitQuer = "INSERT INTO statistic (statSessionID, statTypeID, statValue) VALUES ('" + sessionID + "', '" + statTable.Rows[i][0] + "', '" + statTable.Rows[i][2] + "');";
                    MySqlConnection connfinal = new MySqlConnection(successfulconn);
                    MySqlCommand finalsubmitcommand = new MySqlCommand(submitQuer, connfinal);
                    finalsubmitcommand.ExecuteNonQuery();
                    i++;
                }
                MessageBox.Show("Stat upload is done.");
                returntoMain();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Something went wrong! " + ex.ToString());
            }
            
        }

        //similarly as the save button, however the value in the textbox is not appended. only are the contents of the row read and the label changes.
        
        private void stattypeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow statrow = statTable.Rows[int.Parse(stattypeDropdown.SelectedIndex.ToString())];
            currentvalTxt.Text = statrow[2].ToString();
        }
        //a method to simply return to the landing page/main menu.
        public void returntoMain()
        {
            this.Hide();
            var mainForm = new mainForm();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            returntoMain();
        }
    }
}

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
                string dropdownQuer = "SELECT stattype.statTypeID, stattype.statName FROM stattype INNER JOIN game_mode_stats ON stattype.statTypeID=game_mode_stats.gameStatTypeID INNER JOIN game_mode ON game_mode_stats.gamemodeID=game_mode.gamemodeID WHERE game_mode.gamemodeName = '" + runninggame.getGameMode().Trim() + "';";

                MySqlConnection conn = new MySqlConnection(successfulconn);
                MySqlDataAdapter myda = new MySqlDataAdapter(dropdownQuer, conn);
                statTable = new DataTable();
                myda.Fill(statTable);

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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            DataRow statrow = statTable.Rows[int.Parse(stattypeDropdown.SelectedIndex.ToString())];
            statrow[2] = desiredvalTxt.Text;
            currentvalTxt.Text = statrow[2].ToString();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

            string sessionQuer = "INSERT INTO gaming_session (gamingSessionStart, gamingSessionEnd, gamingsessionPlayerID) VALUES ('" + startdatetime.Trim() + "', '" + enddatetime.Trim() + "', '" + runninglogin.getID().ToString().Trim() + "');";
            MySqlConnection conn = new MySqlConnection(successfulconn);
            MySqlCommand submissioncommand = new MySqlCommand(sessionQuer, conn);
            submissioncommand.ExecuteNonQuery();

            string selectQuer = "SELECT * FROM gaming_session WHERE gamingSessionStart='" + startdatetime.Trim() + "' AND gamingSessionEnd='" + enddatetime.Trim() + "' AND gamingsessionPlayerID='" + runninglogin.getID().ToString().Trim() + "';";
            MySqlConnection conn2 = new MySqlConnection(successfulconn);
            MySqlDataAdapter myda = new MySqlDataAdapter(selectQuer, conn2);
            DataTable selectionTable = new DataTable();
            myda.Fill(selectionTable);

            string sessionID = selectionTable.Rows[0].Field<string>(0);
            int rowamount = selectionTable.Rows.Count;
            int i = 0;

            while (i != rowamount)
            {
                string submitQuer = "INSERT INTO statistic (statSessionID, statTypeID, statValue) VALUES ('" + sessionID + "', '" +  + "', '";
                MySqlConnection connfinal = new MySqlConnection(successfulconn);
                MySqlCommand finalsubmitcommand = new MySqlCommand(submitQuer, connfinal);
                finalsubmitcommand.ExecuteNonQuery();
                i++;
            }

            //THE FINAL QUERY, INSERT INTO GAMING SESSION, STATISTICS INSERTS (will need sessionID associated with it too)
            //POTENTIAL SOLUTION FOR STATS, FOR EVERY STATISTIC TYPE IN DATATABLE/COUNTER/ETC, CALL A METHOD THAT WILL INSERT INTO THE TABLE

            //insert, follwowed by select so that i can pull the sessionID(?)
            //use a unique traits to select, start+end+playerID
        }

        private void stattypeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow statrow = statTable.Rows[int.Parse(stattypeDropdown.SelectedIndex.ToString())];
            currentvalTxt.Text = statrow[2].ToString();
        }

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

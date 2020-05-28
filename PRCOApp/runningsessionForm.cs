using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//this is a form to provide feedback to the user of the app that a game session is in progress, where one would usually minimise this window until the game session is concluded and manually stopped.
//the session takes timestamps of the beginning and end of the session and passes it onto the final form where a game session and statistics are submitted.

namespace PRCOApp
{
    public partial class runningsessionForm : Form
    {
        Login runninglogin;
        Game runninggame;
        string startDateTimeSQLForm;
        string successfulconn;

        //a datetime and integer value is created exclusively for the time elapsed label.
        int i = 1;
        DateTime ticker = new DateTime();

        //similarly as the previous form, more values are passed to this one via a constructor.
        public runningsessionForm(Game selectedGame, Login selectedLogin, string connstring)
        {
            InitializeComponent();
            this.runninggame = selectedGame;
            this.runninglogin = selectedLogin;
            this.successfulconn = connstring;
        }

        //a timer is enabled, and a snapshot of the current time is taken and parsed into a string in an appropriate format for MySQL.
        //this snapshot is taken for the session start timestamp.
        private void runningsessionForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            DateTime startDateTime = DateTime.Now;
            startDateTimeSQLForm = startDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        //once the "conclude session" button is pressed, timer stops, another snapshot is taken.
        //these two values along with others previously carried across from other forms are parsed into the "complete session" form
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            DateTime endDateTime = DateTime.Now;
            string endDateTimeSQLForm = endDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            this.Hide();
            var completesessionForm = new completesessionForm(runninggame, runninglogin, startDateTimeSQLForm, endDateTimeSQLForm, successfulconn);
            completesessionForm.FormClosed += (s, args) => this.Close();
            completesessionForm.Show();
        }

        //the timer label text is incremented every tick of the timer by one second, and the label is explicitly formatted as shown below.
        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLbl.Text = ticker.AddSeconds(i++).ToString("HH:mm:ss");
        }
    }
}

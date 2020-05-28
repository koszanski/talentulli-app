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
    public partial class runningsessionForm : Form
    {
        Login runninglogin;
        Game runninggame;
        Team runningteam;
        string startDateTimeSQLForm;
        string successfulconn;

        int i = 1;
        DateTime ticker = new DateTime();
        //timer value
        public runningsessionForm(Game selectedGame, Team selectedTeam, Login selectedLogin, string connstring)
        {
            InitializeComponent();
            this.runninggame = selectedGame;
            this.runningteam = selectedTeam;
            this.runninglogin = selectedLogin;
            this.successfulconn = connstring;
        }

        private void runningsessionForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            DateTime startDateTime = DateTime.Now;
            startDateTimeSQLForm = startDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            DateTime endDateTime = DateTime.Now;
            string endDateTimeSQLForm = endDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            this.Hide();
            var completesessionForm = new completesessionForm(runninggame, runningteam, runninglogin, startDateTimeSQLForm, endDateTimeSQLForm, successfulconn);
            completesessionForm.FormClosed += (s, args) => this.Close();
            completesessionForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLbl.Text = ticker.AddSeconds(i++).ToString("HH:mm:ss");
        }
    }
}

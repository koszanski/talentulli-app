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
        //currently logged in user(?)
        Game currentgame; //and gamemode
        //team
        //timer value
        public runningsessionForm(Game selectedGame)
        {
            InitializeComponent();
            this.currentgame = selectedGame;
        }

        private void runningsessionForm_Load(object sender, EventArgs e)
        {
            //ascending timer and stop button, later pass the time value into the next form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //relatively simple, pass values given from previous forms along with the timestamp

        }
    }
}

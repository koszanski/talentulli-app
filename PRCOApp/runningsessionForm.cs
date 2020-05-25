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
        Game currentgame;
        public runningsessionForm(Game selectedGame)
        {
            InitializeComponent();
            this.currentgame = selectedGame;
        }

        private void runningsessionForm_Load(object sender, EventArgs e)
        {
            //ascending timer and stop button, later pass the time value into the next form
        }
    }
}

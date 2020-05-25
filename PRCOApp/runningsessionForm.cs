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
        public runningsessionForm(Game selectedGame)
        {
            InitializeComponent();
        }

        private void runningsessionForm_Load(object sender, EventArgs e)
        {
            //ascending timer and stop button, later pass the time value into the next form
        }
    }
}

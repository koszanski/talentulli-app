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
    public partial class completesessionForm : Form
    {
        public completesessionForm()
        {
            InitializeComponent();
        }

        private void completesessionForm_Load(object sender, EventArgs e)
        {
            //okay solution: dropdown to select a value, label that displays value of committed value, save button to commit to memory and submit button that sends query

            //needed new values to pull:
            //statistic types associated with specific game-mode
            
            //final result will be an insert query into game session, then
            //multiple statistics for every single one committed to memory

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

        }
    }
}

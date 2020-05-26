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
            //IMPORTANT: generate a textbox foreach value??
            //shitty solution: have a big ass amount of textboxes, show/hide depending on 
            //one textbox, have it cycle through each value?

            //okay solution: dropdown to select a value, label that displays value of committed value, save button and submit button that sends query

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            //initial loading of sql table, maybe shove it into an array and do a foreach?
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //draggable panel
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //submit 
            //try connection, if it works, go to new form and carry the session thing
        }


        //pull contents from database into dropdown
        //CRUD functions depending on what is in the dropdown box

        //add flat button to quit
    }
}

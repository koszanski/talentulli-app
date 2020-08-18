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
    public partial class ipPopup : Form
    {
        public ipPopup()
        {
            InitializeComponent();
        }

        private void ipPopup_Load(object sender, EventArgs e)
        {

        }

        private void ipSubmit_Click(object sender, EventArgs e)
        {
            string theIP = iptxtBox.Text;

            this.Hide();
            var loginform = new loginForm(theIP);
            loginform.FormClosed += (s, args) => this.Close();
            loginform.Show();
        }
    }
}

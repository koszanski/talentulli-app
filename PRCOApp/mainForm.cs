using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//uses FontAwesome.Sharp. https://github.com/awesome-inc/FontAwesome.Sharp

namespace PRCOApp
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }


        //needed pulled sql database objects:
        //users, for login
        //teams, potentially for verification against possible games that one can select
        //game, gamemode, dropdown before initiating a sesh

        //pull statistics types matching to game mode (AND IDEALLY CHECK AGAINST GAME)

        //session (obvious to alter)
        //stats (obvious to alter)

        //potentially: upcoming event display by pulling event?
        //announcements

        //most likely will not be implemented: checking against objective, seeing whether its met, congratulating if met


        private void homeBtn_Click(object sender, EventArgs e)
        {
            //show/hide form elements
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            //show hide form elements
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            //load appropriate tables into background, check ERD
        }
        //pull contents from database into dropdown
        //CRUD functions depending on what is in the dropdown box
    }
}

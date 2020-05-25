using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        string SQLConnString = "Server=localhost;Database=esportorgdb;User id=root;Password=;";
        //potentially have an option to modify this string and designate a specific server?
        private void loginForm_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLConnString);

            try
            {
                conn.Open();
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Connection has failed! " + ex.ToString());
                //close app
            }

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {


            try
            {
                String theLogin = loginTextBox.Text;
                String thePassword = passwordTextBox.Text;


                this.Hide();
                var mainform = new mainForm();
                mainform.FormClosed += (s, args) => this.Close();
                mainform.Show();
                
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Something went wrong! " + ex.ToString());
            }
            //pull values from textbox into a variable
            //submit 
            //try connection again, foreach statement, iterate through login table, followed by password table
            //if it works, go to new form and carry the credentials over
        }


    }
}

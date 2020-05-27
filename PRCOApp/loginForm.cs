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
                MessageBox.Show("Connection successful.");
                conn.Close();
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Connection has failed! " + ex.ToString());
                Application.Exit();
            }

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {


            try
            {
                String theLogin = loginTextBox.Text;
                String thePassword = passwordTextBox.Text;
                string quer = "SELECT * FROM user WHERE userLogin = '" + theLogin.Trim() + "' AND userPass = '" + thePassword.Trim() + "'";

                MySqlConnection conn = new MySqlConnection(SQLConnString);
                MySqlDataAdapter myda = new MySqlDataAdapter(quer, conn);
                DataTable dbtbl = new DataTable();
                myda.Fill(dbtbl);

                if (dbtbl.Rows.Count == 1)
                {
                    int theID = dbtbl.Rows[0].Field<int>(0);
                    Login newlogin = new Login(theID, theLogin, thePassword);

                    this.Hide();
                    var mainform = new mainForm(newlogin, SQLConnString);
                    mainform.FormClosed += (s, args) => this.Close();
                    mainform.Show();
                }

                else
                {
                    MessageBox.Show("Error! Username/password mismatch.");
                }
                
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Something went wrong! " + ex.ToString());
            }
        }


    }
}

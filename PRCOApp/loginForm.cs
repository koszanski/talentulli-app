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

//uses MySQL.Data. https://www.nuget.org/packages/MySql.Data/8.0.20

namespace PRCOApp
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }


        //static connection string baked into sourcecode pointing towards internal SQL server.
        //slightly disadvantageous as the only way to change server IP, database name, etc. is to recompile from source with another connection string.
        //however since the source is available, this probably will not be an issue for organisation administrators.
        string SQLConnString = "Server=localhost;Database=esportorgdb;User id=root;Password=;";

        //upon load of the form, a quick connection is attempted just to see if it's possible to interface with the db.
        //a try-catch is used for sql error handling
        private void loginForm_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLConnString);

            try
            {
                conn.Open();
                MessageBox.Show("Connection successful.");
                conn.Close();
            }
            //application gives a MySQL error message via a messagebox and exits upon affirmation.
            catch (MySqlException ex)
            {
                MessageBox.Show("Connection has failed! " + ex.ToString());
                Application.Exit();
            }

        }
        //upon clicking, the procedure for logging in is initiated.
        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //a SELECT query on the user table is ran with the contents of the textboxes for input.
                String theLogin = loginTextBox.Text;
                String thePassword = passwordTextBox.Text;
                string quer = "SELECT * FROM user WHERE userLogin = '" + theLogin.Trim() + "' AND userPass = '" + thePassword.Trim() + "'";

                //a connection is started, a data adapter is created using the query parameter, the adapter then fills a created datatable with the queried table.
                MySqlConnection conn = new MySqlConnection(SQLConnString);
                MySqlDataAdapter myda = new MySqlDataAdapter(quer, conn);
                DataTable dbtbl = new DataTable();
                myda.Fill(dbtbl);

                //if the aformentioned query returns a player that matches with the login and password, login is carried out.
                //the ID, the login and the password is passed into a "login" class object, and the login is passed along with the connection string to the main form.
                if (dbtbl.Rows.Count == 1)
                {
                    int theID = dbtbl.Rows[0].Field<int>(0);
                    Login newlogin = new Login(theID, theLogin, thePassword);

                    this.Hide();
                    var mainform = new mainForm(newlogin, SQLConnString);
                    mainform.FormClosed += (s, args) => this.Close();
                    mainform.Show();
                }
                //if a username/password doesn't match, a warning appears.
                else
                {
                    MessageBox.Show("Error! Username/password mismatch.");
                }
                
            }
            //if there's an SQL problem during login, an error appears.
            catch (MySqlException ex)
            {
                MessageBox.Show("Something went wrong! " + ex.ToString());
            }
        }


    }
}

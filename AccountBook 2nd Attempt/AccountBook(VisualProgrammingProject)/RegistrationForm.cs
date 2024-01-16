using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AccountBook_VisualProgrammingProject_
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextbox.Text;
            string conformPass = CPasswordtextbox.Text;
            if (password == conformPass)
            {
                string query = ("insert into LoginInfo (name, password) values ('" + email + "', '" + password + "')");
                string connectionstring = ("Data Source= DESKTOP-97SJ17M; Initial Catalog= AccountBook; Integrated Security= True;");
                using (SqlConnection Con = new SqlConnection(connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand(query, Con)) 
                    {
                        Con.Open();
                        cmd.ExecuteNonQuery();
                        Con.Close();

                    }
                    MessageBox.Show("You are Registered Succesfully");
                }
            }
            else 
            { MessageBox.Show("Your Password Didnot Matched"); }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            LoginForm lgform = new LoginForm();
            this.Hide();
            lgform.Show();

        }
    }
}

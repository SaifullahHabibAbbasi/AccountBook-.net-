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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            if (AdminBtn.Text == "Admin")
            {
                AdminBtn.BackColor = Color.FromArgb(128, 64, 0);
                label1.Text = "Admin Login";
                AdminBtn.Text = "Employee";
            }
            else
            {
                AdminBtn.BackColor = Color.FromArgb(130, 67, 0);
                AdminBtn.Text = "Admin";
                label1.Text = "Employee Login";
            }

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection LoginConnection = new SqlConnection("Data Source = DESKTOP-97SJ17M; Initial Catalog= AccountBook; Integrated Security=True;"))
            {
                string Email = EmailTextBox.Text;
                string Password = PasswordTextbox.Text;
                string DataQuery = ("select * from LoginInfo where name =@Email and password=@password");
                SqlDataAdapter dataAdapter = new SqlDataAdapter(DataQuery, LoginConnection);
                dataAdapter.SelectCommand.Parameters.Add("@Email", Email);
                dataAdapter.SelectCommand.Parameters.Add("@Password", Password);

                DataTable dataTable1 = new DataTable();
                dataAdapter.Fill(dataTable1);
                if (dataTable1.Rows.Count > 0)
                {
                    AccountBook Ab = new AccountBook();
                    this.Hide();
                    Ab.Show();
                }
                else { MessageBox.Show("Your Credetials are Wrong"); }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            RegistrationForm RgForm = new RegistrationForm();
            this.Hide();
            RgForm.Show();
        }
    }
}

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
    public partial class AccountBook : Form
    {
        string ConnectionString = ("Data Source=DESKTOP-97SJ17M; Initial Catalog= AccountBook; Integrated Security= True;");

        public AccountBook()
        {
            InitializeComponent();
        }

        private void ChangeButtonColorOnClick()
        {
            //homeBtn.BackColor = Color.FromArgb(128, 64, 0);
            homeBtn.BackColor = Color.White;
            SaleCatbtn.BackColor = Color.White;
            GatewaysaleBtn.BackColor = Color.White;
            ExpenseBtn.BackColor = Color.White;
            OutstandingBillsBtn.BackColor = Color.White;
            OutstandingRecBtn.BackColor = Color.White;
            DrawingBtn.BackColor = Color.White;
            DiscountBtn.BackColor = Color.White;

        }
        //function to execute sql query
        private void ExecuteSqlQuery(string query)
        {
           
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the SQL command
                        command.ExecuteNonQuery();
                        MessageBox.Show("Query executed successfully!");
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        //functiom to get data from data base using adpaters
        private DataTable GetData(string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        // Fill the DataTable with data from the database
                        
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return dataTable;
        }
        private void homeBtn_Click(object sender, EventArgs e)
        {
            ChangeButtonColorOnClick();
            homeBtn.BackColor = Color.FromArgb(192, 64, 0);
            HomePanel.Visible = true;
            HomePanel.BringToFront();


        }

        private void SaleCatbtn_Click(object sender, EventArgs e)
        {
            ChangeButtonColorOnClick();
            SaleCatbtn.BackColor = Color.FromArgb(192, 64, 0);
            CategorySalePanel.BringToFront();
            CategorySalePanel.Visible = true;
        }

        private void GatewaysaleBtn_Click(object sender, EventArgs e)
        {
            ChangeButtonColorOnClick();
            GatewaysaleBtn.BackColor = Color.FromArgb(192, 64, 0);
        }

        private void ExpenseBtn_Click(object sender, EventArgs e)
        {
            ChangeButtonColorOnClick();
            ExpenseBtn.BackColor = Color.FromArgb(192, 64, 0);
        }

        private void OutstandingBillsBtn_Click(object sender, EventArgs e)
        {
            ChangeButtonColorOnClick();
            OutstandingBillsBtn.BackColor = Color.FromArgb(192, 64, 0);
        }

        private void OutstandingRecBtn_Click(object sender, EventArgs e)
        {
            ChangeButtonColorOnClick();
            OutstandingRecBtn.BackColor = Color.FromArgb(192, 64, 0);
        }

        private void DrawingBtn_Click(object sender, EventArgs e)
        {
            ChangeButtonColorOnClick();
            DrawingBtn.BackColor = Color.FromArgb(192, 64, 0);
        }

        private void DiscountBtn_Click(object sender, EventArgs e)
        {
            ChangeButtonColorOnClick();
            DiscountBtn.BackColor = Color.FromArgb(192, 64, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeButtonColorOnClick();
            HomePanel.Visible = false;
            CategorySalePanel.Visible = false;
            LOGOPANEL.Visible = true;
            LOGOPANEL.BringToFront();
        }

        private void AddBtn_catsale_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDate = dateTimePicker_catsale.Value.Date;
                Double Amount = double.Parse(Saletextbox_Catsale.Text);
                string CategoryName = CategComboBox_Catsale.Text;
               // Categ_gridViiew_Catsale.Rows.Add(selectedDate, Amount, CategoryName);

                string query = ("insert into SalesCategoryTable (SaleDate, Amount,CategoryName )values ('" + selectedDate + "','" + Amount + "','" + CategoryName + "')");
                ExecuteSqlQuery(query);
                GetDataBtn_Catsale.PerformClick();
            }
                   
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        
        }

        private void GetDataBtn_Catsale_Click(object sender, EventArgs e)
        {
            //where SaleDate='"+date1+"'"
            DateTime date= dateTimePicker_catsale.Value.Date;
            string date1 = date.ToString();
            string query = ("Select * from SalesCategoryTable where SaleDate='" + date1 + "'");
            DataTable result = GetData(query);
            Categ_gridViiew_Catsale.DataSource = result;
            Categ_gridViiew_Catsale.AutoGenerateColumns = true;
        }

        private void clearGrid_catsale_Click(object sender, EventArgs e)
        {
            if (Categ_gridViiew_Catsale.Rows.Count > 0)
            {
                try
                {
                    Categ_gridViiew_Catsale.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }
            }
            else {
                Categ_gridViiew_Catsale.Rows.Clear();
            }
        }


        private void AccountBook_Load(object sender, EventArgs e)
        {
            
            LOGOPANEL.Visible = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username;
            string Password;

            Username = textBox1.Text;
            Password = textBox2.Text;

            string connectionstring = "server=LAPTOP-S5MNDU94\\SQLEXPRESS;database=career_assurancce;integrated Security=SSPI;";
            using (SqlConnection _con = new SqlConnection(connectionstring)) 
            {

                string queryStatement = "SELECT Count(1) From Registration WHERE Username = @Username AND Pass = @Password";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    _cmd.Parameters.AddWithValue("@Username", Username);
                    _cmd.Parameters.AddWithValue("@Password", Password);

                    _con.Open();
                    int result =(int)_cmd.ExecuteScalar();

                    _con.Close();

                    if(result > 0)
                    {
                        Form2 form = new Form2();
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password!!!....");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }

                }
            }
            Console.WriteLine("input read");
        }

       private void textBox2_TextChanged(object sender, EventArgs e)
            {

            }
    }
}

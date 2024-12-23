using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            string first_name;
            string last_name;
            int MathsMarks;
            int ScienceMarks;
            int MarathiMarks;
            int HindiMarks;
            int EnglishMarks;

            first_name = textBox1.Text;
            last_name = textBox7.Text;


            MathsMarks = Convert.ToInt32(textBox2.Text);
            ScienceMarks = Convert.ToInt32(textBox3.Text);
            MarathiMarks = Convert.ToInt32(textBox4.Text);
            HindiMarks = Convert.ToInt32(textBox5.Text);
            EnglishMarks = Convert.ToInt32(textBox6.Text);

            string connectionstring = "server=LAPTOP-S5MNDU94\\SQLEXPRESS;database=career_assurancce;integrated Security=SSPI;";
            try
            {
                using (SqlConnection _con = new SqlConnection(connectionstring))
                {
                    _con.Open();
                    string insertstudentQuery = "INSERT INTO Students(first_name,last_name)  OUTPUT INSERTED.student_id VALUES (@student_Fname,@student_Lname) ";
                    int student_id;
                    using (SqlCommand _cmd = new SqlCommand(insertstudentQuery, _con))

                    {
                        _cmd.Parameters.AddWithValue("@student_Fname,@student_Lname",student_Fname,student_Lname);
                        student_id = (int)_cmd.ExecuteScalar();

                        Dictionary<string, int> marks = new Dictionary<string, int>
                        {
                            { "Maths", 1 },
                            { "Science", 2 },
                            { "Marathi", 3 },
                            { "Hindi", 4 },
                            { "English", 5 }
                        };

                        Dictionary<int, int> marksData = new Dictionary<int, int>
                        {
                            {1,MathsMarks },
                            {2,ScienceMarks },
                            {3,MarathiMarks },
                            {4,HindiMarks },
                            {5,EnglishMarks }
                        };

                        string insertMarksQuery = "INSERT INTO Marks (student_id,subject_id,marks) VALUES (@student_id,@subject_id,@marks)";
                        using (SqlCommand _cmd1 = new SqlCommand(insertMarksQuery, _con))
                        {
                            foreach (var entry in marks)
                            {
                                _cmd.Parameters.Clear();
                                _cmd.Parameters.AddWithValue("@student_id", student_id);
                                _cmd.Parameters.AddWithValue("@subject_id", entry.Key);
                                _cmd.Parameters.AddWithValue("@marks", entry.Value);
                                _cmd.ExecuteNonQuery();

                            }
                        }
                        MessageBox.Show("Data Inserted Successfully");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"ex.Message occurred:{ex.Message}");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}





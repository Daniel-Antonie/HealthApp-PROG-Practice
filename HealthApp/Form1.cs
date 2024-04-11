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

namespace HealthApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //register implementaiton 
            if ()//validate method
            {
                string name = txtName.Text;
                string surname = txtSurname.Text;
                int id = Convert.ToInt32(txtIDNum.Text);
                string email = txtEmail.Text;
                string password = txtPasswrod.Text;
                string cpassword = txtConfPassword.Text;
                string speciality = txtSpeciality.Text;

                //pass input into sql DB 

                using (SqlConnection con = new SqlConnection())
                {
                    con.Open(); //db now open to accept input from app
                    string query = "INSERT INTO";
                    //starting with patient registration
                    if (string.IsNullOrEmpty(speciality))
                    {
                        //use the same fields into your DB
                        query += "Patient(Name, Surname, ID, Email, Password) VALUES (@Name, @Surname, @ID, @Email, @Password)"; // += means query = query ....
                    }//if statement for patient registration

                    else
                    {
                        query += "Doctor (Name, Surname, ID, Email, Password, Speciality) VALUES (@Name, @Surname, @ID, @Email, @Password, @Speciality)";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Surname", surname);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Speciality", speciality);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Succeeded!");
                    con.Close();
                }

            }
        }
    }
}

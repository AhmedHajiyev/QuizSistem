using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizSistem
{
    public partial class StudentSignUp : Form
    {
        public StudentSignUp()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SignInForm signInForm = new SignInForm();
            signInForm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = PasswordGenerator.GeneratePassword();

            using (QuizSystemDbContext context = new QuizSystemDbContext())
            {
                var student = new Student
                {
                    Email = emailBox.Text,
                    Name = usernameBox.Text,
                    Password = password
                };

                context.Students.Add(student);
                context.SaveChanges();


                GmailSender.SendGmail(student.Email, student.Name, student.Password);

                this.Hide();
                SignInForm signInForm = new SignInForm();
                signInForm.ShowDialog();
                this.Close();
            }

            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            usernameBox.Clear();
            emailBox.Clear();
        }
    }
}

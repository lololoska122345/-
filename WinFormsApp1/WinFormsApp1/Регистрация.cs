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
using ClassLibrary1;
namespace WinFormsApp1
{
    public partial class Регистрация : Form
    {
        private SqlConnection connection;
        public Регистрация()
        {
            InitializeComponent();
            connection = БД.connection;
        }
        int current = 1;
        int current1 = 1;
        private void button3_Click(object sender, EventArgs e)
        {
            if (current == 1)
            {
                textBox3.PasswordChar = '\0';
                current = 0;
                button2.ForeColor = Color.Green;
            }
            else
            {
                textBox3.PasswordChar = '*';
                current = 1;
                button2.ForeColor = Color.Black;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (current == 1)
            {
                textBox4.PasswordChar = '\0';
                current = 0;
                button3.ForeColor = Color.Green;
            }
            else
            {
                textBox4.PasswordChar = '*';
                current = 1;
                button3.ForeColor = Color.Black;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            bool allFieldsEmpty = string.IsNullOrEmpty(textBox1.Text) ||
                                      string.IsNullOrEmpty(textBox3.Text) ||
                                      string.IsNullOrEmpty(textBox4.Text) ||
                                      string.IsNullOrEmpty(textBox5.Text);
            button1.Enabled = !allFieldsEmpty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox4.Text;
            string password2 = textBox5.Text;
            if (password == password2)
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM [dbo].[Users] WHERE login = @login OR FIO = @FIO";
                SqlCommand checkCommand = connection.CreateCommand();
                checkCommand.CommandText = checkQuery;
                checkCommand.Parameters.AddWithValue("@FIO", textBox1.Text);
                checkCommand.Parameters.AddWithValue("@login", textBox3.Text);
                int count = (int)checkCommand.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Данный пользователь уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    connection.Close();
                    return;
                }
                string query = "INSERT INTO [dbo].[Users] (FIO, phone, login, password, type) VALUES (@FIO, @phone, @login, @pass, @role)";
                SqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@FIO", textBox1.Text);
                command.Parameters.AddWithValue("@phone", maskedTextBox1.Text);
                command.Parameters.AddWithValue("@login", textBox3.Text);
                command.Parameters.AddWithValue("@pass", textBox4.Text);
                command.Parameters.AddWithValue("@role", "Заказчик");
                MessageBox.Show("Пользователь добавлен!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                command.ExecuteScalar();
                connection.Close();
                Close();
            }
            else
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

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
using ClassLibrary1;
namespace WinFormsApp1
{
    public partial class Пользователи : Form
    {
        private int selectedId;
        private SqlConnection connection;
        public Пользователи()
        {
            InitializeComponent();
            connection = БД.connection;
        }
        int count;
        void LoadQ()
        {
            БД.LoadData("SELECT userID AS ID, FIO AS ФИО, phone as Телефон, login AS Логин, password AS Пароль, type AS Роль FROM [dbo].[Users]", dataGridView1);
            count = dataGridView1.Rows.Count;
            label7.Text = "Всего записей:" + count;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string checkQuery = "SELECT COUNT(*) FROM [dbo].[Users] WHERE FIO = @FIO";
            SqlCommand checkCommand = connection.CreateCommand();
            checkCommand.CommandText = checkQuery;
            checkCommand.Parameters.AddWithValue("@FIO", textBox1.Text);
            int count = (int)checkCommand.ExecuteScalar();
            if (count > 0)
            {
                MessageBox.Show("Данный пользователь уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connection.Close();
                return;
            }
            string query = "INSERT INTO [dbo].[Users] (FIO, phone, login, password, type) VALUES (@FIO, @phone,@login, @password, @type)";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@FIO", textBox1.Text);
            command.Parameters.AddWithValue("@phone", maskedTextBox1.Text);
            command.Parameters.AddWithValue("@login", textBox2.Text);
            command.Parameters.AddWithValue("@password", textBox3.Text);
            command.Parameters.AddWithValue("@type", comboBox1.SelectedItem.ToString());
            MessageBox.Show("Запись успешно добавлена!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            command.ExecuteScalar();
            if (comboBox1.SelectedItem.ToString() == "Автомеханик")
            {
                string addMaster = "INSERT INTO [dbo].[Mechanics] (FIO, phone) VALUES (@FIO, @phone)";
                SqlCommand command1 = connection.CreateCommand();
                command1.CommandText = addMaster;
                command1.Parameters.AddWithValue("@FIO", textBox1.Text);
                command1.Parameters.AddWithValue("@phone", maskedTextBox1.Text);
                command1.ExecuteScalar();
            }
            connection.Close();
            LoadQ();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void Пользователи_Load(object sender, EventArgs e)
        {
            LoadQ();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                textBox1.Text = selectedRow.Cells["ФИО"].Value.ToString();
                textBox2.Text = selectedRow.Cells["Логин"].Value.ToString();
                textBox3.Text = selectedRow.Cells["Пароль"].Value.ToString();
                maskedTextBox1.Text = selectedRow.Cells["Телефон"].Value.ToString();
                comboBox1.SelectedIndex = comboBox1.FindStringExact(selectedRow.Cells["Роль"].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE [dbo].[Users] SET [FIO] = @FIO, [phone] = @phone, login = @login, password = @password, [type] = @type WHERE [userID] = @SelectedId";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            connection.Open();
            command.Parameters.AddWithValue("@FIO", textBox1.Text);
            command.Parameters.AddWithValue("@login", textBox2.Text);
            command.Parameters.AddWithValue("@password", textBox3.Text);
            command.Parameters.AddWithValue("@phone", maskedTextBox1.Text);
            command.Parameters.AddWithValue("@type", comboBox1.SelectedItem.ToString());
            command.Parameters.AddWithValue("@SelectedId", selectedId);
            command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно изменена!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
            LoadQ();
            selectedId = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Автомеханик")
            {
                try
                {
                    connection.Open();
                    string query = $"DELETE FROM Mechanics WHERE FIO = @FIO";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@FIO", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    БД.DeleteRow("userID", selectedId, "Users");
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Невозможно удалить автомеханика, так как он занят в заявках или отчетах.", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка при удалении автомеханика: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                БД.DeleteRow("userID", selectedId, "Users");
            }
            LoadQ();
            selectedId = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string FindFIO = textBox4.Text;
            if (string.IsNullOrWhiteSpace(FindFIO))
            {
                LoadQ();
            }
            else
            {
                БД.LoadDataWithParameter("SELECT userID AS ID, FIO AS ФИО, phone as Телефон, login AS Логин, password AS Пароль, type AS Роль FROM [dbo].[Users] WHERE FIO LIKE @FIO", dataGridView1, "@FIO", $"%{FindFIO}%");
                label7.Text = "Всего записей:\n" + dataGridView1.Rows.Count + " из " + count;
            }
        }
    }
}

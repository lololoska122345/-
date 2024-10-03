using System;

using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows.Forms;
using ClassLibrary1;

namespace WinFormsApp1
{
    public partial class Автомеханики : Form
    {
        private int selectedId;
        private SqlConnection connection;
        public Автомеханики()
        {
            InitializeComponent();
            connection = БД.connection;
        }
        void LoadQ()
        {
            if (БД.role == "Автомеханик")
            {
                button3.Visible = false;
                БД.LoadDataWithParameter("SELECT masterID as ID, FIO AS ФИО, phone AS Телефон FROM [dbo].[Mechanics] WHERE FIO = @FIO", dataGridView1, "@FIO", БД.FIO);

            }
            else
            {
                button3.Visible = true;
                БД.LoadData("SELECT masterID as ID, FIO AS ФИО, phone AS Телефон FROM [dbo].[Mechanics]", dataGridView1);
            }
            label2.Text = "Всего записей:" + dataGridView1.Rows.Count;
        }
        private void Автомеханики_Load(object sender, EventArgs e)
        {
            LoadQ();
        }
        private void Автомеханики_Load_1(object sender, EventArgs e)
        {
            LoadQ();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE [dbo].[Mechanics] SET [FIO] = @FIO, [phone] = @phone WHERE [masterID] = @SelectedId";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            connection.Open();
            command.Parameters.AddWithValue("@FIO", textBox1.Text);
            command.Parameters.AddWithValue("@phone", maskedTextBox1.Text);
            command.Parameters.AddWithValue("@SelectedId", selectedId);
            command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно изменена!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
            LoadQ();
            selectedId = 0;
            textBox1.Clear();
            maskedTextBox1.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                textBox1.Text = selectedRow.Cells["ФИО"].Value.ToString();
                maskedTextBox1.Text = selectedRow.Cells["Телефон"].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool allFieldsEmpty = string.IsNullOrEmpty(textBox1.Text);
            if (selectedId != 0)
            {
                button2.Enabled = !allFieldsEmpty;
                button3.Enabled = !allFieldsEmpty;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                БД.DeleteRow("masterID", selectedId, "Mechanics");
                connection.Open();
                string query = $"DELETE FROM Users WHERE FIO = @FIO";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@FIO", textBox1.Text);
                cmd.ExecuteNonQuery();
                connection.Close();
                LoadQ();
                selectedId = 0;
                textBox1.Clear();
                maskedTextBox1.Clear();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("Невозможно удалить автомеханика, так как он занят в заявках или отчетах.", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

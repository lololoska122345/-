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
    public partial class Запчасти : Form
    {
        private int selectedId;
        private SqlConnection connection;
        public Запчасти()
        {
            InitializeComponent();
            connection = БД.connection;
        }
        void LoadQ()
        {
            БД.LoadData("SELECT partID as ID, partName AS [Название], partCost AS Стоимость FROM [dbo].[Parts]", dataGridView1);
            label4.Text = "Всего записей:" + dataGridView1.Rows.Count;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                textBox1.Text = selectedRow.Cells["Название"].Value.ToString();
                textBox2.Text = selectedRow.Cells["Стоимость"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string checkQuery = "SELECT COUNT(*) FROM [dbo].[Parts] WHERE partName = @partName";
            SqlCommand checkCommand = connection.CreateCommand();
            checkCommand.CommandText = checkQuery;
            checkCommand.Parameters.AddWithValue("@partName", textBox1.Text);
            int count = (int)checkCommand.ExecuteScalar();
            if (count > 0)
            {
                MessageBox.Show("Данная деталь уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connection.Close();
                return;
            }
            string query = "INSERT INTO [dbo].[Parts] (partName, partCost) VALUES (@partName, @partCost)";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@partName", textBox1.Text);
            command.Parameters.AddWithValue("@partCost", textBox2.Text);
            MessageBox.Show("Запись успешно добавлена!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            command.ExecuteScalar();
            connection.Close();
            textBox1.Clear();
            textBox2.Clear();
            LoadQ();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE [dbo].[Parts] SET [partName] = @partName, [partCost] = @partCost WHERE [partID] = @SelectedId";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            connection.Open();
            command.Parameters.AddWithValue("@partName", textBox1.Text);
            command.Parameters.AddWithValue("@partCost", Convert.ToInt32(textBox2.Text));
            command.Parameters.AddWithValue("@SelectedId", selectedId);
            command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно изменена!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
            LoadQ();
            selectedId = 0;
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            БД.DeleteRow("partID", selectedId, "Parts");
            LoadQ();
            selectedId = 0;
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool allFieldsEmpty = string.IsNullOrEmpty(textBox1.Text) ||
                        string.IsNullOrEmpty(textBox2.Text);
            button1.Enabled = !allFieldsEmpty;
            if (selectedId != 0)
            {
                button2.Enabled = !allFieldsEmpty;
                button3.Enabled = !allFieldsEmpty;
            }
        }

        private void Запчасти_Load(object sender, EventArgs e)
        {
            LoadQ();
        }
    }
}

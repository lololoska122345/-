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
    public partial class Комментарии : Form
    {
        private int selectedId;
        private int masterID;
        private SqlConnection connection;
        public Комментарии(int selectedId, int masterID)
        {
            this.selectedId = selectedId;
            this.masterID = masterID;
            InitializeComponent();
            connection = БД.connection;
        }
        public Комментарии(int selectedId)
        {
            this.selectedId = selectedId;
            InitializeComponent();
            connection = БД.connection;
        }

        private void Комментарии_Load(object sender, EventArgs e)
        {
            if (БД.role == "Заказчик" || БД.role == "Оператор")
            {
                button2.Visible = false;
            }
            else
            {
                button2.Visible = true;
            }
            label1.Text = $"Комментарий к заявке: {selectedId}";
            connection.Open();
            string checkQuery = "SELECT COUNT(*) FROM [dbo].[Comments] WHERE requestID = @requestID";
            SqlCommand checkCommand = connection.CreateCommand();
            checkCommand.CommandText = checkQuery;
            checkCommand.Parameters.AddWithValue("@requestID", selectedId);
            int count = (int)checkCommand.ExecuteScalar();
            if (count > 0)
            {
                string query = "SELECT message FROM [dbo].[Comments] WHERE requestID = @requestID";
                SqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@requestID", selectedId);
                var result = command.ExecuteScalar();
                textBox1.Text = result.ToString();
                connection.Close();
                return;
            }
            else
            {
                string query = "INSERT INTO [dbo].[Comments] (requestID, masterID) VALUES (@requestID, @masterID)";
                SqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@requestID", selectedId);
                command.Parameters.AddWithValue("@masterID", masterID);
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string checkQuery = "SELECT commentID FROM [dbo].[Comments] WHERE requestID = @requestID";
            SqlCommand checkCommand = connection.CreateCommand();
            checkCommand.CommandText = checkQuery;
            checkCommand.Parameters.AddWithValue("@requestID", selectedId);
            int ID = (int)checkCommand.ExecuteScalar();
            string query = "UPDATE [dbo].[Comments] SET message = @message WHERE commentID = @commentID";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@message", textBox1.Text);
            command.Parameters.AddWithValue("@commentID", ID);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Комментарий изменен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

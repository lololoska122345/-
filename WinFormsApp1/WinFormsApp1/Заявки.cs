using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClassLibrary1;
namespace WinFormsApp1
{
    public partial class Заявки : Form
    {
        private int selectedId;
        private SqlConnection connection;
        int count = 0;
        public Заявки()
        {
            InitializeComponent();
            connection = БД.connection;
        }
        void LoadQ()
        {
            if (БД.role == "Заказчик")
            {
                БД.LoadDataWithParameter("SELECT requestID AS ID, startDate AS [Начало работ], carType AS [Тип машины], carModel AS [Модель машины], problemDescription AS [Описание проблемы], requestStatus AS [Статус], completionDate AS [Дата окончания работ], Parts.partName AS [Деталь], Mechanics.FIO AS [ФИО мастера], Users.FIO AS [ФИО клиента], Users.phone AS Телефон FROM [dbo].[Requests] LEFT JOIN Mechanics ON Requests.masterID = Mechanics.masterID LEFT JOIN Users ON Requests.clientID = Users.userID LEFT JOIN Parts ON Requests.repairParts = Parts.partID WHERE Users.FIO = @FIO", dataGridView1, "@FIO", БД.FIO);
                comboBox1.SelectedIndex = 1;
            }
            else if (БД.role == "Автомеханик")
            {
                БД.LoadDataWithParameter("SELECT requestID AS ID, startDate AS [Начало работ], carType AS [Тип машины], carModel AS [Модель машины], problemDescription AS [Описание проблемы], requestStatus AS [Статус], completionDate AS [Дата окончания работ], Parts.partName AS [Деталь], Mechanics.FIO AS [ФИО мастера], Users.FIO AS [ФИО клиента], Users.phone AS Телефон FROM [dbo].[Requests] LEFT JOIN Mechanics ON Requests.masterID = Mechanics.masterID LEFT JOIN Users ON Requests.clientID = Users.userID LEFT JOIN Parts ON Requests.repairParts = Parts.partID WHERE Mechanics.FIO = @FIO", dataGridView1, "@FIO", БД.FIO);
            }
            else
            {
                БД.LoadData("SELECT requestID AS ID, startDate AS [Начало работ], carType AS [Тип машины], carModel AS [Модель машины], problemDescription AS [Описание проблемы], requestStatus AS [Статус], completionDate AS [Дата окончания работ], Parts.partName AS [Деталь], Mechanics.FIO AS [ФИО мастера], Users.FIO AS [ФИО клиента], Users.phone AS Телефон FROM [dbo].[Requests] LEFT JOIN Mechanics ON Requests.masterID = Mechanics.masterID LEFT JOIN Users ON Requests.clientID = Users.userID LEFT JOIN Parts ON Requests.repairParts = Parts.partID ", dataGridView1);
                comboBox1.SelectedIndex = 2;
            }
            count = dataGridView1.Rows.Count;
            label11.Text = "Всего записей:" + count;
        }
        void LoadQ1()
        {
            if (БД.role == "Заказчик")
            {
                БД.LoadDataWithParameter("SELECT requestID AS ID, startDate AS [Начало работ], carType AS [Тип машины], carModel AS [Модель машины], problemDescription AS [Описание проблемы], requestStatus AS [Статус], completionDate AS [Дата окончания работ], Parts.partName AS [Деталь], Mechanics.FIO AS [ФИО мастера], Users.FIO AS [ФИО клиента], Users.phone AS Телефон FROM [dbo].[Requests] LEFT JOIN Mechanics ON Requests.masterID = Mechanics.masterID LEFT JOIN Users ON Requests.clientID = Users.userID LEFT JOIN Parts ON Requests.repairParts = Parts.partID WHERE Users.FIO = @FIO AND Requests.requestStatus = N'В исполнении'", dataGridView1, "@FIO", БД.FIO);
            }
            else if (БД.role == "Автомеханик")
            {
                БД.LoadDataWithParameter("SELECT requestID AS ID, startDate AS [Начало работ], carType AS [Тип машины], carModel AS [Модель машины], problemDescription AS [Описание проблемы], requestStatus AS [Статус], completionDate AS [Дата окончания работ], Parts.partName AS [Деталь], Mechanics.FIO AS [ФИО мастера], Users.FIO AS [ФИО клиента], Users.phone AS Телефон FROM [dbo].[Requests] LEFT JOIN Mechanics ON Requests.masterID = Mechanics.masterID LEFT JOIN Users ON Requests.clientID = Users.userID LEFT JOIN Parts ON Requests.repairParts = Parts.partID WHERE Mechanics.FIO = @FIO AND Requests.requestStatus = N'В исполнении'", dataGridView1, "@FIO", БД.FIO);
            }
            else
            {
                БД.LoadData("SELECT requestID AS ID, startDate AS [Начало работ], carType AS [Тип машины], carModel AS [Модель машины], problemDescription AS [Описание проблемы], requestStatus AS [Статус], completionDate AS [Дата окончания работ], Parts.partName AS [Деталь], Mechanics.FIO AS [ФИО мастера], Users.FIO AS [ФИО клиента], Users.phone AS Телефон FROM [dbo].[Requests] LEFT JOIN Mechanics ON Requests.masterID = Mechanics.masterID LEFT JOIN Users ON Requests.clientID = Users.userID LEFT JOIN Parts ON Requests.repairParts = Parts.partID WHERE Requests.requestStatus = N'В исполнении' ", dataGridView1);
            }
            label11.Text = "Всего записей:" + dataGridView1.Rows.Count + " из "+ count;
        }
        private int masterID;
        private void Заявки_Load(object sender, EventArgs e)
        {
            БД.LoadDataToCombobox("FIO", "Mechanics", comboBox2, "masterID");
            БД.LoadDataToCombobox("partName", "Parts", comboBox3, "partID");
            if (БД.role == "Автомеханик")
            {
                int index = comboBox2.FindStringExact(БД.FIO);
                comboBox2.SelectedIndex = index;
                comboBox2.SelectedIndex = masterID;
            }
            comboBox4.Items.Clear();
            comboBox4.ValueMember = null;
            connection.Open();
            string query = $"SELECT * FROM [dbo].[Users] WHERE type = @type ";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@type", "Заказчик");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            comboBox4.DataSource = tb;
            comboBox4.DisplayMember = "FIO";
            comboBox4.ValueMember = "userID";
            comboBox4.SelectedIndex = -1;
            connection.Close();
            if (БД.role == "Заказчик")
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                button3.Text = "Посмотреть комментарий";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                int index = comboBox4.FindStringExact(БД.FIO);
                comboBox4.SelectedIndex = index;
            }
            else if (БД.role == "Автомеханик")
            {
                button2.Text = "Изменить статус/запчасть";
                button3.Text = "Оставить/Изменить комментарий";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                comboBox1.Enabled = false;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = false;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox2.Enabled = false;
                comboBox1.Enabled = true;
                int index = comboBox2.FindStringExact(БД.FIO);
                comboBox2.SelectedIndex = index;
            }
            else if (БД.role == "Оператор")
            {
                button2.Text = "Изменить статус/автомеханика";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                comboBox1.Enabled = true;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = false;
                button3.Text = "Посмотреть комментарий";
                comboBox2.Enabled = true;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
            }
            LoadQ();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "INSERT INTO [dbo].[Requests] (startDate, carType,carModel,problemDescription,requestStatus,clientID) VALUES (@startDate, @carType,@carModel,@problemDescription,@requestStatus, @userID)";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@startDate", DateTime.Now);
            command.Parameters.AddWithValue("@carType", textBox3.Text);
            command.Parameters.AddWithValue("@carModel", textBox1.Text);
            command.Parameters.AddWithValue("@problemDescription", textBox2.Text);
            command.Parameters.AddWithValue("@requestStatus", "В обработке");
            command.Parameters.AddWithValue("@userID", comboBox4.SelectedValue.ToString());
            MessageBox.Show("Запись успешно добавлена!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            command.ExecuteScalar();
            connection.Close();
            LoadQ();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (БД.role == "Оператор")
            {
                if (comboBox1.SelectedItem == "В исполнении")
                {
                    masterID = comboBox2.SelectedIndex;
                    string query = "UPDATE [dbo].[Requests] SET requestStatus = @requestStatus, startDate = @startDate, masterID = @master WHERE [requestID] = @SelectedId";
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = query;
                    connection.Open();
                    command.Parameters.AddWithValue("@requestStatus", comboBox1.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@startDate", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@master", comboBox2.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@SelectedId", selectedId);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Можно поставить только статус \"В исполнении\". Остальные статусы ставит мастер.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (БД.role == "Автомеханик")
            {
                if (comboBox1.SelectedItem.ToString() == "Готово" && comboBox3.SelectedIndex != -1)
                {
                    TimeSpan time = dateTimePicker2.Value - dateTimePicker1.Value;
                    int days = time.Days;
                    string query1 = "SELECT partCost from [dbo].[Parts] WHERE partID = @ID";
                    SqlCommand command1 = connection.CreateCommand();
                    command1.CommandText = query1;
                    connection.Open();
                    int i = comboBox3.SelectedIndex + 1;
                    command1.Parameters.AddWithValue("@ID", i);
                    object price = command1.ExecuteScalar();
                    int pricedetail = (int)price;
                    int totalCost = days * 3000 + pricedetail;
                    connection.Close();
                    string query = "UPDATE [dbo].[Requests] SET requestStatus = @requestStatus, completionDate = @completionDate, repairParts = @repairParts WHERE [requestID] = @SelectedId";
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = query;
                    connection.Open();
                    command.Parameters.AddWithValue("@requestStatus", comboBox1.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@completionDate", DateTime.Now);
                    command.Parameters.AddWithValue("@repairParts", comboBox3.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@SelectedId", selectedId);
                    command.ExecuteNonQuery();
                    connection.Close();
                    connection.Open();
                    string query2 = "INSERT INTO [dbo].[Reports] (reportDate, masterID, requestID,totalCost, timeSpent) VALUES (@reportDate, @masterID,@requestID,@totalCost,@timeSpent)";
                    SqlCommand command2 = connection.CreateCommand();
                    command2.CommandText = query2;
                    command2.Parameters.AddWithValue("@reportDate", DateTime.Now);
                    command2.Parameters.AddWithValue("@masterID", comboBox2.SelectedValue.ToString());
                    command2.Parameters.AddWithValue("@requestID", selectedId);
                    command2.Parameters.AddWithValue("@totalCost", totalCost);
                    command2.Parameters.AddWithValue("@timeSpent", days);
                    command2.ExecuteScalar();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Не выбрана деталь, которая была/будет починена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            LoadQ();
            selectedId = 0;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            button3.Visible = false;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (БД.role == "Заказчик")
            {
                if (comboBox1.SelectedItem == "В исполнении" || comboBox1.SelectedItem == "Готово")
                {
                    MessageBox.Show("Нельзя удалить заявку самостоятельно, потому что она в работе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                comboBox4.SelectedIndex = -1;
            }
            БД.DeleteRow("requestID", selectedId, "Requests");
            LoadQ();
            selectedId = 0;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            button3.Visible = false;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                if (selectedRow.Cells["Начало работ"].Value != DBNull.Value)
                {
                    dateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells["Начало работ"].Value);
                }
                textBox3.Text = selectedRow.Cells["Тип машины"].Value.ToString();
                textBox2.Text = selectedRow.Cells["Описание проблемы"].Value.ToString();
                textBox1.Text = selectedRow.Cells["Модель машины"].Value.ToString();
                comboBox1.SelectedIndex = comboBox1.FindStringExact(selectedRow.Cells["Статус"].Value.ToString());
                if (selectedRow.Cells["Дата окончания работ"].Value != DBNull.Value)
                {
                    dateTimePicker2.Value = Convert.ToDateTime(selectedRow.Cells["Дата окончания работ"].Value);
                }
                comboBox2.SelectedIndex = comboBox2.FindStringExact(selectedRow.Cells["ФИО мастера"].Value.ToString());
                comboBox3.SelectedIndex = comboBox3.FindStringExact(selectedRow.Cells["Деталь"].Value.ToString());
                comboBox4.SelectedIndex = comboBox4.FindStringExact(selectedRow.Cells["ФИО клиента"].Value.ToString());
            }
            if (БД.role == "Автомеханик")
            {
                button3.Visible = true;
            }
            else
            {
                button4.Enabled = true;
                button3.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool allEmpty = string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text);
            button1.Enabled = !allEmpty;
            if (selectedId != 0)
            {
                button2.Enabled = !allEmpty;
                button3.Enabled = !allEmpty;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool allEmpty = string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                comboBox1.SelectedIndex == -1 ||
                comboBox2.SelectedIndex == -1 ||
                comboBox4.SelectedIndex == -1;
            button1.Enabled = !allEmpty;
            if (selectedId != 0)
            {
                button2.Enabled = !allEmpty;
                button3.Enabled = !allEmpty;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (БД.role == "Автомеханик")
            {
                connection.Open();
                string checkQuery = "INSERT INTO [dbo].[Comments] (masterID, requestID) VALUES (@masterID, @requestID)";
                SqlCommand checkCommand = connection.CreateCommand();
                checkCommand.CommandText = checkQuery;
                checkCommand.Parameters.AddWithValue("@masterID", comboBox2.SelectedValue.ToString());
                checkCommand.Parameters.AddWithValue("@requestID", selectedId);
                checkCommand.ExecuteScalar();
                connection.Close();
                Комментарии CommentForm = new Комментарии(selectedId);
                CommentForm.ShowDialog();
            }
            else
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM [dbo].[Comments] WHERE requestID = @requestID";
                SqlCommand checkCommand = connection.CreateCommand();
                checkCommand.CommandText = checkQuery;
                checkCommand.Parameters.AddWithValue("@requestID", selectedId);
                int count = (int)checkCommand.ExecuteScalar();
                connection.Close();
                if (count > 0)
                {
                    Комментарии CommentForm = new Комментарии(selectedId);
                    CommentForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Нет комментариев от мастера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                LoadQ1();
            }
            else
            {
                LoadQ();
            }
        }
    }
}

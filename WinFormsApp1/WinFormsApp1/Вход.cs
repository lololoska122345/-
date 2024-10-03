using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ClassLibrary1;
namespace WinFormsApp1
{
    public partial class ���� : Form
    {
        private SqlConnection connection;
        public ����()
        {
            InitializeComponent();
            connection = ��.connection;
        }
        int countdown = 180;
        int count = 3;
        void AddHistoryLog(string login, string successful)
        {
            connection.Open();
            string query = "INSERT INTO [dbo].[History] (date, login, Successful) VALUES (@date, @login, @Successful)";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@date", DateTime.Now);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@Successful", successful);
            command.ExecuteScalar();
            connection.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            string result = ��.CheckUser(login, password);
            if (result == "����������� ������ �������.")
            {
                MessageBox.Show($"����� ����������, {��.FIO}", "�����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AddHistoryLog(login, "�������");
                ������� form1 = new �������();
                form1.Show();
                this.Hide();
            }
            else if (result == "������� ������ �� ����������")
            {
                MessageBox.Show($"���������� ������ ������ �����, ������� ������ �� ����������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == "������ ��������")
            {
                if (count == 3 || count == 2)
                {
                    count--;
                    MessageBox.Show($"�� ����� ������������ ������. �������� �������: {count}", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AddHistoryLog(login, "�� �������");
                    textBox2.Enabled = false;
                    button2.Enabled = false;
                    button1.Enabled = false;
                    �����cs captchaForm = new �����cs();
                    DialogResult result1 = captchaForm.ShowDialog();
                    if (result1 == DialogResult.OK)
                    {
                        textBox2.Enabled = true;
                        button2.Enabled = true;
                        button1.Enabled = true;
                    }
                }
                else if (count == 1)
                {
                    count--;
                    AddHistoryLog(login, "�� �������");
                    button2.Enabled = false;
                    textBox2.Enabled = false;
                    button1.Enabled = false;
                    label4.Visible = true;
                    label4.Text = $"������ �� ����������� ������� �����: {countdown / 60:D2}:{countdown % 60:D2}";
                    timer1.Start();
                }
                else if (count == 0)
                {
                    MessageBox.Show("��� �������������� ������ ������ ���������� ���������", "������", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    AddHistoryLog(login, "�� �������");
                    Application.Exit();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ����������� registration = new �����������();
            registration.ShowDialog();
        }
        int current = 1;
        private void button3_Click(object sender, EventArgs e)
        {
            if (current == 1)
            {
                textBox2.PasswordChar = '\0';
                current = 0;
                button3.ForeColor = Color.Green;
            }
            else
            {
                textBox2.PasswordChar = '*';
                current = 1;
                button3.ForeColor = Color.Black;
            }
        }

        private void ����_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool allEmpty = string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text);
            button1.Enabled = !allEmpty;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countdown--;
            label4.Text = $"������ �� ����������� ������� �����: {countdown / 60:D2}:{countdown % 60:D2}";
            if (countdown <= 0)
            {
                timer1.Stop();
                button2.Enabled = true;
                button1.Enabled = true;
                textBox2.Enabled = true;
                label4.Visible = false;
            }
        }
    }
}

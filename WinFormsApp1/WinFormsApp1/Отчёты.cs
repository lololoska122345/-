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
    public partial class Отчёты : Form
    {
        private int selectedId;
        private SqlConnection connection;
        public Отчёты()
        {
            InitializeComponent();
            connection = БД.connection;
        }
        void LoadQ()
        {
            БД.LoadData("SELECT reportID AS ID, reportDate AS [Дата отчета], Mechanics.FIO AS [ФИО автомеханика], requestID AS [ID заявки], totalCost AS [Общая стоимость], timeSpent AS [Затраченное время] FROM [dbo].[Reports] LEFT JOIN Mechanics ON Reports.masterID = Mechanics.masterID", dataGridView1);
            label3.Text = "Всего записей:" + dataGridView1.Rows.Count;
        }
        private void Отчёты_Load(object sender, EventArgs e)
        {
            LoadQ();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                label1.Text = "Отчёт по заявке: "+selectedRow.Cells["ID Заявки"].Value.ToString();
                textBox2.Text = selectedRow.Cells["Затраченное время"].Value.ToString();
                textBox3.Text = selectedRow.Cells["Общая стоимость"].Value.ToString();
            }
        }
    }
}

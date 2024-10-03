using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
namespace WinFormsApp1
{
    public partial class Каталог : Form
    {
        public Каталог()
        {
            InitializeComponent();
        }

        private void Каталог_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Роль: " + БД.role;
            if (БД.role == "Оператор")
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button4.Location = new Point(205, 371);
                button6.Visible = true;
            }

            else if (БД.role == "Автомеханик")
            {
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = true;
                button4.Location = new Point(205, 188);
                button6.Visible = false;
                linkLabel1.Visible = false;
                linkLabel1.Enabled = false;
            }
            else
            {
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = false;
                linkLabel1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Заявки requestForm = new Заявки();
            requestForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Автомеханики mechanicsForm = new Автомеханики();
            mechanicsForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Пользователи usersForm = new Пользователи();
            usersForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Запчасти Form = new Запчасти();
            Form.ShowDialog();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Отчёты otchetForm = new Отчёты();
            otchetForm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            История historyForm = new История();
            historyForm.ShowDialog();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Вход enter = new Вход();
            enter.Show();
        }

        private void Каталог_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

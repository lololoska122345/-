using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
namespace WinFormsApp1
{
    public partial class История : Form
    {
        public История()
        {
            InitializeComponent();
        }

        private void История_Load(object sender, EventArgs e)
        {
            БД.LoadData("SELECT date AS [Дата входа], login AS [Логин], Successful AS [Успешно/Не успешно] FROM [dbo].[History]", dataGridView1);
        }
    }
}

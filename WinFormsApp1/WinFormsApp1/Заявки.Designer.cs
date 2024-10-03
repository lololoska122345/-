namespace WinFormsApp1
{
    partial class Заявки
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox3 = new TextBox();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label6 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            label9 = new Label();
            button2 = new Button();
            button1 = new Button();
            comboBox1 = new ComboBox();
            button3 = new Button();
            label10 = new Label();
            comboBox4 = new ComboBox();
            button4 = new Button();
            label11 = new Label();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.DarkSlateGray;
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBox3.ForeColor = SystemColors.Window;
            textBox3.Location = new Point(330, 102);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(233, 40);
            textBox3.TabIndex = 50;
            textBox3.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.DarkSlateGray;
            label4.Location = new Point(330, 67);
            label4.Name = "label4";
            label4.Size = new Size(174, 32);
            label4.TabIndex = 49;
            label4.Text = "Тип машины:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.DarkSlateGray;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(37, 335);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(805, 351);
            dataGridView1.TabIndex = 46;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.DarkSlateGray;
            label1.Location = new Point(446, 9);
            label1.Name = "label1";
            label1.Size = new Size(132, 48);
            label1.TabIndex = 43;
            label1.Text = "Заявки";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Comic Sans MS", 10.8F, FontStyle.Bold);
            dateTimePicker1.Location = new Point(12, 102);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 54;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.DarkSlateGray;
            label6.Location = new Point(12, 67);
            label6.Name = "label6";
            label6.Size = new Size(240, 32);
            label6.TabIndex = 53;
            label6.Text = "Дата начала работ:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CalendarFont = new Font("Comic Sans MS", 10.8F, FontStyle.Bold);
            dateTimePicker2.Location = new Point(12, 200);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 56;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.DarkSlateGray;
            label2.Location = new Point(12, 161);
            label2.Name = "label2";
            label2.Size = new Size(278, 32);
            label2.TabIndex = 55;
            label2.Text = "Дата окончания работ:";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.DarkSlateGray;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBox1.ForeColor = SystemColors.Window;
            textBox1.Location = new Point(330, 196);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(233, 40);
            textBox1.TabIndex = 58;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.DarkSlateGray;
            label3.Location = new Point(330, 161);
            label3.Name = "label3";
            label3.Size = new Size(215, 32);
            label3.TabIndex = 57;
            label3.Text = "Модель машины:";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.DarkSlateGray;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBox2.ForeColor = SystemColors.Window;
            textBox2.Location = new Point(610, 102);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(253, 134);
            textBox2.TabIndex = 60;
            textBox2.TextChanged += textBox1_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.DarkSlateGray;
            label5.Location = new Point(610, 67);
            label5.Name = "label5";
            label5.Size = new Size(264, 32);
            label5.TabIndex = 59;
            label5.Text = "Описание проблемы:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.ForeColor = Color.DarkSlateGray;
            label7.Location = new Point(910, 151);
            label7.Name = "label7";
            label7.Size = new Size(174, 32);
            label7.TabIndex = 63;
            label7.Text = "Автомеханик:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label8.ForeColor = Color.DarkSlateGray;
            label8.Location = new Point(910, 67);
            label8.Name = "label8";
            label8.Size = new Size(98, 32);
            label8.TabIndex = 61;
            label8.Text = "Статус:";
            // 
            // comboBox2
            // 
            comboBox2.BackColor = Color.DarkSlateGray;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FlatStyle = FlatStyle.Flat;
            comboBox2.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            comboBox2.ForeColor = SystemColors.InactiveBorder;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(910, 186);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(233, 29);
            comboBox2.TabIndex = 66;
            comboBox2.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox3
            // 
            comboBox3.BackColor = Color.DarkSlateGray;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FlatStyle = FlatStyle.Flat;
            comboBox3.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            comboBox3.ForeColor = SystemColors.InactiveBorder;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(910, 267);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(233, 29);
            comboBox3.TabIndex = 67;
            comboBox3.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label9.ForeColor = Color.DarkSlateGray;
            label9.Location = new Point(910, 232);
            label9.Name = "label9";
            label9.Size = new Size(129, 32);
            label9.TabIndex = 68;
            label9.Text = "Запчасти:";
            // 
            // button2
            // 
            button2.BackColor = Color.DarkSlateGray;
            button2.Enabled = false;
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 64, 0);
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(934, 400);
            button2.Name = "button2";
            button2.Size = new Size(209, 78);
            button2.TabIndex = 48;
            button2.Text = "Изменить статус/запчасть";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkSlateGray;
            button1.Enabled = false;
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 64, 0);
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(934, 335);
            button1.Name = "button1";
            button1.Size = new Size(209, 59);
            button1.TabIndex = 47;
            button1.Text = "Зарегистрировать";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.DarkSlateGray;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            comboBox1.ForeColor = SystemColors.InactiveBorder;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "В обработке", "В исполнении", "Готово" });
            comboBox1.Location = new Point(910, 107);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(233, 29);
            comboBox1.TabIndex = 69;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkSlateGray;
            button3.Enabled = false;
            button3.FlatAppearance.BorderColor = Color.FromArgb(0, 64, 0);
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button3.ForeColor = SystemColors.ButtonFace;
            button3.Location = new Point(934, 613);
            button3.Name = "button3";
            button3.Size = new Size(209, 73);
            button3.TabIndex = 70;
            button3.Text = "Оставить комментарий";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label10.ForeColor = Color.DarkSlateGray;
            label10.Location = new Point(434, 251);
            label10.Name = "label10";
            label10.Size = new Size(96, 32);
            label10.TabIndex = 72;
            label10.Text = "Клиент";
            // 
            // comboBox4
            // 
            comboBox4.BackColor = Color.DarkSlateGray;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.Enabled = false;
            comboBox4.FlatStyle = FlatStyle.Flat;
            comboBox4.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            comboBox4.ForeColor = SystemColors.InactiveBorder;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(434, 286);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(233, 29);
            comboBox4.TabIndex = 71;
            comboBox4.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkSlateGray;
            button4.Enabled = false;
            button4.FlatAppearance.BorderColor = Color.FromArgb(0, 64, 0);
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button4.ForeColor = SystemColors.ButtonFace;
            button4.Location = new Point(934, 484);
            button4.Name = "button4";
            button4.Size = new Size(209, 78);
            button4.TabIndex = 73;
            button4.Text = "Удалить";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label11.ForeColor = Color.DarkSlateGray;
            label11.Location = new Point(12, 9);
            label11.Name = "label11";
            label11.Size = new Size(192, 32);
            label11.TabIndex = 74;
            label11.Text = "Всего записей:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Comic Sans MS", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            checkBox1.ForeColor = Color.DarkSlateGray;
            checkBox1.Location = new Point(12, 251);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(231, 29);
            checkBox1.TabIndex = 75;
            checkBox1.Text = "Только в исполнении";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Заявки
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumAquamarine;
            ClientSize = new Size(1271, 736);
            Controls.Add(checkBox1);
            Controls.Add(label11);
            Controls.Add(button4);
            Controls.Add(label10);
            Controls.Add(comboBox4);
            Controls.Add(button3);
            Controls.Add(comboBox1);
            Controls.Add(label9);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(textBox2);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(dateTimePicker2);
            Controls.Add(label2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label6);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "Заявки";
            Text = "Заявки";
            Load += Заявки_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox3;
        private Label label4;
        private DataGridView dataGridView1;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Label label6;
        private DateTimePicker dateTimePicker2;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label5;
        private Label label7;
        private Label label8;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Label label9;
        private Button button2;
        private Button button1;
        private ComboBox comboBox1;
        private Button button3;
        private Label label10;
        private ComboBox comboBox4;
        private Button button4;
        private Label label11;
        private CheckBox checkBox1;
    }
}
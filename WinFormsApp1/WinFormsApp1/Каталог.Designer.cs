namespace WinFormsApp1
{
    partial class Каталог
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
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button6 = new Button();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.DarkSlateGray;
            label1.Location = new Point(163, 18);
            label1.Name = "label1";
            label1.Size = new Size(332, 48);
            label1.TabIndex = 1;
            label1.Text = "Выберите таблицу";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.DarkSlateGray;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBox1.ForeColor = SystemColors.Window;
            textBox1.Location = new Point(0, 689);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(624, 33);
            textBox1.TabIndex = 6;
            textBox1.Text = "Роль:";
            // 
            // button1
            // 
            button1.BackColor = Color.DarkSlateGray;
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 64, 0);
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(205, 99);
            button1.Name = "button1";
            button1.Size = new Size(225, 70);
            button1.TabIndex = 7;
            button1.Text = "Заявки";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkSlateGray;
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 64, 0);
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(205, 188);
            button2.Name = "button2";
            button2.Size = new Size(225, 74);
            button2.TabIndex = 8;
            button2.Text = "Автомеханики";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkSlateGray;
            button3.FlatAppearance.BorderColor = Color.FromArgb(0, 64, 0);
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button3.ForeColor = SystemColors.ButtonFace;
            button3.Location = new Point(205, 277);
            button3.Name = "button3";
            button3.Size = new Size(225, 74);
            button3.TabIndex = 9;
            button3.Text = "Пользователи";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkSlateGray;
            button4.FlatAppearance.BorderColor = Color.FromArgb(0, 64, 0);
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button4.ForeColor = SystemColors.ButtonFace;
            button4.Location = new Point(205, 371);
            button4.Name = "button4";
            button4.Size = new Size(225, 74);
            button4.TabIndex = 10;
            button4.Text = "Запчасти";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.DarkSlateGray;
            button6.FlatAppearance.BorderColor = Color.FromArgb(0, 64, 0);
            button6.FlatAppearance.BorderSize = 2;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button6.ForeColor = SystemColors.ButtonFace;
            button6.Location = new Point(205, 464);
            button6.Name = "button6";
            button6.Size = new Size(225, 74);
            button6.TabIndex = 12;
            button6.Text = "Отчёты";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Comic Sans MS", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            linkLabel1.LinkColor = Color.DarkSlateGray;
            linkLabel1.Location = new Point(367, 661);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(261, 25);
            linkLabel1.TabIndex = 13;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Посмотреть историю входа";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Comic Sans MS", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            linkLabel2.LinkColor = Color.DarkSlateGray;
            linkLabel2.Location = new Point(0, 661);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(70, 25);
            linkLabel2.TabIndex = 14;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Выход";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // Каталог
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumAquamarine;
            ClientSize = new Size(625, 723);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Каталог";
            Text = "Каталог";
            FormClosing += Каталог_FormClosing;
            Load += Каталог_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button6;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
    }
}
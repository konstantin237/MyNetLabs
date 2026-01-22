using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab_2__forms_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int GetLastDigit(int n)
        {
            return n % 10;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите число.", "Ошибка ввода");
                return;
            }

            int n = int.Parse(textBox1.Text);

            if (!int.TryParse(textBox1.Text, out n))
            {
                MessageBox.Show("Введите корректное целое число.", "Ошибка ввода");
                return;
            }

            if (n <= 0 || n > 100)
            {
                MessageBox.Show("Введите натуральное число от 1 до 100.", "Ошибка ввода");
                return;
            }

            int lastDigit = GetLastDigit(n);

            labelResult.Text = "Последняя цифра: " + lastDigit;
        }

        private void labelResult_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Windows.Forms;

namespace ArithmeticCheckApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumber.Text, out int number) && number >= 10 && number <= 99)
            {
                int tens = number / 10;
                int units = number % 10;

                int square = number * number;
                int sumCubes = (int)(4 * (Math.Pow(tens, 3) + Math.Pow(units, 3)));

                if (square == sumCubes)
                {
                    lblResult.Text = $"Для числа {number}: Условие выполнено ✅";
                }
                else
                {
                    lblResult.Text = $"Для числа {number}: Условие не выполнено ❌";
                }
            }
            else
            {
                lblResult.Text = "Введите двузначное число!";
            }
        }
    }
}

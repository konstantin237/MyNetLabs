using System;
using System.Linq;
using System.Windows.Forms;

namespace LabWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем значение x из текстового поля
                int x = int.Parse(txtInputX.Text);

                // Определяем значения a, b, c
                int a = x + 2;
                int b = x - 3;
                int c = x + 5;

                // Находим минимум среди a, b, c
                int minValue = Math.Min(a, Math.Min(b, c));
                int maxValue = Math.Max(a, Math.Max(b, c));

                double y;
                string formula;

                // Выбираем формулу в зависимости от минимального значения
                if (a == minValue)
                {
                    y = (a + 110 * c) / (6.0 * b);
                    formula = "(a + 110c) / 6b";
                }
                else if (b == minValue)
                {
                    y = (10 * c + 5 * a) / (14.0 * b);
                    formula = "(10c + 5a) / 14b";
                }
                else
                {
                    y = maxValue;
                    formula = "max(a, b, c)";
                }

                // Вывод результата
                txtOutputY.Text = y.ToString("F2");
                lblFormula.Text = "Использована формула: " + formula;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода! Убедитесь, что введено число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

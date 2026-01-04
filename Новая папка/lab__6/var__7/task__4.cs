using System;
using System.Linq;
using System.Windows.Forms;

namespace NumberCheckApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            // Получение введённого числа
            if (!long.TryParse(txtNumber.Text, out long number) || number <= 0)
            {
                MessageBox.Show("Введите натуральное число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получение параметров
            if (!int.TryParse(txtK.Text, out int k) ||
                !int.TryParse(txtB.Text, out int b) ||
                !int.TryParse(txtX.Text, out int x) ||
                !int.TryParse(txtY.Text, out int y) ||
                !int.TryParse(txtP.Text, out int p) ||
                !int.TryParse(txtBigB.Text, out int B) ||
                !int.TryParse(txtM.Text, out int m) ||
                !int.TryParse(txtN.Text, out int n))
            {
                MessageBox.Show("Введите корректные значения параметров!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Разбиваем число на цифры
            int[] digits = number.ToString().Select(c => c - '0').ToArray();

            // (a) Проверяем сумму цифр > k и чётность числа
            int sumDigits = digits.Sum();
            bool conditionA = (sumDigits > k) && (number % 2 == 0);

            // (b) Проверяем чётность количества цифр и ограничение на b
            bool conditionB = (digits.Length % 2 == 0) && (number <= b);

            // (c) Проверяем, начинается ли число с x и заканчивается на y
            bool conditionC = (digits.First() == x) && (digits.Last() == y);

            // (d) Проверяем произведение цифр и делимость на B
            int productDigits = digits.Aggregate(1, (acc, digit) => acc * digit);
            bool conditionD = (productDigits < p) && (number % B == 0);

            // (e) Проверяем сумму цифр > m и делимость на n
            bool conditionE = (sumDigits > m) && (number % n == 0);

            // Вывод результатов
            txtResult.Text = $"a) {conditionA}\r\n" +
                             $"b) {conditionB}\r\n" +
                             $"c) {conditionC}\r\n" +
                             $"d) {conditionD}\r\n" +
                             $"e) {conditionE}";
        }
    }
}

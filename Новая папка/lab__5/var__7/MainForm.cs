using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeometryApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Читаем координаты, проверяем корректность ввода
                if (!double.TryParse(txtAx.Text, out double ax) ||
                    !double.TryParse(txtAy.Text, out double ay) ||
                    !double.TryParse(txtBx.Text, out double bx) ||
                    !double.TryParse(txtBy.Text, out double by) ||
                    !double.TryParse(txtCx.Text, out double cx) ||
                    !double.TryParse(txtCy.Text, out double cy))
                {
                    throw new FormatException("Ошибка: Введите корректные числовые значения.");
                }

                // Вычисляем координаты четвертой точки D
                double dx = ax + (cx - bx);
                double dy = ay + (cy - by);

                // Проверяем, можно ли построить прямоугольник
                if (!IsRectangle(ax, ay, bx, by, cx, cy, dx, dy))
                {
                    throw new InvalidOperationException("Невозможно построить прямоугольник по заданным точкам.");
                }

                // Вычисляем площадь прямоугольного треугольника AVD
                double area = 0.5 * Math.Abs((dx - ax) * (dy - ay));

                lblResult.Text = $"Координаты точки D: ({dx}, {dy})\n" +
                                 $"Площадь треугольника AVD: {area:F2}";

                // Блокируем поля ввода и скрываем кнопку "Рассчитать"
                ToggleControls(false);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неизвестная ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Очистка полей ввода и результата
            txtAx.Clear();
            txtAy.Clear();
            txtBx.Clear();
            txtBy.Clear();
            txtCx.Clear();
            txtCy.Clear();
            lblResult.Text = "";

            // Разблокируем поля и показываем кнопку "Рассчитать"
            ToggleControls(true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool IsRectangle(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy)
        {
            // Проверяем, образуют ли точки прямоугольник (угол 90°)
            double ab = Distance(ax, ay, bx, by);
            double bc = Distance(bx, by, cx, cy);
            double cd = Distance(cx, cy, dx, dy);
            double da = Distance(dx, dy, ax, ay);
            double ac = Distance(ax, ay, cx, cy);
            double bd = Distance(bx, by, dx, dy);

            return Math.Abs(ab * bc + cd * da) < 1e-6 && Math.Abs(ac * bd) < 1e-6;
        }

        private double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        private void ToggleControls(bool enable)
        {
            txtAx.Enabled = enable;
            txtAy.Enabled = enable;
            txtBx.Enabled = enable;
            txtBy.Enabled = enable;
            txtCx.Enabled = enable;
            txtCy.Enabled = enable;
            btnCalculate.Visible = enable;
        }
    }
}

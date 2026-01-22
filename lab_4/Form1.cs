using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace lab_4
{
    public partial class Form1 : Form
    {
        TextBox txtAx, txtAy, txtBx, txtBy, txtCx, txtCy;
        Button btnSolve, btnClear;
        Label lblResult;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Лабораторная работа №4, вариант 7";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(520, 380);

            InitializeControls();
        }

        private void InitializeControls()
        {
            Label lblTask = new Label();
            lblTask.Text =
                "Даны три точки A, B, C. Предполагая, что ABCD – прямоугольник,\n" +
                "определить площадь прямоугольного треугольника ABD.\n" +
                "Если прямоугольник построить невозможно – выдать сообщение.";
            lblTask.Location = new Point(10, 10);
            lblTask.Size = new Size(480, 60);
            this.Controls.Add(lblTask);

            int y = 80;
            CreatePointInput("A", 10, y, out txtAx, out txtAy);
            CreatePointInput("B", 170, y, out txtBx, out txtBy);
            CreatePointInput("C", 330, y, out txtCx, out txtCy);

            btnSolve = new Button();
            btnSolve.Text = "Решить";
            btnSolve.Location = new Point(100, 200);
            btnSolve.Click += new EventHandler(BtnSolve_Click);
            this.Controls.Add(btnSolve);

            btnClear = new Button();
            btnClear.Text = "Очистить";
            btnClear.Location = new Point(260, 200);
            btnClear.Visible = false; // при первом запуске скрыта
            btnClear.Click += new EventHandler(BtnClear_Click);
            this.Controls.Add(btnClear);

            lblResult = new Label();
            lblResult.Location = new Point(10, 250);
            lblResult.Size = new Size(480, 80);
            lblResult.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(lblResult);
        }

        private void CreatePointInput(string name, int x, int y, out TextBox txtX, out TextBox txtY)
        {
            // Заголовок точки
            Label lblPoint = new Label();
            lblPoint.Text = "Точка " + name;
            lblPoint.Location = new Point(x, y);
            lblPoint.Size = new Size(120, 20);
            this.Controls.Add(lblPoint);

            // Метка X
            Label lblX = new Label();
            lblX.Text = "X:";
            lblX.AutoSize = true;
            lblX.Location = new Point(x, y + 30);
            this.Controls.Add(lblX);

            // Поле ввода X (сдвинуто далеко вправо)
            txtX = new TextBox();
            txtX.Location = new Point(x + 40, y + 27);
            txtX.Size = new Size(80, 20);
            this.Controls.Add(txtX);

            // Метка Y
            Label lblY = new Label();
            lblY.Text = "Y:";
            lblY.AutoSize = true;
            lblY.Location = new Point(x, y + 60);
            this.Controls.Add(lblY);

            // Поле ввода Y (сдвинуто далеко вправо)
            txtY = new TextBox();
            txtY.Location = new Point(x + 40, y + 57);
            txtY.Size = new Size(80, 20);
            this.Controls.Add(txtY);
        }


        private void BtnSolve_Click(object sender, EventArgs e)
        {
            try
            {
                // Исключение №1 — неверный формат ввода
                double ax = ParseDouble(txtAx.Text);
                double ay = ParseDouble(txtAy.Text);
                double bx = ParseDouble(txtBx.Text);
                double by = ParseDouble(txtBy.Text);
                double cx = ParseDouble(txtCx.Text);
                double cy = ParseDouble(txtCy.Text);

                // Проверка прямого угла в точке B
                if (!IsRightAngle(ax, ay, bx, by, cx, cy))
                {
                    // Исключение №2 — логическая ошибка
                    throw new InvalidOperationException(
                        "По заданным точкам невозможно построить прямоугольник."
                    );
                }

                double area = TriangleArea(ax, ay, bx, by, cx, cy);

                lblResult.Text =
                    "Точки:\n" +
                    "A(" + ax + ", " + ay + ")\n" +
                    "B(" + bx + ", " + by + ")\n" +
                    "C(" + cx + ", " + cy + ")\n" +
                    "Треугольник ABD является прямоугольным.\n" +
                    "Площадь треугольника ABD = " + area.ToString("F3");

                LockInputs();
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Ошибка ввода координат. Введите числовые значения.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private double ParseDouble(string text)
        {
            return double.Parse(text.Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        // Проверка прямого угла в точке B через скалярное произведение
        private bool IsRightAngle(double ax, double ay, double bx, double by, double cx, double cy)
        {
            double abx = ax - bx;
            double aby = ay - by;
            double cbx = cx - bx;
            double cby = cy - by;

            double dot = abx * cbx + aby * cby;
            return Math.Abs(dot) < 1e-6;
        }

        // Площадь прямоугольного треугольника
        private double TriangleArea(double ax, double ay, double bx, double by, double cx, double cy)
        {
            double ab = Distance(ax, ay, bx, by);
            double bc = Distance(bx, by, cx, cy);
            return ab * bc / 2.0;
        }

        private double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(
                (x1 - x2) * (x1 - x2) +
                (y1 - y2) * (y1 - y2)
            );
        }

        private void LockInputs()
        {
            txtAx.Enabled = false;
            txtAy.Enabled = false;
            txtBx.Enabled = false;
            txtBy.Enabled = false;
            txtCx.Enabled = false;
            txtCy.Enabled = false;

            btnSolve.Visible = false;
            btnClear.Visible = true;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtAx.Text = "";
            txtAy.Text = "";
            txtBx.Text = "";
            txtBy.Text = "";
            txtCx.Text = "";
            txtCy.Text = "";

            txtAx.Enabled = true;
            txtAy.Enabled = true;
            txtBx.Enabled = true;
            txtBy.Enabled = true;
            txtCx.Enabled = true;
            txtCy.Enabled = true;

            lblResult.Text = "";

            btnSolve.Visible = true;
            btnClear.Visible = false; // снова скрыта
        }
    }
}

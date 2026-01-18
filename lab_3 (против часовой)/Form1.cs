using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab_3
{
    public partial class Form1 : Form
    {
        private TextBox tbX, tbY, tbRegion;
        private Label lblX, lblY, lblRegion;
        private Button btnDraw, btnClear;
        private Graphics g;


        public Form1()
        {
            this.Text = "Лабораторная работа №3, вариант 7";
            this.Width = 600;
            this.Height = 600;

            // ===== ПОДПИСИ =====
            lblX = new Label() { Left = 20, Top = 10, Width = 50, Text = "X" };
            lblY = new Label() { Left = 100, Top = 10, Width = 50, Text = "Y" };
            lblRegion = new Label()
            {
                Left = 180,
                Top = 10,
                Width = 100,
                Text = "Область (1–4)"
            };

            // ===== ПОЛЯ ВВОДА =====
            tbX = new TextBox() { Left = 20, Top = 35, Width = 60 };
            tbY = new TextBox() { Left = 100, Top = 35, Width = 60 };
            tbRegion = new TextBox() { Left = 180, Top = 35, Width = 60 };

            btnDraw = new Button() { Left = 260, Top = 35, Text = "Проверить" };
            btnClear = new Button() { Left = 360, Top = 35, Text = "Очистить" };





            btnDraw.Click += DrawClick;
            btnClear.Click += ClearClick;

            // ===== ДОБАВЛЕНИЕ НА ФОРМУ =====
            this.Controls.Add(lblX);
            this.Controls.Add(lblY);
            this.Controls.Add(lblRegion);

            this.Controls.Add(tbX);
            this.Controls.Add(tbY);
            this.Controls.Add(tbRegion);
            this.Controls.Add(btnDraw);
            this.Controls.Add(btnClear);

            this.Paint += DrawAxes;
        }


        void DrawAxes(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            int cx = ClientSize.Width / 2;
            int cy = ClientSize.Height / 2;

            g.DrawLine(Pens.Black, cx, 0, cx, ClientSize.Height);
            g.DrawLine(Pens.Black, 0, cy, ClientSize.Width, cy);

            Point[] rhombus =
            {
                new Point(cx + 120, cy),
                new Point(cx, cy - 120),
                new Point(cx - 120, cy),
                new Point(cx, cy + 120)
            };

            g.DrawPolygon(Pens.Blue, rhombus);
        }

        void DrawClick(object sender, EventArgs e)
        {
            int x, y, region;

            if (!int.TryParse(tbX.Text, out x) ||
                !int.TryParse(tbY.Text, out y) ||
                !int.TryParse(tbRegion.Text, out region))
            {
                MessageBox.Show("Введите X, Y и номер области (1–4)");
                return;
            }

            bool result = IsPointInRegion(x, y, region);

            bool[] quarters = GetQuarters(x, y);

            // Формируем красивый вывод четвертей
            string quarterInfo = string.Format(
                "Четверть 1 (верхняя левая): {0}\n" +
                "Четверть 2 (верхняя правая): {1}\n" +
                "Четверть 3 (нижняя правая): {2}\n" +
                "Четверть 4 (нижняя левая): {3}",
                quarters[0] ? "true" : "false",
                quarters[1] ? "true" : "false",
                quarters[3] ? "true" : "false",
                quarters[2] ? "true" : "false"
            );

            int cx = ClientSize.Width / 2;
            int cy = ClientSize.Height / 2;

            Graphics gr = this.CreateGraphics();

            Brush b = result ? Brushes.Green : Brushes.Red;
            gr.FillEllipse(b, cx + x * 10 - 4, cy - y * 10 - 4, 8, 8);

            // Показываем результат проверки и информацию о четвертях
            MessageBox.Show(
                (result ? "Точка принадлежит области" : "Точка НЕ принадлежит области") +
                "\n\n" + quarterInfo
            );
        }


        void ClearClick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        // ===== МЕТОД 1 =====
        static bool[] GetQuarters(double x, double y)
        {
            return new bool[]
            {
        x < 0 && y > 0,   // верхняя левая
        x >= 0 && y > 0,  // верхняя правая
        x < 0 && y <= 0,  // нижняя левая
        x >= 0 && y <= 0  // нижняя правая
            };
        }

        // ===== МЕТОД 2 =====
        static bool IsPointInRegion(double x, double y, int region)
        {
            bool inside = Math.Abs(x) + Math.Abs(y) <= 12;
            bool[] q = GetQuarters(x, y);

            if (q[0]) return inside ? region == 2 : region == 3;
            if (q[1]) return inside ? region == 1 : region == 4;
            if (q[2]) return inside ? region == 1 : region == 3;
            if (q[3]) return inside ? region == 2 : region == 4;

            return false;
        }
    }
}

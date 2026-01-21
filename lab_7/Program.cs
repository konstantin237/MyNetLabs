using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace lab_7
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    // ===== КЛАСС ПОЛИНОМ =====
    public class Polynomial
    {
        public int Degree;
        public double LeadingCoeff;
        public double[] Roots;

        public Polynomial(int degree, double leadingCoeff, double[] roots)
        {
            Degree = degree;
            LeadingCoeff = leadingCoeff;
            Roots = roots;
        }

        // Построение коэффициентов по корням
        // P(x) = a * (x - r1)(x - r2)...
        public double[] BuildCoefficients()
        {
            List<double> coeffs = new List<double>();
            coeffs.Add(1.0);

            foreach (double r in Roots)
            {
                List<double> newCoeffs = new List<double>();
                newCoeffs.Add(-r * coeffs[0]);

                for (int i = 1; i < coeffs.Count; i++)
                    newCoeffs.Add(coeffs[i - 1] - r * coeffs[i]);

                newCoeffs.Add(coeffs[coeffs.Count - 1]);
                coeffs = newCoeffs;
            }

            for (int i = 0; i < coeffs.Count; i++)
                coeffs[i] *= LeadingCoeff;

            return coeffs.ToArray();
        }

        // Перемножение полиномов
        public static double[] Multiply(double[] a, double[] b)
        {
            double[] res = new double[a.Length + b.Length - 1];

            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < b.Length; j++)
                    res[i + j] += a[i] * b[j];

            return res;
        }

        // Преобразование в строку
        public static string ToString(double[] coeffs)
        {
            int n = coeffs.Length - 1;
            string s = "";

            for (int i = 0; i < coeffs.Length; i++)
            {
                double c = coeffs[i];
                int p = n - i;
                if (Math.Abs(c) < 1e-9) continue;

                if (s.Length > 0 && c > 0) s += " + ";
                if (c < 0) s += " - ";

                double a = Math.Abs(c);
                if (!(a == 1 && p > 0))
                    s += a.ToString("0.###");

                if (p > 0)
                {
                    s += "x";
                    if (p > 1) s += "^" + p;
                }
            }

            return s == "" ? "0" : s;
        }
    }

    // ===== ОСНОВНАЯ ФОРМА =====
    public class MainForm : Form
    {
        TextBox txtDegP, txtDegQ;
        TextBox txtCoefP, txtCoefQ;
        Button btnBuild, btnExec, btnReset;
        DataGridView gridP, gridQ;
        Label lblResult;

        public MainForm()
        {
            Text = "Полиномы: произведение по корням";
            Width = 900;
            Height = 600;
            Init();
        }

        void Init()
        {
            // ===== ВВОД СТЕПЕНЕЙ И КОЭФФИЦИЕНТОВ =====
            Controls.Add(new Label { Text = "Степень P(x):", Location = new Point(10, 10) });
            txtDegP = new TextBox { Location = new Point(120, 10) };
            Controls.Add(txtDegP);

            Controls.Add(new Label { Text = "Старший коэффициент P(x):", Location = new Point(260, 10) });
            txtCoefP = new TextBox { Location = new Point(460, 10), Text = "1" };
            Controls.Add(txtCoefP);

            Controls.Add(new Label { Text = "Степень Q(x):", Location = new Point(10, 40) });
            txtDegQ = new TextBox { Location = new Point(120, 40) };
            Controls.Add(txtDegQ);

            Controls.Add(new Label { Text = "Старший коэффициент Q(x):", Location = new Point(260, 40) });
            txtCoefQ = new TextBox { Location = new Point(460, 40), Text = "1" };
            Controls.Add(txtCoefQ);

            // ===== КНОПКИ =====
            btnBuild = new Button { Text = "Построить шаблоны", Location = new Point(10, 80) };
            btnBuild.Click += Build;
            Controls.Add(btnBuild);

            btnExec = new Button { Text = "Выполнить", Location = new Point(200, 80), Enabled = false };
            btnExec.Click += Execute;
            Controls.Add(btnExec);

            btnReset = new Button { Text = "Сброс", Location = new Point(320, 80), Enabled = false };
            btnReset.Click += Reset;
            Controls.Add(btnReset);

            // ===== ПОДПИСИ ТАБЛИЦ =====
            Controls.Add(new Label { Text = "Корни P(x)", Location = new Point(10, 115), Font = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold) });
            Controls.Add(new Label { Text = "Корни Q(x)", Location = new Point(430, 115), Font = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold) });

            // ===== ТАБЛИЦЫ =====
            gridP = new DataGridView { Location = new Point(10, 140), Width = 400, Height = 200 };
            gridQ = new DataGridView { Location = new Point(430, 140), Width = 400, Height = 200 };
            Controls.Add(gridP);
            Controls.Add(gridQ);

            // ===== РЕЗУЛЬТАТ =====
            lblResult = new Label
            {
                Location = new Point(10, 360),
                Width = 820,
                Height = 200,
                Font = new Font(FontFamily.GenericSansSerif, 10)
            };
            Controls.Add(lblResult);
        }

        void Build(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDegP.Text, out int dP) || dP <= 0 ||
                !int.TryParse(txtDegQ.Text, out int dQ) || dQ <= 0)
            {
                MessageBox.Show("Неверно введена степень");
                return;
            }

            BuildGrid(gridP, dP);
            BuildGrid(gridQ, dQ);

            txtDegP.Enabled = txtDegQ.Enabled = false;
            txtCoefP.Enabled = txtCoefQ.Enabled = false;
            btnBuild.Enabled = false;

            btnExec.Enabled = btnReset.Enabled = true;
        }

        void BuildGrid(DataGridView g, int d)
        {
            g.Columns.Clear();
            g.Rows.Clear();
            g.ColumnCount = 1;
            g.Columns[0].Name = "Корень";
            for (int i = 0; i < d; i++) g.Rows.Add();
        }

        void Execute(object sender, EventArgs e)
        {
            try
            {
                Polynomial P = Read(gridP, txtCoefP);
                Polynomial Q = Read(gridQ, txtCoefQ);

                double[] a = P.BuildCoefficients();
                double[] b = Q.BuildCoefficients();
                double[] r = Polynomial.Multiply(a, b);

                lblResult.Text =
                    "P(x) = " + Polynomial.ToString(a) + "\n\n" +
                    "Q(x) = " + Polynomial.ToString(b) + "\n\n" +
                    "R(x) = P(x) · Q(x) = " + Polynomial.ToString(r);

                gridP.Enabled = gridQ.Enabled = false;
                btnExec.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Ошибка ввода корней");
            }
        }

        Polynomial Read(DataGridView g, TextBox coef)
        {
            int d = g.Rows.Count;
            double a = Convert.ToDouble(coef.Text);
            double[] r = new double[d];

            for (int i = 0; i < d; i++)
                r[i] = Convert.ToDouble(g.Rows[i].Cells[0].Value);

            return new Polynomial(d, a, r);
        }

        void Reset(object sender, EventArgs e)
        {
            txtDegP.Text = txtDegQ.Text = "";
            txtCoefP.Text = txtCoefQ.Text = "1";

            txtDegP.Enabled = txtDegQ.Enabled = true;
            txtCoefP.Enabled = txtCoefQ.Enabled = true;

            btnBuild.Enabled = true;
            btnExec.Enabled = btnReset.Enabled = false;

            gridP.Columns.Clear();
            gridQ.Columns.Clear();
            gridP.Enabled = gridQ.Enabled = true;

            lblResult.Text = "";
        }
    }




}

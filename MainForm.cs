using System;
using System.Drawing;
using System.Windows.Forms;
using MultiToolLibrary;

namespace MultiToolWinForm
{
    public class MainForm : Form
    {
        private Label lblA, lblB, lblC;
        private TextBox txtA, txtB, txtC;
        private Button btnSolve;
        private TextBox txtOut;

        public MainForm()
        {
            this.Text = "Quadratic Solver - WinForm (TrungLe)";
            this.Width = 700;
            this.Height = 420;

            lblA = new Label(); lblA.Text = "a:"; lblA.Left = 10; lblA.Top = 10; lblA.Width = 20;
            this.Controls.Add(lblA);
            txtA = new TextBox(); txtA.Left = 40; txtA.Top = 8; txtA.Width = 120; txtA.Text = "1";
            this.Controls.Add(txtA);

            lblB = new Label(); lblB.Text = "b:"; lblB.Left = 180; lblB.Top = 10; lblB.Width = 20;
            this.Controls.Add(lblB);
            txtB = new TextBox(); txtB.Left = 210; txtB.Top = 8; txtB.Width = 120; txtB.Text = "0";
            this.Controls.Add(txtB);

            lblC = new Label(); lblC.Text = "c:"; lblC.Left = 350; lblC.Top = 10; lblC.Width = 20;
            this.Controls.Add(lblC);
            txtC = new TextBox(); txtC.Left = 380; txtC.Top = 8; txtC.Width = 120; txtC.Text = "-1";
            this.Controls.Add(txtC);

            btnSolve = new Button(); btnSolve.Text = "Solve"; btnSolve.Left = 520; btnSolve.Top = 6; btnSolve.Width = 120;
            btnSolve.Click += new EventHandler(btnSolve_Click);
            this.Controls.Add(btnSolve);

            txtOut = new TextBox(); txtOut.Left = 10; txtOut.Top = 40; txtOut.Width = 650; txtOut.Height = 320;
            txtOut.Multiline = true; txtOut.ScrollBars = ScrollBars.Both; txtOut.Font = new Font(FontFamily.GenericMonospace, 10);
            this.Controls.Add(txtOut);
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtA.Text);
                double b = double.Parse(txtB.Text);
                double c = double.Parse(txtC.Text);

                QuadraticSolver solver = new QuadraticSolver();
                solver.A = a; solver.B = b; solver.C = c;
                QuadraticResult res = solver.Solve();

                txtOut.Text = "";
                txtOut.AppendText("Nature: " + res.Nature + Environment.NewLine);
                if (!double.IsNaN(res.Discriminant))
                    txtOut.AppendText("Discriminant: " + res.Discriminant.ToString("0.######") + Environment.NewLine);
                if (res.Root1 != null && res.Root1.Length > 0)
                    txtOut.AppendText("Root 1: " + res.Root1 + Environment.NewLine);
                if (res.Root2 != null && res.Root2.Length > 0)
                    txtOut.AppendText("Root 2: " + res.Root2 + Environment.NewLine);
                txtOut.AppendText(Environment.NewLine);
                txtOut.AppendText(res.Art + Environment.NewLine);
                txtOut.AppendText(res.Signature + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

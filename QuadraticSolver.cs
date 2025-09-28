using System;
using System.Text;

namespace MultiToolLibrary
{
    // Kết quả
    public class QuadraticResult
    {
        private double discriminant;
        private string root1;
        private string root2;
        private string nature;
        private string signature;
        private string art;

        public QuadraticResult() { }

        public double Discriminant { get { return discriminant; } set { discriminant = value; } }
        public string Root1 { get { return root1; } set { root1 = value; } }
        public string Root2 { get { return root2; } set { root2 = value; } }
        public string Nature { get { return nature; } set { nature = value; } }
        public string Signature { get { return signature; } set { signature = value; } }
        public string Art { get { return art; } set { art = value; } }

        // Trả về JSON đơn giản (thủ công)
        public string ToJson()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.AppendFormat("\"discriminant\":{0},", discriminant);
            sb.AppendFormat("\"root1\":\"{0}\",", EscapeJson(root1));
            sb.AppendFormat("\"root2\":\"{0}\",", EscapeJson(root2));
            sb.AppendFormat("\"nature\":\"{0}\",", EscapeJson(nature));
            sb.AppendFormat("\"signature\":\"{0}\",", EscapeJson(signature));
            sb.AppendFormat("\"art\":\"{0}\"", EscapeJson(art));
            sb.Append("}");
            return sb.ToString();
        }

        private string EscapeJson(string s)
        {
            if (s == null) return "";
            return s.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "\\r").Replace("\n", "\\n");
        }
    }

    // Class solver (DLL độc lập)
    public class QuadraticSolver
    {
        private double a;
        private double b;
        private double c;
        private QuadraticResult result;

        public QuadraticSolver()
        {
            a = 0.0; b = 0.0; c = 0.0;
            result = null;
        }

        // Thuộc tính input
        public double A { get { return a; } set { a = value; } }
        public double B { get { return b; } set { b = value; } }
        public double C { get { return c; } set { c = value; } }

        // Kết quả sau Solve()
        public QuadraticResult Result { get { return result; } }

        // Solve: xử lý và trả về QuadraticResult
        public QuadraticResult Solve()
        {
            QuadraticResult r = new QuadraticResult();
            // signature cá nhân dựa trên hệ số
            r.Signature = GenerateSignature();

            // ASCII-art nhỏ: dựa trên dấu delta
            r.Art = GenerateArt();

            // Nếu a == 0 => không phải bậc 2
            if (Math.Abs(a) < 1e-12)
            {
                r.Nature = "Not quadratic (a == 0)";
                // Nếu b != 0 => linear bx + c = 0
                if (Math.Abs(b) > 1e-12)
                {
                    double x = -c / b;
                    r.Discriminant = double.NaN;
                    r.Root1 = FormatDouble(x);
                    r.Root2 = "";
                }
                else
                {
                    // b == 0
                    if (Math.Abs(c) < 1e-12)
                    {
                        r.Root1 = "";
                        r.Root2 = "";
                        r.Nature = "Infinite solutions (0=0)";
                    }
                    else
                    {
                        r.Root1 = "";
                        r.Root2 = "";
                        r.Nature = "No solution (constant != 0)";
                    }
                }
                this.result = r;
                return r;
            }

            double delta = b * b - 4.0 * a * c;
            r.Discriminant = delta;

            if (delta > 1e-12)
            {
                r.Nature = "Two distinct real roots";
                double sqrt = Math.Sqrt(delta);
                double x1 = (-b + sqrt) / (2.0 * a);
                double x2 = (-b - sqrt) / (2.0 * a);
                r.Root1 = FormatDouble(x1);
                r.Root2 = FormatDouble(x2);
            }
            else if (Math.Abs(delta) <= 1e-12)
            {
                r.Nature = "One real root (double)";
                double x = -b / (2.0 * a);
                r.Root1 = FormatDouble(x);
                r.Root2 = r.Root1;
            }
            else // delta < 0
            {
                r.Nature = "Two complex roots";
                double real = -b / (2.0 * a);
                double imag = Math.Sqrt(-delta) / (2.0 * a);
                r.Root1 = FormatComplex(real, imag);
                r.Root2 = FormatComplex(real, -imag);
            }

            this.result = r;
            return r;
        }

        private string FormatDouble(double v)
        {
            // Giữ 6 chữ số thập phân tối đa, xóa trailing zeros
            string s = v.ToString("0.######");
            return s;
        }

        private string FormatComplex(double re, double im)
        {
            string sre = FormatDouble(re);
            string sim = FormatDouble(Math.Abs(im));
            if (im >= 0)
                return sre + " + " + sim + "i";
            else
                return sre + " - " + sim + "i";
        }

        private string GenerateSignature()
        {
            // Dấu ấn cá nhân: kết hợp chữ "TrungLê" + hash đơn giản từ a,b,c
            int h = 17;
            h = h * 23 + (int)Math.Round(a * 1000);
            h = h * 23 + (int)Math.Round(b * 1000);
            h = h * 23 + (int)Math.Round(c * 1000);
            int tag = Math.Abs(h % 10000);
            return "Signature: TrungLe#" + tag.ToString();
        }

        private string GenerateArt()
        {
            // art đơn giản: biểu tượng delta lớn nếu delta >=0, else khác
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  ___  ");
            sb.AppendLine(" / _ \\ ");
            sb.AppendLine("| (_) |  Quadratic solver by TrungLe");
            sb.AppendLine(" \\___/ ");
            return sb.ToString();
        }
    }
}

using System;
using System.Web;
using MultiToolLibrary;

public partial class api : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "application/json";

        double a = double.Parse(Request.Form["a"]);
        double b = double.Parse(Request.Form["b"]);
        double c = double.Parse(Request.Form["c"]);

        QuadraticSolver solver = new QuadraticSolver();
        QuadraticResult result = solver.Solve();

        string json = result.ToJson();
        Response.Write(json);
        Response.End();
    }
}
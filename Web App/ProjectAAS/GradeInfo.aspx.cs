using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAAS
{
    public partial class GradeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                if (this.Request["FNumber"] != null)
                {
                    string param = this.Request["fnumber"];
                    this.LoadData(param);
                }
                else
                {
                    this.Response.Redirect("Grades.aspx");
                }
            }
        }

        private void LoadData(string param)
        {
            int facultyNum = 0;
            try
            {
                facultyNum = Convert.ToInt32(param);
            }
            catch
            {
                this.Response.Redirect("Grades.aspx");
            }
            Configurator configurator = new Configurator();
            Grade grade = configurator.LoadGradesByFacultyNumber(facultyNum);
            this.TextBoxFacultyNumber.Text = grade.FNumber.ToString();
            this.TextBoxSubjectID.Text = grade.SubjectId.ToString();
            this.TextBoxFinalGrade.Text = grade.FinalGrade.ToString();


            this.ViewState["FNumber"] = facultyNum;
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (this.ViewState["FNumber"] != null)
            {
                int fnumber = Convert.ToInt32(this.ViewState["FNumber"]);
                Configurator configurator = new Configurator();
                configurator.UpdateGrade(
                    fnumber,
                    Convert.ToInt32(this.TextBoxFinalGrade.Text));

                this.Response.Redirect("Grades.aspx");
            }
        }
    }
}
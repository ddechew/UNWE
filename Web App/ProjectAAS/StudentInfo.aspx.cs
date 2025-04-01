using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAAS
{
    public partial class StudentInfo : System.Web.UI.Page
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
                    this.Response.Redirect("Students.aspx");
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
                this.Response.Redirect("Students.aspx");
            }
            Configurator configurator = new Configurator();
            Student student = configurator.LoadStudentByFacultyNumber(facultyNum);
            this.TextBoxFacultyNumber.Text = student.FNumber.ToString();
            this.TextBoxSpecialtyId.Text = student.SpecialtyId.ToString();
            this.TextBoxFirstName.Text = student.FName;
            this.TextBoxMiddleName.Text = student.MName;
            this.TextBoxLastName.Text = student.LName;
            this.TextBoxAddress.Text = student.Address;
            this.TextBoxPhone.Text = student.Phone;
            this.TextBoxEmail.Text = student.Email;


            this.ViewState["FNumber"] = facultyNum;
        }


        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (this.ViewState["FNumber"] != null)
            {
                int fnumber = Convert.ToInt32(this.ViewState["FNumber"]);
                Configurator configurator = new Configurator();
                configurator.UpdateStudent(
                    fnumber, 
                    Convert.ToInt32(this.TextBoxSpecialtyId.Text), 
                    this.TextBoxFirstName.Text, 
                    this.TextBoxMiddleName.Text,
                    this.TextBoxLastName.Text,
                    this.TextBoxAddress.Text,
                    this.TextBoxPhone.Text,
                    this.TextBoxEmail.Text);
                this.Response.Redirect("Students.aspx");
            }
        }
    }
}
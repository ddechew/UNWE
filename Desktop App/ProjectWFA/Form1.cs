using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void specialtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSpecialty fSpecialty = new FormSpecialty(); 
            fSpecialty.ShowDialog();
        }

        private void subjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSubject fSubject = new FormSubject(); 
            fSubject.ShowDialog();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStudent fStudent = new FormStudent();
            fStudent.ShowDialog();
        }

        private void gradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGrade fGrade = new FormGrade(); 
            fGrade.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void specialtyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormViewSpecialties fvViewSpecialties = new FormViewSpecialties();
            fvViewSpecialties.ShowDialog();
        }

        private void subjecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormViewSubjects fvViewSubjects = new FormViewSubjects();
            fvViewSubjects.ShowDialog();
        }

        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormViewStudents fvViewStudents = new FormViewStudents();
            fvViewStudents.ShowDialog();
        }

        private void gradeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormViewGrades fvViewGrades = new FormViewGrades();
            fvViewGrades.ShowDialog();
        }
    }
}

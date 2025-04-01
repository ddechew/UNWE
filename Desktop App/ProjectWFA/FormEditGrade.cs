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
    public partial class FormEditGrade : Form
    {
        private int fNumber;
        private DataGridView dataGridView;

        public FormEditGrade()
        {
            InitializeComponent();
        }

        public void Init(int fNumber, int subjectId, int finalGrade, DataGridView dataGridView)
        {
            this.fNumber = fNumber;
            this.comboBoxStudent.Text = fNumber.ToString();
            this.comboBoxSubject.Text = subjectId.ToString();
            this.dataGridView = dataGridView;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Configurator configurator = new Configurator();
            configurator.UpdateGrade(
                Convert.ToInt32(this.comboBoxStudent.Text), 
                Convert.ToInt32(this.comboBoxSubject.Text), 
                Convert.ToInt32(this.numericUpDownFinalGrade.Value));

            DataTable dTable = configurator.LoadGrades();
            dataGridView.DataSource = dTable;
            dataGridView.Refresh();
            this.Close();
        }
    }
}

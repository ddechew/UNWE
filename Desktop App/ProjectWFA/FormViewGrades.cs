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
    public partial class FormViewGrades : Form
    {
        private DataGridView dataGridView;
        public FormViewGrades()
        {
            InitializeComponent();
            dataGridView = this.dataGridViewGrades;
        }

        private void FormViewGrades_Load(object sender, EventArgs e)
        {
            Configurator configurator = new Configurator();
            DataTable dTable = configurator.LoadGrades();
            dataGridView.DataSource = dTable;
            dataGridView.Refresh();
        }

        private void dataGridViewGrades_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int fNumber = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                int subjectId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[1].Value);
                int finalGrade = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[2].Value);

                FormEditGrade formEditGrade = new FormEditGrade();
                formEditGrade.Init(fNumber, subjectId, finalGrade, dataGridView);
                formEditGrade.ShowDialog();
            }
        }
    }
}

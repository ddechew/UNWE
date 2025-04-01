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
    public partial class FormViewStudents : Form
    {
        private DataGridView dataGridView;
        public FormViewStudents()
        {
            InitializeComponent();
            dataGridView = this.dataGridViewStudents;
        }

        private void FormViewStudents_Load(object sender, EventArgs e)
        {
            Configurator configurator = new Configurator();
            DataTable dTable = configurator.LoadStudents();
            dataGridView.DataSource = dTable;
            dataGridView.Refresh();
        }

        private void dataGridViewStudents_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int fNumber = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                int specialtyId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[1].Value);
                string fName = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                string mName = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                string lName = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                string address = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                string phone = dataGridView.SelectedRows[0].Cells[6].Value.ToString();
                string email = dataGridView.SelectedRows[0].Cells[7].Value.ToString();
                FormEditStudent formEditStudent = new FormEditStudent();
                formEditStudent.Init(fNumber, specialtyId, fName, mName, lName, address, phone, email, dataGridView);
                formEditStudent.ShowDialog();
            }
        }

        private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

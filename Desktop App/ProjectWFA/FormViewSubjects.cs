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
    public partial class FormViewSubjects : Form
    {
        private DataGridView dataGridView;

        public FormViewSubjects()
        {
            InitializeComponent();
            dataGridView = this.dataGridViewSubjects;
        }

        private void FormViewSubjects_Load(object sender, EventArgs e)
        {
            Configurator configurator = new Configurator();
            DataTable dTable = configurator.LoadSubjects();
            dataGridView.DataSource = dTable;
            dataGridView.Refresh();
        }

        private void dataGridViewSubjects_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                string name = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                FormEditSubject formEditSubject = new FormEditSubject();
                formEditSubject.Init(id, name, dataGridView);
                formEditSubject.ShowDialog();
            }
        }
    }
}

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
    public partial class FormViewSpecialties : Form
    {
        private DataGridView dataGridView;
        public FormViewSpecialties()
        {
            InitializeComponent();
            dataGridView = this.dataGridViewSpecialties;
        }

        private void FormViewSpecialties_Load(object sender, EventArgs e)
        {
            Configurator configurator = new Configurator();
            DataTable dTable = configurator.LoadSpecialties();
            dataGridView.DataSource = dTable;
            dataGridView.Refresh();
        }

        private void dataGridViewSpecialties_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                string name = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                FormEditSpecialty formEditSpecialty = new FormEditSpecialty();
                formEditSpecialty.Init(id, name, dataGridView);
                formEditSpecialty.ShowDialog();
            }
        }

        private void dataGridViewSpecialties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

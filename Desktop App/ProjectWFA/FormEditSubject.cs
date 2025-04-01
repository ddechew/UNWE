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
    public partial class FormEditSubject : Form
    {
        private int id;
        private DataGridView dataGridView;

        public FormEditSubject()
        {
            InitializeComponent();
        }

        public void Init(int id, string name, DataGridView dataGridView)
        {
            this.id = id;
            this.numericUpDownID.Value = id;
            this.textBoxName.Text = name;
            this.dataGridView = dataGridView;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Configurator configurator = new Configurator();
            configurator.UpdateSubject(this.id, (int)this.numericUpDownID.Value, this.textBoxName.Text);
            DataTable dTable = configurator.LoadSubjects();
            dataGridView.DataSource = dTable;
            dataGridView.Refresh();
            this.Close();
            // I decided to add automatic refresh upon clicking the save button for better user experience
        }

        private void FormEditSubject_Load(object sender, EventArgs e)
        {

        }
    }
}

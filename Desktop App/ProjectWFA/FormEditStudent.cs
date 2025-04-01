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
    public partial class FormEditStudent : Form
    {
        private int fNumber;
        private DataGridView dataGridView;

        public FormEditStudent()
        {
            InitializeComponent();
        }

        public void Init(int fNumber, int specialtyId, string fName, string mName, string lName, string address, string phone, string email, DataGridView dataGridView)
        {
            Configurator configurator = new Configurator();

            DataTable dTable = configurator.LoadSpecialties();

            this.comboBoxSpecialty.DataSource = dTable;
            this.comboBoxSpecialty.ValueMember = "id";
            this.comboBoxSpecialty.DisplayMember = "name";

            this.fNumber = fNumber;

            this.numericUpDownFNumber.Value = fNumber;
            this.comboBoxSpecialty.SelectedValue = specialtyId;
            this.textBoxFName.Text = fName;
            this.textBoxMName.Text = mName;
            this.textBoxLName.Text = lName;
            this.textBoxAddress.Text = address;
            this.textBoxPhone.Text = phone;
            this.textBoxEMail.Text = email;

            this.dataGridView = dataGridView;
        }

        // I added refresh upon click save here as well.
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Configurator configurator = new Configurator();
            configurator
                .UpdateStudent(this.fNumber,
                (int)this.numericUpDownFNumber.Value, 
                Convert.ToInt32(this.comboBoxSpecialty.SelectedValue), 
                this.textBoxFName.Text, 
                this.textBoxMName.Text, 
                this.textBoxLName.Text, 
                this.textBoxAddress.Text, 
                this.textBoxPhone.Text, 
                this.textBoxEMail.Text);

            DataTable dTable = configurator.LoadStudents();
            dataGridView.DataSource = dTable;
            dataGridView.Refresh();
            this.Close();
        }
    }
}

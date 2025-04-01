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
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
        }

        private void FormSubject_Load(object sender, EventArgs e)
        {
            Configurator configurator = new Configurator();
            DataTable dTable = configurator.LoadSpecialties();
            this.comboBoxSpecialty.DataSource = dTable; 
            this.comboBoxSpecialty.ValueMember = "id"; 
            this.comboBoxSpecialty.DisplayMember = "name";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Configurator configurator = new Configurator(); 
            configurator.SaveStudent((int)this.numericUpDownFNumber.Value, Convert.ToInt32(this.comboBoxSpecialty.SelectedValue), this.textBoxFName.Text, this.textBoxMName.Text, this.textBoxLName.Text, this.textBoxAddress.Text, this.textBoxPhone.Text, this.textBoxEMail.Text);
            this.Close();
        }

        private void comboBoxSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

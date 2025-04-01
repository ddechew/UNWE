namespace ProjectWFA
{
    partial class FormViewSpecialties
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewSpecialties = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpecialties)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSpecialties
            // 
            this.dataGridViewSpecialties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSpecialties.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewSpecialties.Name = "dataGridViewSpecialties";
            this.dataGridViewSpecialties.RowHeadersWidth = 51;
            this.dataGridViewSpecialties.RowTemplate.Height = 24;
            this.dataGridViewSpecialties.Size = new System.Drawing.Size(776, 363);
            this.dataGridViewSpecialties.TabIndex = 0;
            this.dataGridViewSpecialties.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSpecialties_CellContentClick);
            this.dataGridViewSpecialties.DoubleClick += new System.EventHandler(this.dataGridViewSpecialties_DoubleClick);
            // 
            // FormViewSpecialties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewSpecialties);
            this.Name = "FormViewSpecialties";
            this.Text = "FormViewSpecialties";
            this.Load += new System.EventHandler(this.FormViewSpecialties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpecialties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSpecialties;
    }
}
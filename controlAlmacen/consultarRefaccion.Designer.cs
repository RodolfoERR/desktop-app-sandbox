namespace controlAlmacen
{
    partial class consultarRefaccion
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
            comboBoxRefactions = new ComboBox();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBoxRefactions
            // 
            comboBoxRefactions.FormattingEnabled = true;
            comboBoxRefactions.Location = new Point(16, 12);
            comboBoxRefactions.Margin = new Padding(2);
            comboBoxRefactions.Name = "comboBoxRefactions";
            comboBoxRefactions.Size = new Size(373, 23);
            comboBoxRefactions.TabIndex = 3;
            comboBoxRefactions.Text = "🔍​ Buscar Refaccion o Subministro";
            comboBoxRefactions.SelectedIndexChanged += comboBoxRefactions_SelectedIndexChanged;
            comboBoxRefactions.TextChanged += comboBoxRefactions_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(comboBoxRefactions);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(404, 44);
            panel1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(29, 68);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(360, 333);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // consultarRefaccion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 450);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "consultarRefaccion";
            Text = "consultarRefaccion";
            Load += consultarRefaccion_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox comboBoxRefactions;
        private Panel panel1;
        private DataGridView dataGridView1;
    }
}
namespace controlAlmacen.Properties
{
    partial class main
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            panel1 = new Panel();
            button1 = new Button();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            comboBoxRefactions = new ComboBox();
            labelName = new Label();
            label2 = new Label();
            label1 = new Label();
            label9 = new Label();
            bindingSource1 = new BindingSource(components);
            huella = new PictureBox();
            label10 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)huella).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(3, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(180, 631);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(28, 291);
            button1.Name = "button1";
            button1.Size = new Size(129, 52);
            button1.TabIndex = 8;
            button1.Text = "Generar Huella Dactilar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.FlatStyle = FlatStyle.Popup;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(28, 335);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.FlatStyle = FlatStyle.Popup;
            label7.Font = new Font("Segoe UI Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(50, 291);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.FlatStyle = FlatStyle.Popup;
            label6.Font = new Font("Segoe UI Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(50, 248);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 5;
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Popup;
            label5.Font = new Font("Segoe UI Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(50, 208);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 4;
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Popup;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(28, 174);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 3;
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.FlatStyle = FlatStyle.Popup;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(28, 583);
            label3.Name = "label3";
            label3.Size = new Size(129, 22);
            label3.TabIndex = 2;
            label3.Text = "Cerrar Sesion ​👤​";
            label3.Click += label3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(9, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(164, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.Controls.Add(comboBoxRefactions);
            panel2.Controls.Add(labelName);
            panel2.Location = new Point(182, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(901, 46);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // comboBoxRefactions
            // 
            comboBoxRefactions.FormattingEnabled = true;
            comboBoxRefactions.Location = new Point(20, 14);
            comboBoxRefactions.Margin = new Padding(2);
            comboBoxRefactions.Name = "comboBoxRefactions";
            comboBoxRefactions.Size = new Size(420, 23);
            comboBoxRefactions.TabIndex = 2;
            comboBoxRefactions.Text = "🔍​ Seleccionar Refaccion o Subministro";
            comboBoxRefactions.SelectedIndexChanged += comboBoxRefactions_SelectedIndexChanged;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.FlatStyle = FlatStyle.Popup;
            labelName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelName.Location = new Point(796, 14);
            labelName.Name = "labelName";
            labelName.Size = new Size(49, 15);
            labelName.TabIndex = 1;
            labelName.Text = "User ​👤​";
            labelName.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(446, 362);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.Location = new Point(196, 108);
            label1.Name = "label1";
            label1.Size = new Size(875, 75);
            label1.TabIndex = 3;
            label1.Text = "Estimado/a colaborador/a,\r\n\r\nLe recordamos que, al retirar una refacción o suministro, es imprescindible registrar su huella dactilar.";
            label1.Click += label1_Click_1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F);
            label9.Location = new Point(285, 525);
            label9.Name = "label9";
            label9.Size = new Size(683, 25);
            label9.TabIndex = 4;
            label9.Text = " En caso contrario, no le será posible obtener la refacción o suministro deseado.";
            label9.Click += label9_Click;
            // 
            // huella
            // 
            huella.BackColor = SystemColors.ButtonShadow;
            huella.BackgroundImage = (Image)resources.GetObject("huella.BackgroundImage");
            huella.Location = new Point(468, 209);
            huella.Margin = new Padding(2);
            huella.Name = "huella";
            huella.Size = new Size(298, 293);
            huella.TabIndex = 5;
            huella.TabStop = false;
            huella.Click += pictureBox2_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(243, 561);
            label10.Name = "label10";
            label10.Size = new Size(784, 25);
            label10.TabIndex = 6;
            label10.Text = "Recuerda Generar tu HUELLA DACTILAR antes de proceder con el retiro de refacciones.";
            // 
            // main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 630);
            Controls.Add(label10);
            Controls.Add(huella);
            Controls.Add(label9);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "main";
            Load += main_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)huella).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label labelName;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label6;
        private Label label8;
        private Label label7;
        private ComboBox comboBoxRefactions;
        private Label label1;
        private Label label9;
        private BindingSource bindingSource1;
        private PictureBox huella;
        private Button button1;
        private Label label10;
    }
}
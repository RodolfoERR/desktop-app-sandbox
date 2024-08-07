namespace controlAlmacen
{
    partial class login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            bindingSource1 = new BindingSource(components);
            textBox1 = new TextBox();
            panel2 = new Panel();
            botonLogin = new Button();
            label2 = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Menu;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-2, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(405, 453);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(402, 453);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ButtonShadow;
            textBox1.Location = new Point(49, 81);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(179, 23);
            textBox1.TabIndex = 1;
            textBox1.UseWaitCursor = true;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.InactiveBorder;
            panel2.Controls.Add(botonLogin);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox1);
            panel2.Location = new Point(464, 82);
            panel2.Name = "panel2";
            panel2.Size = new Size(279, 274);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // botonLogin
            // 
            botonLogin.BackColor = SystemColors.Highlight;
            botonLogin.ForeColor = SystemColors.ControlLight;
            botonLogin.Location = new Point(76, 206);
            botonLogin.Name = "botonLogin";
            botonLogin.Size = new Size(120, 39);
            botonLogin.TabIndex = 5;
            botonLogin.Text = "Iniciar Sesion";
            botonLogin.UseVisualStyleBackColor = false;
            botonLogin.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 129);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 4;
            label2.Text = "Contraseña";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 63);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 3;
            label1.Text = "Usuario";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ButtonShadow;
            textBox2.Location = new Point(49, 147);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(179, 23);
            textBox2.TabIndex = 2;
            textBox2.UseWaitCursor = true;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "login";
            Opacity = 0.9D;
            Text = "Iniciar Sesion";
            Load += login_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private BindingSource bindingSource1;
        private TextBox textBox1;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private TextBox textBox2;
        private Button botonLogin;
    }
}

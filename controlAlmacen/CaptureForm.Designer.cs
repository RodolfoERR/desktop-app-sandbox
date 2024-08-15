namespace controlAlmacen
{
    partial class CaptureForm
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
            PromptLabel = new Label();
            StatusLabel = new Label();
            Picture = new PictureBox();
            Prompt = new TextBox();
            StatusText = new TextBox();
            StatusLine = new Label();
            CloseButton = new Button();
            ((System.ComponentModel.ISupportInitialize)Picture).BeginInit();
            SuspendLayout();
            // 
            // PromptLabel
            // 
            PromptLabel.AutoSize = true;
            PromptLabel.Location = new Point(310, 14);
            PromptLabel.Margin = new Padding(4, 0, 4, 0);
            PromptLabel.Name = "PromptLabel";
            PromptLabel.Size = new Size(50, 15);
            PromptLabel.TabIndex = 1;
            PromptLabel.Text = "Prompt:";
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(310, 75);
            StatusLabel.Margin = new Padding(4, 0, 4, 0);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(42, 15);
            StatusLabel.TabIndex = 3;
            StatusLabel.Text = "Status:";
            // 
            // Picture
            // 
            Picture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Picture.BackColor = SystemColors.Window;
            Picture.BorderStyle = BorderStyle.Fixed3D;
            Picture.Location = new Point(14, 14);
            Picture.Margin = new Padding(4, 3, 4, 3);
            Picture.Name = "Picture";
            Picture.Size = new Size(289, 332);
            Picture.TabIndex = 0;
            Picture.TabStop = false;
            // 
            // Prompt
            // 
            Prompt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Prompt.Location = new Point(314, 32);
            Prompt.Margin = new Padding(4, 3, 4, 3);
            Prompt.Name = "Prompt";
            Prompt.ReadOnly = true;
            Prompt.Size = new Size(349, 23);
            Prompt.TabIndex = 2;
            // 
            // StatusText
            // 
            StatusText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StatusText.BackColor = SystemColors.Window;
            StatusText.Location = new Point(314, 93);
            StatusText.Margin = new Padding(4, 3, 4, 3);
            StatusText.Multiline = true;
            StatusText.Name = "StatusText";
            StatusText.ReadOnly = true;
            StatusText.ScrollBars = ScrollBars.Both;
            StatusText.Size = new Size(349, 252);
            StatusText.TabIndex = 4;
            // 
            // StatusLine
            // 
            StatusLine.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StatusLine.Location = new Point(10, 350);
            StatusLine.Margin = new Padding(4, 0, 4, 0);
            StatusLine.Name = "StatusLine";
            StatusLine.Size = new Size(559, 45);
            StatusLine.TabIndex = 5;
            StatusLine.Text = "[Status line]";
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CloseButton.DialogResult = DialogResult.Cancel;
            CloseButton.Location = new Point(576, 368);
            CloseButton.Margin = new Padding(4, 3, 4, 3);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(88, 27);
            CloseButton.TabIndex = 6;
            CloseButton.Text = "Cerrar";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // CaptureForm
            // 
            AcceptButton = CloseButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CloseButton;
            ClientSize = new Size(678, 408);
            Controls.Add(CloseButton);
            Controls.Add(StatusLine);
            Controls.Add(StatusText);
            Controls.Add(StatusLabel);
            Controls.Add(Prompt);
            Controls.Add(PromptLabel);
            Controls.Add(Picture);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(464, 340);
            Name = "CaptureForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Capturar";
            FormClosed += CaptureForm_FormClosed;
            Load += CaptureForm_Load;
            ((System.ComponentModel.ISupportInitialize)Picture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.TextBox Prompt;
        private System.Windows.Forms.TextBox StatusText;
        private System.Windows.Forms.Label StatusLine;
        private System.Windows.Forms.Button CloseButton;
        private Label PromptLabel;
        private Label StatusLabel;
    }
}
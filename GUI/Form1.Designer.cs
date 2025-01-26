namespace To_do_List_List
{
    partial class Form1
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
            button1 = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(423, 44);
            button1.Name = "button1";
            button1.Size = new Size(46, 43);
            button1.TabIndex = 1;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Green;
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(0, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(484, 125);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Location = new Point(66, 122);
            panel2.Name = "panel2";
            panel2.Size = new Size(327, 391);
            panel2.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Historic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(24, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(373, 38);
            textBox1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(481, 513);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Your To-Do-List";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Panel panel1;
        private Panel panel2;
        private TextBox textBox1;
    }
}

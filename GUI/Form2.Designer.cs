namespace To_do_List_List.GUI
{
    partial class Form2
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
            Label label1;
            textBox1 = new TextBox();
            label2 = new Label();
            checkedListBox1 = new CheckedListBox();
            button1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 41);
            label1.Name = "label1";
            label1.Size = new Size(234, 31);
            label1.TabIndex = 0;
            label1.Text = "Nome de usa tarefa: ";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(21, 96);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(465, 34);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 166);
            label2.Name = "label2";
            label2.Size = new Size(129, 31);
            label2.TabIndex = 2;
            label2.Text = "Categoria: ";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Big exterm importance(BEI) ", "Muito importante", "Importante", "Relativa ", "Nulo " });
            checkedListBox1.Location = new Point(21, 213);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(234, 114);
            checkedListBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(344, 222);
            button1.Name = "button1";
            button1.Size = new Size(107, 94);
            button1.TabIndex = 4;
            button1.Text = "add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(510, 349);
            Controls.Add(button1);
            Controls.Add(checkedListBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Form2";
            Text = "Add-Task";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label2;
        private CheckedListBox checkedListBox1;
        private Button button1;
    }
}
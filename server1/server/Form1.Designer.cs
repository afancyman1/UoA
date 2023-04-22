namespace server
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
            available_files = new ListBox();
            button1 = new Button();
            all_files = new ListBox();
            button2 = new Button();
            button3 = new Button();
            FindError = new Label();
            SuspendLayout();
            // 
            // available_files
            // 
            available_files.FormattingEnabled = true;
            available_files.ItemHeight = 15;
            available_files.Location = new Point(442, 103);
            available_files.Name = "available_files";
            available_files.Size = new Size(243, 169);
            available_files.TabIndex = 0;
            available_files.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(442, 307);
            button1.Name = "button1";
            button1.Size = new Size(127, 23);
            button1.TabIndex = 1;
            button1.Text = "show_available_files";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // all_files
            // 
            all_files.FormattingEnabled = true;
            all_files.ItemHeight = 15;
            all_files.Location = new Point(49, 103);
            all_files.Name = "all_files";
            all_files.Size = new Size(239, 169);
            all_files.TabIndex = 2;
            all_files.SelectedIndexChanged += all_files_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Location = new Point(49, 307);
            button2.Name = "button2";
            button2.Size = new Size(97, 23);
            button2.TabIndex = 3;
            button2.Text = "show_all_files";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(327, 177);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 4;
            button3.Text = "add_file";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // FindError
            // 
            FindError.AutoSize = true;
            FindError.Location = new Point(12, 15);
            FindError.Name = "FindError";
            FindError.Size = new Size(55, 15);
            FindError.TabIndex = 5;
            FindError.Text = "FindError";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(FindError);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(all_files);
            Controls.Add(button1);
            Controls.Add(available_files);
            Name = "Form1";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox available_files;
        private Button button1;
        private ListBox all_files;
        private Button button2;
        private Button button3;
        private Label FindError;
    }
}
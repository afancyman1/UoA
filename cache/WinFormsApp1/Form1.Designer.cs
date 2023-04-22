namespace WinFormsApp1
{
    partial class Cache
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
            file_list = new ListBox();
            show_files_button = new Button();
            clear_selected_file_button = new Button();
            log_list = new TextBox();
            button1 = new Button();
            textBox1 = new TextBox();
            FindError = new Button();
            SuspendLayout();
            // 
            // file_list
            // 
            file_list.FormattingEnabled = true;
            file_list.ItemHeight = 15;
            file_list.Location = new Point(154, 111);
            file_list.Name = "file_list";
            file_list.Size = new Size(125, 199);
            file_list.TabIndex = 0;
            file_list.SelectedIndexChanged += file_list_SelectedIndexChanged;
            // 
            // show_files_button
            // 
            show_files_button.Location = new Point(154, 316);
            show_files_button.Name = "show_files_button";
            show_files_button.Size = new Size(125, 23);
            show_files_button.TabIndex = 1;
            show_files_button.Text = "show_files";
            show_files_button.UseVisualStyleBackColor = true;
            show_files_button.Click += show_files_button_Click;
            // 
            // clear_selected_file_button
            // 
            clear_selected_file_button.Location = new Point(154, 345);
            clear_selected_file_button.Name = "clear_selected_file_button";
            clear_selected_file_button.Size = new Size(125, 23);
            clear_selected_file_button.TabIndex = 2;
            clear_selected_file_button.Text = "clear_selected_file";
            clear_selected_file_button.UseVisualStyleBackColor = true;
            clear_selected_file_button.Click += clear_selected_file_button_Click;
            // 
            // log_list
            // 
            log_list.Location = new Point(372, 147);
            log_list.Multiline = true;
            log_list.Name = "log_list";
            log_list.Size = new Size(296, 163);
            log_list.TabIndex = 3;
            log_list.TextChanged += log_list_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(452, 316);
            button1.Name = "button1";
            button1.Size = new Size(132, 23);
            button1.TabIndex = 4;
            button1.Text = "clear_log_list";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(327, 28);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(257, 23);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // FindError
            // 
            FindError.Location = new Point(19, 26);
            FindError.Name = "FindError";
            FindError.Size = new Size(75, 23);
            FindError.TabIndex = 6;
            FindError.Text = "FindError";
            FindError.UseVisualStyleBackColor = true;
            FindError.Click += button2_Click;
            // 
            // Cache
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(FindError);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(log_list);
            Controls.Add(clear_selected_file_button);
            Controls.Add(show_files_button);
            Controls.Add(file_list);
            Name = "Cache";
            Text = "Cache";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox file_list;
        private Button show_files_button;
        private Button clear_selected_file_button;
        private TextBox log_list;
        private Button button1;
        private TextBox textBox1;
        private Button FindError;
    }
}
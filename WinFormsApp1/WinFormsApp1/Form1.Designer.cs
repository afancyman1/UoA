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
            this.file_list = new System.Windows.Forms.ListBox();
            this.show_files_button = new System.Windows.Forms.Button();
            this.clear_selected_file_button = new System.Windows.Forms.Button();
            this.log_list = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // file_list
            // 
            this.file_list.FormattingEnabled = true;
            this.file_list.ItemHeight = 15;
            this.file_list.Location = new System.Drawing.Point(154, 111);
            this.file_list.Name = "file_list";
            this.file_list.Size = new System.Drawing.Size(125, 199);
            this.file_list.TabIndex = 0;
            this.file_list.SelectedIndexChanged += new System.EventHandler(this.file_list_SelectedIndexChanged);
            // 
            // show_files_button
            // 
            this.show_files_button.Location = new System.Drawing.Point(154, 316);
            this.show_files_button.Name = "show_files_button";
            this.show_files_button.Size = new System.Drawing.Size(125, 23);
            this.show_files_button.TabIndex = 1;
            this.show_files_button.Text = "show_files";
            this.show_files_button.UseVisualStyleBackColor = true;
            this.show_files_button.Click += new System.EventHandler(this.show_files_button_Click);
            // 
            // clear_selected_file_button
            // 
            this.clear_selected_file_button.Location = new System.Drawing.Point(154, 345);
            this.clear_selected_file_button.Name = "clear_selected_file_button";
            this.clear_selected_file_button.Size = new System.Drawing.Size(125, 23);
            this.clear_selected_file_button.TabIndex = 2;
            this.clear_selected_file_button.Text = "clear_selected_file";
            this.clear_selected_file_button.UseVisualStyleBackColor = true;
            this.clear_selected_file_button.Click += new System.EventHandler(this.clear_selected_file_button_Click);
            // 
            // log_list
            // 
            this.log_list.Location = new System.Drawing.Point(372, 147);
            this.log_list.Multiline = true;
            this.log_list.Name = "log_list";
            this.log_list.Size = new System.Drawing.Size(296, 163);
            this.log_list.TabIndex = 3;
            this.log_list.TextChanged += new System.EventHandler(this.log_list_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(452, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "clear_log_list";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cache
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.log_list);
            this.Controls.Add(this.clear_selected_file_button);
            this.Controls.Add(this.show_files_button);
            this.Controls.Add(this.file_list);
            this.Name = "Cache";
            this.Text = "Cache";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox file_list;
        private Button show_files_button;
        private Button clear_selected_file_button;
        private TextBox log_list;
        private Button button1;
    }
}
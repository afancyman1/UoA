namespace client
{
    partial class client
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
            this.label1 = new System.Windows.Forms.Label();
            this.showList = new System.Windows.Forms.Button();
            this.available_files = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.clear_content = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "available_files_list";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // showList
            // 
            this.showList.Location = new System.Drawing.Point(59, 249);
            this.showList.Name = "showList";
            this.showList.Size = new System.Drawing.Size(75, 23);
            this.showList.TabIndex = 1;
            this.showList.Text = "showList";
            this.showList.UseVisualStyleBackColor = true;
            this.showList.Click += new System.EventHandler(this.showList_Click);
            // 
            // available_files
            // 
            this.available_files.FormattingEnabled = true;
            this.available_files.ItemHeight = 15;
            this.available_files.Location = new System.Drawing.Point(59, 104);
            this.available_files.Name = "available_files";
            this.available_files.Size = new System.Drawing.Size(189, 139);
            this.available_files.TabIndex = 2;
            this.available_files.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "clear_list";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(59, 278);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(189, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "download_selected_file";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(356, 104);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 139);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // clear_content
            // 
            this.clear_content.Location = new System.Drawing.Point(403, 262);
            this.clear_content.Name = "clear_content";
            this.clear_content.Size = new System.Drawing.Size(120, 23);
            this.clear_content.TabIndex = 6;
            this.clear_content.Text = "clear_content";
            this.clear_content.UseVisualStyleBackColor = true;
            this.clear_content.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "content_of_file";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // client
            // 
            this.ClientSize = new System.Drawing.Size(642, 419);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clear_content);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.available_files);
            this.Controls.Add(this.showList);
            this.Controls.Add(this.label1);
            this.Name = "client";
            this.Text = "client";
            this.Load += new System.EventHandler(this.client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button showList;
        private ListBox available_files;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Button clear_content;
        private Label label2;
    }
}
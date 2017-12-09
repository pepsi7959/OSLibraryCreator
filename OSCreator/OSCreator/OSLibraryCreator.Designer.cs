namespace OSCreator
{
    partial class OSLibraryCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSLibraryCreator));
            this.openFile_btn = new System.Windows.Forms.Button();
            this.openCSVFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.libraryType_cbb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // openFile_btn
            // 
            this.openFile_btn.Location = new System.Drawing.Point(205, 19);
            this.openFile_btn.Name = "openFile_btn";
            this.openFile_btn.Size = new System.Drawing.Size(75, 23);
            this.openFile_btn.TabIndex = 1;
            this.openFile_btn.Text = "Generate";
            this.openFile_btn.UseVisualStyleBackColor = true;
            this.openFile_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // openCSVFileDialog
            // 
            this.openCSVFileDialog.FileName = "openCSVFileDialog";
            // 
            // libraryType_cbb
            // 
            this.libraryType_cbb.FormattingEnabled = true;
            this.libraryType_cbb.Items.AddRange(new object[] {
            "People Definition",
            "Light Definition",
            "Ventilation",
            "Space Type"});
            this.libraryType_cbb.Location = new System.Drawing.Point(78, 19);
            this.libraryType_cbb.Name = "libraryType_cbb";
            this.libraryType_cbb.Size = new System.Drawing.Size(121, 21);
            this.libraryType_cbb.TabIndex = 4;
            this.libraryType_cbb.Text = "People Definition";
            this.libraryType_cbb.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Library Type";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // save_btn
            // 
            this.save_btn.Enabled = false;
            this.save_btn.Location = new System.Drawing.Point(286, 19);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 6;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // OSLibraryCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 55);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.libraryType_cbb);
            this.Controls.Add(this.openFile_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OSLibraryCreator";
            this.Text = "OpenStudio Library Creator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openCSVFileDialog;
        private System.Windows.Forms.Button openFile_btn;
        private System.Windows.Forms.ComboBox libraryType_cbb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}


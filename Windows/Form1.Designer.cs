namespace Windows
{
    partial class Window
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
            this.Button = new System.Windows.Forms.Button();
            this.TextBox = new System.Windows.Forms.RichTextBox();
            this.Combo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Button
            // 
            this.Button.Location = new System.Drawing.Point(142, 152);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(105, 55);
            this.Button.TabIndex = 0;
            this.Button.Text = "Choose a file";
            this.Button.UseVisualStyleBackColor = true;
            this.Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(111, 50);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(171, 70);
            this.TextBox.TabIndex = 1;
            this.TextBox.Text = "";
            // 
            // Combo
            // 
            this.Combo.FormattingEnabled = true;
            this.Combo.Items.AddRange(new object[] {
            "Search a file with specific key",
            "Compare 2 txt files",
            "Quadratic formula",
            "Order files"});
            this.Combo.Location = new System.Drawing.Point(111, 238);
            this.Combo.Name = "Combo";
            this.Combo.Size = new System.Drawing.Size(171, 21);
            this.Combo.TabIndex = 2;
            this.Combo.SelectedIndexChanged += new System.EventHandler(this.Combo_SelectedIndexChanged);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 345);
            this.Controls.Add(this.Combo);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.Button);
            this.Name = "Window";
            this.Text = "Windows Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button;
        private System.Windows.Forms.RichTextBox TextBox;
        private System.Windows.Forms.ComboBox Combo;
    }
}


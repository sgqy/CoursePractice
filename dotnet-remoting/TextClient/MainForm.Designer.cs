namespace TextClient
{
    partial class MainForm
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
            this.textBoxUnicode = new System.Windows.Forms.TextBox();
            this.textBoxGBKValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxUnicode
            // 
            this.textBoxUnicode.Location = new System.Drawing.Point(12, 25);
            this.textBoxUnicode.Multiline = true;
            this.textBoxUnicode.Name = "textBoxUnicode";
            this.textBoxUnicode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxUnicode.Size = new System.Drawing.Size(391, 50);
            this.textBoxUnicode.TabIndex = 0;
            // 
            // textBoxGBKValue
            // 
            this.textBoxGBKValue.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGBKValue.Location = new System.Drawing.Point(12, 94);
            this.textBoxGBKValue.Multiline = true;
            this.textBoxGBKValue.Name = "textBoxGBKValue";
            this.textBoxGBKValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxGBKValue.Size = new System.Drawing.Size(391, 164);
            this.textBoxGBKValue.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unicode String";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "GBK Hex Value";
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(12, 264);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 4;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 300);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxGBKValue);
            this.Controls.Add(this.textBoxUnicode);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(431, 339);
            this.MinimumSize = new System.Drawing.Size(431, 339);
            this.Name = "MainForm";
            this.Text = "TextClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUnicode;
        private System.Windows.Forms.TextBox textBoxGBKValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonConvert;
    }
}


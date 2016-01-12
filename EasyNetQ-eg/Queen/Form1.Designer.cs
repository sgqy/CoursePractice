namespace Queen
{
    partial class Form1
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.numctrlTotal = new System.Windows.Forms.NumericUpDown();
            this.buttonPublish = new System.Windows.Forms.Button();
            this.comboReader = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkRandom = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numctrlTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 39);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(809, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // numctrlTotal
            // 
            this.numctrlTotal.Location = new System.Drawing.Point(49, 12);
            this.numctrlTotal.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numctrlTotal.Name = "numctrlTotal";
            this.numctrlTotal.Size = new System.Drawing.Size(282, 20);
            this.numctrlTotal.TabIndex = 1;
            // 
            // buttonPublish
            // 
            this.buttonPublish.Location = new System.Drawing.Point(746, 9);
            this.buttonPublish.Name = "buttonPublish";
            this.buttonPublish.Size = new System.Drawing.Size(75, 23);
            this.buttonPublish.TabIndex = 2;
            this.buttonPublish.Text = "Publish";
            this.buttonPublish.UseVisualStyleBackColor = true;
            this.buttonPublish.Click += new System.EventHandler(this.buttonPublish_Click);
            // 
            // comboReader
            // 
            this.comboReader.FormattingEnabled = true;
            this.comboReader.Items.AddRange(new object[] {
            "Alice",
            "Milly"});
            this.comboReader.Location = new System.Drawing.Point(385, 11);
            this.comboReader.Name = "comboReader";
            this.comboReader.Size = new System.Drawing.Size(245, 21);
            this.comboReader.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Reader";
            // 
            // checkRandom
            // 
            this.checkRandom.AutoSize = true;
            this.checkRandom.Location = new System.Drawing.Point(636, 13);
            this.checkRandom.Name = "checkRandom";
            this.checkRandom.Size = new System.Drawing.Size(104, 17);
            this.checkRandom.TabIndex = 6;
            this.checkRandom.Text = "Random Reader";
            this.checkRandom.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 74);
            this.Controls.Add(this.checkRandom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboReader);
            this.Controls.Add(this.buttonPublish);
            this.Controls.Add(this.numctrlTotal);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form1";
            this.Text = "Queen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numctrlTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NumericUpDown numctrlTotal;
        private System.Windows.Forms.Button buttonPublish;
        private System.Windows.Forms.ComboBox comboReader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkRandom;
    }
}


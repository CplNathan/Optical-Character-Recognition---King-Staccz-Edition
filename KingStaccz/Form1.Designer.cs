
namespace KingStaccz
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
            this.currentPicture = new System.Windows.Forms.PictureBox();
            this.ccNumber = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.secNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.expNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.updLabel = new System.Windows.Forms.Label();
            this.ppeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.currentPicture)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // currentPicture
            // 
            this.currentPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.currentPicture.Location = new System.Drawing.Point(13, 13);
            this.currentPicture.Name = "currentPicture";
            this.currentPicture.Size = new System.Drawing.Size(256, 256);
            this.currentPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.currentPicture.TabIndex = 0;
            this.currentPicture.TabStop = false;
            // 
            // ccNumber
            // 
            this.ccNumber.Location = new System.Drawing.Point(82, 16);
            this.ccNumber.Name = "ccNumber";
            this.ccNumber.ReadOnly = true;
            this.ccNumber.Size = new System.Drawing.Size(425, 23);
            this.ccNumber.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.secNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.expNumber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ccNumber);
            this.groupBox1.Location = new System.Drawing.Point(275, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 256);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // secNumber
            // 
            this.secNumber.Location = new System.Drawing.Point(273, 58);
            this.secNumber.Name = "secNumber";
            this.secNumber.ReadOnly = true;
            this.secNumber.Size = new System.Drawing.Size(234, 23);
            this.secNumber.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 61);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "CV2";
            // 
            // expNumber
            // 
            this.expNumber.Location = new System.Drawing.Point(82, 58);
            this.expNumber.Name = "expNumber";
            this.expNumber.ReadOnly = true;
            this.expNumber.Size = new System.Drawing.Size(151, 23);
            this.expNumber.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 61);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Expiry";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "CC Number";
            // 
            // updLabel
            // 
            this.updLabel.AutoSize = true;
            this.updLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.updLabel.Location = new System.Drawing.Point(13, 276);
            this.updLabel.Name = "updLabel";
            this.updLabel.Size = new System.Drawing.Size(131, 30);
            this.updLabel.TabIndex = 3;
            this.updLabel.Text = "Updated: No";
            // 
            // ppeLabel
            // 
            this.ppeLabel.AutoSize = true;
            this.ppeLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ppeLabel.Location = new System.Drawing.Point(13, 306);
            this.ppeLabel.Name = "ppeLabel";
            this.ppeLabel.Size = new System.Drawing.Size(123, 30);
            this.ppeLabel.TabIndex = 4;
            this.ppeLabel.Text = "Entered: No";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ppeLabel);
            this.Controls.Add(this.updLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.currentPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "King Staccz Bank Drainer";
            ((System.ComponentModel.ISupportInitialize)(this.currentPicture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox currentPicture;
        private System.Windows.Forms.TextBox ccNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox expNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox secNumber;
        private System.Windows.Forms.Label updLabel;
        private System.Windows.Forms.Label ppeLabel;
    }
}


﻿
namespace TextAnalysis {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button2 = new System.Windows.Forms.Button();
            this.inputText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.baseText = new System.Windows.Forms.Label();
            this.vectorisedText = new System.Windows.Forms.Label();
            this.allVectors = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Process text";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(176, 12);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(612, 23);
            this.inputText.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Base text";
            // 
            // baseText
            // 
            this.baseText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.baseText.Location = new System.Drawing.Point(12, 67);
            this.baseText.Name = "baseText";
            this.baseText.Size = new System.Drawing.Size(776, 140);
            this.baseText.TabIndex = 6;
            this.baseText.Text = "label2";
            this.baseText.Click += new System.EventHandler(this.baseText_Click);
            // 
            // vectorisedText
            // 
            this.vectorisedText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vectorisedText.Location = new System.Drawing.Point(176, 249);
            this.vectorisedText.Name = "vectorisedText";
            this.vectorisedText.Size = new System.Drawing.Size(612, 499);
            this.vectorisedText.TabIndex = 7;
            this.vectorisedText.Text = "label2";
            // 
            // allVectors
            // 
            this.allVectors.FormattingEnabled = true;
            this.allVectors.ItemHeight = 15;
            this.allVectors.Location = new System.Drawing.Point(13, 249);
            this.allVectors.Name = "allVectors";
            this.allVectors.Size = new System.Drawing.Size(157, 499);
            this.allVectors.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "All vectors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Vectorised text";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 770);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.allVectors);
            this.Controls.Add(this.vectorisedText);
            this.Controls.Add(this.baseText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label baseText;
        private System.Windows.Forms.Label vectorisedText;
        private System.Windows.Forms.ListBox allVectors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

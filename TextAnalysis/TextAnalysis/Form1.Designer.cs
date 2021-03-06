
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
            this.processText_btn = new System.Windows.Forms.Button();
            this.inputText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.baseText = new System.Windows.Forms.Label();
            this.vectorisedText = new System.Windows.Forms.Label();
            this.allVectors = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.prevText = new System.Windows.Forms.Button();
            this.nextText = new System.Windows.Forms.Button();
            this.showingText = new System.Windows.Forms.Label();
            this.allDefinitions = new System.Windows.Forms.ListBox();
            this.resetDB_btn = new System.Windows.Forms.Button();
            this.visualise_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // processText_btn
            // 
            this.processText_btn.Location = new System.Drawing.Point(12, 12);
            this.processText_btn.Name = "processText_btn";
            this.processText_btn.Size = new System.Drawing.Size(134, 23);
            this.processText_btn.TabIndex = 3;
            this.processText_btn.Text = "Process text";
            this.processText_btn.UseVisualStyleBackColor = true;
            this.processText_btn.Click += new System.EventHandler(this.processText_btn_Click);
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(176, 12);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(209, 23);
            this.inputText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
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
            // 
            // vectorisedText
            // 
            this.vectorisedText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vectorisedText.Location = new System.Drawing.Point(176, 249);
            this.vectorisedText.Name = "vectorisedText";
            this.vectorisedText.Size = new System.Drawing.Size(612, 162);
            this.vectorisedText.TabIndex = 7;
            this.vectorisedText.Text = "label2";
            // 
            // allVectors
            // 
            this.allVectors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.allVectors.FormattingEnabled = true;
            this.allVectors.ItemHeight = 15;
            this.allVectors.Location = new System.Drawing.Point(13, 249);
            this.allVectors.Name = "allVectors";
            this.allVectors.Size = new System.Drawing.Size(157, 469);
            this.allVectors.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "All vectors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Vectorised text";
            // 
            // prevText
            // 
            this.prevText.Enabled = false;
            this.prevText.Location = new System.Drawing.Point(401, 11);
            this.prevText.Name = "prevText";
            this.prevText.Size = new System.Drawing.Size(75, 23);
            this.prevText.TabIndex = 11;
            this.prevText.Text = "Prev Text";
            this.prevText.UseVisualStyleBackColor = true;
            this.prevText.Click += new System.EventHandler(this.prevText_Click);
            // 
            // nextText
            // 
            this.nextText.Enabled = false;
            this.nextText.Location = new System.Drawing.Point(482, 11);
            this.nextText.Name = "nextText";
            this.nextText.Size = new System.Drawing.Size(75, 23);
            this.nextText.TabIndex = 12;
            this.nextText.Text = "Next Text";
            this.nextText.UseVisualStyleBackColor = true;
            this.nextText.Click += new System.EventHandler(this.nextText_Click);
            // 
            // showingText
            // 
            this.showingText.AutoSize = true;
            this.showingText.Location = new System.Drawing.Point(563, 12);
            this.showingText.Name = "showingText";
            this.showingText.Size = new System.Drawing.Size(96, 15);
            this.showingText.TabIndex = 13;
            this.showingText.Text = "No texts to show";
            // 
            // allDefinitions
            // 
            this.allDefinitions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allDefinitions.FormattingEnabled = true;
            this.allDefinitions.ItemHeight = 15;
            this.allDefinitions.Location = new System.Drawing.Point(176, 429);
            this.allDefinitions.Name = "allDefinitions";
            this.allDefinitions.Size = new System.Drawing.Size(612, 319);
            this.allDefinitions.TabIndex = 18;
            // 
            // resetDB_btn
            // 
            this.resetDB_btn.BackColor = System.Drawing.Color.Red;
            this.resetDB_btn.Location = new System.Drawing.Point(713, 11);
            this.resetDB_btn.Name = "resetDB_btn";
            this.resetDB_btn.Size = new System.Drawing.Size(75, 23);
            this.resetDB_btn.TabIndex = 19;
            this.resetDB_btn.Text = "Reset DB";
            this.resetDB_btn.UseVisualStyleBackColor = false;
            this.resetDB_btn.Click += new System.EventHandler(this.resetDB_btn_Click);
            // 
            // visualise_btn
            // 
            this.visualise_btn.Location = new System.Drawing.Point(12, 720);
            this.visualise_btn.Name = "visualise_btn";
            this.visualise_btn.Size = new System.Drawing.Size(158, 28);
            this.visualise_btn.TabIndex = 20;
            this.visualise_btn.Text = "Visualisation";
            this.visualise_btn.UseVisualStyleBackColor = true;
            this.visualise_btn.Click += new System.EventHandler(this.visualise_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 763);
            this.Controls.Add(this.visualise_btn);
            this.Controls.Add(this.resetDB_btn);
            this.Controls.Add(this.allDefinitions);
            this.Controls.Add(this.showingText);
            this.Controls.Add(this.nextText);
            this.Controls.Add(this.prevText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.allVectors);
            this.Controls.Add(this.vectorisedText);
            this.Controls.Add(this.baseText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.processText_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button processText_btn;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label baseText;
        private System.Windows.Forms.Label vectorisedText;
        private System.Windows.Forms.ListBox allVectors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button prevText;
        private System.Windows.Forms.Button nextText;
        private System.Windows.Forms.Label showingText;
        private System.Windows.Forms.ListBox allDefinitions;
        private System.Windows.Forms.Button resetDB_btn;
        private System.Windows.Forms.Button visualise_btn;
    }
}


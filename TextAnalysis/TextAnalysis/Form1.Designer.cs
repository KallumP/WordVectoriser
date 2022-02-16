
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
            this.prevText = new System.Windows.Forms.Button();
            this.nextText = new System.Windows.Forms.Button();
            this.showingText = new System.Windows.Forms.Label();
            this.moveBagR = new System.Windows.Forms.Button();
            this.moveBagL = new System.Windows.Forms.Button();
            this.bagContent_lbl = new System.Windows.Forms.Label();
            this.currentBagPos = new System.Windows.Forms.Label();
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
            this.inputText.Size = new System.Drawing.Size(209, 23);
            this.inputText.TabIndex = 4;
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
            this.prevText.Location = new System.Drawing.Point(454, 11);
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
            this.nextText.Location = new System.Drawing.Point(535, 11);
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
            this.showingText.Location = new System.Drawing.Point(616, 12);
            this.showingText.Name = "showingText";
            this.showingText.Size = new System.Drawing.Size(96, 15);
            this.showingText.TabIndex = 13;
            this.showingText.Text = "No texts to show";
            // 
            // moveWindowR
            // 
            this.moveBagR.Enabled = false;
            this.moveBagR.Location = new System.Drawing.Point(317, 429);
            this.moveBagR.Name = "moveWindowR";
            this.moveBagR.Size = new System.Drawing.Size(135, 23);
            this.moveBagR.TabIndex = 15;
            this.moveBagR.Text = "Move window right";
            this.moveBagR.UseVisualStyleBackColor = true;
            this.moveBagR.Click += new System.EventHandler(this.moveWindowR_Click);
            // 
            // moveWindowL
            // 
            this.moveBagL.Enabled = false;
            this.moveBagL.Location = new System.Drawing.Point(176, 429);
            this.moveBagL.Name = "moveWindowL";
            this.moveBagL.Size = new System.Drawing.Size(135, 23);
            this.moveBagL.TabIndex = 14;
            this.moveBagL.Text = "Move window left";
            this.moveBagL.UseVisualStyleBackColor = true;
            this.moveBagL.Click += new System.EventHandler(this.moveWindowL_Click);
            // 
            // bagContent_lbl
            // 
            this.bagContent_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bagContent_lbl.Location = new System.Drawing.Point(176, 455);
            this.bagContent_lbl.Name = "bagContent_lbl";
            this.bagContent_lbl.Size = new System.Drawing.Size(612, 162);
            this.bagContent_lbl.TabIndex = 16;
            this.bagContent_lbl.Text = "label2";
            // 
            // currentBagPos
            // 
            this.currentBagPos.AutoSize = true;
            this.currentBagPos.Location = new System.Drawing.Point(458, 433);
            this.currentBagPos.Name = "currentBagPos";
            this.currentBagPos.Size = new System.Drawing.Size(38, 15);
            this.currentBagPos.TabIndex = 17;
            this.currentBagPos.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 770);
            this.Controls.Add(this.currentBagPos);
            this.Controls.Add(this.bagContent_lbl);
            this.Controls.Add(this.moveBagR);
            this.Controls.Add(this.moveBagL);
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
        private System.Windows.Forms.Button prevText;
        private System.Windows.Forms.Button nextText;
        private System.Windows.Forms.Label showingText;
        private System.Windows.Forms.Button moveBagR;
        private System.Windows.Forms.Button moveBagL;
        private System.Windows.Forms.Label bagContent_lbl;
        private System.Windows.Forms.Label currentBagPos;
    }
}


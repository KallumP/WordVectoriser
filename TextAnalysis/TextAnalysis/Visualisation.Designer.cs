namespace TextAnalysis {
    partial class Visualisation {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.currentVector_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // currentVector_lbl
            // 
            this.currentVector_lbl.AutoSize = true;
            this.currentVector_lbl.Location = new System.Drawing.Point(10, 9);
            this.currentVector_lbl.Name = "currentVector_lbl";
            this.currentVector_lbl.Size = new System.Drawing.Size(83, 15);
            this.currentVector_lbl.TabIndex = 0;
            this.currentVector_lbl.Text = "Current vector";
            // 
            // Visualisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.currentVector_lbl);
            this.DoubleBuffered = true;
            this.Name = "Visualisation";
            this.Text = "Visualisation";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Visualisation_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Visualisation_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Visualisation_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentVector_lbl;
    }
}
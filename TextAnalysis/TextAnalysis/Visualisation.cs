using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TextAnalysis {
    public partial class Visualisation : Form {
        public Visualisation(int vector) {
            InitializeComponent();
        }

        private void Visualisation_Paint(object sender, PaintEventArgs e) {

            DrawVector(e.Graphics);
        }

        void DrawVector(Graphics g) {

            Point center = new Point(Width / 2, Height / 2);

            g.DrawEllipse(Pens.Black, center.X, center.Y, 20, 20);

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TextAnalysis {
    public partial class Visualisation : Form {

        int vector;
        public Visualisation(int _vector) {
            InitializeComponent();
            vector = _vector;
        }

        private void Visualisation_Paint(object sender, PaintEventArgs e) {

            currentVector_lbl.Text = vector.ToString() + ", " + TextAnalysis.Text.vectors[vector].word;
            DrawVector(e.Graphics, vector);


        }

        void DrawVector(Graphics g, int _vector) {

            Point center = new Point(Width / 2, Height / 2);

            string word = TextAnalysis.Text.vectors[_vector].word;
            int fontSize = 10;
            string font = "Consolas";
            Font f = new Font(font, fontSize);



            //gets the size of the word
            Size proposedSize = new Size(int.MaxValue, int.MaxValue);
            TextFormatFlags flags = TextFormatFlags.NoPadding;
            Size size = TextRenderer.MeasureText(g, word,f, proposedSize, flags);


            g.DrawString(word, f, Brushes.Black, center.X - size.Width / 2, center.Y - size.Height/2);
            g.DrawEllipse(Pens.Black, center.X - size.Width / 2 - 5, center.Y - size.Width / 2 - 5, size.Width + 10, size.Width + 10);

        }

    }
}

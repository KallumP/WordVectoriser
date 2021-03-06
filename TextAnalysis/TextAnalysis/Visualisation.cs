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
        Point mousePos;
        int hoveredVect;

        public Visualisation(int startingVector) {
            InitializeComponent();
            vector = startingVector;
            WindowState = FormWindowState.Maximized;
        }

        private void Visualisation_Paint(object sender, PaintEventArgs e) {
            //label1.Text = mousePos.X.ToString() + ", " + mousePos.Y.ToString();

            //updates which vector is being visualised
            currentVector_lbl.Text = "Vector being visualised: " + vector.ToString() + ", " + TextAnalysis.Text.vectors[vector].word;

            //draws the vector
            DrawVector(e.Graphics, vector);

            //loops through all the definitions for this vector
            for (int i = 0; i < TextAnalysis.Text.vectors[vector].definitions.Count; i++)
                DrawDefinition(e.Graphics, i, TextAnalysis.Text.vectors[vector].definitions.Count);
        }

        void DrawVector(Graphics g, int _vector) {

            Point center = new Point(Width / 2, Height / 2);
            string word = TextAnalysis.Text.vectors[_vector].word;
            int fontSize = 10;
            string font = "Consolas";
            Font f = new Font(font, fontSize);

            //gets the size of the word (used to size the bubble)
            Size proposedSize = new Size(int.MaxValue, int.MaxValue);
            TextFormatFlags flags = TextFormatFlags.NoPadding;
            Size size = TextRenderer.MeasureText(g, word, f, proposedSize, flags);

            //draws the bubble around the word
            int padding = 10;
            g.DrawEllipse(Pens.Black,
                center.X - size.Width / 2 - padding / 2,
                center.Y - size.Width / 2 - padding / 2,
                size.Width + padding,
                size.Width + padding);

            //draws the word
            g.DrawString(word, f, Brushes.Black, center.X - size.Width / 2, center.Y - size.Height / 2);

        }

        void DrawDefinition(Graphics g, int definitionIndex, int totalDefinitions) {


            int fontSize = 8;
            string font = "Consolas";
            Font f = new Font(font, fontSize);

            int distanceFromCenter = fontSize * 51;
            Point center = new Point(Width / 2, Height / 2);
            float ratio = (definitionIndex + 1f) / totalDefinitions;
            float angle = (float)(ratio * Math.PI * 2);

            Point position = new Point();
            position.X = (int)(distanceFromCenter * Math.Sin(angle) + center.X);
            position.Y = (int)(distanceFromCenter * Math.Cos(angle) + center.Y);

            Definition d = TextAnalysis.Text.vectors[vector].definitions[definitionIndex];


            //gets the size of this definition
            Size definitionSize = new Size(0, 0);
            int padding = 5;
            //loops through all the vectors in this definitions
            for (int i = 0; i < d.relatedVectors.Count; i++) {

                //gets the size of the word (used to size the bubble)
                string word = TextAnalysis.Text.vectors[d.relatedVectors[i]].word;
                Size proposedSize = new Size(int.MaxValue, int.MaxValue);
                TextFormatFlags flags = TextFormatFlags.NoPadding;
                Size textSize = TextRenderer.MeasureText(g, word, f, proposedSize, flags);

                //sets the sizes of this definition
                if (textSize.Width > definitionSize.Width)
                    definitionSize.Width = textSize.Width;
                definitionSize.Height += textSize.Height + 3;
            }

            //draws all vectors in this definition
            int nextDrawHeight = 0;
            //loops through all the vectors in this definitions
            for (int i = 0; i < d.relatedVectors.Count; i++) {

                //gets the word for this vector
                string word = TextAnalysis.Text.vectors[d.relatedVectors[i]].word;
                Point stringLocation = new Point(position.X - definitionSize.Width / 2, position.Y - definitionSize.Height / 2 + nextDrawHeight);

                //gets the size of the word (used to size the bubble)
                Size proposedSize = new Size(int.MaxValue, int.MaxValue);
                TextFormatFlags flags = TextFormatFlags.NoPadding;
                Size textSize = TextRenderer.MeasureText(g, word, f, proposedSize, flags);
                Rectangle stringBound = new Rectangle(stringLocation.X, stringLocation.Y, textSize.Width, textSize.Height);

                Brush b = Brushes.Black;
                //if the mouse was hovering on this vector
                if (stringBound.Contains(mousePos)) {

                    hoveredVect = TextAnalysis.Text.vectors[d.relatedVectors[i]].token;
                    b = Brushes.Green;
                }

                //draws this word
                g.DrawString(word, f, b, stringLocation.X, stringLocation.Y);
                //g.DrawRectangle(Pens.Black, position.X, position.Y + nextDrawHeight, textSize.Width, textSize.Height);

                nextDrawHeight += textSize.Height + 3;
            }

            g.DrawRectangle(Pens.Black, position.X - definitionSize.Width / 2, position.Y - definitionSize.Height / 2, definitionSize.Width + padding, definitionSize.Height);
        }

        private void Visualisation_MouseMove(object sender, MouseEventArgs e) {

            mousePos = e.Location;
            Invalidate();
        }

        private void Visualisation_MouseClick(object sender, MouseEventArgs e) {
            Visualisation v = new Visualisation(hoveredVect);
            v.Show();
            Hide();
        }
    }
}

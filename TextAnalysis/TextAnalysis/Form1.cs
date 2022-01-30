using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAnalysis {
    public partial class Form1 : Form {

        List<Text> texts;
        int currentTextToShow;

        public Form1() {
            InitializeComponent();

            texts = new List<Text>();


        }

        private void button2_Click(object sender, EventArgs e) {

            //adds the text from the textbos into the list of all texts
            texts.Add(new Text(inputText.Text));

            //vectorises the new text
            texts[texts.Count - 1].vectorise();

            currentTextToShow = texts.Count - 1;

            prevText.Enabled = true;
            nextText.Enabled = true;
            inputText.Text = "";

            ShowText();
        }


        void outputAllVectors() {

            List<Vector> vectors = texts[currentTextToShow].GetVectors();

            allVectors.Items.Clear();

            foreach (Vector vector in vectors) {


                allVectors.Items.Add(vector.token + ": " + vector.word);
            }
        }

        private void prevText_Click(object sender, EventArgs e) {

            if (currentTextToShow > 0)
                currentTextToShow--;

            ShowText();

        }

        private void nextText_Click(object sender, EventArgs e) {

            if (currentTextToShow < texts.Count - 1)
                currentTextToShow++;

            ShowText();
        }

        void ShowText() {

            //updates the label showing the base text
            baseText.Text = texts[currentTextToShow].baseText;


            //updates the label showing the vectorised text
            vectorisedText.Text = texts[currentTextToShow].outputVectorised();

            //shows all vectors
            outputAllVectors();

            showingText.Text = "Showing text " + (currentTextToShow + 1) + ", out of " + texts.Count;

        }
    }



}

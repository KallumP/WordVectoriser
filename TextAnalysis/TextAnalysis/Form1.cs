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

        Text input;

        public Form1() {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {
            input = new Text(inputText.Text);

            baseText.Text = input.baseText;

            input.vectorise();

            vectorisedText.Text = input.outputVectorised();

            outputAllVectors();

        }


        void outputAllVectors() {

            List<Vector> vectors = input.GetVectors();

            allVectors.Items.Clear();

            foreach (Vector vector in vectors) {


                allVectors.Items.Add(vector.token + ": " + vector.word);
            }
        }

        private void baseText_Click(object sender, EventArgs e) {

        }
    }



}

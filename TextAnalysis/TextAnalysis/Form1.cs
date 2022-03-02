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
        DBConnection dbCon;

        public Form1() {
            InitializeComponent();

            texts = new List<Text>();

            string connectionString = Properties.Settings.Default.DictionaryConnStr;
            dbCon = new DBConnection(connectionString);
            dbCon.OpenConnection();

        }

        private void processText_btn_Click(object sender, EventArgs e) {

            //adds the text from the textbox into the list of all texts
            texts.Add(new Text(inputText.Text));

            //vectorises the new text
            texts[texts.Count - 1].Vectorise();
            texts[texts.Count - 1].GenerateDefinitions();

            currentTextToShow = texts.Count - 1;

            prevText.Enabled = true;
            nextText.Enabled = true;
            inputText.Text = "";

            ShowText();
            ShowAllDefinitions();
        }


        void OutputAllVectors() {

            List<Vector> vectors = TextAnalysis.Text.vectors;

            allVectors.Items.Clear();

            foreach (Vector vector in vectors)

                allVectors.Items.Add(vector.token + ": " + vector.word);

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
            baseText.Text = texts[currentTextToShow].normalisedText;


            //updates the label showing the vectorised text
            vectorisedText.Text = texts[currentTextToShow].OutputVectorised();

            //shows all vectors
            OutputAllVectors();

            showingText.Text = "Showing text " + (currentTextToShow + 1) + ", out of " + texts.Count;

        }

        void ShowAllDefinitions() {

            allDefinitions.Items.Clear();  

            List<int> outputtedVectors = new List<int>();

            //loops through all the vectors in the vectorised text
            for (int i = 0; i < texts[currentTextToShow].vectorisedText.Count; i++) {

                int currentVector = texts[currentTextToShow].vectorisedText[i];

                //only outputs this vectors definitions if it hasn't already been outputted
                if (!outputtedVectors.Contains(currentVector)) {

                    //loops through all the definitions for this vector
                    for (int j = 0; j < TextAnalysis.Text.vectors[TextAnalysis.Text.TokenInVectorsList(currentVector)].relatedVectors.Count(); j++) {

                        string toAdd = "";

                        int currentVectorToken = TextAnalysis.Text.TokenInVectorsList(currentVector);
                        string currentVectorWord = TextAnalysis.Text.vectors[currentVectorToken].word;

                        toAdd += "Current Vector: (" + currentVectorToken + ")" + currentVectorWord + ". Definition: " + j + ". Related vectors: ";

                        //loops through all the vectors in this definition for this vector
                        for (int k = 0; k < TextAnalysis.Text.vectors[TextAnalysis.Text.TokenInVectorsList(currentVector)].relatedVectors[j].Count(); k++) {

                            int definitionToken = TextAnalysis.Text.vectors[TextAnalysis.Text.TokenInVectorsList(currentVector)].relatedVectors[j][k];
                            string definitionString = TextAnalysis.Text.vectors[definitionToken].word;

                            toAdd += "( " + definitionToken + ")" + definitionString + ", ";
                        }

                        allDefinitions.Items.Add(toAdd);
                    }

                    outputtedVectors.Add(currentVector);
                }

            }

        }
    }
}

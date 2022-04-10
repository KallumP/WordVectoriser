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

            //sets up the database helper class
            DBManager.Setup(Properties.Settings.Default.DictionaryConnStr);

            PullAllVectors();
            PullAllDefinitions();
            OutputDBVecsToCLI();
        }

        private void processText_btn_Click(object sender, EventArgs e) {

            ProcessText(inputText.Text);


            //updates ui settings
            currentTextToShow = texts.Count - 1;

            prevText.Enabled = true;
            nextText.Enabled = true;
            inputText.Text = "";


            PushAllVectors();
            OutputDBVecsToCLI();

            //output to window
            UpdateUI();
        }

        private void prevText_Click(object sender, EventArgs e) {

            if (currentTextToShow > 0)
                currentTextToShow--;

            UpdateUI();

        }

        private void nextText_Click(object sender, EventArgs e) {

            if (currentTextToShow < texts.Count - 1)
                currentTextToShow++;

            UpdateUI();
        }


        void PullAllVectors() {

            //gets all the vector data from the database
            string result = DBManager.GetAllVectors();

            if (result != null) {

                //splits all vector data into the separate vector data
                string[] vectorsRaw = result.Split(';');

                //loops through all the vector data
                for (int i = 0; i < vectorsRaw.Length; i++) {

                    if (vectorsRaw[i] != "") {

                        string vectorToken = vectorsRaw[i].Split(',')[0];
                        string vectorText = vectorsRaw[i].Split(',')[1];

                        //pushes this as a new vector with a known token
                        TextAnalysis.Text.vectors.Add(new Vector(vectorText, Int16.Parse(vectorToken)));
                    }
                }

                OutputAllVectors();
            }
        }

        void PullAllDefinitions() {

            //loops through all the vectors
            for (int i = 0; i < TextAnalysis.Text.vectors.Count; i++) {

                //gets all the definition data for this vector
                string result = DBManager.GetAllDefinitions(TextAnalysis.Text.vectors[i]);

                if (result != null) {

                    //splits all definition data into separate definition data
                    string[] definitionsSingles = result.Split(';');

                    //loops through all the pulled definitions
                    for (int j = 0; j < definitionsSingles.Length; j++) {

                        //makes sure this string is not empty
                        if (definitionsSingles[j] != "") {

                            //a list to store all related vectors
                            List<int> related = new List<int>();

                            //pulls all related vector data
                            string relatedResult = DBManager.GetAllRelatedVectors(definitionsSingles[j]);

                            //splits the related vector data into separate vector data
                            string[] relatedSingles = relatedResult.Split(';');

                            //adds each related vector into the list
                            for (int k = 0; k < relatedSingles.Length; k++)

                                //makes sure this string is not empty
                                if (relatedSingles[k] != "")

                                    related.Add(Int16.Parse(relatedSingles[k]));

                            //adds the definition into this vector
                            TextAnalysis.Text.vectors[i].definitions.Add(new Definition(related, Int16.Parse(definitionsSingles[j])));
                        }
                    }
                }
            }
        }



        void PushAllVectors() {
            //pushes vectors to the database
            DBManager.InsertVectorsAndDefinitions(TextAnalysis.Text.vectors);
        }

        void ProcessText(string toProcess) {

            //adds the text from the textbox into the list of all texts
            texts.Add(new Text(toProcess));

            //vectorises and defines the new text
            texts[texts.Count - 1].Vectorise();
            texts[texts.Count - 1].GenerateDefinitions();
            TextAnalysis.Text.UploadVectors();

        }

        void UpdateUI() {
            ShowText();
            ShowAllDefinitions();
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

        void OutputAllVectors() {

            List<Vector> vectors = TextAnalysis.Text.vectors;

            allVectors.Items.Clear();

            foreach (Vector vector in vectors)

                allVectors.Items.Add(vector.token + ": " + vector.word);

        }

        void ShowAllDefinitions() {

            allDefinitions.Items.Clear();

            List<int> outputtedVectors = new List<int>();

            //loops through all the vector tokens in the vectorised text
            for (int i = 0; i < texts[currentTextToShow].vectorisedText.Count; i++) {

                int currentVectorToken = texts[currentTextToShow].vectorisedText[i];
                int currentVectorIndex = TextAnalysis.Text.IndexOfVectorToken(currentVectorToken);

                //only outputs this vectors definitions if it hasn't already been outputted
                if (!outputtedVectors.Contains(currentVectorToken)) {

                    //loops through all the definitions for this vector
                    for (int j = 0; j < TextAnalysis.Text.vectors[currentVectorIndex].definitions.Count(); j++) {

                        string toAdd = "";

                        string currentVectorWord = TextAnalysis.Text.vectors[currentVectorIndex].word;

                        toAdd += "Current Vector: (" + currentVectorIndex + ")" + currentVectorWord + ". Definition: " + j + ", " + TextAnalysis.Text.vectors[currentVectorIndex].definitions[j].identifier + ". Related vectors: ";

                        //loops through all the vectors in this definition for this vector
                        for (int k = 0; k < TextAnalysis.Text.vectors[currentVectorIndex].definitions[j].relatedVectors.Count(); k++) {

                            int definitionToken = TextAnalysis.Text.vectors[currentVectorIndex].definitions[j].relatedVectors[k];
                            string definitionString = TextAnalysis.Text.vectors[definitionToken].word;

                            toAdd += "( " + definitionToken + ")" + definitionString + ", ";
                        }

                        allDefinitions.Items.Add(toAdd);
                    }

                    outputtedVectors.Add(currentVectorToken);
                }

            }

        }

        void OutputDBVecsToCLI() {
            Console.Clear();
            string result = DBManager.GetAllVectors();
            Console.WriteLine(result);
        }

        private void resetDB_btn_Click(object sender, EventArgs e) {
            DBManager.DeleteAll();
        }
    }
}

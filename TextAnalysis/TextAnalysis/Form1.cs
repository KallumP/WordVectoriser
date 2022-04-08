﻿using System;
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

            OutputDBVecsToCLI();
        }

        private void processText_btn_Click(object sender, EventArgs e) {

            ProcessText(inputText.Text);


            //updates ui settings
            currentTextToShow = texts.Count - 1;

            prevText.Enabled = true;
            nextText.Enabled = true;
            inputText.Text = "";


            //pushes vectors to the database
            DBManager.InsertVectors(TextAnalysis.Text.vectors);
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


        void ProcessText(string toProcess) {

            //adds the text from the textbox into the list of all texts
            texts.Add(new Text(toProcess));

            //vectorises the new text
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

            //loops through all the vectors in the vectorised text
            for (int i = 0; i < texts[currentTextToShow].vectorisedText.Count; i++) {

                int currentVector = texts[currentTextToShow].vectorisedText[i];

                //only outputs this vectors definitions if it hasn't already been outputted
                if (!outputtedVectors.Contains(currentVector)) {

                    //loops through all the definitions for this vector
                    for (int j = 0; j < TextAnalysis.Text.vectors[TextAnalysis.Text.TokenInVectorsList(currentVector)].definitions.Count(); j++) {

                        string toAdd = "";

                        int currentVectorToken = TextAnalysis.Text.TokenInVectorsList(currentVector);
                        string currentVectorWord = TextAnalysis.Text.vectors[currentVectorToken].word;

                        toAdd += "Current Vector: (" + currentVectorToken + ")" + currentVectorWord + ". Definition: " + j + ", " + TextAnalysis.Text.vectors[TextAnalysis.Text.TokenInVectorsList(currentVector)].definitions[j].identifier + ". Related vectors: ";

                        //loops through all the vectors in this definition for this vector
                        for (int k = 0; k < TextAnalysis.Text.vectors[TextAnalysis.Text.TokenInVectorsList(currentVector)].definitions[j].relatedVectors.Count(); k++) {

                            int definitionToken = TextAnalysis.Text.vectors[TextAnalysis.Text.TokenInVectorsList(currentVector)].definitions[j].relatedVectors[k];
                            string definitionString = TextAnalysis.Text.vectors[definitionToken].word;

                            toAdd += "( " + definitionToken + ")" + definitionString + ", ";
                        }

                        allDefinitions.Items.Add(toAdd);
                    }

                    outputtedVectors.Add(currentVector);
                }

            }

        }

        void OutputDBVecsToCLI() {
            Console.Clear();
            string result = DBManager.GetAllVectors();
            Console.WriteLine(result);
        }
    }
}

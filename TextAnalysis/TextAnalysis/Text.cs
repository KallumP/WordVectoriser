using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis {
    public class Text {

        static List<Vector> vectors = new List<Vector>();

        public string baseText { get; }

        public string normalisedText { get; set; }
        List<int> vectorisedText;

        public Text(string input) {

            baseText = input;
            NormaliseText();

        }


        public void NormaliseText() {

            string lowerCaseText = baseText.ToLower();
            normalisedText = "";

            //loops through all the characters in the normalised text
            for (int i = lowerCaseText.Length - 1; i >= 0; i--) {

                string current = lowerCaseText[i].ToString();

                Console.WriteLine("Currently looking at character: " + current);

                //cehcks if this is not a letter or a number or a full stop or a space or an apostrophe
                if (lowerCaseText[i] >= 97 && lowerCaseText[i] <= 122 || lowerCaseText[i] >= 48 && lowerCaseText[i] <= 57 || lowerCaseText[i] == 46 || lowerCaseText[i] == 32 || lowerCaseText[i] == 39) {

                    if (lowerCaseText[i] == 46)
                        current = " " + current;

                    Console.WriteLine("Adding: " + current);
                    normalisedText = current + normalisedText;
                    Console.WriteLine("Normalised text: " + normalisedText);

                }
            }
        }

        public void Vectorise() {

            string textToVectorise = normalisedText;

            vectorisedText = new List<int>();

            //splits the text into an arry of all words;
            string[] splitText = textToVectorise.Split(' ');

            //loops through all the words from the input
            for (int i = 0; i < splitText.Length; i++) {

                //gets the index of the current word
                int index = InList(splitText[i]);

                //if the index was not found
                if (index == -1) {

                    //creates a new vector
                    vectors.Add(new Vector(splitText[i]));

                    //saves the index to be the last vector
                    index = vectors.Count - 1;

                }

                //saves the vector in the vectorised text
                vectorisedText.Add(vectors[index].token);
            }
        }

        int InList(string toCheck) {

            for (int i = 0; i < vectors.Count; i++)

                if (vectors[i].word == toCheck)

                    return i;

            return -1;
        }

        public string OutputVectorised() {

            string toOut = "";

            foreach (int i in vectorisedText)
                toOut += i + ",";

            return toOut;
        }

        public List<Vector> GetVectors() {
            return vectors;
        }



    }

    public class Vector {
        static int count;
        public string word { get; set; }
        public int token { get; set; }

        public Vector(string input) {
            word = input;
            token = count++;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis {
    public class Text {

        public string baseText { get; }

        static List<Vector> vectors { get; } = new List<Vector>();


        List<int> vectorisedText;

        public Text(string input) {

            baseText = input;

        }


        public void vectorise() {

            vectorisedText = new List<int>();

            //splits the text into an arry of all words;
            string[] splitText = baseText.Split(' ');

            //loops through all the words from the input
            for (int i = 0; i < splitText.Length; i++) {

                //gets the index of the current word
                int index = inList(splitText[i]);

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

        public int inList(string toCheck) {

            for (int i = 0; i < vectors.Count; i++)

                if (vectors[i].word == toCheck)

                    return i;

            return -1;
        }

        public string outputVectorised() {

            string toOut = "";

            foreach (int i in vectorisedText) {

                toOut += i + ",";

            }

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

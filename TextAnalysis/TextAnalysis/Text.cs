using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis {
    public class Text {

        static List<Vector> vectors = new List<Vector>();

        public string baseText { get; }

        public string normalisedText { get; set; }
        public List<int> vectorisedText { get; set; }

        int bagSize;
        public int bagPosition { get; set; }

        public Text(string input) {

            baseText = input;
            NormaliseText();

            bagSize = 10;
            bagPosition = 0;

        }

        public void NormaliseText() {

            string lowerCaseText = baseText.ToLower();
            normalisedText = "";

            //loops through all the characters in the normalised text
            for (int i = lowerCaseText.Length - 1; i >= 0; i--) {

                string current = lowerCaseText[i].ToString();

                //Console.WriteLine("Currently looking at character: " + current);

                //cehcks if this is not a letter or a number or a full stop or a space or an apostrophe
                if (lowerCaseText[i] >= 97 && lowerCaseText[i] <= 122 ||
                    lowerCaseText[i] >= 48 && lowerCaseText[i] <= 57 ||
                    lowerCaseText[i] == 46 ||
                    lowerCaseText[i] == 32 ||
                    lowerCaseText[i] == 39) {

                    //checks if the character was a full stop
                    if (lowerCaseText[i] == 46)

                        //separates the full stop from the previous word with a space
                        current = " " + current;

                    //adds the current (wanted) character to the normalise text
                    //Console.WriteLine("Adding: " + current);
                    normalisedText = current + normalisedText;
                    //Console.WriteLine("Normalised text: " + normalisedText);

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

        public string VectorTokenToString(int vector) {

            for (int i = 0; i < vectors.Count; i++)
                if (vectors[i].token == vector)
                    return vectors[i].word;

            return null;
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



        public void UpdateBagPosition(int direction) {

            //updates the bag position
            bagPosition += direction;

            //constrains the position to size of the vector list
            if (bagPosition < 0)
                bagPosition = 0;

            else if (bagPosition > vectorisedText.Count - 1)
                bagPosition = vectorisedText.Count - 1;

            //no need to try chaning if there are no other vectors to change to
            if (vectorisedText.Count > 1)

                //checks if the current bagposition is on a full stop
                if (VectorTokenToString(vectorisedText[bagPosition]) == ".")

                    //keeps updating the position (doesn't go beyond the list bounds)
                    if (bagPosition == 0)
                        UpdateBagPosition(1);
                    else if (bagPosition == vectorisedText.Count - 1)
                        UpdateBagPosition(-1);
                    else
                        UpdateBagPosition(direction);


        }

        public string GetBagVectors() {

            //make sure that the text has been vectorised
            if (vectorisedText != null) {

                //sets the start and end of the bag
                int start = bagPosition - bagSize / 2;
                int end = bagPosition + bagSize / 2;

                //constrains the bag between the start and end of the vector list
                if (start < 0)
                    start = 0;
                if (end > vectorisedText.Count - 1)
                    end = vectorisedText.Count - 1;


                string toReturn = "";

                //loops through all the vectors in the bag
                for (int i = start; i < end; i++)

                    //constructs the string of the vector's token and word
                    toReturn += "(" + vectors[vectorisedText[i]].token + ")" + vectors[vectorisedText[i]].word + " ";

                return toReturn;



            } else return "";
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

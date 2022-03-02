using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis {
    public class Text {

        public static List<Vector> vectors = new List<Vector>();

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

                //gets the vectors index of the current word
                int index = StringInVectorsList(splitText[i]);

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

        public static int StringInVectorsList(string toCheck) {

            for (int i = 0; i < vectors.Count; i++)

                if (vectors[i].word == toCheck)

                    return i;

            return -1;
        }

        public static int TokenInVectorsList(int toCheck) {

            for (int i = 0; i < vectors.Count; i++)

                if (vectors[i].token == toCheck)

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


        public void GenerateDefinitions() {

            bagPosition = 0;

            do
                vectors[TokenInVectorsList(vectorisedText[bagPosition])].definitions.Add(new Definition(GetBagVectors()));
            while (IncrementBagPosition());

        }



        public List<int> GetBagVectors() {

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


                //stops the start from being behind a full stop
                for (int i = bagPosition; i >= start; i--)
                    if (VectorTokenToString(vectors[vectorisedText[i]].token) == ".")
                        start = i + 1;

                //stops the end from going past a full stop
                for (int i = bagPosition; i <= end; i++)
                    if (VectorTokenToString(vectors[vectorisedText[i]].token) == ".")
                        end = i;


                List<int> toReturn = new List<int>();

                //loops through all the vectors in the bag
                for (int i = start; i < end; i++)

                    //stops the inclusion of the bag position in the definition
                    if (i != bagPosition)

                        //adds this vector to the list of defining vectors
                        toReturn.Add(vectors[vectorisedText[i]].token);

                return toReturn;

            } else return null;
        }

        bool IncrementBagPosition() {

            //updates the bag position
            bagPosition++;

            if (bagPosition > vectorisedText.Count - 1)
                return false;

            //checks if the current bagposition is on a full stop
            if (VectorTokenToString(vectorisedText[bagPosition]) == ".")

                //increments the bag position past the full stop
                return IncrementBagPosition();

            return true;
        }
    }

    public class Vector {
        static int tokenGlobal;
        public string word { get; set; }
        public int token { get; set; }

        public List<Definition> definitions;

        public Vector(string input) {
            word = input;
            token = tokenGlobal++;
            definitions = new List<Definition>();
        }

        public Vector(string input, int _token) {
            word = input;
            token = _token;
            definitions = new List<Definition>();
        }
    }

    public class Definition {

        //need way of setting the largest id from the database when all defitions are found

        public static int identifierGlobal;

        public int identifier;
        public List<int> relatedVectors;

        public Definition(List<int> _relatedVectors) {

            identifier =  identifierGlobal++;
            relatedVectors = _relatedVectors;
        }

        public Definition(List<int> _relatedVectors, int _identifier) {

            identifier = _identifier;
            relatedVectors = _relatedVectors;
        }


    }
}

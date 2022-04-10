using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;

namespace TextAnalysis {
    public static class DBManager {

        static string connectionString;
        static SqlConnection connectionToDB;

        public static void Setup(string _connectionString) {
            connectionString = _connectionString;
        }

        public static void InsertVectorsAndDefinitions(List<Vector> vectors) {

            string query;
            string selectResult;

            //loops through all the vectors to upload vectors
            foreach (Vector v in vectors) {


                //query to pull this vector from the db
                query = "SELECT * FROM Vector WHERE token = " + v.token.ToString() + ";";
                selectResult = ExecuteSelect(query);

                //checks if there wasn't already this vector in the db
                if (selectResult == null) {

                    //insert vector where vector token does not exist (no duplicate vectors)
                    query = "INSERT INTO Vector (token, string) VALUES (" + v.token.ToString() + ",'" + v.word + "');";
                    ExecuteQuery(query);

                }
            }

            //loops through all the vectors to upload definitions
            foreach (Vector v in vectors) {

                //loops through each definition for this vector
                foreach (Definition d in v.definitions) {

                    //query to pull this vector from the db
                    query = "SELECT * FROM Definition WHERE id = " + d.identifier.ToString() + ";";
                    selectResult = ExecuteSelect(query);

                    //checks to see if this definition does not already exist
                    if (selectResult == null) {

                        //inserts the definition
                        query = "INSERT INTO Definition (id, vectorLink) VALUES (" + d.identifier.ToString() + "," + v.token.ToString() + ");";
                        ExecuteQuery(query);

                        //loops through all related vectors
                        foreach (int i in d.relatedVectors) {

                            //inserts all related vectors linked to definition
                            query = "INSERT INTO Related (definitionID, relatedVector) VALUES (" + d.identifier.ToString() + "," + i.ToString() + ");";
                            ExecuteQuery(query);
                        }
                    }
                }
            }
        }

        public static string GetAllVectors() {

            //selects all vectors
            string query = "SELECT * FROM Vector";
            string result = ExecuteMultipleSelect(query);
            return result;
        }

        public static string GetAllDefinitions(Vector v) {

            //selects all definitions for this vector
            string query = "SELECT id FROM Definition WHERE (vectorLink = " + v.token.ToString() + ");";
            string result = ExecuteMultipleSelect(query);
            return result;
        }

        public static string GetAllRelatedVectors(string definitionIdentifier) {

            //selects all related vectors for this definition
            string query = "SELECT relatedVector FROM Related WHERE (definitionID = " + definitionIdentifier + ");";
            string result = ExecuteMultipleSelect(query);
            return result;
        }

        public static void DeleteAll() {

            //deletes everything from all tables
            string query = "DELETE FROM Related; DELETE FROM Definition; DELETE FROM Vector;";
            ExecuteQuery(query);
        }

        public static void ExecuteQuery(string query) {

            //stops the database from being used more than once
            using (connectionToDB = new SqlConnection(connectionString)) {

                //sets up the sql command with the query string, and the database to apply the command to
                SqlCommand command = new SqlCommand(query, connectionToDB);


                //opens the connection to the database
                connectionToDB.Open();

                //executes the command
                command.ExecuteNonQuery();


                //closes the execution
                connectionToDB.Close();
            }
        }

        public static string ExecuteSelect(string query) {

            //stops the database from being used more than once
            using (connectionToDB = new SqlConnection(connectionString)) {

                SqlCommand command = new SqlCommand(query, connectionToDB);

                connectionToDB.Open();

                //string result = Convert.ToString(POST.ExecuteNonQuery());
                SqlDataReader dr = command.ExecuteReader();

                //sets up a variable to save the column to
                string resultString = null;

                //makes sure that a row was found
                if (dr.HasRows) {
                    //reads the data in the row
                    dr.Read();

                    //saves the first index of the data from that row
                    resultString = dr[0].ToString();
                }

                connectionToDB.Close();

                return resultString;
            }
        }

        public static string ExecuteMultipleSelect(string query) {

            //stops the database from being used more than once
            using (connectionToDB = new SqlConnection(connectionString)) {

                SqlCommand command = new SqlCommand(query, connectionToDB);

                connectionToDB.Open();

                //string result = Convert.ToString(POST.ExecuteNonQuery());
                SqlDataReader dr = command.ExecuteReader();

                //sets up a variable to save the column to
                string resultString = null;

                //makes sure that a row was found
                if (dr.HasRows) {

                    while (dr.Read()) {

                        //loops through all the values in this column
                        for (int i = 0; i < dr.FieldCount; i++) {

                            resultString += dr.GetValue(i);

                            //adds on a comma if this isn't the last value
                            if (i != dr.FieldCount - 1)
                                resultString += ",";
                        }

                        //end of this value
                        resultString += ";";
                    }
                }

                connectionToDB.Close();

                return resultString;
            }
        }
    }
}

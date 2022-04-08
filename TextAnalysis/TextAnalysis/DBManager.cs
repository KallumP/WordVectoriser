using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;
//using System.Data.SqlClient;

namespace TextAnalysis {
    public static class DBManager {

        static string connectionString;
        static SqlConnection connectionToDB;

        public static void Setup(string _connectionString) {
            connectionString = _connectionString;
        }

        public static void OpenConnection() {

            //open the connection
            connectionToDB.Open();
        }

        public static void CloseConnection() {

            connectionToDB.Close();
        }


        public static void InsertVectors(List<Vector> vectors) {

            //loops through all the vectors
            foreach (Vector v in vectors) {

                string query;
                string selectResult;


                //query to pull this vector from the db
                query = "SELECT * FROM Vector WHERE token = " + v.token.ToString() + ";";
                selectResult = ExecuteSelect(query);

                //checks if there wasn't already this vector in the db
                if (selectResult != null) {

                    //insert vector where vector token does not exist (no duplicate vectors)
                    query = "INSERT INTO Vector (token, string) VALUES (" + v.token.ToString() + "," + v.word + ");";
                    ExecuteInsert(query);

                }

                //loops through each definition for this vector
                foreach (Definition d in v.definitions) {

                    //query to pull this vector from the db
                    query = "SELECT * FROM Definition WHERE id = " + d.identifier.ToString() + ";";
                    selectResult = ExecuteSelect(query);

                    //checks to see if this definition does not already exist
                    if (selectResult != null) {

                        //inserts the definition
                        query = "INSERT INTO Definition (id, vectorLink) VALUES (" + d.identifier.ToString() + "," + v.token.ToString() + ");";
                        ExecuteInsert(query);

                        //loops through all related vectors
                        foreach (int i in d.relatedVectors) {

                            //inserts all related vectors linked to definition
                            query = "INSERT INTO Related (definitionID, relatedVector) VALUES (" + d.identifier.ToString() + "," + i.ToString() + ");";
                            ExecuteInsert(query);
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
            string query = "SELECT id FROM Definition WHERE (vectorLink = " + v.token.ToString() + ";";
            string result = ExecuteMultipleSelect(query);
            return result;
        }

        public static string GetAllRelatedVectors(Definition d) {

            //selects all related vectors for this definition
            string query = "SELECT relatedVector FROM Related WHERE (definitionID = " + d.identifier.ToString() + ";";
            string result = ExecuteMultipleSelect(query);
            return result;
        }


        public static void ExecuteInsert(string query) {

            //stops the database from being used more than once
            using (connectionToDB = new SqlConnection(connectionString)) {

                //sets up the sql command with the query string, and the database to apply the command to
                SqlCommand command = new SqlCommand(query, connectionToDB);


                //opens the connection to the database
                connectionToDB.Open();
                //OpenConnection();

                //executes the command
                command.ExecuteNonQuery();


                //closes the execution
                connectionToDB.Close();
                //CloseConnection();
            }
        }

        public static string ExecuteSelect(string query) {

            //stops the database from being used more than once
            using (connectionToDB = new SqlConnection(connectionString)) {

                SqlCommand command = new SqlCommand(query, connectionToDB);

                connectionToDB.Open();
                //OpenConnection();

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
                //CloseConnection();

                return resultString;
            }
        }

        public static string ExecuteMultipleSelect(string query) {

            //stops the database from being used more than once
            using (connectionToDB = new SqlConnection(connectionString)) {

                SqlCommand command = new SqlCommand(query, connectionToDB);

                connectionToDB.Open();
                //OpenConnection();

                //string result = Convert.ToString(POST.ExecuteNonQuery());
                SqlDataReader dr = command.ExecuteReader();

                //sets up a variable to save the column to
                string resultString = null;

                //makes sure that a row was found
                if (dr.HasRows) {

                    while (dr.Read())

                        resultString += dr.GetValue(0) + "!";
                }

                connectionToDB.Close();
                //CloseConnection();

                return resultString;
            }
        }



        //public static DataSet GetDataSet(string sqlStatement) {

        //    DataSet dataSet;

        //    // create the object dataAdapter to manipulate a table from the database specified by connectionToDB
        //    dataAdapter = new SqlDataAdapter(sqlStatement, connectionToDB);

        //    // create the dataset
        //    dataSet = new DataSet();

        //    dataAdapter.Fill(dataSet);

        //    //return the dataSet
        //    return dataSet;
        //}


    }
}

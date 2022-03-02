using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;

namespace TextAnalysis {
    internal class DBConnection {

        string connectionString;
        SqlConnection dbConnection;
        SqlDataAdapter dataAdapter;

        public DBConnection(string _connectionString) {
            connectionString = _connectionString;
        }

        public void OpenConnection() {

            // create the connection to the database as an instance of SqlConnection
            dbConnection = new SqlConnection(connectionString);

            //open the connection
            dbConnection.Open();
        }

        public void CloseConnection() {

            dbConnection.Close();
        }

        public DataSet GetDataSet(string sqlStatement) {
            
            DataSet dataSet;

            // create the object dataAdapter to manipulate a table from the database StudentDissertations specified by connectionToDB
            dataAdapter = new SqlDataAdapter(sqlStatement, dbConnection);

            // create the dataset
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            //return the dataSet
            return dataSet;
        }


    }
}

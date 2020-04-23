using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class Aplication
    {
        public bool Calculator(string login)
        {
            int points2 = 0;
            const string conS = @"Data Source= localhost; Initial Catalog = LoanCalculator; user id= sa; password=Root123.";
            SqlConnection conForLc = new SqlConnection(conS);
            string commandText = $"Select * from Register where login = '{login}'";
            if (ConnectionState.Closed == conForLc.State ){conForLc.Open();}
            SqlCommand add = new SqlCommand(commandText,conForLc);
            SqlDataReader read = add.ExecuteReader();
            while(read.Read())
            {
                points2+=int.Parse(read.GetValue(11).ToString());
            }
            read.Close();
            return true;
        }
    }
}
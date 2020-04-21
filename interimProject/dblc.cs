using System;
using System.Data;
using System.Data.SqlClient;
namespace interimProject
{
    class Dblc
    {
        const string conS = @"Data Source= localhost; Initial Catalog = LoanCalculator; user id= sa; password=Root123.";
        SqlConnection conForLc = new SqlConnection(conS);
        public void OpenConnection ()
        {
            conForLc.Open();
            System.Console.WriteLine("db is connected!");
        }
        public void CheckingConnection()
        {
        if (conForLc.State == ConnectionState.Open)
            {
                System.Console.WriteLine("Connected successfully!!!");
            }else{
                System.Console.WriteLine("Ooops, troubles with connection!!!");
            } 
        }

    }
}
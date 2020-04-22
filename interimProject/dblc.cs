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
        public void Selection()
        {
            string commandText = "Select * from Person";
            SqlCommand command = new SqlCommand(commandText, conForLc);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                System.Console.WriteLine($"ID:{reader.GetValue(0)}\nLast Name:{reader.GetValue(1)}\nFirst Name:{reader.GetValue(2)}\nMiddle Name:{reader.GetValue(3)}\nBirth Date:{reader.GetValue(4)}");
            } 
        }
        public void Insert (string lastName, string firstName, string middleName, string dateOfBirth)
        {
            string insertingSqlCommand = string.Format($"insert into Person([Last_Name],[First_Name],[Middle_Name], [Birth_date]) values ('{lastName}','{firstName}','{middleName}', '{dateOfBirth}')");
            
            SqlCommand command = new SqlCommand(insertingSqlCommand,conForLc);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                System.Console.WriteLine("Insert command successfull!!!");
            }
        }
        public void SelectionById(int idselect)
        {
            string SelectionByIdCommand = string.Format($"select * from Person where Id = {idselect}");
            SqlCommand command = new SqlCommand(SelectionByIdCommand, conForLc);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                System.Console.WriteLine($"ID:{reader.GetValue(0)}\nLast Name:{reader.GetValue(1)}\nFirst Name:{reader.GetValue(2)}\nMiddle Name:{reader.GetValue(3)}");
            }
        }
        public void UpdateById(int inputId, string lastName2, string firstName2, string middleName2, string dateOfBirth2)
        {
            string updateIdCommand = string.Format($"update Person set Last_Name = '{lastName2}',First_Name ='{firstName2}',Middle_Name ='{middleName2}',Birth_Date = '{dateOfBirth2}' where Id = {inputId}");
            SqlCommand command = new SqlCommand(updateIdCommand, conForLc);
            var result = command.ExecuteNonQuery();

            if(result > 0)
            {
               System.Console.WriteLine($"Updated Person with {inputId} Id!"); 
            }else{
                System.Console.WriteLine($"There is no ID like {inputId}!!");
            }
        }
        public void DeleteId (int deleteId)
        {
            string deleteIdCommand = string.Format($"delete Person where Id = {deleteId}");
            SqlCommand command = new SqlCommand(deleteIdCommand, conForLc);
            var result = command.ExecuteNonQuery();
            if(result > 0)
            {
               System.Console.WriteLine($"ID {deleteId} was deleted"); 
            }else{
                System.Console.WriteLine($"There is no {deleteId} ID!");
            }
        }
    }
}
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
        // public void Selection()
        // {
        //     string commandText = "Select * from Register";
        //     SqlCommand command = new SqlCommand(commandText, conForLc);
        //     SqlDataReader reader = command.ExecuteReader();
        //     while (reader.Read())
        //     {
        //         System.Console.WriteLine($"ID:{reader.GetValue(0)}\nLast Name:{reader.GetValue(1)}\nFirst Name:{reader.GetValue(2)}\nMiddle Name:{reader.GetValue(3)}\nBirth Date:{reader.GetValue(4)}");
        //     } 
        // }
        // public void clientInsert (string lastName, string firstName, string middleName)
        // {
        //     string insertingSqlCommand = string.Format($"insert into Person([Last_Name],[First_Name],[Middle_Name]) values ('{lastName}','{firstName}','{middleName}')");
            
        //     SqlCommand command = new SqlCommand(insertingSqlCommand,conForLc);
        //     var result = command.ExecuteNonQuery();
        //     if (result > 0)
        //     {
        //         System.Console.WriteLine("Insert command successfull!!!");
        //     }
        // }
        public void AdminInsert (string lastName, string firstName, string middleName, string login, string passportID, string systempassword )
        {
            string insertingSqlCommand = string.Format($"insert into Register([Lastname],[FirstName],[MiddleName], [login], [role], [PassportID],[SystemPasword]) values ('{lastName}','{firstName}', '{middleName}','{login}','Admin','{passportID}','{systempassword}')");
            
            SqlCommand command = new SqlCommand(insertingSqlCommand,conForLc);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                System.Console.WriteLine("Insert command successfull!!!");
            }
        }
        // public void SelectionById(int idselect)
        // {
        //     string SelectionByIdCommand = string.Format($"select * from Register where Id = {idselect}");
        //     SqlCommand command = new SqlCommand(SelectionByIdCommand, conForLc);
        //     SqlDataReader reader = command.ExecuteReader();
        //     while (reader.Read())
        //     {
        //         System.Console.WriteLine($"ID:{reader.GetValue(0)}\nLast Name:{reader.GetValue(1)}\nFirst Name:{reader.GetValue(2)}\nMiddle Name:{reader.GetValue(3)}");
        //     }
        // }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
namespace interimProject
{
    class DbRegister
    {
        const string conS = @"Data Source= localhost; Initial Catalog = LoanCalculator; user id= sa; password=Root123.";
        SqlConnection conForLc = new SqlConnection(conS);
        public void OpenConnection()
        {
            conForLc.Open();
            System.Console.WriteLine("db is connected!");
        }
        public void CheckingConnection()
        {
            if (conForLc.State == ConnectionState.Open)
            {
                System.Console.WriteLine("Connected successfully!!!");
            }
            else
            {
                System.Console.WriteLine("Ooops, troubles with connection!!!");
            }
        }

        // public void Select()
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
        public void SelectionByLogin(string login)
        {
            string SelectionByIdCommand = string.Format($"select * from Register where login = '{login}'");
            SqlCommand command = new SqlCommand(SelectionByIdCommand, conForLc);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                System.Console.WriteLine($"Last Name:{reader.GetValue(1)}\nFirst Name:{reader.GetValue(2)}\nLogin:{reader.GetValue(3)}\nPassport ID:{reader.GetValue(5)}\nGender:{reader.GetValue(6)}\nMarital Status:{reader.GetValue(7)}\nBirth Date:{reader.GetValue(8)}\nCitizenship:{reader.GetValue(9)}\nSystem Password:{reader.GetValue(10)}");
            }
            reader.Close();
        }

        public void Checkingidentity(string inputLogin, string inputSystemPassword)
        {
            string checkingcommand = string.Format($"select * from Register");
            SqlCommand checking = new SqlCommand(checkingcommand, conForLc);
            SqlDataReader readerForChecking = checking.ExecuteReader();
            while (readerForChecking.Read())
            {
                if (inputLogin == readerForChecking.GetValue(3).ToString() && inputSystemPassword == readerForChecking.GetValue(10).ToString())
                {
                    System.Console.WriteLine($"wellcome, {readerForChecking.GetValue(2).ToString()}");
                }
            }
            readerForChecking.Close();
        }
        public void SelectionByLoginFromApp(string login)
        {
            string SelectionByIdCommand = string.Format($"select * from Application where login = '{login}'");
            SqlCommand command = new SqlCommand(SelectionByIdCommand, conForLc);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                System.Console.WriteLine($"Purpose:{reader.GetValue(1)}\nMounth salary at that time:{reader.GetValue(2)}\nTerm:{reader.GetValue(3)}\nCredit Amoung:{reader.GetValue(5)}\nResolution:{reader.GetValue(6)}");
            }
            reader.Close();
        }
    }
}
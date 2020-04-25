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
            {System.Console.WriteLine("Connected successfully!!!");}
            else{System.Console.WriteLine("Ooops, troubles with connection!!!");}
        }
        public void SelectFromRegister(string sortCompany)
        {
            string commandText = "Select * from Register where Company = '{sortCompany}'";
            SqlCommand command = new SqlCommand(commandText, conForLc);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                System.Console.WriteLine($"ID:{reader.GetValue(0)}\nLast Name:{reader.GetValue(1)}\nFirst Name:{reader.GetValue(2)}\nLogin:{reader.GetValue(3)}\nRole:{reader.GetValue(4)}PassportID:{reader.GetValue(5)}\nGender:{reader.GetValue(6)}\nMarital status:{reader.GetValue(7)}\nBirth Date:{reader.GetValue(8)}\nCitizenship:{reader.GetValue(9)}\nSystemPassword:{reader.GetValue(10)}\ndefaultPoint:{reader.GetValue(11)}");
            }
            reader.Close();
        }
        public void SelectFromApplication(string sortCompany)
        {
            string commandText = "Select * from Application where Company = '{sortCompany}'";
            SqlCommand command = new SqlCommand(commandText, conForLc);
            SqlDataReader reader1 = command.ExecuteReader();
            while (reader1.Read())
            {
                System.Console.WriteLine($"Login:{reader1.GetValue(0)}\nPurpose:{reader1.GetValue(1)}\nMounth salary at that time:{reader1.GetValue(2)}\nTerm:{reader1.GetValue(3)}\nCredit Amoung:{reader1.GetValue(4)}\nResolution:{reader1.GetValue(5)}");
            }
            reader1.Close();
        }
        public void SelectFromCreditHistory(string sortCompany)
        {
            string commandText = "Select * from CreditHistory where Company = '{sortCompany}'";
            SqlCommand command = new SqlCommand(commandText, conForLc);
            SqlDataReader reader1 = command.ExecuteReader();
            while (reader1.Read())
            {
                System.Console.WriteLine($"Login:{reader1.GetValue(0)}\nCredit ID:{reader1.GetValue(1)}\nPurpose:{reader1.GetValue(2)}\nCredit amoung:{reader1.GetValue(3)}\nTerm:{reader1.GetValue(4)}\nDelay:{reader1.GetValue(5)}\nDate of opening:{reader1.GetValue(6)}\nDate of closing:{reader1.GetValue(7)}\nCredit rest:{reader1.GetValue(8)}\nStatus:{reader1.GetValue(9)}");
            }
            reader1.Close();
        }
        public void SelectFromConnectingadmin(string sortCompany)
        {
            string commandText = "Select * from ConnectingAdmin where Company = '{sortCompany}'";
            SqlCommand command = new SqlCommand(commandText, conForLc);
            SqlDataReader reader1 = command.ExecuteReader();
            while (reader1.Read())
            {
                System.Console.WriteLine($"Login:{reader1.GetValue(0)}\nCompany:{reader1.GetValue(1)}\nMassage:{reader1.GetValue(2)}");
            }
            reader1.Close();
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
                else if (inputLogin == readerForChecking.GetValue(3).ToString() && inputSystemPassword != readerForChecking.GetValue(10).ToString())
                {
                    Console.Clear();
                    System.Console.WriteLine("Incorrect systempassword!!!");
                    System.Console.WriteLine("there is no connection. restart the program for correct work!!!");
                }
                else if (inputLogin != readerForChecking.GetValue(3).ToString() && inputSystemPassword == readerForChecking.GetValue(10).ToString())
                {
                    Console.Clear();
                    System.Console.WriteLine("Incorrect Login!!!");
                    System.Console.WriteLine("there is no connection. restart the program for correct work!!!");
                }
                
            }
            readerForChecking.Close();
        }
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
        public void SelectionByLoginFromApp(string login)
        {
            string SelectionByIdCommand = string.Format($"select * from Application where login = '{login}'");
            SqlCommand command = new SqlCommand(SelectionByIdCommand, conForLc);
            SqlDataReader reader1 = command.ExecuteReader();

            while (reader1.Read())
            {
                System.Console.WriteLine($"Purpose:{reader1.GetValue(1)}\nMounth salary at that time:{reader1.GetValue(2)}\nTerm:{reader1.GetValue(3)}\nCredit Amoung:{reader1.GetValue(4)}\nResolution:{reader1.GetValue(5)}");
            }
            reader1.Close();
        }
        public void SelectionByLoginFromCreditHistory(string login)
        {
            string SelectionByIdCommand = string.Format($"select * from CreditHistory where login = '{login}'");
            SqlCommand command = new SqlCommand(SelectionByIdCommand, conForLc);
            SqlDataReader reader1 = command.ExecuteReader();

            while (reader1.Read())
            {
                System.Console.WriteLine($"Credit ID:{reader1.GetValue(1)}\nPurpose:{reader1.GetValue(2)}\nCredit amoung:{reader1.GetValue(3)}\nTerm:{reader1.GetValue(4)}\nDelay:{reader1.GetValue(5)}\nDate of opening:{reader1.GetValue(6)}\nDate of closing:{reader1.GetValue(7)}\nCredit rest:{reader1.GetValue(8)}\nStatus:{reader1.GetValue(9)}");
            }
            reader1.Close();
        }
        public void selectbyLoginfromConnectingadmin(string login)
        {
            string SelectionByIdCommand = string.Format($"select * from ConnectingAdmin where login = '{login}'");
            SqlCommand command = new SqlCommand(SelectionByIdCommand, conForLc);
            SqlDataReader reader1 = command.ExecuteReader();

            while (reader1.Read())
            {
                System.Console.WriteLine($"Еhe company you are contacting:{reader1.GetValue(1)}\nYour massage:{reader1.GetValue(2)}");
            }
            reader1.Close();
        }
                public void HSelectFromRegister()
        {
            string commandText = "Select * from Register";
            SqlCommand command = new SqlCommand(commandText, conForLc);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                System.Console.WriteLine($"ID:{reader.GetValue(0)}\nLast Name:{reader.GetValue(1)}\nFirst Name:{reader.GetValue(2)}\nLogin:{reader.GetValue(3)}\nRole:{reader.GetValue(4)}PassportID:{reader.GetValue(5)}\nGender:{reader.GetValue(6)}\nMarital status:{reader.GetValue(7)}\nBirth Date:{reader.GetValue(8)}\nCitizenship:{reader.GetValue(9)}\nSystemPassword:{reader.GetValue(10)}\ndefaultPoint:{reader.GetValue(11)}");
            }
            reader.Close();
        }
        public void HSelectFromApplication()
        {
            string commandText = "Select * from Application";
            SqlCommand command = new SqlCommand(commandText, conForLc);
            SqlDataReader reader1 = command.ExecuteReader();
            while (reader1.Read())
            {
                System.Console.WriteLine($"Login:{reader1.GetValue(0)}\nPurpose:{reader1.GetValue(1)}\nMounth salary at that time:{reader1.GetValue(2)}\nTerm:{reader1.GetValue(3)}\nCredit Amoung:{reader1.GetValue(4)}\nResolution:{reader1.GetValue(5)}");
            }
            reader1.Close();
        }
        public void HSelectFromCreditHistory()
        {
            string commandText = "Select * from CreditHistory";
            SqlCommand command = new SqlCommand(commandText, conForLc);
            SqlDataReader reader1 = command.ExecuteReader();
            while (reader1.Read())
            {
                System.Console.WriteLine($"Login:{reader1.GetValue(0)}\nCredit ID:{reader1.GetValue(1)}\nPurpose:{reader1.GetValue(2)}\nCredit amoung:{reader1.GetValue(3)}\nTerm:{reader1.GetValue(4)}\nDelay:{reader1.GetValue(5)}\nDate of opening:{reader1.GetValue(6)}\nDate of closing:{reader1.GetValue(7)}\nCredit rest:{reader1.GetValue(8)}\nStatus:{reader1.GetValue(9)}");
            }
            reader1.Close();
        }
        public void HSelectFromConnectingadmin()
        {
            string commandText = "Select * from ConnectingAdmin '";
            SqlCommand command = new SqlCommand(commandText, conForLc);
            SqlDataReader reader1 = command.ExecuteReader();
            while (reader1.Read())
            {
                System.Console.WriteLine($"Login:{reader1.GetValue(0)}\nCompany:{reader1.GetValue(1)}\nMassage:{reader1.GetValue(2)}");
            }
            reader1.Close();
        }
    }
}
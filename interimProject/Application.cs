using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class Application
    {
        string password { get; set; }
        int Purpose { get; set; }
        int Salary { get; set; }
        int term { get; set; }
        int creditAmoung { get; set; }
        const string conS = @"Data Source= localhost; Initial Catalog = LoanCalculator; user id= sa; password=Root123.";
        SqlConnection conForLc = new SqlConnection(conS);
        public bool Calculator(string login)
        {
            int points2 = 0;
            this.password = password;
            string commandText = $"Select * from Register where SystemPassword = '{password}'";
            if (ConnectionState.Closed == conForLc.State) { conForLc.Open(); }
            SqlCommand add = new SqlCommand(commandText, conForLc);
            SqlDataReader read = add.ExecuteReader();
            while (read.Read())
            {
                points2 += int.Parse(read.GetValue(11).ToString());
            }
            read.Close();
            System.Console.WriteLine("To apply for a loan, you must fill out the fields!");
            System.Console.Write("Choose purpose:\n*1* --> Appliances\n*2*-->HomeFix\n*3*-->to buy phone\n*4*-->smth else\nYour choise:");
            int purpose = int.Parse(Console.ReadLine());
            this.Purpose = purpose;
            if (purpose == 1) { points2 += 2; }
            else if (purpose == 2) { points2 += 1; }
            else if (purpose == 4) { points2 -= 1; }
            System.Console.Write("Enter Credit amoung: ");
            int creditAmoung = int.Parse(Console.ReadLine());
            this.creditAmoung = creditAmoung;
            System.Console.Write("Enter your mounth salary: ");
            int salary = int.Parse(Console.ReadLine());
            this.Salary = salary;
            System.Console.Write("Enter term (MM): ");
            points2++;
            int term = int.Parse(Console.ReadLine());
            this.term = term;
            if ((creditAmoung * 100) / salary < 80) { points2 += 4; }
            else if ((creditAmoung * 100) / salary >= 80 & (creditAmoung * 100) / salary < 150) { points2 += 3; }
            else if ((creditAmoung * 100) / salary >= 150 & (creditAmoung * 100) / salary < 250) { points2 += 2; }
            else if ((creditAmoung * 100) / salary > 250) { points2 += 1; }
            int delay = 0;
            int countcloseCredit = 0;
            commandText = $"Select * from CreditHistory where login = '{login}'";
            SqlCommand find = new SqlCommand(commandText, conForLc);
            SqlDataReader findreader = find.ExecuteReader();
            while (findreader.Read())
            {
                delay += int.Parse(findreader.GetValue(5).ToString());
                if (findreader.GetValue(9).ToString() == "open")
                {
                    System.Console.WriteLine("You have an open credit!\nApplication rejected!!!");
                    return false;
                }
                else { countcloseCredit += 1; }
            }
            findreader.Close();
            if (points2 < 12)
            {
                System.Console.WriteLine("Application rejected!!!");
                return false;
            }
            else
            {
                System.Console.WriteLine("Credit approved for you!");
                return true;
            }


        }
        public void Insert()
        {
            string insertingSqlCommand = string.Format($"insert into Application ([login],[Purpose],[Salary],[creditAmoung],[term]) values ('{password}', {Purpose} ,{Salary}, {creditAmoung}, {term})");
            if (ConnectionState.Closed == conForLc.State)
            { conForLc.Open(); }
            SqlCommand command = new SqlCommand(insertingSqlCommand, conForLc);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                System.Console.WriteLine($"successfully registered!\n Wellcome!");
            }
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class Application
    {
        string login { get; set; }
        string Purpose { get; set; }
        int Salary { get; set; }
        int term { get; set; }
        int creditAmoung { get; set; }
        const string conS = @"Data Source= localhost; Initial Catalog = LoanCalculator; user id= sa; password=Root123.";
        SqlConnection conForLc = new SqlConnection(conS);
        public bool Calculator(string login)
        {
            int points2 = 0;
            int delay = 0;
            int countcloseCredit = 0;
            this.login = login;
            string commandText = $"Select * from Register where login = '{login}'";
            if (ConnectionState.Closed == conForLc.State) { conForLc.Open(); }
            SqlCommand add = new SqlCommand(commandText, conForLc);
            SqlDataReader read = add.ExecuteReader();
            while (read.Read())
            {
                points2 += int.Parse(read.GetValue(11).ToString());
            }
            read.Close();
            System.Console.WriteLine("To apply for a loan, you must fill out the fields!");
            System.Console.Write("Choose purpose:\n*1* --> Appliances\n*2*-->HomeFix\n*3*-->Phone\n*4*-->smth else\nYour choise:");
            string purpose = Console.ReadLine().ToLower();
            this.Purpose = purpose;
            if (purpose == "appliances") { points2 += 2; }
            else if (purpose == "homeFix") { points2++;; }
            else if (purpose == "phone") { points2--;; }
            System.Console.Write("Enter Credit amoung: ");
            int creditAmoung = int.Parse(Console.ReadLine());
            this.creditAmoung = creditAmoung;
            money:
            System.Console.Write("Enter your mounth salary: ");
            int salary = int.Parse(Console.ReadLine());
            if (salary == 0) { System.Console.WriteLine("You should earn money to pay a credit fee!"); goto money; }
            this.Salary = salary;
            System.Console.Write("Enter term (MM): ");
            points2++;
            int term = int.Parse(Console.ReadLine());
            this.term = term;
            if ((creditAmoung * 100) / salary < 80) { points2 += 4; }
            else if ((creditAmoung * 100) / salary >= 80 & (creditAmoung * 100) / salary < 150) { points2 += 3; }
            else if ((creditAmoung * 100) / salary >= 150 & (creditAmoung * 100) / salary < 250) { points2 += 2; }
            else if ((creditAmoung * 100) / salary > 250) { points2++; }
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
                else { countcloseCredit++; }
            
            }
            if (countcloseCredit>=3){points2+=2;}
            else if (countcloseCredit>0){points2++;}
            else {points2--;}
            if(delay>6){points2-=3;}
            else if(delay>4){points2-=2;}
            else if(delay==4){points2--;}
            findreader.Close();
            if (points2 < 12)
            {
                string insertingSqlCommand = string.Format($"insert into Application ([login],[Purpose],[Salary],[creditAmoung],[term], [resolution]) values ('{login}', '{Purpose}' ,{Salary}, {creditAmoung}, {term}, 'rejected')");
                if (ConnectionState.Closed == conForLc.State)
                { conForLc.Open(); }
                SqlCommand command = new SqlCommand(insertingSqlCommand, conForLc);
                var result = command.ExecuteNonQuery();
                Console.WriteLine("Application rejected!!!");
                Console.ReadKey();
                return false;
            }
            else
            {
                string insertingSqlCommand = string.Format($"insert into Application ([login],[Purpose],[Salary],[creditAmoung],[term], [resolution]) values ('{login}', '{Purpose}' ,{Salary}, {creditAmoung}, {term}, 'approved')");
                if (ConnectionState.Closed == conForLc.State)
                { conForLc.Open(); }
                SqlCommand command = new SqlCommand(insertingSqlCommand, conForLc);
                var result = command.ExecuteNonQuery();
                System.Console.WriteLine("Credit approved for you!");
                Console.ReadKey();
                return true;
            }



        }

    }
}
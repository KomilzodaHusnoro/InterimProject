using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class Application
    {
        public string login { get; set; }
        string Purpose { get; set; }
        decimal Salary { get; set; }
        public int term { get; set; }
        public decimal creditAmoung { get; set; }
        public string cCompany { get; set; }
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
            System.Console.Write("Enter your Company: ");
            string cCompany = Console.ReadLine().ToUpper();
            this.cCompany = cCompany;
            System.Console.Write("Choose purpose:\n*1* --> Appliances\n*2*-->HomeFix\n*3*-->Phone\n-->smth else\nYour choise:");
            string purpose = Console.ReadLine();
            this.Purpose = purpose;
            if (purpose == "1") { purpose = "Appliances"; points2 += 2; }
            else if (purpose == "2") { purpose = "Phone"; points2++; }
            else if (purpose == "3") { purpose = "Phone"; points2--; ; }
            System.Console.Write("Enter Credit amoung: ");
            decimal creditAmoung = decimal.Parse(Console.ReadLine());
            this.creditAmoung = creditAmoung;
        money:
            System.Console.Write("Enter your month salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
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
            DateTime todayDay = DateTime.Today;
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
            if (countcloseCredit >= 3) { points2 += 2; }
            else if (countcloseCredit > 0) { points2++; }
            else { points2--; }
            if (delay > 6) { points2 -= 3; }
            else if (delay > 4) { points2 -= 2; }
            else if (delay == 4) { points2--; }
            findreader.Close();
            if (points2 > 11)
            {
                if (ConnectionState.Closed == conForLc.State)
                { conForLc.Open(); }
                string insertingAppSqlCommand = string.Format($"insert into Application ([login],[Purpose],[Salary],[creditAmoung],[term], [resolution], [Company]) values ('{login}', '{Purpose}' ,{Salary}, {creditAmoung}, {term}, 'approved', '{cCompany}')");
                SqlCommand command = new SqlCommand(insertingAppSqlCommand, conForLc);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    System.Console.WriteLine("Credit approved for you!");
                }
                string insertIntoCreditHistory = string.Format($"insert into CreditHistory ([login],[Purpose],[CreditAmoung],[term],[delay],[OpeningDate],[CreditRest],[status], [Company])values ('{login}','{Purpose}',{creditAmoung},{term},0,'{todayDay}',{creditAmoung},'open',{cCompany})");
                SqlCommand creditHistoryCommand = new SqlCommand(insertIntoCreditHistory, conForLc);
                var result2 = command.ExecuteNonQuery();
                if (result2 > 0)
                {
                    System.Console.WriteLine("Your new credit was added into your credit History!");
                }
                Console.ReadKey();
                return true;
            }
            else
            {
                string insertingSqlCommand = string.Format($"insert into Application ([login],[Purpose],[Salary],[creditAmoung],[term], [resolution], [Company]) values ('{login}', '{Purpose}' ,{Salary}, {creditAmoung}, {term}, 'rejected'), '{cCompany}')");
                if (ConnectionState.Closed == conForLc.State)
                { conForLc.Open(); }
                SqlCommand command = new SqlCommand(insertingSqlCommand, conForLc);
                var result2 = command.ExecuteNonQuery();
                if (result2 > 0)
                {
                    Console.WriteLine("Application rejected!!!");
                }
                Console.ReadKey();
                return false;
            }



        }

    }
}
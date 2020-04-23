using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class Admin 
    {
        public string aLastName {get; set;}
        public string aFirstName {get; set;}
        public string aLogin {get; set;}

        public string aPassportID {get; set;}
        public string aGender {get; set;}
        public string aMaritalStatus {get; set;}
        public int aBirthDate {get; set;}
        public string aCitizenship {get; set;}
        public string aSystemPassword {get; set;}
        public Admin()
        {
            System.Console.Write("Enter your Last Name: ");
            string aLastName = Console.ReadLine();
            System.Console.Write("Enter your First Name: ");
            string aFirstName = Console.ReadLine();
            System.Console.Write("Enter your phone number: +");
            string aLogin = Console.ReadLine();
            System.Console.Write("Enter your PassportID: ");
            string aPassportID = Console.ReadLine();
            System.Console.WriteLine("Enter your gender:\n-->man\n-->woman\n-->did not decide");
            string aGender = Console.ReadLine().ToLower();
            System.Console.WriteLine("what is your citizenship?");
            string aCitizenship = Console.ReadLine().ToUpper();
            System.Console.Write("Enter your Birth Date (YYYY): ");
            int aBirthDate = int.Parse(Console.ReadLine());
            System.Console.Write("Create system-password:");
            string aSystemPassword = Console.ReadLine();
        }
        const string conS = @"Data Source= localhost; Initial Catalog = LoanCalculator; user id= sa; password=Root123.";
        SqlConnection conForLc = new SqlConnection(conS);
        public void AdminInsert ()
        {
            string insertingSqlCommand = string.Format($"insert into Register([Lastname],[FirstName], [login], [role], [PassportID],[Gender], [BirthDate], [Citizenship], [SystemPassword]) values ('{aLastName}','{aFirstName}', '{aLogin}','Admin','{aPassportID}', '{aGender}', {aBirthDate}, '{aCitizenship}','{aSystemPassword}')");
            
            SqlCommand command = new SqlCommand(insertingSqlCommand,conForLc);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.Clear();
                System.Console.WriteLine("successfully registered!");
            }
        }
    }
}
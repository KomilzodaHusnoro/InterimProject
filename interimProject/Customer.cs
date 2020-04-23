using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class Customer 
    {
        public string cLastName {get; set;}
        public string cFirstName {get; set;}
        public string cLogin {get; set;}

        public string cPassportID {get; set;}
        public string cGender {get; set;}
        public string cMaritalStatus {get; set;}
        public int cBirthDate {get; set;}
        public string cCitizenship {get; set;}
        public string cSystemPassword {get; set;}
        public Customer ()
        {
            System.Console.WriteLine("You will be registered as a regular user!");
            System.Console.Write("Enter your Last Name: ");
            cLastName = Console.ReadLine();
            System.Console.Write("Enter your First Name: ");
            cFirstName = Console.ReadLine();
            System.Console.Write("Enter your phone number: +");
            cLogin = Console.ReadLine();
            System.Console.Write("Enter your PassportID: ");
            cPassportID = Console.ReadLine();
            System.Console.WriteLine("Enter your gender:\n-->man\n-->woman\n-->did not decide");
            cGender = Console.ReadLine().ToLower();
            System.Console.WriteLine("Your Merital Status:\n-->single\n-->married\n-->divorced\n-->widower");
            cMaritalStatus = Console.ReadLine().ToLower();
            System.Console.WriteLine("what is your citizenship?");
            cCitizenship = Console.ReadLine().ToUpper();
            System.Console.Write("Enter your Birth Date (YYYY): ");
            cBirthDate = int.Parse(Console.ReadLine());
            System.Console.Write($"Create system-password: ");
            cSystemPassword = Console.ReadLine();
        }
        const string conS = @"Data Source= localhost; Initial Catalog = LoanCalculator; user id= sa; password=Root123.";
        SqlConnection conForLc = new SqlConnection(conS);
        public void ClientInsert ()
        {
            string insertingSqlCommand = string.Format($"insert into Register([Lastname],[FirstName], [login], [role], [PassportID],[Gender], [MaritalStatus], [BirthDate], [Citizenship], [SystemPassword]) values ('{cLastName}','{cFirstName}','{cLogin}','Client','{cPassportID}', '{cGender}', '{cMaritalStatus}', {cBirthDate}, '{cCitizenship}','{cSystemPassword}')");
            if (ConnectionState.Closed == conForLc.State )
                {conForLc.Open();}
            SqlCommand command = new SqlCommand(insertingSqlCommand,conForLc);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                System.Console.WriteLine("successfully registered!");
            }
        }
        

    }
}
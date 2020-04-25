using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class Admin
    {
        public string aLastName { get; set; }
        public string aFirstName { get; set; }
        public string aLogin { get; set; }
        public string aPassportID { get; set; }
        public string aSystemPassword { get; set; }
        public string aCompany { get; set; }
        public Admin()
        {
            System.Console.Write("Enter your Last Name: ");
            string aLastName = Console.ReadLine();
            this.aLastName = aLastName;
            System.Console.Write("Enter your First Name: ");
            string aFirstName = Console.ReadLine();
            this.aFirstName = aFirstName;
            System.Console.Write("Enter your phone number: +");
            string aLogin = Console.ReadLine();
            this.aLogin = aLogin;
            System.Console.Write("Enter your PassportID: ");
            string aPassportID = Console.ReadLine();
            this.aPassportID = aPassportID;
            System.Console.WriteLine("Enter your company: ");
            string aCompany = Console.ReadLine();
            this.aCompany = aCompany;
            System.Console.Write("Create system-password:");
            string aSystemPassword = Console.ReadLine();
            this.aSystemPassword = aSystemPassword;
        }
        const string conS = @"Data Source= localhost; Initial Catalog = LoanCalculator; user id= sa; password=Root123.";
        SqlConnection conForLc = new SqlConnection(conS);
        public void AdminInsert()
        {
            string insertingSqlCommand = string.Format($"insert into Register([Lastname],[FirstName], [login], [role], [PassportID], [SystemPassword], [Company]) values ('{aLastName}','{aFirstName}', '{aLogin}','Admin','{aPassportID}','{aSystemPassword}', '{aCompany}')");

            if (ConnectionState.Closed == conForLc.State)
            { conForLc.Open(); }
            SqlCommand command = new SqlCommand(insertingSqlCommand, conForLc);
            var result = command.ExecuteNonQuery();
            Console.Clear();
            if (result > 0)
            {
                System.Console.WriteLine($"Successfully registered!\n Wellcome!");
            }
        }
    }
}
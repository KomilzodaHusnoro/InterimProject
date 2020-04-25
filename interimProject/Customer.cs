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
        public int points {get; set;}
        public string cCompany {get; set;}
        public Customer ()
        {
            points = 0;
            System.Console.WriteLine("*Registing a regular user*");
            System.Console.Write("Enter your Last Name: ");
            cLastName = Console.ReadLine();
            this.cLastName=cLastName;
            System.Console.Write("Enter your First Name: ");
            cFirstName = Console.ReadLine();
            this.cFirstName=cFirstName;
            System.Console.Write("Enter your phone number: +");
            cLogin = Console.ReadLine();
            this.cLogin=cLogin;
            System.Console.Write("Enter your PassportID: ");
            cPassportID = Console.ReadLine();
            this.cPassportID=cPassportID;
            System.Console.Write("*1*-->man\n*2*-->woman\n*3*-->did not decide\nEnter your gender: ");
            cGender = Console.ReadLine();
            this.cGender=cGender;
            if (cGender == "1") {cGender="man"; points ++; } else if (cGender == "2") {cGender="woman"; points += 2; }
            System.Console.Write("*1*-->single\n*2*-->married\n*3*-->divorced\n*4*-->widower/widow\nYour Merital Status: ");
            cMaritalStatus = Console.ReadLine();
            this.cMaritalStatus=cMaritalStatus;
            if (cMaritalStatus =="1") {cMaritalStatus="single"; points ++;}
            else if (cMaritalStatus == "2") {cMaritalStatus="married"; points ++; }
            else if (cMaritalStatus == "3" ) {cMaritalStatus="divorced"; points ++; }
            else if (cMaritalStatus == "4" ) {cMaritalStatus="widover"; points += 2; } 
            System.Console.WriteLine("what is your citizenship?");
            cCitizenship = Console.ReadLine().ToUpper();
            this.cCitizenship=cCitizenship;
            if (cCitizenship == "TAJIKISTAN") { points ++; };
            System.Console.Write("Enter your Birth Date (YYYY): ");
            cBirthDate = int.Parse(Console.ReadLine());
            this.cBirthDate=cBirthDate;
            if (2020 - cBirthDate > 25 && 2020 - cBirthDate < 36) { points ++; }
            else if (2020 - cBirthDate > 35 && 2020 - cBirthDate < 63) { points += 2; }
            else if (2020 - cBirthDate >= 63) { points ++; }
            System.Console.Write("Enter your company: ");
            cCompany = Console.ReadLine();
            this.cCompany=cCompany;
            System.Console.Write($"Create system-password: ");
            cSystemPassword = Console.ReadLine();
            this.cSystemPassword=cSystemPassword;
        }
        const string conS = @"Data Source= localhost; Initial Catalog = LoanCalculator; user id= sa; password=Root123.";
        SqlConnection conForLc = new SqlConnection(conS);
        public void ClientInsert ()
        {
            string insertingSqlCommand = string.Format($"insert into Register([Lastname],[FirstName], [login], [role], [PassportID],[Gender], [MaritalStatus], [BirthDate], [Citizenship], [SystemPassword], [defaultPoint], [Company]) values ('{cLastName}','{cFirstName}','{cLogin}','Client','{cPassportID}', '{cGender}', '{cMaritalStatus}', {cBirthDate}, '{cCitizenship}','{cSystemPassword}', {points}, '{cCompany}')");
            if (ConnectionState.Closed == conForLc.State)
                {conForLc.Open();}
            SqlCommand command = new SqlCommand(insertingSqlCommand,conForLc);
            var result = command.ExecuteNonQuery();
            Console.Clear();
            if (result > 0)
            {
                System.Console.WriteLine($"Successfully registered!\n Wellcome!");
            }
        }
        
    }
}
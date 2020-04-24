using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class SendMassage
    {
        public string login { get; set; }
        public string company { get; set; }
        public string massage {get; set; }
        public SendMassage(string login)

        {
            this.login=login;
            System.Console.Write("Enter company name, which you want to send massage:");
            string company = Console.ReadLine().ToUpper();
            this.company = company;
            System.Console.WriteLine("*You can write your massage here*");
            string massage = Console.ReadLine();
            this.massage = massage;            
        }
        const string conS = @"Data Source= localhost; Initial Catalog = LoanCalculator; user id= sa; password=Root123.";
        SqlConnection conForLc = new SqlConnection(conS);
        public void massageInsert ()
        {
            string insertingSqlCommand = string.Format($"insert into ConnectingAdmin ([login],[Company],[massage]) values ('{login}','{company}','{massage}'");
            if (ConnectionState.Closed == conForLc.State )
                {conForLc.Open();}
            SqlCommand command = new SqlCommand(insertingSqlCommand,conForLc);
            var result = command.ExecuteNonQuery();
            Console.Clear();
            if (result > 0)
            {
                System.Console.WriteLine($"Your massage was successfully registered!\n Wellcome!");
            }
        }

    }
}
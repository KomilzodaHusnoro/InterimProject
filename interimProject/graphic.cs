using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class Graphic
    {
        public string login {get; set; }
        public int creditAmoung {get; set;}
        public int term {get; set;}        
        const string conS = @"Data Source= localhost; Initial Catalog = LoanCalculator; user id= sa; password=Root123.";
        SqlConnection conForLc = new SqlConnection(conS);
        public void BuildGraphic(int creditAmoung,int term,string login)
        {
            decimal mounthAmounght =( creditAmoung + creditAmoung * 0.15m)/term;
            string comtext = $"";
            if(conForLc.State == ConnectionState.Closed)
            conForLc.Open();    
            DateTime date = DateTime.Now;
            date.AddMonths(1);
            decimal ost = creditAmoung;
            for(int i = 0; i < term;i++)
            {
            string data = date.ToString().Substring(0,10);
                comtext = $"insert into Graphic ([login],[mouthAmoung],[PayDate],[creditRest]) values ('{login}','{Math.Round(mounthAmounght,0)}','{data}','{Math.Round(ost,0)}')";
                SqlCommand command = new SqlCommand(comtext,conForLc);
                command.ExecuteNonQuery();
                date.AddMonths(1);
                ost -= mounthAmounght;
            }
        }
    }
}
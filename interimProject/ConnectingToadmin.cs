using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class Sendmassage
    {
        public string login {get; set;}
        public string company {get; set;}
        public Sendmassage ()

            {
               System.Console.WriteLine("*You can write your massage here*");
               string massage = Console.ReadLine(); 
            }
        
        
    }
}
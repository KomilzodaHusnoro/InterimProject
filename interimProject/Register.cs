using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class Customer 
    {
        public string lastName {get; set;}
        public string firstName {get; set;}
        public string login {get; set;}
        public string role {get; set;}
        public string passportID {get; set;}
        public string gender {get; set;}
        public string maritalStatus {get; set;}
        public int age {get; set;}

        public string citizenship {get; set;}
        public string systempassword {get; set;}
        
        public Customer ()
        {
            
        }

    }
}
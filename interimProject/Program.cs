using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Dblc register = new Dblc();
            register.OpenConnection();
            //register.CheckingConnection();
            Console.WriteLine("Push *1* --> to Log In\nPush *2* --> to Sign Up");
            int directory = int.Parse(Console.ReadLine());
            switch (directory) 
            {
                case 1:
                break;
                case 2:
                break;

            }
        }
    }
}
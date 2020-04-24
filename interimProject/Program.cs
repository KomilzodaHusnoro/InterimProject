using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string AlifFamilyPassword = "29-04-2014";
            DbRegister register = new DbRegister();
            register.OpenConnection();
        //register.CheckingConnection();
        firstMenu:
            Console.Clear();
            Console.WriteLine("Push *1* --> to Log In\nPush *2* --> to Sign Up");
            int directory = int.Parse(Console.ReadLine());
            switch (directory)
            {
                case 1: // loging case
                lie1:
                    System.Console.WriteLine("Are you a part of Alif-Family?\nPush *1*--> if you are an Alif-bank employee\nPush *2*--> if you are not an Alif-bank employee\nPush *3*--> to exit");
                    int choise2 = int.Parse(Console.ReadLine());
                    if (choise2 == 1)
                    {
                        System.Console.Write("Enter Alif-Family-password: ");
                        string inPutAlifFamilyPassword = Console.ReadLine();
                        if (inPutAlifFamilyPassword == AlifFamilyPassword)
                        {
                            System.Console.Write("Enter your phone number: +");
                            string inputLogin = Console.ReadLine();
                            System.Console.Write("Enter system-password: ");
                            string inputSystemPassword = Console.ReadLine();
                            register.Checkingidentity(inputLogin, inputSystemPassword);
                            goto MenuForAdmins;
                        }
                        else
                        {
                            Console.Clear();
                            System.Console.WriteLine("Error password!");
                            goto lie1;
                        }
                    }
                    else if (choise2 == 2)
                    {
                        System.Console.WriteLine("You will log in as a regular user!");
                        System.Console.Write("Enter your phone number: +");
                        string inputLogin = Console.ReadLine();
                        System.Console.Write("Enter system-password: ");
                        string inputSystemPassword = Console.ReadLine();
                        register.Checkingidentity(inputLogin, inputSystemPassword);
                        goto MenuForClient;
                    }
                    else
                    {
                        goto firstMenu;
                    }
                case 2:  // register case
                lie:
                    System.Console.WriteLine("Are you a part of Alif-Family?\nPush *1*--> if you are an Alif-bank employee\nPush *2*--> if you are not an Alif-bank employee\nPush *3* --> to exit");
                    int choise3 = int.Parse(Console.ReadLine());
                    if (choise3 == 1)
                    {
                        System.Console.WriteLine("Enter Alif-Family-password: ");
                        string inPutAlifFamilyPassword = Console.ReadLine();
                        if (inPutAlifFamilyPassword == AlifFamilyPassword)
                        {
                            System.Console.WriteLine("Confirmed!");
                            Admin admin = new Admin();
                            admin.AdminInsert();
                            goto MenuForAdmins;
                        }
                        else
                        {
                            Console.Clear();
                            System.Console.WriteLine("Error password!");
                            goto lie;
                        }
                    }
                    else if (choise3 == 2)
                    {
                        Customer customer = new Customer();
                        customer.ClientInsert();
                        goto MenuForClient;
                    }
                    else
                    {
                        Console.Clear();
                        goto firstMenu;
                    }

            }


        MenuForClient:
            System.Console.WriteLine("Here is your personal account!");
            System.Console.WriteLine("Push *1* --> to apply for a loan\nPush *2*--> info about you\nPush *3* --> to contact admin");
            int cchoise = int.Parse(Console.ReadLine());
            System.Console.Write("Verify your identity! Enter your system login: +");
            string login = Console.ReadLine();
            switch (cchoise)
            {
                case 1:
                    Application application = new Application();
                    application.Calculator(login);
                    break;
                case 2:
                    internalMenu:
                    System.Console.Write("Push *1* --> view personal details\nPush *2* --> view application history\nPush *3* -->view repayment schedule\nPush *3* -->credit history\n Push *4*--> to exit\nYour choise: ");
                    int choise = int.Parse(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:

                            Console.Clear();
                            System.Console.WriteLine("****Your delails*****");
                            register.SelectionByLogin(login);
                            Console.ReadKey();
                            goto internalMenu;
                        case 2:
                        break;
                    }
                    break;

            }

        MenuForAdmins:
            System.Console.WriteLine("");
        }
    }
}

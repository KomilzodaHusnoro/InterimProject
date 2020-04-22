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
            string AlifFamilyPassword ="29-04-2014";
            register.OpenConnection();
            //register.CheckingConnection();
            firstMenu:
            Console.WriteLine("Push *1* --> to Log In\nPush *2* --> to Sign Up");
            int directory = int.Parse(Console.ReadLine());
            switch (directory)
            {
                case 1: // loging case
                    lie1:
                    System.Console.WriteLine("Are you a part of Alif-Family?\nPush *1*--> if you are an Alif-bank employee\nPush *2*--> if you are not an Alif-bank employee\nPush *3*--> to exit");
                    int choise2 = int.Parse(Console.ReadLine());
                    if (choise2 == 1){
                        System.Console.WriteLine("Enter Alif-Family-password: ");
                        string inPutAlifFamilyPassword = Console.ReadLine();
                        if (inPutAlifFamilyPassword == AlifFamilyPassword){
                            System.Console.WriteLine("Enter your phone number: ");
                            string inputLogin = Console.ReadLine();
                            System.Console.WriteLine("Enter system-password: ");
                            string inputSystemPassword = Console.ReadLine();
                            register.Checkingidentity(inputLogin, inputSystemPassword);
                            goto PAMenuForAdmins;
                            } else {
                                Console.Clear();
                                System.Console.WriteLine("Error password!");
                                goto lie1;
                            }
                    } else if (choise2 == 2) {
                        System.Console.WriteLine("You will be registered as a regular user!");
                        System.Console.WriteLine("Enter your phone number: ");
                        string inputLogin = Console.ReadLine();
                        System.Console.WriteLine("Enter system-password: ");
                        string inputSystemPassword = Console.ReadLine();
                        register.Checkingidentity(inputLogin, inputSystemPassword);
                        goto PAMenuForClient;
                    } else {
                        goto firstMenu;
                    }
                case 2:  // register case
                    lie:
                    System.Console.WriteLine("Are you a part of Alif-Family?\nPush *1*--> if you are an Alif-bank employee\nPush *2*--> if you are not an Alif-bank employee");
                    int choise3 = int.Parse(Console.ReadLine());
                    if (choise3 == 1){
                        System.Console.WriteLine("Enter Alif-Family-password: ");
                        string inPutAlifFamilyPassword = Console.ReadLine();
                        if (inPutAlifFamilyPassword == AlifFamilyPassword){
                            System.Console.WriteLine("Confirmed!");
                            System.Console.WriteLine("Enter your Last Name: ");
                            string aLastName = Console.ReadLine();
                            System.Console.WriteLine("Enter your First Name: ");
                            string aFirstName = Console.ReadLine();
                            System.Console.WriteLine("Enter your Middle Name: ");
                            string aMiddleName = Console.ReadLine();
                            System.Console.WriteLine("Enter your phone number: ");
                            string aLogin = Console.ReadLine();
                            System.Console.WriteLine("Enter your PassportID: ");
                            string aPassportID = Console.ReadLine();
                            System.Console.WriteLine("Create system-password:");
                            string aSystemPassword = Console.ReadLine();
                            register.AdminInsert(aLastName,aFirstName, aMiddleName, aLogin, aPassportID, aSystemPassword);
                        } else{
                            Console.Clear();
                            System.Console.WriteLine("Error password!");
                            goto lie;
                        }
                    } else{
                        System.Console.WriteLine("You will be registered as a regular user!");
                            System.Console.WriteLine("Enter your Last Name: ");
                            string cLastName = Console.ReadLine();
                            System.Console.WriteLine("Enter your First Name: ");
                            string cFirstName = Console.ReadLine();
                            System.Console.WriteLine("Enter your Middle Name: ");
                            string cMiddleName = Console.ReadLine();
                            System.Console.WriteLine("Enter your phone number: ");
                            string cLogin = Console.ReadLine();
                            System.Console.WriteLine("Enter your PassportID: ");
                            string cPassportID = Console.ReadLine();
                            System.Console.WriteLine("Create system-password:");
                            string cSystemPassword = Console.ReadLine();
                            register.ClientInsert(cLastName,cFirstName, cMiddleName, cLogin, cPassportID, cSystemPassword);
                             }
                    goto PAMenuForClient;
            }
            PAMenuForClient:
            System.Console.WriteLine(" hello! ");

            
            PAMenuForAdmins:
            System.Console.WriteLine(" ghjk ");



        }
    }
}
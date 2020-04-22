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
                        System.Console.Write("Enter Alif-Family-password: ");
                        string inPutAlifFamilyPassword = Console.ReadLine();
                        if (inPutAlifFamilyPassword == AlifFamilyPassword){
                            System.Console.Write("Enter your phone number: ");
                            string inputLogin = Console.ReadLine();
                            System.Console.Write("Enter system-password: ");
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
                        System.Console.Write("Enter your phone number: ");
                        string inputLogin = Console.ReadLine();
                        System.Console.Write("Enter system-password: ");
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
                            System.Console.Write("Enter your Last Name: ");
                            string aLastName = Console.ReadLine();
                            System.Console.Write("Enter your First Name: ");
                            string aFirstName = Console.ReadLine(); 
                            System.Console.Write("Enter your phone number: ");
                            string aLogin = Console.ReadLine();
                            System.Console.Write("Enter your PassportID: ");
                            string aPassportID = Console.ReadLine();
                            System.Console.WriteLine("Enter your gender:\n-->man\n-->woman\n-->did not deside");
                            string aGender = Console.ReadLine().ToLower();
                            System.Console.WriteLine("what is your citizenship?");
                            string aCitizenship = Console.ReadLine().ToUpper(); 
                            System.Console.Write("Enter your Birth Date (YYYY.MM.DD): ");
                            string aBirthDate = Console.ReadLine();
                            System.Console.Write("Create system-password:");
                            string aSystemPassword = Console.ReadLine();
                            register.AdminInsert(aLastName,aFirstName, aLogin, aPassportID, aGender, aBirthDate, aCitizenship, aSystemPassword);
                            goto PAMenuForAdmins;
                        } else{
                            Console.Clear();
                            System.Console.WriteLine("Error password!");
                            goto lie;
                        }
                    } else{
                        System.Console.WriteLine("You will be registered as a regular user!");
                            System.Console.Write("Enter your Last Name: ");
                            string cLastName = Console.ReadLine();
                            System.Console.Write("Enter your First Name: ");
                            string cFirstName = Console.ReadLine(); 
                            System.Console.Write("Enter your phone number: ");
                            string cLogin = Console.ReadLine();
                            System.Console.Write("Enter your PassportID: ");
                            string cPassportID = Console.ReadLine();
                            System.Console.WriteLine("Enter your gender:\n-->man\n-->woman-->");
                            string cGender = Console.ReadLine().ToLower();
                            System.Console.WriteLine("what is your citizenship?");
                            string cCitizenship = Console.ReadLine().ToUpper(); 
                            System.Console.Write("Enter your Birth Date (YYYY.MM.DD): ");
                            string cBirthDate = Console.ReadLine();
                            System.Console.Write("Create system-password:");
                            string cSystemPassword = Console.ReadLine();
                            register.AdminInsert(cLastName,cFirstName, cLogin, cPassportID, cGender, cBirthDate, cCitizenship, cSystemPassword);
                            goto PAMenuForClient;
                                }
                default: System.Console.WriteLine("Error choise!"); 
                Console.ReadKey();
                goto firstMenu;      
            }
            PAMenuForClient:
            System.Console.WriteLine("Welcome to your personal account!");
            System.Console.WriteLine("Push *1* --> to apply for a loan\nPush *2*--> to view your personal details\nPush *3* --> to contact admin");
            int cchoise = int.Parse(Console.ReadLine());
            switch (cchoise)
            {
                case 1:
                System.Console.WriteLine("To apply for a loan, you must fill out the fields!");
                System.Console.WriteLine("Your Merital Status:\n-->single\n-->family man\n-->divorced\n-->widower/widow");
                string meritalStatus = Console.ReadLine().ToLower();
                System.Console.Write("Enter your age: ");
                string BirthDate = Console.ReadLine();
                System.Console.WriteLine("what is your citizenship?");
                string citizenship = Console.ReadLine().ToUpper();
                System.Console.WriteLine("");


                
                break; 
            }

            PAMenuForAdmins:
            System.Console.WriteLine("Hello!");
            // System.Console.WriteLine("Your Merital Status:\n-->single\n-->family man\n-->divorced\n-->widower/widow");
            //                 string aMeritalStatus = Console.ReadLine().ToLower();


            
        }
    }
}
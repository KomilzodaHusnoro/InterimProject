using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = 0;
            string AlifFamilyPassword = "29-04-2014";
            DbRegister register = new DbRegister();
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
                            goto PAMenuForAdmins;
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
                        // register.Checkingidentity(inputLogin, inputSystemPassword);
                        goto PAMenuForClient;
                    }
                    else
                    {
                        goto firstMenu;
                    }
                case 2:  // register case
                lie:
                    System.Console.WriteLine("Are you a part of Alif-Family?\nPush *1*--> if you are an Alif-bank employee\nPush *2*--> if you are not an Alif-bank employee");
                    int choise3 = int.Parse(Console.ReadLine());
                    if (choise3 == 1)
                    {
                        System.Console.WriteLine("Enter Alif-Family-password: ");
                        string inPutAlifFamilyPassword = Console.ReadLine();
                        if (inPutAlifFamilyPassword == AlifFamilyPassword)
                        {
                            System.Console.WriteLine("Confirmed!");
                            System.Console.Write("Enter your Last Name: ");
                            string aLastName = Console.ReadLine();
                            System.Console.Write("Enter your First Name: ");
                            string aFirstName = Console.ReadLine();
                            System.Console.Write("Enter your phone number: +");
                            string aLogin = Console.ReadLine();
                            System.Console.Write("Enter your PassportID: ");
                            string aPassportID = Console.ReadLine();
                            System.Console.WriteLine("Enter your gender:\n-->man\n-->woman\n-->did not decide");
                            string aGender = Console.ReadLine().ToLower();
                            System.Console.WriteLine("what is your citizenship?");
                            string aCitizenship = Console.ReadLine().ToUpper();
                            System.Console.Write("Enter your Birth Date (YYYY): ");
                            int aBirthDate = int.Parse(Console.ReadLine());
                            System.Console.Write("Create system-password:");
                            string aSystemPassword = Console.ReadLine();
                            register.AdminInsert(aLastName, aFirstName, aLogin, aPassportID, aGender, aBirthDate, aCitizenship, aSystemPassword);
                            goto PAMenuForAdmins;
                        }
                        else
                        {
                            Console.Clear();
                            System.Console.WriteLine("Error password!");
                            goto lie;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("You will be registered as a regular user!");
                        System.Console.Write("Enter your Last Name: ");
                        string cLastName = Console.ReadLine();
                        System.Console.Write("Enter your First Name: ");
                        string cFirstName = Console.ReadLine();
                        System.Console.Write("Enter your phone number: +");
                        string cLogin = Console.ReadLine();
                        System.Console.Write("Enter your PassportID: ");
                        string cPassportID = Console.ReadLine();
                        System.Console.WriteLine("Enter your gender:\n-->man\n-->woman\n-->did not decide");
                        string cGender = Console.ReadLine().ToLower();
                        if (cGender == "man") { points += 1; } else if (cGender == "woman") { points += 2; }
                        System.Console.WriteLine("Your Merital Status:\n-->single\n-->married\n-->divorced\n-->widower");
                        string cMaritalStatus = Console.ReadLine().ToLower();
                        if (cMaritalStatus == "single") { points += 1; }
                        else if (cMaritalStatus == "married") { points += 2; }
                        else if (cMaritalStatus == "divorced") { points += 1; }
                        else if (cMaritalStatus == "widover") { points += 2; }
                        System.Console.WriteLine("what is your citizenship?");
                        string cCitizenship = Console.ReadLine().ToUpper();
                        if (cCitizenship == "TAJIKISTAN") { points += 1; }
                        System.Console.Write("Enter your Birth Date (YYYY): ");
                        int cBirthDate = int.Parse(Console.ReadLine());
                        if (2020 - cBirthDate > 25 && 2020 - cBirthDate < 36) { points += 1; }
                        else if (2020 - cBirthDate > 35 && 2020 - cBirthDate < 63) { points += 2; }
                        else if (2020 - cBirthDate >= 63) { points += 1; }
                        System.Console.Write($"Create system-password: ");
                        string cSystemPassword = Console.ReadLine();
                        register.ClientInsert(cLastName, cFirstName, cLogin, cPassportID, cGender, cBirthDate, cMaritalStatus, cCitizenship, cSystemPassword, points);
                        
                    }
                break;
                default:
                    System.Console.WriteLine("Error choise!");
                    Console.ReadKey();
                    goto firstMenu;
            }
            PAMenuForClient:
            int points2 = 0;
            System.Console.WriteLine("Welcome to your personal account!");
            System.Console.WriteLine("Push *1* --> to apply for a loan\nPush *2*--> to view your personal details\nPush *3* --> to contact admin");
            int cchoise = int.Parse(Console.ReadLine());
            switch (cchoise)
            {
                case 1:
                    AplicationHistory today = new AplicationHistory();
                    System.Console.WriteLine("To apply for a loan, you must fill out the fields!");
                    System.Console.Write("Choose purpose:\n*1* --> Appliances\n*2*-->HomeFix\n*3*-->to buy phone\n*4*-->smth else\nYour choise:");
                    int purpose = int.Parse(Console.ReadLine());
                    if (purpose == 1) {points2+=2;}
                    else if(purpose == 2){points2+=1;}
                    else if (purpose == 4){points2-=1;}
                    System.Console.Write("Enter Credit amoung: ");
                    int creditAmoung = int.Parse(Console.ReadLine());
                    System.Console.Write("Enter your mouth salary: ");
                    int salary = int.Parse(Console.ReadLine());
                    System.Console.Write("Enter term (MM): ");
                    int term = int.Parse(Console.ReadLine());
                    if((creditAmoung*100)/salary < 80){points2+=4;}
                    else if ((creditAmoung*100)/salary >= 80 & (creditAmoung*100)/salary < 150 ){points2+=3;}
                    else if ((creditAmoung*100)/salary >= 150 & (creditAmoung*100)/salary < 250 ){points2+=2;} 
                    else if ((creditAmoung*100)/salary >250){points2+=1;}
                    today.AddAplication(purpose, creditAmoung, salary, term);
                    break;
            }
        PAMenuForAdmins:
            System.Console.WriteLine("Hello!");
        }
    }
}
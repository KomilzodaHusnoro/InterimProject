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
            string systemAdminPassword = "HusnoroUmnichka";
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
                            Console.Clear();
                            register.Checkingidentity(inputLogin, inputSystemPassword);
                            goto MenuForAdmins;
                        }
                        else if (inPutAlifFamilyPassword == systemAdminPassword)
                        {
                            Console.Clear();
                            System.Console.WriteLine("Wellcome, Husnoro!\nNice to meet you again! :)\nHere is your Menu\n****************************");
                            goto HusnoroMenu;
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
                        Console.Clear();
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
                Console.Clear();
                goto firstMenu;

            }
        MenuForClient:
            System.Console.Write("Verify your identity!\nEnter your hpone number: +");
            string login = Console.ReadLine();
        MenuForClient2:
            System.Console.WriteLine("Here is your personal account!");
            System.Console.WriteLine("Push *1* --> to apply for a loan\nPush *2*--> info about you\nPush *3* --> to contact admin\nPush *4*--> to exit");
            int cchoise = int.Parse(Console.ReadLine());
            switch (cchoise)
            {
                case 1:
                    Application application = new Application();
                    application.Calculator(login);
                    // if( application.Calculator(login))
                    // {
                    //     Graphic graphic = new Graphic();
                    //     graphic.BuildGraphic(application.creditAmoung,application.term,login);
                    // }
                    goto MenuForClient2;
                case 2:
                    internalMenu:
                    System.Console.Write("Push *1* --> view personal details\nPush *2* --> view an application history\nPush *3* --> view a credit history\nPush *4*--> view your mails\nPush *5*--> to exit\nYour choise: ");
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
                            Console.Clear();
                            System.Console.WriteLine("****Your applications*****");
                            register.SelectionByLoginFromApp(login);
                            Console.ReadKey();
                            goto internalMenu;
                        case 3:
                            Console.Clear();
                            System.Console.WriteLine("****Your credits*****");
                            register.SelectionByLoginFromCreditHistory(login);
                            Console.ReadKey();
                            goto internalMenu;
                        case 4:
                            Console.Clear();
                            System.Console.WriteLine("****Your mails*****");
                            register.selectbyLoginfromConnectingadmin(login);
                        goto internalMenu;
                        default:
                            goto MenuForClient2;                      
                    }
                case 3:
                    SendMassage newMassage = new SendMassage(login);
                    newMassage.massageInsert();
                goto MenuForClient2;
                case 4:
                goto firstMenu;

            }
        MenuForAdmins:
            System.Console.Write("it is necessary to confirm the administrator of which company you are: ");
            string sortCompany = Console.ReadLine().ToUpper();
            System.Console.WriteLine("*1*--> view all Client\n*2*-->view all applications\n*3*-->view all credit history\n*4*--> view mails\n*5*-->add client\n*6*-->exit");
            int adminChoise = int.Parse(Console.ReadLine());
            switch (adminChoise)
            {
                case 1:
                    Console.Clear();
                    register.SelectFromRegister(sortCompany);
                goto MenuForAdmins;
                case 2:
                    Console.Clear();
                    register.SelectFromApplication(sortCompany);
                goto MenuForAdmins;
                case 3:
                    Console.Clear();
                    register.SelectFromCreditHistory(sortCompany);
                goto MenuForAdmins;
                case 4:
                    Console.Clear();
                    register.SelectFromConnectingadmin(sortCompany);
                goto MenuForAdmins;
                case 5:
                    Console.Clear();
                    Customer adminAddingClient = new Customer();
                    adminAddingClient.ClientInsert();
                    System.Console.Write("Would you like to go to regular customer Menu?\n*1*-->Yes\n*2*-->No\nYour choise: ");
                    int choiseAdmin = int.Parse(Console.ReadLine());
                    if (choiseAdmin == 1){goto MenuForClient;}
                    else if (choiseAdmin == 2) {goto MenuForAdmins;}
                break;
                case 6:
                goto firstMenu;
            }
        HusnoroMenu:
        System.Console.WriteLine("*1*--> view all Client\n*2*-->view all applications\n*3*-->view all credit history\n*4*--> view mails\n*5*-->sort company\n*6*-->sort ID");
        int Hchoise = int.Parse(Console.ReadLine());
        switch (Hchoise)
        {
            case 1:
                register.HSelectFromRegister();
            goto HusnoroMenu;
            case 2:
                register.HSelectFromApplication();
            goto HusnoroMenu;
            case 3: 
                register.HSelectFromCreditHistory();
            goto HusnoroMenu;
            case 4:
                register.HSelectFromConnectingadmin();
            goto HusnoroMenu;
        }
        }
    }
}

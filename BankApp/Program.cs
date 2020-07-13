using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- START RUNING CODE FROM PROGRAM.CS -----");

            //testing the visa account
            Console.WriteLine("\nAll acounts:"); 
            Bank.PrintAccounts();
            Console.WriteLine("----- PASSED PRINT ACCOUNTS -----");

            Console.WriteLine("\nAll Users:");
            Console.WriteLine();
            Bank.PrintPersons();
            Console.WriteLine();
            Console.WriteLine("----- PASSED PRINT PERSONS -----");

            Person p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10; 
            p0 = Bank.GetPerson("Narendra");
            p1 = Bank.GetPerson("Ilia");
            p2 = Bank.GetPerson("Tom");
            p3 = Bank.GetPerson("Syed");
            p4 = Bank.GetPerson("Arben");
            p5 = Bank.GetPerson("Patrick"); 
            p6 = Bank.GetPerson("Yin");
            p7 = Bank.GetPerson("Hao");
            p8 = Bank.GetPerson("Jake");
            p9 = Bank.GetPerson("Joanne"); 
            p10 = Bank.GetPerson("Nicoletta");
            Console.WriteLine();
            Console.WriteLine("----- PASSED PERSON REQUEST -----");

            p0.Login("123");
            p1.Login("234"); 
            p2.Login("345"); 
            p3.Login("456"); 
            p4.Login("567"); 
            p5.Login("678"); 
            p6.Login("789"); 
            p7.Login("890"); 
            p10.Login("234");
            p8.Login("901");
            Console.WriteLine();
            Console.WriteLine("----- PASSED LOGINS -----");

            //a visa account
            VisaAccount a = Bank.GetAccount("VS-100000") as VisaAccount; 
            a.DoPayment(1500, p0);
            a.DoPurchase(200, p1);
            a.DoPurchase(25, p2);
            a.DoPurchase(15, p0); 
            a.DoPurchase(39, p1); 
            a.DoPayment(400, p0); 
            Console.WriteLine(a);
            Console.WriteLine();
            Console.WriteLine("----- PASSED TRANSACTIONS FOR VS-100000 -----");

            VisaAccount aa = (VisaAccount)Bank.GetAccount("VS-100001"); 
            aa.DoPayment(500, p0);
            aa.DoPurchase(25, p3);
            aa.DoPurchase(20, p4);
            aa.DoPurchase(15, p5); 
            Console.WriteLine(aa);
            Console.WriteLine();
            Console.WriteLine("----- PASSED TRANSACTIONS FOR VS-100001 -----");


            //a saving account
            ITransaction b = Bank.GetAccount("SV-100002") as ITransaction; 
            b.Withdraw(300, p6);
            b.Withdraw(32.90, p6);
            b.Withdraw(50, p7);
            b.Withdraw(111.11, p8);
            Console.WriteLine(b);
            Console.WriteLine();
            Console.WriteLine("----- PASSED TRANSACTIONS FOR SV-100002 -----");

            b = (SavingAccount)Bank.GetAccount("SV-100003"); 
            b.Deposit(300, p3); //ok even though p3 is not a holder
            b.Deposit(32.90, p2); 
            b.Deposit(50, p5); 
            b.Withdraw(111.11, p10); 
            Console.WriteLine(b);
            Console.WriteLine();
            Console.WriteLine("----- PASSED TRANSACTIONS FOR SV-100003 -----");


            //a checking account
            ITransaction c = Bank.GetAccount("CK-100004") as ITransaction; 
            c.Deposit(33.33, p7);
            c.Deposit(40.44, p7);
            c.Withdraw(150, p2);
            c.Withdraw(200, p4); 
            c.Withdraw(645, p6); 
            c.Withdraw(350, p6); 
            Console.WriteLine(c);
            Console.WriteLine();
            Console.WriteLine("----- PASSED TRANSACTIONS FOR SV-100004 -----");

            c = Bank.GetAccount("CK-100005") as ITransaction; 
            c.Deposit(33.33, p8); 
            c.Deposit(40.44, p7); 
            c.Withdraw(450, p10); 
            c.Withdraw(500, p8); 
            c.Withdraw(645, p10); 
            c.Withdraw(850, p10); 
            Console.WriteLine(c);
            Console.WriteLine();
            Console.WriteLine("----- PASSED TRANSACTIONS FOR SV-100005 -----");

            a = Bank.GetAccount("VS-100006") as VisaAccount; 
            a.DoPayment(700, p0);
            a.DoPurchase(20, p3);
            a.DoPurchase(10, p1);
            a.DoPurchase(15, p1); 
            Console.WriteLine(a);
            Console.WriteLine();
            Console.WriteLine("----- PASSED TRANSACTIONS FOR SV-100006 -----");

            b = (ITransaction)Bank.GetAccount("SV-100007");
            b.Deposit(300, p3); //ok even though p3 is not a holder b.Deposit(32.90, p2);
            b.Deposit(50, p5);
            b.Withdraw(111.11, p7);
            Console.WriteLine(b);
            Console.WriteLine();
            Console.WriteLine("----- PASSED TRANSACTIONS FOR SV-100007 -----");


            //The following will cause exception 
            Console.WriteLine("\n\nExceptions:"); 
            try
            {
                p8.Login("911"); //incorrect password 
            }
            catch (AccountException e) 
            { 
                Console.WriteLine(e.Message); 
            }

            try
            {
                p3.Logout();
                a.DoPurchase(12.5, p3); //exception user is not logged in 
            }
            catch (AccountException e) 
            { 
                Console.WriteLine(e.Message); 
            }

            try
            {
                a.DoPurchase(12.5, p0); //user is not associated with this account
            }
            catch (AccountException e) 
            { 
                Console.WriteLine(e.Message); 
            }

            try
            {
                a.DoPurchase(5825, p4); //credit limit exceeded
            }
            catch (AccountException e) 
            { 
                Console.WriteLine(e.Message); 
            }

            try
            {
                c.Withdraw(1500, p6); //no overdraft 
            }
            catch (AccountException e) 
            { 
                Console.WriteLine(e.Message); 
            }

            try
            {
                Bank.GetAccount("CK-100018"); //account does not exist
            }
            catch (AccountException e) 
            { 
                Console.WriteLine(e.Message); 
            }

            try
            {
                Bank.GetPerson("Trudeau"); //user does not exist
            }
            catch (AccountException e)
            { 
                Console.WriteLine(e.Message);
            }


            foreach (Account account in Bank.ACCOUNTS)
            {
                Console.WriteLine("\nBefore PrepareMonthlyReport()"); 
                Console.WriteLine(account);
                Console.WriteLine("\nAfter PrepareMonthlyReport()");
                account.PrepareMonthlyReport(); //all transactions are cleared, balance changes
                Console.WriteLine(account);
            }
        }
    }
}

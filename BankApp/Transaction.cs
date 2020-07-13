using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_BankApp
{
    // interface for the transaction class
    interface ITransaction
    {
        void Withdraw(double amount, Person person);
        void Deposit(double amount, Person person);
    }

    class Transaction
    {
        // flieds and properties of the class transactions
        public string AccountNumber { get; }
        public double Amount { get; }
        public Person Originator { get; }
        public DateTime Time { get; }

        // constructor for the transaction class
        public Transaction(string accountNumber, double amount, Person person, DateTime time)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator = person;
            Time = time;
        }

        // methods - actions for the transaction class
        public override string ToString()
        {
            return $"\n--- TRANSACTION INFO:\n" +
                $"Date:\t\t\t{Time.ToShortTimeString()}\n" +
                $"Name:\t\t\t{Originator}\n" +
                $"Account Number:\t\t{AccountNumber}\n" +
                $"Transaction:\t\t{Amount:C}\n";
        }

    }
}

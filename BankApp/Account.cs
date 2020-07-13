using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_BankApp
{
    abstract class Account
    {
        // fields and properties for the account class
        public readonly List<Person> users = new List<Person>();
        public readonly List<Transaction> transactions = new List<Transaction>();
        private static int LAST_NUMBER = 100_000;
        public double Balance { get; protected set; }
        public double LowestBalance { get; protected set; }
        public string Number { get; }

        // constructor of the account class
        public Account(string type, double balance)
        {
            Number = $"{type}{LAST_NUMBER}";
            LAST_NUMBER++;
            Balance = balance;
            LowestBalance = balance;
        }

        // methos - actions of the account class
        public void Deposit(double amount, Person person)
        {
            Balance += amount;
            if (Balance < LowestBalance)
            {
                LowestBalance = Balance;
            }
            transactions.Add(new Transaction(Number, amount, person, DateTime.Now));
        }

        public void AddUser(Person person)
        {
            users.Add(new Person(person.Name, person.SIN));
        }

        public bool IsUser(string name)
        {
            foreach (Person person in users)
            {
                if (person.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public abstract void PrepareMonthlyReport();

        public override string ToString()
        {
            return $"\n--- ACCOUNT INFO:\n" +
                $"Account Number:\t{Number}\n" +
                $"Users:\t\t{string.Join(", ", users)}\n" +
                $"Balance:\t{Balance:C}\n";
        }
    }
}

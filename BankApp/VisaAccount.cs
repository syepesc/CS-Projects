using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_BankApp
{
    class VisaAccount : Account, ITransaction
    {
        // fields and properties of visa account class
        private double creditLimit;
        private double INTEREST_RATE = 0.1995;

        // constructor for visa account class
        public VisaAccount(double balance = 0, double creditLimit = 1200) : base("VS-", balance)
        {          
            this.creditLimit = creditLimit;            
        }

        // methods - acitons of the sabings account class
        public void DoPayment(double amount, Person person)
        {
            base.Deposit(amount, person);
        }

        public void DoPurchase(double amount, Person person)
        {
            // throwing exceptions as rules specifies
            try
            {
               // for (int i = 0; i < users.Count; i++)
                //{
                    if (users.Contains<Person>(person) == true)
                    {
                        throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT); // exceptions are brought from exceptions class
                    }
                    else if (person.IsAuthenticated == false)
                    {
                        throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
                    }
                    else if (amount > creditLimit) 
                    {
                        throw new AccountException(ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
                    }
                    else
                    {
                        base.Deposit(-amount, person); // -1 to withdraw the amount of the account
                    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void ITransaction.Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
        }

        void ITransaction.Withdraw(double amount, Person person)
        {
            // throwing exceptions as rules specifies
            if (users.Contains<Person>(person) == false)
            {
                throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT); // exceptions are brought from exceptions class
            }
            else if (person.IsAuthenticated == false)
            {
                throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
            }
            else if (amount > Balance)
            {
                throw new AccountException(ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }
            else
            {
                base.Deposit(-amount, person); // -1 to withdraw the amount of the account
            }
        }

        public override void PrepareMonthlyReport()
        {
            double interests;
            interests = INTEREST_RATE * LowestBalance / 12;
            Balance = Balance - interests;
            transactions.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_BankApp
{
    class SavingAccount : Account, ITransaction
    {
        // fields and properties of the saving account class
        private double COST_PER_TRANSACTION = 0.05;
        private double INTEREST_RATE = 0.015;


        // constructor for the savings account class
        public SavingAccount(double balance = 0) : base("SV-", balance)
        {
        }


        // methods - acitons of the sabings account class
        public new void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
        }

        public void Withdraw(double amount, Person person)
        {
            // throwing exceptions as rules specifies
            try
            {
                if (users.Contains<Person>(person) == true)
                {
                    throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT); // exceptions are brought from exceptions class
                }
                else if (person.IsAuthenticated == false)
                {
                    throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
                }
                else if (amount > Balance)
                {
                    throw new AccountException(ExceptionEnum.NO_OVERDRAFT);
                }
                else
                {
                    base.Deposit(amount * -1, person); // -1 to withdraw the amount of the account
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void PrepareMonthlyReport()
        {
            double serviceCharge, interests;
            serviceCharge = COST_PER_TRANSACTION * transactions.Count;
            interests = INTEREST_RATE * LowestBalance / 12;
            Balance = Balance + interests - serviceCharge;
            transactions.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_BankApp
{
    class CheckingAccount : Account, ITransaction
    {
        // fields and properties of the checking account class
        private double COST_PER_TRANSACTION = 0.05;
        private double INTEREST_RATE = 0.005;
        private bool hasOverDraft;

        // constructor of the checking account class
        public CheckingAccount(double balance = 0, bool hasOverDraft = false) : base("CK-", balance) // takes the arguments from the parent class 'account'
        {
            this.hasOverDraft = hasOverDraft;
        }

        // mthods - actions of the checking acocunt class
        public new void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person); // calls the deposit method from the parent class
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
                else if (amount > Balance || hasOverDraft == false)
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

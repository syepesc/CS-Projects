using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_BankApp
{
    class Person
    {
        // fields and properties for person object
        private string password;
        public string SIN { get; }
        public string Name { get; }
        public bool IsAuthenticated { get; private set; }

        // constructor for person object
        public Person(string name, string SIN)
        {
            Name = name;
            this.SIN = SIN;
            password = SIN.Substring(0,3);
        }

        // methods - actions of the person class
        public void Login(string password)
        {
            try
            {
                if (password != this.password)
                {
                    IsAuthenticated = false;
                    throw new AccountException(ExceptionEnum.PASSWORD_INCORRECT);
                }
                else
                {
                    IsAuthenticated = true;
                    Console.WriteLine($"{Name,-15}\thas logged IN.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Logout()
        {
           IsAuthenticated = false;
           Console.WriteLine($"{Name,-15}\thas logged OUT.");
        }

        public override string ToString()
        {
            return $"{Name}"; 
        }
    }
}

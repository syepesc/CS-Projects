﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_BankApp
{
    public enum ExceptionEnum
    {
        ACCOUNT_DOES_NOT_EXIST,
        CREDIT_LIMIT_HAS_BEEN_EXCEEDED,
        NAME_NOT_ASSOCIATED_WITH_ACCOUNT,
        NO_OVERDRAFT,
        PASSWORD_INCORRECT,
        USER_DOES_NOT_EXIST,
        USER_NOT_LOGGED_IN
    }
    class AccountException : Exception
    {
        public AccountException(ExceptionEnum reason) : base(reason.ToString())
        {
        }
    }
}

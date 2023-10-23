using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApplication.Interfaces
{
    public interface IAccount
    {
       int AccountId {  get; }
       decimal Balance {  get; }

       void Deposit(decimal amount);
       void Withdraw(decimal amount);
    }
}

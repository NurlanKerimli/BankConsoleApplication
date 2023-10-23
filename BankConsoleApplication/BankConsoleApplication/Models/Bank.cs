using BankConsoleApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApplication.Models
{
    public class Bank
    {
        private List<IAccount> accounts;
        public Bank()
        {
            accounts = new List<IAccount>();
        }

        public IAccount CreateAccount()
        {
            IAccount account = new Account();
            accounts.Add(account);
            return account;
        }
        public void DepositMoney(int accountId, decimal amount)
        {
            IAccount account = GetAccountById(accountId);
            account.Deposit(amount);
        }

        public void WithdrawMoney(int accountId, decimal amount)
        {
            IAccount account = GetAccountById(accountId);
            account.Withdraw(amount);
        }
        public void TransferMoney(int fromAccountId, int toAccounId, decimal amount)
        {
            IAccount fromAccount = GetAccountById(fromAccountId);
            IAccount toAccount = GetAccountById(toAccounId);
            fromAccount.Withdraw(amount);
            toAccount.Withdraw(amount);
        }
        public List<IAccount> GetAllAccounts()
        {
            return accounts;
        }
        public IAccount GetAccountById(int accountId)
        {
            IAccount account = null;
            foreach (IAccount acc in accounts)
            {
                if (acc.AccountId == accountId)
                {
                    account = acc;
                    break;
                }
            }

            if (account == null)
            {
                Console.WriteLine("Verilmiş ID ilə hesab tapılmadı.");
            }

            return account;
        }
    }
}

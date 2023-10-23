using BankConsoleApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankConsoleApplication.Models
{
    internal class Account : IAccount
    {
        public int nextAccountId=1 ;
        public int AccountId { get; set; }
        public decimal Balance {  get;private set;}
        private List<Transaction> transactions;
        public Account()
        {
            AccountId = nextAccountId++;
            Balance = 0;
            transactions = new List<Transaction>();
        }
        public void Deposit(decimal amount)
        {
            if (amount <=0)
            {
                Console.WriteLine("Deposit məbləği yoxdur.");
            }
            Balance += amount;
            Transaction transaction = new Transaction(transactions.Count + 1, amount, "Deposit");
            transactions.Add(transaction);
        }       

        public void Withdraw(decimal amount)
        {
            if(amount <=0)
            {
                Console.WriteLine("Çıxarılacaq məbləğ yoxdur.");

            }
            if (Balance < amount)
            {
                Console.WriteLine("Hesabda kifayət qədər pul yoxdur.");
            }
            Balance-=amount;
            Transaction transaction = new Transaction(transactions.Count + 1, amount, "Withdraw");
            transactions.Add(transaction);
        }
    }
}

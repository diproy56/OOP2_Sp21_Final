using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Account
    {
        public string AccName { get; set; }
        public string AccNo { get; } //Restricted the set property. Because we can initial our AccNo only for one time that's why we can only get this value!
        public double Balance { get; set; }

        public int totalNumberOfTransaction { get; set; }

        Transaction[] listOfTransaction;

        public Account()
        {
            listOfTransaction = new Transaction[10];

        }
        public Account(string accName, string accNo, double balance)
        {
            AccName = accName;
            AccNo = accNo;
            Balance = balance;
            listOfTransaction = new Transaction[10];
        }

        public void AddTransaction(Transaction transactions)
        {

            this.listOfTransaction[totalNumberOfTransaction++] = transactions;

        }

        public void ShowAllTransaction()
        {
            for (int i = 0; i < totalNumberOfTransaction; i++)
            {
                listOfTransaction[i].ShowInfo();
            }
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine("Your Account has been credited by {0}", amount);
        }

        virtual public void Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine("Your Account has been debited by {0} to self ", amount);
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }
        virtual public void Transfer(Account acc, int amount)
        {
            if (amount <= Balance)
            {
                this.Balance -= amount;
                acc.Balance += amount;
                Console.WriteLine("Your Account has been debitated by {0} to {1} ({2}) ", amount, acc.AccName, acc.AccNo);
                Transaction t = new Transaction(this, acc, amount, "Business Purporses");
                this.AddTransaction(t);
                acc.AddTransaction(t);

            }
        }
        public void ShowInfo()
        {
            Console.WriteLine("Acc Name: " + AccName);
            Console.WriteLine("Acc No: " + AccNo);
            Console.WriteLine("Balance: " + Balance);
        }
    }
}

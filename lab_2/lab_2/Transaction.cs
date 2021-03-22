using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Transaction
    {
        public Account Sender { get; set; }
        public Account Receiver { get; set; }
        public int Amount { get; set; }
        public string AdditionalInfo { get; set; }


        public Transaction()
        {
            Console.WriteLine("Default Constructor");
        }

        public Transaction(Account sender, Account receiver, int amount, string additionalinfo)
        {
            Sender = sender;
            Receiver = receiver;
            Amount = amount;
            AdditionalInfo = additionalinfo;


        }

        public void ShowInfo()
        {
            Console.WriteLine("Sender Name: {0}; Account No: {1} & Amount send= {2}", Sender.AccName, Sender.AccNo, Amount);
            Console.WriteLine("Receiver Name: {0}; Account No: {1} & Amount receive= {2}", Receiver.AccName, Receiver.AccNo, Amount);
            Console.WriteLine("Transfered Amount {0}= ", Amount);
            Console.WriteLine("Purpose of Transaction {0} ", AdditionalInfo);
        }
    }
}

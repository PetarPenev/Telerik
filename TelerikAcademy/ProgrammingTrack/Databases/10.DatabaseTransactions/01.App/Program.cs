using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.Model.Classes;
using _03.Model.Data;
using System.Transactions;
using System.Data.Entity;
using _03.Model.Data.Migrations;

namespace _01.App
{
    class Program
    {
        public static bool SimpleTransaction(Context context, string cardPin, string cardNumber, decimal amountToWithdraw)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.RepeatableRead;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                var cardToAccept = context.CardAccounts.Where(p => (p.CardNumber == cardNumber && p.CardPin == cardPin)).FirstOrDefault();
                if (cardToAccept != null)
                {
                    if (cardToAccept.CardCash >= amountToWithdraw)
                    {
                        cardToAccept.CardCash -= amountToWithdraw;
                        context.SaveChanges();
                        scope.Complete();
                        return true;
                    }
                }

                return false;
            }
        }

        public static bool LoggingTransaction(Context context, string cardPin, string cardNumber, decimal amountToWithdraw)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.RepeatableRead;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                var cardToAccept = context.CardAccounts.Where(p => (p.CardNumber == cardNumber && p.CardPin == cardPin)).FirstOrDefault();
                if (cardToAccept != null)
                {
                    if (cardToAccept.CardCash >= amountToWithdraw)
                    {
                        cardToAccept.CardCash -= amountToWithdraw;
                        context.SaveChanges();
                        scope.Complete();
                        LogData(context, cardNumber, DateTime.Now, amountToWithdraw);
                        return true;
                    }
                }

                return false;
            }
        }

        private static void LogData(Context context, string cardNumber, DateTime date, decimal amountToWithdraw)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.RepeatableRead;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                context.TransactionsHistory.Add(new TransactionHistory()
                {
                    Amount = amountToWithdraw,
                    TransactionDate = date,
                    CardNumber = cardNumber
                });
                context.SaveChanges();
                scope.Complete();
            }
        }

        static void Main()
        {

            // Context is seeded and a test client is added.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());

            using (Context context = new Context())
            {
                context.CardAccounts.Add(new CardAccount() { CardNumber = "5555555555", CardCash = 50m, CardPin = "5555" });
                context.SaveChanges();
            }

            // Task 2. Simple operation without loging. First will execute correctly. Second will not.
            using (Context context = new Context())
            {               
                string cardPin = "5555";
                string cardNumber = "5555555555";
                decimal amountToWihdraw = 20m;
                var transactionCompleted = SimpleTransaction(context, cardPin, cardNumber, amountToWihdraw);
                Console.WriteLine("Transaction completed: {0}", transactionCompleted);
                var secondTransactionCompleted = SimpleTransaction(context, cardPin, cardNumber, 2000m);
                Console.WriteLine("Transaction completed: {0}", secondTransactionCompleted);
            }

            // Task 3. Logging.
            using (Context context = new Context())
            {
                string cardPin = "5555";
                string cardNumber = "5555555555";
                decimal amountToWihdraw = 20m;
                var transactionCompleted = SimpleTransaction(context, cardPin, cardNumber, amountToWihdraw);
                Console.WriteLine("Transaction completed: {0}", transactionCompleted);
            }
        }
    }
}

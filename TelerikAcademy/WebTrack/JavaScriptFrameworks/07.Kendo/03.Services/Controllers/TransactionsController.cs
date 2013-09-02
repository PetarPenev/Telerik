using _01.Models;
using _02.Data;
using _03.Services.Attributes;
using _03.Services.Exceptions;
using _03.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ValueProviders;

namespace _03.Services.Controllers
{
    public class TransactionsController : BaseController
    {
        [HttpGet]
        [ActionName("get-transactions")]
        public HttpResponseMessage GetTransactions([
            ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BankContext();
                using (context)
                {
                    this.ValidateSessionKey(context, sessionKey);
                    var user = context.Users.SingleOrDefault(u => u.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new ServerErrorException("Identification failure");
                    }

                    var transactions = context.Transactions.Include("Owner").Include("Account").
                        Where(t => t.Owner.Id == user.Id).ToList();

                    var transactionModels = (from transaction in transactions
                                             select new TransactionModel()
                                             {
                                                 AccountId = transaction.Account.Id,
                                                 Amount = transaction.Amount,
                                                 TransactionType = 
                                                    (transaction.TransactionType == TransactionType.Deposit) ? "deposit" : "withdrawal"
                                             });

                    return Request.CreateResponse(HttpStatusCode.OK, transactionModels);
                }
            });

            return responseMessage;
        }
    }
}
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
    public class AccountsController : BaseController
    {
        [HttpGet]
        [ActionName("get-accounts")]
        public HttpResponseMessage GetAccountsByUser(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                BankContext context = new BankContext();
                var user = context.Users.SingleOrDefault(u => u.SessionKey == sessionKey);

                if (user == null)
                {
                    throw new ServerErrorException("Identification failure");
                }

                var accounts = context.Accounts.Include("Owner").Where(a => a.Owner.Id == user.Id);

                var accountModels = (from account in accounts
                                     select new AccountModel()
                                     {
                                         Id = account.Id,
                                         Balance = account.Balance
                                     });

                return Request.CreateResponse(HttpStatusCode.OK, accountModels);
            });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("update-account")]
        public HttpResponseMessage UpdateAccount([FromBody] SumModel sum, int accountId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                BankContext context = new BankContext();
                var user = context.Users.SingleOrDefault(u => u.SessionKey == sessionKey);

                if (user == null)
                {
                    throw new ServerErrorException("Identification failure");
                }

                var account = context.Accounts.Include("Owner").SingleOrDefault(a => a.Id == accountId);

                if (account == null)
                {
                    throw new ServerErrorException("Account does not exist");
                }

                if (account.Owner.Id != user.Id)
                {
                    throw new ServerErrorException("Identification does not match account");
                }

                if ((sum.Sum < 0) && (account.Balance + sum.Sum < 0))
                {
                    throw new ServerErrorException("Amount of money insufficient");
                }

                account.Balance += sum.Sum;
                context.SaveChanges();

                var transaction = new Transaction();
                transaction.Amount = sum.Sum;
                transaction.Owner = user;
                transaction.Account = account;
                if (sum.Sum < 0)
                {
                    transaction.TransactionType = TransactionType.Withdrawal;
                }
                else
                {
                    transaction.TransactionType = TransactionType.Deposit;
                }

                context.Transactions.Add(transaction);
                context.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("get-by-id")]
        public HttpResponseMessage GetById(int id, [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                BankContext context = new BankContext();
                var user = context.Users.SingleOrDefault(u => u.SessionKey == sessionKey);

                if (user == null)
                {
                    throw new ServerErrorException("Identification failure");
                }

                var account = context.Accounts.Include("Owner").SingleOrDefault(a => a.Id == id);

                if (account == null)
                {
                    throw new ServerErrorException("Account does not exist");
                }

                if (account.Owner.Id != user.Id)
                {
                    throw new ServerErrorException("Identification does not match account");
                }

                var accountToReturn = new AccountModel()
                {
                    Id= account.Id,
                    Balance = account.Balance
                };

                return Request.CreateResponse(HttpStatusCode.OK, accountToReturn);
            });

            return responseMsg;
        }
    }
}
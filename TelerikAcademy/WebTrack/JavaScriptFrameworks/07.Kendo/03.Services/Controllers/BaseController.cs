namespace _03.Services.Controllers
{
    using _02.Data;
    using _03.Services.Exceptions;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    /// <summary>
    /// Represents a base controller.
    /// </summary>
    public class BaseController : ApiController
    {
        // private static Dictionary<string, HttpStatusCode> ErrorToStatusCodes = new Dictionary<string, HttpStatusCode>();

        protected const string SessionKeyChars = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        protected const string SessionKeyDigits = "0123456789";
        protected const int SessionKeyLength = 50;

        static BaseController()
        {
            //ErrorToStatusCodes["null_username"] = HttpStatusCode.BadRequest;
            //ErrorToStatusCodes["null_displayname"] = HttpStatusCode.BadRequest;
            //ErrorToStatusCodes["username_out_of_range"] = HttpStatusCode.BadRequest;
            //ErrorToStatusCodes["displayname_out_of_range"] = HttpStatusCode.BadRequest;
            //ErrorToStatusCodes["invalid_characters"] = HttpStatusCode.BadRequest;
            //ErrorToStatusCodes["invalid_password"] = HttpStatusCode.BadRequest;
            //ErrorToStatusCodes["invalid_post"] = HttpStatusCode.BadRequest;
            //ErrorToStatusCodes["user_exists"] = HttpStatusCode.BadRequest;
            //ErrorToStatusCodes["user_does_not_exist"] = HttpStatusCode.BadRequest;
            //ErrorToStatusCodes["invalid_credentials"] = HttpStatusCode.BadRequest;
            //ErrorToStatusCodes["inv_session_key"] = HttpStatusCode.BadRequest;
            //ErrorToStatusCodes["invalid-post-body"] = HttpStatusCode.BadRequest;
            //ErrorToStatusCodes["inv_post"] = HttpStatusCode.BadRequest;
            //ErrorToStatusCodes["inv_put_body"] = HttpStatusCode.BadRequest;
            //ErrorToStatusCodes["invalid_tag"] = HttpStatusCode.BadRequest;
        }

        protected T PerformOperationAndHandleExceptions<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }
        /*protected HttpResponseMessage PerformOperationAndHandleExceptions(Func<HttpResponseMessage> operation)
        {
            try
            {
                return operation();
            }
            catch (ServerErrorException ex)
            {
                var httpError = new HttpError(ex.Message);
                httpError["errCode"] = ex.ErrorCode;
                var statusCode = ErrorToStatusCodes[ex.ErrorCode];
                return Request.CreateErrorResponse(statusCode, httpError);
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }*/

        protected void ValidateSessionKey(BankContext context, string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new ServerErrorException("Session key cannot be null", "inv_session_key");
            }

            if (sessionKey.Any(ch => !SessionKeyChars.Contains(ch) && !SessionKeyDigits.Contains(ch)))
            {
                throw new ServerErrorException(
                    "Session key  must contain only Latin letters and digits", "inv_session_key");
            }

            if (sessionKey.Length != SessionKeyLength)
            {
                throw new ServerErrorException(
                    string.Format("Session key  must be {0} characters long", SessionKeyLength), "inv_session_key");
            }

            var existingUser = context.Users.SingleOrDefault(u => u.SessionKey == sessionKey);

            // If you want the comparison to be case-sensitive, please uncomment.
            if (existingUser == null /*|| existingUser.SessionKey != sessionKey*/)
            {
                throw new ServerErrorException("Invalid session key", "inv_session_key");
            }
        }
    }
}
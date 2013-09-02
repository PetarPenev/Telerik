namespace _03.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using _03.Services.Exceptions;
    using _02.Data;
    using _01.Models;
    using _03.Services.Attributes;
    using _03.Services.Models;

    /// <summary>
    /// Represents a user controller.
    /// </summary>
    public class UsersController : BaseController
    {
        protected const int MinNameLength = 6;
        protected const int MaxNameLength = 30;
        protected const int Sha1Length = 40;

        private static readonly Random rand = new Random();

        protected const string ValidUsernameCharacters =
           "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";
        protected const string ValidDisplayNameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";

        // /api/user/register
        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser([FromBody]UserUnloggedModel userModel)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BankContext();
                using (context)
                {
                    if (userModel == null)
                    {
                        throw new ServerErrorException("User credentials not passed correctly",
                            "invalid_credentials");
                    }

                    this.ValidateUsername(userModel.Username);
                    this.ValidateAuthCode(userModel.AuthCode);

                    var lowerCaseUsername = userModel.Username.ToLower();

                    var existingUser = context.Users.SingleOrDefault(u => u.Username == lowerCaseUsername);

                    if (existingUser != null)
                    {
                        throw new ServerErrorException("User with that username or nickname already exists.", "user_exists");
                    }

                    var newUser = new User();
                    newUser.Username = lowerCaseUsername;
                    newUser.AuthCode = userModel.AuthCode;
                    context.Users.Add(newUser);
                    context.SaveChanges();

                    var sessionKey = this.GenerateSessionKey(newUser.Id);
                    newUser.SessionKey = sessionKey;
                    context.SaveChanges();

                    var userReturnModel = new UserLoggedModel();
                    userReturnModel.SessionKey = newUser.SessionKey;
                    userReturnModel.DisplayName = newUser.Username;

                    return Request.CreateResponse(HttpStatusCode.Created, userReturnModel);
                }
            });

            return responseMessage;
        }

        // /api/user/login
        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser([FromBody]UserUnloggedModel userModel)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BankContext();
                using (context)
                {
                    if (userModel == null)
                    {
                        throw new ServerErrorException("User credentials not passed correctly",
                            "invalid_credentials");
                    }

                    this.ValidateUsername(userModel.Username);
                    this.ValidateAuthCode(userModel.AuthCode);

                    var lowerCaseUsername = userModel.Username.ToLower();

                    var existingUser = context.Users.SingleOrDefault(u => u.Username == lowerCaseUsername &&
                        u.AuthCode == userModel.AuthCode);

                    if (existingUser == null)
                    {
                        throw new ServerErrorException("User with that username or password does not exist.",
                            "user_does_not_exist");
                    }

                    if (existingUser.SessionKey == null)
                    {
                        var sessionKey = this.GenerateSessionKey(existingUser.Id);
                        existingUser.SessionKey = sessionKey;
                        context.SaveChanges();
                    }

                    var userReturnModel = new UserLoggedModel();
                    userReturnModel.SessionKey = existingUser.SessionKey;
                    userReturnModel.DisplayName = existingUser.Username;

                    return Request.CreateResponse(HttpStatusCode.Created, userReturnModel);
                }
            });

            return responseMessage;
        }

        // /api/user/logout
        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser([
            ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BankContext();
                using (context)
                {
                    this.ValidateSessionKey(context, sessionKey);
                    var existingUser = context.Users.SingleOrDefault(u => u.SessionKey == sessionKey);

                    /* If you want the comparison to be case-sensitive, please uncomment.
                    if (existingUser == null /*|| existingUser.SessionKey != sessionKey)
                    {
                        throw new ServerErrorException("Invalid session key", "inv_session_key");
                    }*/

                    existingUser.SessionKey = null;
                    context.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            });

            return responseMessage;
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ServerErrorException("Username cannot be null", "null_username");
            }

            if ((username.Length < MinNameLength) || (username.Length > MaxNameLength))
            {
                throw new ServerErrorException(
                    string.Format("Username should be between {0} and {1} characters long.",
                    MinNameLength, MaxNameLength), "username_out_of_range");
            }

            if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ServerErrorException(
                    "Username must contain only Latin letters, digits _.", "invalid_characters");
            }
        }

        private void ValidateDisplayname(string displayName)
        {
            if (displayName == null)
            {
                throw new ServerErrorException("Display name cannot be null", "null_displayname");
            }

            if ((displayName.Length < MinNameLength) || (displayName.Length > MaxNameLength))
            {
                throw new ServerErrorException(
                    string.Format("Display name should be between {0} and {1} characters long.",
                    MinNameLength, MaxNameLength), "displayname_out_of_range");
            }

            if (displayName.Any(ch => !ValidDisplayNameCharacters.Contains(ch)))
            {
                throw new ServerErrorException(
                    "Display name must contain only Latin letters, digits _. -", "invalid_characters");
            }
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ServerErrorException("Password should be encrypted correctly", "invalid_password");
            }
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);
            while (skeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                skeyBuilder.Append(SessionKeyChars[index]);
            }
            return skeyBuilder.ToString();
        }
    }
}
using Spring.IO;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using Spring.Social.OAuth1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Dropbox
{
    class Program
    {
        private const string DropboxAppKey = "4ktpdu63eq869ig";
        private const string DropboxAppSecret = "jlgo99651eq1bec";
        private const string OAuthTokenFileName = "OAuthTokenFileName.txt";

        static void Main()
        {
            DropboxServiceProvider dropboxServiceProvider =
                new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);

            // Authenticate the application (if not authenticated) and load the OAuth token
            if (!File.Exists(OAuthTokenFileName))
            {
                AuthorizeAppOAuth(dropboxServiceProvider);
            }
            OAuthToken oauthAccessToken = LoadOAuthToken();

            // Login in Dropbox
            IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

            // Display user name (from his profile)
            DropboxProfile profile = dropbox.GetUserProfileAsync().Result;
            Console.WriteLine("Hi " + profile.DisplayName + "!");

            // Specify the path to the folder on your disk
            Console.WriteLine("Please enter the full path to the photo album folder on the disk");
            string folderPath = Console.ReadLine();
            var filePaths = Directory.GetFiles(folderPath);
            var fileNames = new List<string>();
            foreach (var path in filePaths)
            {
                fileNames.Add(path.Substring(path.LastIndexOf('\\') + 1));
            }

            // Create new folder
            string newFolderName = "PhotoGallery_" + DateTime.Now.Ticks;
            Entry createFolderEntry = dropbox.CreateFolderAsync(newFolderName).Result;
            Console.WriteLine("Created folder: {0}", createFolderEntry.Path);

            // Upload a file
            var fileCounter = 0;
            foreach (var path in filePaths)
	        {
		        Entry uploadFileEntry = dropbox.UploadFileAsync(
                new FileResource(path),
                "/" + newFolderName + "/" + fileNames[fileCounter]).Result;
                Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);
                fileCounter++;
	        }

            // Share a file
            DropboxLink sharedUrl = dropbox.GetShareableLinkAsync(createFolderEntry.Path).Result;
            Process.Start(sharedUrl.Url);
        }

        private static OAuthToken LoadOAuthToken()
        {
            string[] lines = File.ReadAllLines(OAuthTokenFileName);
            OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
            return oauthAccessToken;
        }

        private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
        {
            // Authorization without callback url
            Console.Write("Getting request token...");
            OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
            Console.WriteLine("Done.");

            OAuth1Parameters parameters = new OAuth1Parameters();
            string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
                oauthToken.Value, parameters);
            Console.WriteLine("Redirect the user for authorization to {0}", authenticateUrl);
            Process.Start(authenticateUrl);
            Console.Write("Press [Enter] when authorization attempt has succeeded.");
            Console.ReadLine();

            Console.Write("Getting access token...");
            AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
            OAuthToken oauthAccessToken =
                dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
            Console.WriteLine("Done.");

            string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
            File.WriteAllLines(OAuthTokenFileName, oauthData);
        }
    }
}

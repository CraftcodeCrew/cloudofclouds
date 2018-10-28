using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Upload;

namespace CloudsOfClouds.CrackHoes
{
    public class GoogleCrackHoe
    {
        private static readonly string[] Scopes = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };
        private static string UploadFileName = "penis";
        private const string ContentType = @"application/octet-stream";
        
        public async Task Magic()
        {
//            GoogleWebAuthorizationBroker.Folder = "Library";
            UserCredential credential;
            using (var stream = new System.IO.FileStream("../CloudsOfClouds/TopSecret/google_credentials.json",
                System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None);
            }

            // Create the service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Sample",
            });

            var progress = await UploadFileAsync(service);
Debug.Write(progress);
            
        }

        private Task<IUploadProgress> UploadFileAsync(DriveService service)
        {
            var title = UploadFileName;
            if (title.LastIndexOf('\\') != -1)
            {
                title = title.Substring(title.LastIndexOf('\\') + 1);
            }

            var uploadStream = new System.IO.FileStream(UploadFileName, System.IO.FileMode.Open,
                System.IO.FileAccess.Read);

            var insert = service.Files.Insert(new File { Title = title }, uploadStream, ContentType);

            insert.ChunkSize = FilesResource.InsertMediaUpload.MinimumChunkSize * 2;

            var task = insert.UploadAsync();

            task.ContinueWith(t =>
            {
                // NotOnRanToCompletion - this code will be called if the upload fails
                Console.WriteLine("Upload Failed. " + t.Exception);
            }, TaskContinuationOptions.NotOnRanToCompletion);
            task.ContinueWith(t =>
            {
                uploadStream.Dispose();
            });

            return task;
        }
    }
}
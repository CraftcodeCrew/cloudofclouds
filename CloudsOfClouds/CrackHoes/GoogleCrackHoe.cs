using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Google.Apis.Upload;
using File = Google.Apis.Drive.v2.Data.File;

namespace CloudsOfClouds.CrackHoes
{
    public class GoogleCrackHoe
    {
        private static readonly string[] Scopes = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };
        private static string UploadFileName = "penis";
        private const string ContentType = @"application/octet-stream";
        
        public async Task Magic(Stream domibitch, BlobId id)
        {
            UploadFileName = id.GetBlobId.ToString();
                        
//            GoogleWebAuthorizationBroker.Folder = "Library";
            try
            {
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
                Console.WriteLine("Connected to Google Drive", Color.GreenYellow);

                var progress = await UploadFileAsync(service, domibitch);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        private Task<IUploadProgress> UploadFileAsync(DriveService service, Stream domibitch)
        {
            var title = UploadFileName;

            var insert = service.Files.Insert(new File { Title = title }, domibitch, ContentType);

            insert.ChunkSize = FilesResource.InsertMediaUpload.MinimumChunkSize * 2;

            var task = insert.UploadAsync();
            Console.WriteLine("Upload to Google Drive has completed", Color.GreenYellow);

            task.ContinueWith(t =>
            {
                // NotOnRanToCompletion - this code will be called if the upload fails
                Console.WriteLine("Upload Failed. " + t.Exception);
            }, TaskContinuationOptions.NotOnRanToCompletion);
            task.ContinueWith(t =>
            {
                domibitch.Dispose();
            });

            return task;
        }
    }
}
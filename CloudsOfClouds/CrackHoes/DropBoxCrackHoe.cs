using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.TopSecret;
using Dropbox.Api;
using Dropbox.Api.Files;

namespace CloudsOfClouds.CrackHoes
{
    public class DropBoxCrackHoe
    {
        public async Task Magic(Stream stream, BlobId blobId)
        {
            using (var dbx = new DropboxClient(DropboxCredentials.API_KEY))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
                Console.WriteLine("Connected to Dropbox", Color.GreenYellow);

                await new DropBoxCrackHoe().Upload(dbx, stream, blobId);
            }
            
            
        }
        
        async Task Upload(DropboxClient dbx, Stream content, BlobId id)
        {
            try
            {
                var task = dbx.Files.UploadAsync(
                    "/" + id.GetBlobId.ToString(),
                    WriteMode.Overwrite.Instance,
                    body: content);
                Console.WriteLine("Upload to Dropbox completed", Color.GreenYellow);
                await task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
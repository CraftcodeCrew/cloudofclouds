using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CloudsOfClouds.TopSecret;
using Dropbox.Api;
using Dropbox.Api.Files;

namespace CloudsOfClouds.CrackHoes
{
    public class DropBoxCrackHoe
    {
        public static async Task Magic()
        {
            using (var dbx = new DropboxClient(DropboxCredentials.API_KEY))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
                Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);

                await new DropBoxCrackHoe().Upload(dbx, "", "penis", "penis");
            }
            
            
        }
        
        async Task Upload(DropboxClient dbx, string folder, string file, string content)
        {
            using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                var updated = await dbx.Files.UploadAsync(
                    folder + "/" + file,
                    WriteMode.Overwrite.Instance,
                    body: mem);
                Console.WriteLine("Saved {0}/{1} rev {2}", folder, file, updated.Rev);
            }
        }
    }
}
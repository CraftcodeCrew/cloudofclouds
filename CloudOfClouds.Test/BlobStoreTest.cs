using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Store;
using Xunit;

namespace CloudOfClouds.Test
{
    public class BlobStoreTest
    {

        [Fact]
        async Task VerifyPutDeliveresId()
        {
            var fileSystem = TestUtilities.CreateFilesystem();
            var fileStream = fileSystem.FileStream.Create(@"c:\myfile.txt", FileMode.Open);
            var store = new BlobStore();

            var id = store.Put(fileStream);

            Assert.NotNull(id);
        }

        [Fact]
        async Task VerifyDataCanBeRead()
        {
            var fileSystem = TestUtilities.CreateFilesystem();
            var fileStream = fileSystem.FileStream.Create(@"c:\myfile.txt", FileMode.Open);
            var store = new BlobStore();

            var id = store.Put(fileStream);
            var stream = store.GetBlob(id);

            Assert.Equal(stream, fileStream);
        }


       
    }
}
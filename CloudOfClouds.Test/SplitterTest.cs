using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.Domain.Services;
using CloudsOfClouds.Domain.Store;
using CloudsOfClouds.Gateways_;
using Moq;
using Xunit;

namespace CloudOfClouds.Test
{
    public class SplitterTest
    {
        [Fact]
        async Task TestNumberOfParts()
        {
            var blobId = new BlobId();
            var numberParts = 2;
            var blobStoreMock = new Mock<IBlobStore>();
            blobStoreMock.Setup(store => store.Put(It.IsAny<Stream>())).Returns(blobId);
            var splitter = new FileSplitter(blobStoreMock.Object);
            var fileSystem = TestUtilities.CreateFilesystem();
            var fileStream = fileSystem.FileStream.Create(@"c:\myfile.txt", FileMode.Open);
            
            var blobids = await splitter.SplitData(numberParts, fileStream);
           
            Assert.Equal(numberParts, blobids.Count());
        }
    }
}
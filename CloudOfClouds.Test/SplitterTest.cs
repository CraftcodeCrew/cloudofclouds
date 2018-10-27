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
            var blobId = new BlobId(CloudProvider.GOOGLE);
            var numberParts = 2;
            var blobStoreMock = new Mock<IBlobStore>();
            blobStoreMock.Setup(store => store.Put(It.IsAny<Stream>())).Returns(blobId);
            var splitter = new FileSplitter(blobStoreMock.Object);
            
            // Arrange
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { @"c:\myfile.txt", new MockFileData("Testing is meh.") },
                { @"c:\demo\jQuery.js", new MockFileData("some js") },
                { @"c:\demo\image.gif", new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2 }) }
            });

            var fileStream = fileSystem.FileStream.Create(@"c:\myfile.txt", FileMode.Open);
            
            var blobids = await splitter.SplitData(numberParts, fileStream);
            Assert.Equal(numberParts, blobids.Count());
        }
    }
}
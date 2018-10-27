using System.Threading.Tasks;
using CloudsOfClouds.Domain.Gateways;
using CloudsOfClouds.Interface;
using Moq;
using Xunit;

namespace CloudOfClouds.Test
{
    public class CloudOfCloudsClientTest
    {
		
		public CloudOfCloudsClientTest()
		{
		}
        

        [Fact]
        async Task UploadTestsAsync()
		{
			var fileSplitter = new Mock<IFileSplitter>();
			var client = new CloudOfCloudsClient(fileSplitter.Object);

			var path = "penis";
			var id = await client.Upload(path);

			fileSplitter.Verify(splitter => splitter.SplitFile(2, path), Times.Once);
            
		}
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Gateways;
using CloudsOfClouds.Domain.Mapper;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.Domain.Store;
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
        async Task VerifySplitterIsCalled()
		{
			var fileSplitter = new Mock<IFileSplitter>();
			var mapper = new Mock<IMapper>();
			fileSplitter.Setup(splitter => splitter.SplitData(2, null)).ReturnsAsync(new List<BlobId>());
			var client = new CloudOfCloudsClient(fileSplitter.Object, mapper.Object);

			await client.Upload(null);

			fileSplitter.Verify(splitter => splitter.SplitData(2, null), Times.Once);
		}
	    
	    [Fact]
	    async Task VerifyMapperIsCalled()
	    {
		    var fileSplitter = new Mock<IFileSplitter>();
		    var mapper = new Mock<IMapper>();
		    mapper.Setup(m => m.AddMap(It.IsAny<IEnumerable<BlobId>>())).Returns(new CoCFileId());
		    var client = new CloudOfCloudsClient(fileSplitter.Object, mapper.Object);

		    await client.Upload(null);

		    mapper.Verify(m => m.AddMap(new List<BlobId>()), Times.Once);
	    }

	    [Fact]
	    async Task VerifyMapperCall()
	    {
		    var mapper = new Mock<IMapper>();
		    mapper.Setup(m => m.AddMap(new List<BlobId>())).Returns(new CoCFileId());
		    
		    
	    }
    }
}

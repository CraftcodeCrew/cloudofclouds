using System.Collections.Generic;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Gateways;
using CloudsOfClouds.Domain.Mapper;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.Domain.Services;
using CloudsOfClouds.Domain.Store;
using CloudsOfClouds.Interface;
using CloudsOfClouds.Services;
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
			var cocService = new Mock<ICoCService>();
			fileSplitter.Setup(splitter => splitter.SplitData(2, null)).ReturnsAsync(new List<BlobId>());
			cocService.Setup(c => c.Upload(It.IsAny<IEnumerable<BlobId>>())).ReturnsAsync(new CoCStatus());
			var client = new CloudOfCloudsClient(fileSplitter.Object, mapper.Object, cocService.Object);

			await client.Upload(null);

			fileSplitter.Verify(splitter => splitter.SplitData(2, null), Times.Once);
		}
	    
	    [Fact]
	    async Task VerifyMapperIsCalled()
	    {
		    var fileSplitter = new Mock<IFileSplitter>();
		    var mapper = new Mock<IMapper>();
		    var cocService = new Mock<ICoCService>();
		    mapper.Setup(m => m.AddMap(It.IsAny<IEnumerable<BlobId>>())).Returns(new CoCFileId());
		    cocService.Setup(c => c.Upload(It.IsAny<IEnumerable<BlobId>>())).ReturnsAsync(new CoCStatus());
		    var client = new CloudOfCloudsClient(fileSplitter.Object, mapper.Object, cocService.Object);

		    await client.Upload(null);

		    mapper.Verify(m => m.AddMap(new List<BlobId>()), Times.Once);
	    }

	    [Fact]
	    async Task VerifyCoCServiceIsCalled()
	    {
		    var fileSplitter = new Mock<IFileSplitter>();
		    var mapper = new Mock<IMapper>();
		    var cocService = new Mock<ICoCService>();
		    var client = new CloudOfCloudsClient(fileSplitter.Object, mapper.Object, cocService.Object);

		    cocService.Setup(c => c.Upload(It.IsAny<IEnumerable<BlobId>>())).ReturnsAsync(new CoCStatus());
		    var fileId = await client.Upload(null);   
		    
		    cocService.Verify(c => c.Upload(new List<BlobId>()), Times.Once);
	    }
	    
    }
}

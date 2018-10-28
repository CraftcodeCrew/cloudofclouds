using System.Collections.Generic;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.Domain.Services;
using CloudsOfClouds.Services;
using Moq;
using Xunit;

namespace CloudOfClouds.Test
{
    public class CoCServiceTest
    {
        [Fact]
        async Task CoCServiceCalledServices()
        {
            var googleCloudService = new Mock<ICloudService>();
            var dropboxCloudService = new Mock<ICloudService>();
            googleCloudService.Setup(s => s.Upload(It.IsAny<BlobId>())).ReturnsAsync(CoCStatus.SUCCESS);
            dropboxCloudService.Setup(s => s.Upload(It.IsAny<BlobId>())).ReturnsAsync(CoCStatus.SUCCESS);
            var cloudServices = new List<ICloudService> {googleCloudService.Object, dropboxCloudService.Object};
            var coCService = new CoCService(cloudServices);

            await coCService.Upload(new List<BlobId>() {new BlobId(), new BlobId()});
            
            googleCloudService.Verify(s => s.Upload(It.IsAny<BlobId>()), Times.AtLeastOnce );
            dropboxCloudService.Verify(s => s.Upload(It.IsAny<BlobId>()), Times.AtLeastOnce);
        }
        
        [Fact]
        async Task CoCServiceReturnsRightState()
        {
            var googleCloudService = new Mock<ICloudService>();
            var dropboxCloudService = new Mock<ICloudService>();
            googleCloudService.Setup(s => s.Upload(It.IsAny<BlobId>())).ReturnsAsync(CoCStatus.FAILURE);
            dropboxCloudService.Setup(s => s.Upload(It.IsAny<BlobId>())).ReturnsAsync(CoCStatus.SUCCESS);
            var cloudServices = new List<ICloudService> {googleCloudService.Object, dropboxCloudService.Object};
            var coCService = new CoCService(cloudServices);

            var state = await coCService.Upload(new List<BlobId>() {new BlobId(), new BlobId()});
            
           Assert.Equal(state, CoCStatus.FAILURE);
        }
    }
}
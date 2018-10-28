using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.Domain.Services;

namespace CloudsOfClouds.Services
{
    public class GoogleCloudService : ICloudService
    {
        public Task<CoCStatus> Upload(BlobId fileId)
        {
            throw new System.NotImplementedException();
        }

        public Task<FileStream> Download(BlobId blobId)
        {
            throw new System.NotImplementedException();
        }
    }
}
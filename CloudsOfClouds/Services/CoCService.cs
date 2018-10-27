using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.Domain.Services;

namespace CloudsOfClouds.Services
{
    public class CoCService : ICoCService
    {
        public Task<FileStream> GetBlob(BlobId id)
        {
            throw new System.NotImplementedException();
        }

        public Task<CoCStatus> Upload(IEnumerable<BlobId> blobIds)
        {
            throw new System.NotImplementedException();
        }
    }
}
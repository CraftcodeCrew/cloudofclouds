using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Domain.Services
{
    public interface ICoCService
    {
		Task<FileStream> GetBlob(BlobId id);

        Task<CoCStatus> Upload(IEnumerable<BlobId> blobIds);
    }
}

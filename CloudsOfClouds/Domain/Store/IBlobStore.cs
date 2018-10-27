using System.IO;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Domain.Store
{
    public interface IBlobStore
    {
		IBlobStore Put(BlobId id, FileStream blob);
		FileStream GetBlob(BlobId blobId);
    }
}

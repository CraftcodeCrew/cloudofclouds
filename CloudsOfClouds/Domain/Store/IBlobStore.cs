using System.IO;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Domain.Store
{
    public interface IBlobStore
    {
		BlobId Put(Stream blob);
		FileStream GetBlob(BlobId blobId);
    }
}

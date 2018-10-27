using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Domain.Services
{
    public interface CoCService
    {
		Task<FileStream> GetBlob(BlobId id);
    }
}

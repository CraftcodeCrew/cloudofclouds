using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Interface
{
    public interface ICloudOfCloudsClient
    {
		Task<CoCFileId> Upload(Stream stream);
		Task<Stream> Download(CoCFileId fileId);
    }
}

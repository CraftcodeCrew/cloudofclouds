using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Interface
{
    public interface ICloudOfCloudsClient
    {
		Task<CoCFile> Upload(Stream stream);
		Task<Stream> Download(CoCFileId fileId);
    }
}

using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Interface
{
    public class CoCClient : ICloudOfCloudsClient
    
    {
        public Task<CoCFileId> Upload(Stream stream)
        {
            return DependencyContainer.ResolveLibaray().Upload(stream);
        }

        public Task<Stream> Download(CoCFileId fileId)
        {
            throw new System.NotImplementedException();
        }
    }
}
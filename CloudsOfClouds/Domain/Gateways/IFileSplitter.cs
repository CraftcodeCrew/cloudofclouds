using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Domain.Gateways
{
    public interface IFileSplitter
    {
		Task<IEnumerable<BlobId>> SplitFile(int parts, string path);
    }
}

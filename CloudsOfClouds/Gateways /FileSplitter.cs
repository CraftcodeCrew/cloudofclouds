using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Gateways;

namespace CloudsOfClouds.Domain.Model
{
    public class FileSplitter : IFileSplitter
    {
        public Task<IEnumerable<BlobId>> SplitData(int parts, Stream stream)
        {
            throw new System.NotImplementedException();
        }
    }
}
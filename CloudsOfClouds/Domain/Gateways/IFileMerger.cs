using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Domain.Gateways
{
    public interface IFileMerger
    {
		Task<FileStream> mergeFiles(IEnumerable<BlobId> parts);
    }
}

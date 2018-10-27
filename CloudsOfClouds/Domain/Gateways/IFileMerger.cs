using System;
using System.Collections.Generic;
using System.IO;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Domain.Gateways
{
    public interface IFileMerger
    {
		FileStream mergeFiles(IEnumerable<BlobId> parts);
    }
}

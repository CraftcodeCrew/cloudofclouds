using System;
using System.Collections.Generic;
using System.IO;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Domain.Gateways
{
    public interface IFileSplitter
    {
		IEnumerable<BlobId> SplitFile(int parts, Path path);
    }
}

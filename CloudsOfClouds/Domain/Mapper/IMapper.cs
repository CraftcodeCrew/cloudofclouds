using System;
using System.Collections.Generic;
using System.IO;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Domain.Mapper
{
    public interface IMapper
    {
		CoCFileId AddMap(IEnumerable<BlobId> parts);
		IEnumerable<BlobId> GetMap(CoCFileId fileID);
    }
}

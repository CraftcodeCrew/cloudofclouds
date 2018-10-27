using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Domain.Mapper
{
    public interface IMapper
    {
		CoCFileId AddMap(IEnumerable<BlobId> parts);
		Task<IEnumerable<BlobId>> GetMap(CoCFileId fileID);
    }
}

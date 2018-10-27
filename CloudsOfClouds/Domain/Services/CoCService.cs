using System;
using System.IO;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Domain.Services
{
    public interface CoCService
    {
		FileStream GetBlob(BlobId id);
    }
}

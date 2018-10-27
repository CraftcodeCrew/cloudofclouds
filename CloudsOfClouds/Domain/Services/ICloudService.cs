using System;
using System.IO;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.Interface;

namespace CloudsOfClouds.Domain.Services
{
    public interface ICloudService
    {
		CoCStatus Upload(CoCFileId fileId);
		FileStream Download(BlobId blobId);
    }
}

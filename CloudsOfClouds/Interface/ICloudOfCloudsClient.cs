using System;
using System.IO;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Interface
{
    public interface ICloudOfCloudsClient
    {
		CoCFile Upload(Path path);
		FileStream Download(CoCFileId fileId);
    }
}

﻿using System;
using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.Interface;

namespace CloudsOfClouds.Domain.Services
{
    public interface ICloudService
    {
        Task<CoCStatus> Upload(CoCFileId fileId);
		Task<FileStream> Download(BlobId blobId);
    }
}

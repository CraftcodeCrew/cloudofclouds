using System;
using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Gateways;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Interface
{
	public class CloudOfCloudsClient : ICloudOfCloudsClient
    {
		private readonly IFileSplitter _fileSplitter;

		public CloudOfCloudsClient(IFileSplitter fileSplitter)
        {
			this._fileSplitter = fileSplitter;
		}

		public Task<FileStream> Download(CoCFileId fileId)
		{
			throw new NotImplementedException();
		}

		public Task<CoCFile> Upload(string path)
		{
			throw new NotImplementedException();
		}
	}
}

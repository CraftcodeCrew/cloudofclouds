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

		public Task<Stream> Download(CoCFileId fileId)
		{
			throw new NotImplementedException();
		}

		public async Task<CoCFile> Upload(Stream stream)
		{
			_fileSplitter.SplitData(2, stream);
			await Task.Delay(20);
			return null;
		}
	}
}

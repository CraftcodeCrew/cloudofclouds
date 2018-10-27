using System;
using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Gateways;
using CloudsOfClouds.Domain.Mapper;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Interface
{
	public class CloudOfCloudsClient : ICloudOfCloudsClient
    {
		private readonly IFileSplitter _fileSplitter;
	    private readonly IMapper _mapper;

		public CloudOfCloudsClient(IFileSplitter fileSplitter, IMapper mapper)
        {
			this._fileSplitter = fileSplitter;
	        this._mapper = mapper;
        }

		public Task<Stream> Download(CoCFileId fileId)
		{
			throw new NotImplementedException();
		}

		public async Task<CoCFileId> Upload(Stream stream)
		{
			var parts = await _fileSplitter.SplitData(2, stream);
			var fileId = _mapper.AddMap(parts);
			await Task.Delay(20);
			return null;
		}
	}
}

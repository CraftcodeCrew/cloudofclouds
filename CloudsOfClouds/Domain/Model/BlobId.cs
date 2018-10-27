using System;
using CloudsOfClouds.Domain.Services;

namespace CloudsOfClouds.Domain.Model
{
	public class BlobId
    {
        private readonly Guid _blobId;
		private readonly CloudProvider _provider;
        
		public BlobId(CloudProvider provider)
        {
            this._blobId = Guid.NewGuid();
			this._provider = provider;
        }

        public Guid GetBlobId => this._blobId;
		public CloudProvider GetProvider => this._provider;
    }
}

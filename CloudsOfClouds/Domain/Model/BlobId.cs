using System;
using CloudsOfClouds.Domain.Services;

namespace CloudsOfClouds.Domain.Model
{
	public class BlobId
    {
        private readonly Guid _blobId;
		private readonly CloudProvider _provider;
        
		public BlobId()
        {
            this._blobId = Guid.NewGuid();
        }

        public Guid GetBlobId => this._blobId;
    }
}

using System.Collections.Generic;
using System.IO;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.Domain.Store;

namespace CloudsOfClouds.Store
{
    public class BlobStore : IBlobStore
    {
        private readonly Dictionary<BlobId, Stream> _database;

        public BlobStore()
        {
            this._database = new Dictionary<BlobId, Stream>();
        }
        
        public BlobId Put(Stream blob)
        {
            var key = new BlobId();
            this._database.Add(key, blob);
            return key;
        }

        public Stream GetBlob(BlobId blobId)
        {
            return _database[blobId];
        }
    }
}
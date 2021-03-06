using System;
using System.IO;
using System.Threading.Tasks;
using CloudsOfClouds.CrackHoes;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.Domain.Services;
using CloudsOfClouds.Store;

namespace CloudsOfClouds.Services
{
    public class GoogleCloudService : ICloudService
    {
        private readonly BlobStore _store;

        public GoogleCloudService(BlobStore store)
        {
            this._store = store;
        }

        public async Task<CoCStatus> Upload(BlobId fileId)
        {
            var file = this._store.GetBlob(fileId);
            
            var hoe = new GoogleCrackHoe();

            try
            {
                await hoe.Magic(file, fileId);
            }
            catch (Exception)
            {
                return CoCStatus.FAILURE;
            }

            return CoCStatus.SUCCESS;

        }

        public Task<FileStream> Download(BlobId blobId)
        {
            throw new System.NotImplementedException();
        }
    }
}
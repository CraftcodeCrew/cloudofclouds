using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.Domain.Services;
using Colorful;

namespace CloudsOfClouds.Services
{
    public class CoCService : ICoCService
    {
        private readonly IEnumerable<ICloudService> _cloudServices;

        private int _servicePointer; 
        
        public CoCService( IEnumerable<ICloudService> cloudServices)
        {
            this._cloudServices = cloudServices;
            
            this._servicePointer = 0;
        }

        public Task<FileStream> GetBlob(BlobId id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CoCStatus> Upload(IEnumerable<BlobId> blobIds)
        {
            var tasks = new List<Task<CoCStatus>>();
            Console.WriteLine($"Routing datapackages to cloud providers", Color.LawnGreen);

            foreach (var id in blobIds)
            {
                var max = this._cloudServices.Count();
                if (this._servicePointer >= max)
                {
                    this._servicePointer = 0;
                }


                var service = this._cloudServices.ToArray()[this._servicePointer];
                tasks.Add(service.Upload(id));
                this._servicePointer++;

            }

            var states = await Task.WhenAll(tasks);
            if (states.Any(s => s.Equals(CoCStatus.FAILURE)))
            {
                return CoCStatus.FAILURE;
            }

            return CoCStatus.SUCCESS;
        }

  
        
    }
}
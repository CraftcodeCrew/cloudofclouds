using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Mapper;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.Gateways_;
using Colorful;

namespace CloudsOfClouds.Mapper
{
    public class Mapper : IMapper
    {
        public Mapper()
        {
            this.GetFileMap = new List<CoCMapDAO>();           
        }

        public List<CoCMapDAO> GetFileMap { get; }

        public CoCFileId AddMap(IEnumerable<BlobId> parts)
        {
            Console.WriteLine($"Updating mapping", Color.GreenYellow);

            var fileId = new CoCFileId();
            var mapDao = new CoCMapDAO();
            mapDao.FileId = fileId;
            mapDao.BlobParts = parts.ToArray();
            GetFileMap.Add(mapDao);

            return fileId;
        }

        public Task<IEnumerable<BlobId>> GetMap(CoCFileId fileID)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.Mapper;
using Xunit;

namespace CloudOfClouds.Test
{
    public class MapperTest
    {
        [Fact]
        void VerifyMapDAOEntryIsCreated()
        {
            var mapper = new Mapper();
            var parts = new List<BlobId>();
            var blob = new BlobId();
            parts.Add(blob);
            
            var fileId = mapper.AddMap(parts);
            
            Assert.True(mapper.GetFileMap.Any(f => f.FileId.Equals(fileId)));
            Assert.True(mapper.GetFileMap.Any(f => f.BlobParts.Contains(blob)));
        }
    }
}
using System;
namespace CloudsOfClouds.Domain.Model
{
	public class CoCMapDAO
	{
		public Guid FileId { get; set; }
		public Tuple<string, string>[] BlobParts { get; set; }
        
    }
}
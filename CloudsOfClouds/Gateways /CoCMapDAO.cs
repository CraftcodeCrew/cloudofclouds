using System;

namespace CloudsOfClouds.Gateways_
{
	public class CoCMapDAO
	{
		public Guid FileId { get; set; }
		public Tuple<string, string>[] BlobParts { get; set; }
        
    }
}
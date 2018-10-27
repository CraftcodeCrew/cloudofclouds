using System;
using CloudsOfClouds.Domain.Model;

namespace CloudsOfClouds.Gateways_
{
	public class CoCMapDAO
	{
		public CoCFileId FileId { get; set; }
		public BlobId[] BlobParts { get; set; }
        
    }
}
using System;
namespace CloudsOfClouds.Domain.Model
{
	public class CoCFileId
	{

		private readonly Guid _fileId;

		public CoCFileId()
		{
			this._fileId = Guid.NewGuid();
		}

		public Guid GetFileId => this._fileId;
	}
}
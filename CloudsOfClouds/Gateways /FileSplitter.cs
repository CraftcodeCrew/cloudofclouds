using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CloudsOfClouds.Domain.Gateways;
using CloudsOfClouds.Domain.Model;
using CloudsOfClouds.Domain.Store;

namespace CloudsOfClouds.Gateways_
{
    public class FileSplitter : IFileSplitter
    {
        private IBlobStore _blobStore;

        public FileSplitter(IBlobStore blobStore)
        {
            this._blobStore = blobStore;
        }

        public async Task<IEnumerable<BlobId>> SplitData(int parts, Stream stream)
        {
            Console.WriteLine($"Splitting data into {parts} parts", Color.GreenYellow);

            var partSize = (stream.Length + (parts - 1)) / parts;
            var blobStreams = SplitStream(stream, partSize);

            return blobStreams.Select(blobStream => _blobStore.Put(blobStream)).ToList();
        }

        private IEnumerable<Stream> SplitStream(Stream stream, long chunkSize)
        {
            var blobStreams = new List<Stream>();
            const int BUFFER_SIZE = 20 * 1024;
            var buffer = new byte[BUFFER_SIZE];

            using (var input = stream)
            {
                var index = 0;
                while (input.Position < input.Length)
                {
                    var output = new MemoryStream();
                    
                        int remaining = (int) chunkSize, bytesRead; // TODO This cast might kill us
                        while (remaining > 0 && (bytesRead = input.Read(buffer, 0,
                                   Math.Min(remaining, BUFFER_SIZE))) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                            remaining -= bytesRead;
                        }
                        blobStreams.Add(new MemoryStream(output.ToArray()));
                    
                    }
                    index++;
                
            }

            return blobStreams;
        }
    }
}
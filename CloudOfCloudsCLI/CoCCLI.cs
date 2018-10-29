using System;
using System.Drawing;
using System.IO;
using System.Threading;
using CloudsOfClouds.Interface;

namespace CloudOfCloudsCLI
{
    class CoCCLI
    {
        static void Main(string[] args)
        {
            var client = new CoCClient();

            foreach (var path in args)
            {
                try
                {
                    var bytes = File.ReadAllBytes(path);

                    Console.WriteLine($"Working on {path}", Color.Yellow);

                    client.Upload(new MemoryStream(bytes)).Wait();
                    Console.WriteLine($"Completed upload of {path}", Color.Yellow);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine($"Starting clean up", Color.Yellow);
                Thread.Sleep(6000);
                Console.WriteLine($"All operations have been completed successfully", Color.Yellow);


            }
        }
    }
}
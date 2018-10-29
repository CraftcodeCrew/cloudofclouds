using System;
using System.IO;
using CloudsOfClouds.CrackHoes;
using CloudsOfClouds.Interface;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var txt = "Hallo Domi! du bist hääääääässlich";
            var stream = GenerateStreamFromString(txt);
            var client = new CoCClient();
            try
            {
                client.Upload(stream).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();


        }
        
        
        
        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
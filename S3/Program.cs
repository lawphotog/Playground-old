using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;

namespace S3
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new AmazonS3Client("", "");

            var bucket = "winhtutaung";

            ListObjectsRequest request = new ListObjectsRequest
            {
                BucketName = bucket,
                Prefix = "gallery/",
                Delimiter = "/"
            };

            ListObjectsResponse response = client.ListObjects(request);

            var folders = new List<string>();

            foreach (var item in response.CommonPrefixes)
            {
                var name = item.Replace("gallery/", "").Replace("/", "");

                folders.Add(name);

                Console.WriteLine(name);
            }

            Console.Read();
        }
    }
}

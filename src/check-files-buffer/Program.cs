using CheckFilesBuffer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace CheckFilesBuffer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Check files buffer integrity";
            Console.WriteLine("Check files buffer v1.1");
            Console.WriteLine("Developer: Erik Vinicius");
            Console.WriteLine("Max supported files: 2\n");

            if (args.Length <= 1)
            {
                Console.WriteLine("Error. More than one file is needed to check the buffer.");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(Environment.ExitCode);
                return;
            }
            else if (args.Length > 2)
            {
                Console.WriteLine("Error. Max supported files: 2");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(Environment.ExitCode);
            }

            List<Item> files = new List<Item>();
            Console.WriteLine("Loading {0} files...\n", args.Length);
            for (int i = 0; i < args.Length; i++)
            {
                var filePath = args[i];
                var fileBuffer = File.ReadAllBytes(filePath);

                Item item = new Item
                {
                    Path = filePath,
                    Buffer = fileBuffer
                };

                files.Add(item);

                Console.WriteLine("Loaded File:\n\tPath:{0}\n\tLength:{1}\n", filePath, fileBuffer.Length);
            }
            Console.WriteLine("Loaded {0} files...\n", files.Count);

            Console.WriteLine("Checking files length...\n");

            for (int i = 0; i < files.Count; i++)
            {
                var item = files[i];
                var nextItem = files[i + 1];

                if ((files.Count - 1) < (i + 1))
                    return;

                if (item.Buffer.Length != nextItem.Buffer.Length)
                {
                    Console.WriteLine("Files length not equals:");
                    Console.WriteLine("\tPath:{0}\n\tLength:{1}\n", item.Path, item.Buffer.Length);
                    Console.WriteLine("\tPath:{0}\n\tLength:{1}", nextItem.Path, nextItem.Buffer.Length);
                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadKey();
                    Environment.Exit(Environment.ExitCode);
                    return;
                }
                Console.WriteLine("Files length equals:", item.Buffer.Length, nextItem.Buffer.Length);
                Console.WriteLine("\tPath:{0}\n\tLength:{1}\n", item.Path, item.Buffer.Length);
                Console.WriteLine("\tPath:{0}\n\tLength:{1}\n", nextItem.Path, nextItem.Buffer.Length);


                Console.WriteLine("Checking files buffer integrity...\n");
                int offset = 0;
                int bufferInvalid = 0;
                for (int j = 0; j < item.Buffer.Length; j++)
                {
                    if (item.Buffer[j] != nextItem.Buffer[j])
                    {
                        bufferInvalid++;
                        int invalidOffset = offset;
                        Console.WriteLine("Invalid offset:{0}", invalidOffset);
                    }
                    offset++;
                }
                if (bufferInvalid > 0)
                    Console.WriteLine("\nInvalid buffers count:{0}", bufferInvalid);
                else
                    Console.WriteLine("Success files buffer equals.");

                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
            }
        }
    }
}

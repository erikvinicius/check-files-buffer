using System;
using System.IO;

namespace CheckFilesBuffer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Check files buffer v1.0";
            Console.WriteLine("Check files buffer v1.0");
            Console.WriteLine("Developer: Erik Vinicius");
            Console.WriteLine("Max supported files: 2\n");
            if(args.Length <= 1)
            {
                Console.WriteLine("Error. More than one file is needed to check the buffer.");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(Environment.ExitCode);
                return;
            }
            else if(args.Length > 2)
            {
                Console.WriteLine("Error. Max supported files: 2");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(Environment.ExitCode);
            }
            Console.WriteLine("Loading {0} files...\n", args.Length);
            for(int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Loaded File. Path:{0} Length:{1}", args[i], File.ReadAllBytes(args[i]).Length);
            }
            Console.WriteLine("\nChecking files length...\n");
            var bufferOne = File.ReadAllBytes(args[0]);
            var bufferTwo = File.ReadAllBytes(args[1]);
            if(bufferOne.Length != bufferTwo.Length)
            {
                Console.WriteLine("\nFiles length not equals.");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(Environment.ExitCode);
                return;
            }
            Console.WriteLine("Files length equals. [{0}/{1}]\n", bufferOne.Length, bufferTwo.Length);
            int offset = 0;
            int bufferInvalid = 0;
            Console.WriteLine("Checking files buffer...\n");
            for (int i = 0; i < bufferOne.Length; i++)
            {
                if (bufferOne[i] != bufferTwo[i])
                {
					bufferInvalid++;
                    int invalidOffset = offset;
                    Console.WriteLine("Invalid Offset:" + invalidOffset);
                }
                offset++;
            }
            if (bufferInvalid > 0)
                Console.WriteLine("Invalid buffers count:{0}", bufferInvalid);
            else
                Console.WriteLine("Sucess files buffer equals.");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

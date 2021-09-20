using System;
using System.IO;

namespace FolderWalker
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            var path = new DirectoryInfo(args[0]);
            if (!path.Exists)
            {
                Console.WriteLine($"[Error] {path} path does not exist or not a directory.");
                return -1;
            }

            var dirs = new DepthFirstDirTraverser(path.FullName);
            // var dirs = new BreadthFirstDirTraverser(path.FullName);

            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
            }

            return 0;
        }
    }
}

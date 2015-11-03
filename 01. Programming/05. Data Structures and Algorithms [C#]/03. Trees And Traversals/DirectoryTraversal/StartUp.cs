namespace DirectoryTraversal
{
    using System;
    using System.IO;
    using System.Linq;
    
    public class StartUp
    {
        private const string Path = "C:\\Windows";
        private const string FileExtension = ".exe";
        private const string AccessToFolderDeniedMessage = "Access to folder {0} is denied";

        public static void Main()
        {
            var startDirectory = new DirectoryInfo(Path);

            TraverseDirectory(startDirectory);
        }

        public static void TraverseDirectory(DirectoryInfo directory)
        {
            try
            {
                var exeFiles = directory
                    .GetFiles()
                    .Where(file => file.Extension == FileExtension);

                foreach (var file in exeFiles)
                {
                    Console.WriteLine(file.FullName);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(AccessToFolderDeniedMessage, directory.FullName);
                return;
            }

            foreach (var subDirectory in directory.GetDirectories())
            {
                TraverseDirectory(subDirectory);
            }
        }
    }
}

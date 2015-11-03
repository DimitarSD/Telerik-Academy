namespace FileSystem
{
    using System;
    using System.IO;

    public class StartUp
    {
        private const string StartFolder = @"C:\Windows\Help";
        private const string TotalSizePrintMessage = "Total size is {0} bytes";
        private const string ShowRootPrintMessage = " <- (root)";

        public static void Main()
        {
            var root = new Folder(StartFolder);

            FillFolderWithFiles(new DirectoryInfo(StartFolder), root);

            PrintFromFolder(root, 0);

            Console.WriteLine(TotalSizePrintMessage, root.GetSizeFromHere());
        }

        public static void FillFolderWithFiles(DirectoryInfo directory, Folder folder)
        {
            foreach (FileInfo file in directory.GetFiles())
            {
                folder.Files.Add(new File(file.Name, file.Length));
            }

            foreach (var subDir in directory.GetDirectories())
            {
                var subFolder = new Folder(subDir.Name);
                folder.SubFolders.Add(subFolder);
                FillFolderWithFiles(subDir, subFolder);
            }
        }

        private static void PrintFromFolder(Folder folder, int offset)
        {
            Console.Write(new string('-', offset) + folder.Name);

            if (offset == 0)
            {
                Console.Write(ShowRootPrintMessage);
            }

            Console.WriteLine();

            foreach (var subfolder in folder.SubFolders)
            {
                PrintFromFolder(subfolder, offset + 2);
            }

            foreach (var file in folder.Files)
            {
                Console.WriteLine(new string('-', offset) + file.Name);
            }
        }
    }
}

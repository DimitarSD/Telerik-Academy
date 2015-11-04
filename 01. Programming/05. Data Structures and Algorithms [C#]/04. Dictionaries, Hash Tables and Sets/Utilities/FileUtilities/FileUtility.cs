namespace Utilities.FileUtilities
{
    using System.IO;

    public class FileUtility
    {
        private const string FileNotFoundExceptionMessage = "File does not exist. File name: ";

        /// <summary>
        /// Gets the content of text file by given path
        /// </summary>
        /// <param name="fullPath">Path of the file</param>
        /// <returns>Returns a string value - the content of the text file</returns>
        public static string GetFileTextContent(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException(FileNotFoundExceptionMessage + fullPath);
            }

            string textContent = string.Empty;

            using (var reader = new StreamReader(fullPath))
            {
                textContent = reader.ReadToEnd();
            }

            return textContent;
        }
    }
}

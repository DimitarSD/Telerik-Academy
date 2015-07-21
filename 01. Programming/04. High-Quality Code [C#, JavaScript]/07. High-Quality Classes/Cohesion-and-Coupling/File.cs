namespace CohesionAndCoupling
{
    using System;

    public class File
    {
        private const string FileNameNullValueExceptionMessage = "File name cannot be null";
        private const string FileNameEmptyStringExceptionMessage = "File name cannot be an empty string";
        private const string SearchedCharacter = ".";

        public static string GetFileExtension(string fileName)
        {
            ValidateFileName(fileName);

            int indexOfLastDot = fileName.LastIndexOf(SearchedCharacter);

            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            ValidateFileName(fileName);

            int indexOfLastDot = fileName.LastIndexOf(SearchedCharacter);

            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }

        private static void ValidateFileName(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(FileNameNullValueExceptionMessage);
            }

            if (fileName == string.Empty)
            {
                throw new ArgumentException(FileNameEmptyStringExceptionMessage);
            }
        }
    }
}

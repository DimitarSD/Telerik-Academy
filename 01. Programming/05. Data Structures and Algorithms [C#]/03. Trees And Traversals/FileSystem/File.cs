namespace FileSystem
{
    using System;

    using Constants;

    public class File
    {
        private const int MinimumFileSize = 0;

        private string name;
        private long size;

        /// <summary>
        /// Creates an instance of File class with file name and file size
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <param name="size">Size of the file</param>
        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        /// <summary>
        /// Gets and sets the name of the file
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ErrorMessages.FileNameCannotBeNullExceptionMessage);
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException(ErrorMessages.FileNameCannotBeEmptyStringExceptionMessage);
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets and sets the size of the file
        /// </summary>
        public long Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value <= MinimumFileSize)
                {
                    string errorMessage = string.Format(ErrorMessages.InvalidFileSizeExceptionMessage, MinimumFileSize);
                    throw new ArgumentOutOfRangeException();
                }

                this.size = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}

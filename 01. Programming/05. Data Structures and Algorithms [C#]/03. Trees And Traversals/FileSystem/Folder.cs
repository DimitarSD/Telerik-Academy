namespace FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Constants;

    public class Folder
    {
        private string name;
        private ICollection<File> files;
        private ICollection<Folder> subFolders;

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.SubFolders = new List<Folder>();
        }

        /// <summary>
        /// Gets and sets the name of the folder
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
                    throw new ArgumentNullException(ErrorMessages.FolderNameCannotBeNullExceptionMessage);
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException(ErrorMessages.FolderNameCannotBeEmptyStringExceptionMessage);
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets and sets a collection of files
        /// </summary>
        public ICollection<File> Files
        {
            get
            {
                return this.files;
            }

            set
            {
                this.files = value;
            }
        }

        /// <summary>
        /// Gets and sets a collection of folders
        /// </summary>
        public ICollection<Folder> SubFolders
        {
            get
            {
                return this.subFolders;
            }

            set
            {
                this.subFolders = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
        
        /// <summary>
        /// Gets the size in bytes
        /// </summary>
        /// <returns>Returns a number of type long - the size</returns>
        public long GetSizeFromHere()
        {
            var size = this.Files.Sum(file => file.Size) + this.SubFolders.Sum(folder => folder.GetSizeFromHere());
            return size;
        }
    }
}

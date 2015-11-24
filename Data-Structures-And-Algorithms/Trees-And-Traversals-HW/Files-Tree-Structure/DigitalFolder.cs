using System;

namespace Files_Tree_Structure
{
    public class DigitalFolder : IDigitalFile
    {
        private string name;
        private DigitalFile[] files;
        private DigitalFolder[] folders;

        public DigitalFolder(string name, DigitalFile[] files, DigitalFolder[] folders)
        {
            this.Name = name;
            this.Files = files;
            this.Folders = folders;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public DigitalFile[] Files
        {
            get { return this.files; }
            set { this.files = value; }
        }

        public DigitalFolder[] Folders
        {
            get { return this.folders; }
            set { this.folders = value; }
        }
    }
}

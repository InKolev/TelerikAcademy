namespace Files_Tree_Structure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DigitalFile : IDigitalFile
    {
        private string name;
        private int size;

        public DigitalFile(string name, int size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
    }
}

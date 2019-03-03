namespace Problem17
{
    using System.Collections.Generic;

    class Directory
    {
        public Directory(string name)
        {
            this.Name = name;
            this.Files = new List<string>();
            this.Directories = new List<Directory>();
        }

        public string Name { get; }

        public List<string> Files { get; }       

        public List<Directory> Directories { get; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
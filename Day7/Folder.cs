using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    class Folder
    {
        public string Name;
        Dictionary<string, Folder> subdirectories = new Dictionary<string, Folder>();
        public Folder Parent;
        int totalSize;

        public void IncreaseSizeInThisDirectory(int number)
        {
            totalSize += number;
        }

        public Folder GetOrCreateSubdirectory(string name)
        {
            var subdirectoryExists = subdirectories.TryGetValue(name, out Folder nextFolder);

            if (!subdirectoryExists)
            {
                nextFolder = new Folder
                {
                    Name = name
                };
                subdirectories.Add(name, nextFolder);
            }

            return nextFolder;
        }

        public Folder GetNextDirectory(string name)
        {
            return subdirectories[name];
        }

        public void CreateSubdirectory(string name)
        {
            Folder newSubdirectory = new Folder
            {
                Name = name,
                Parent = this
            };
            subdirectories.Add(name, newSubdirectory);
        }

        public IEnumerable<Folder> GetSubdirectories()
        {
            foreach (var entry in subdirectories)
            {
                var dir = entry.Value;
                yield return dir;

                foreach (var subdir in dir.GetSubdirectories())
                    yield return subdir;
            }
        }

        public void AddSizeToParents(int size)
        {
            if (Parent == null) return;

            Parent.totalSize += size;
            if (Parent.Parent == null) return;
            Parent.Parent.totalSize += size;
            Parent.Parent.AddSizeToParents(size);
        }

        public int FindSumOfDirectoriesSizeNoLargerThan100000()
        {
            var allSubdirectories = GetSubdirectories();
            var sum = allSubdirectories.Where(x => x.totalSize <= 100000).Sum(x => x.totalSize);
            return sum;
        }

        public int FindTheBestDirectoryToBeDeleted()
        {
            var allSubdirectories = GetSubdirectories();
            var theBestDirectory = allSubdirectories.Where(x => x.totalSize >= 8381165).Min(x => x.totalSize);
            return theBestDirectory;
        }
    }
}

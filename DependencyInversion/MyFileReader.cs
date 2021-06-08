using System.IO;

namespace DependencyInversion
{
    class MyFileReader : IFileReader
    {
        public string[] Read(string filename)
        {
            return File.ReadAllLines(filename);
        }
    }
}

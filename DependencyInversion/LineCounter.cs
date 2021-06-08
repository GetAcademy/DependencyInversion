using System.IO;

namespace DependencyInversion
{
    class LineCounter
    {
        private readonly IFileReader _fileReader;

        public LineCounter(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public int CountV3(string filename)
        {
            var lines = _fileReader.Read(filename);
            var length = lines.Length;
            return length;
        }

        public static int CountV2(string[] lines)
        {
            return lines.Length;
        }

        public static int CountV1(string filename)
        {
            return File.ReadAllLines(filename).Length;
        }
    }
}

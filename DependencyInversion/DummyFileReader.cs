namespace DependencyInversion
{
    class DummyFileReader : IFileReader
    {
        private readonly string[] _lines;

        public DummyFileReader(string[] lines)

        {
            _lines = lines;
        }

        public string[] Read(string filename)
        {
            return _lines;
        }
    }
}
